"""
VMware power-on + remote MySQL install stage.

Refactored from the original ``MySQL.py``. The stage connects to vCenter,
locates the target VM, powers it on if needed, waits for an IP and installs
MySQL over SSH. All connection details come from config; secrets are expected
to be supplied via environment variables (see README) rather than hard-coded.
"""

from __future__ import annotations

import logging
import time
from typing import Any, Dict

from . import StageResult, stage

MYSQL_INSTALL_COMMAND = (
    "sudo apt-get update && "
    "sudo apt-get install -y mysql-server && "
    "sudo systemctl enable mysql && "
    "sudo systemctl start mysql"
)


def _find_vm(content: Any, vm_name: str):
    from pyVmomi import vim  # noqa: F401  (imported for side effects/typing parity)

    for datacenter in content.rootFolder.childEntity:
        for vm in datacenter.vmFolder.childEntity:
            if getattr(vm, "name", None) == vm_name:
                return vm
    raise LookupError(f"VM '{vm_name}' not found")


def _power_on(vm, log: logging.Logger) -> None:
    from pyVmomi import vim

    if vm.runtime.powerState == "poweredOn":
        log.info("VM already powered on")
        return
    log.info("powering on VM ...")
    task = vm.PowerOn()
    while task.info.state not in (vim.TaskInfo.State.success, vim.TaskInfo.State.error):
        time.sleep(1)
    if task.info.state == vim.TaskInfo.State.error:
        raise RuntimeError("failed to power on VM")
    log.info("VM powered on")


def _wait_for_ip(vm, log: logging.Logger, timeout: int) -> str:
    waited = 0
    while not vm.guest.ipAddress:
        if waited >= timeout:
            raise TimeoutError(f"VM did not acquire an IP within {timeout}s")
        log.info("waiting for VM IP ...")
        time.sleep(5)
        waited += 5
    return vm.guest.ipAddress


def _install_mysql(ip: str, user: str, password: str, log: logging.Logger) -> None:
    import paramiko

    client = paramiko.SSHClient()
    client.set_missing_host_key_policy(paramiko.AutoAddPolicy())
    try:
        log.info("SSH connecting to %s ...", ip)
        client.connect(hostname=ip, username=user, password=password)
        log.info("installing MySQL (this can take a while) ...")
        _, stdout, stderr = client.exec_command(MYSQL_INSTALL_COMMAND)
        exit_status = stdout.channel.recv_exit_status()
        out, err = stdout.read().decode(), stderr.read().decode()
        if out.strip():
            log.debug("stdout:\n%s", out)
        if err.strip():
            log.debug("stderr:\n%s", err)
        if exit_status != 0:
            raise RuntimeError(f"MySQL install exited with status {exit_status}")
        log.info("MySQL installation complete")
    finally:
        client.close()


@stage("vm_mysql")
def run(config: Dict[str, Any], log: logging.Logger, dry_run: bool) -> StageResult:
    required = ["vcenter_host", "vcenter_user", "vcenter_password", "vm_name",
                "ssh_user", "ssh_password"]
    missing = [k for k in required if not config.get(k)]
    if missing:
        msg = f"missing config/secrets: {', '.join(missing)}"
        log.error(msg)
        return StageResult("vm_mysql", ok=False, message=msg)

    if dry_run:
        log.info("[dry-run] would power on '%s' on %s and install MySQL over SSH",
                 config["vm_name"], config["vcenter_host"])
        return StageResult("vm_mysql", ok=True, message="dry-run")

    try:
        import atexit

        from pyVim.connect import Disconnect, SmartConnect

        log.info("connecting to vCenter %s ...", config["vcenter_host"])
        si = SmartConnect(
            host=config["vcenter_host"],
            user=config["vcenter_user"],
            pwd=config["vcenter_password"],
            disableSslCertValidation=True,
        )
        atexit.register(Disconnect, si)

        vm = _find_vm(si.RetrieveContent(), config["vm_name"])
        _power_on(vm, log)
        ip = _wait_for_ip(vm, log, timeout=config.get("ip_timeout", 120))
        log.info("VM IP: %s", ip)
        _install_mysql(ip, config["ssh_user"], config["ssh_password"], log)
        return StageResult("vm_mysql", ok=True, message=f"MySQL installed on {ip}",
                           data={"ip": ip})
    except ImportError as exc:
        msg = f"dependency missing ({exc}); install pyvmomi and paramiko"
        log.error(msg)
        return StageResult("vm_mysql", ok=False, message=msg)
    except Exception as exc:  # noqa: BLE001 - surface any provisioning failure
        log.error("vm_mysql stage failed: %s", exc)
        return StageResult("vm_mysql", ok=False, message=str(exc))
