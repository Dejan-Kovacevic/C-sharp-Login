"""
RAM optimization stage (Windows).

Refactored from the original ``Ram_Opt.py`` into a pipeline stage. Each action
is opt-in through config and guarded so the orchestrator can run it as part of a
sequence without crashing on non-Windows hosts or in dry-run mode.
"""

from __future__ import annotations

import logging
import platform
import subprocess
from typing import Any, Dict

from . import StageResult, stage


def _is_admin() -> bool:
    try:
        import ctypes  # Windows only

        return bool(ctypes.windll.shell32.IsUserAnAdmin())
    except Exception:
        return False


def _ram_usage() -> Dict[str, float] | None:
    try:
        import psutil
    except ImportError:
        return None
    m = psutil.virtual_memory()
    gb = 1024 ** 3
    return {
        "total": m.total / gb,
        "available": m.available / gb,
        "percent": m.percent,
        "used": m.used / gb,
    }


def _log_usage(log: logging.Logger, label: str) -> None:
    usage = _ram_usage()
    if usage is None:
        log.warning("psutil not installed - skipping RAM usage report")
        return
    log.info(
        "%s | total=%.2fGB used=%.2fGB available=%.2fGB (%.0f%%)",
        label,
        usage["total"],
        usage["used"],
        usage["available"],
        usage["percent"],
    )


def _run(cmd: list[str], log: logging.Logger, dry_run: bool) -> bool:
    log.info("$ %s", " ".join(cmd))
    if dry_run:
        return True
    try:
        subprocess.run(cmd, check=True, capture_output=True)
        return True
    except (subprocess.CalledProcessError, FileNotFoundError) as exc:
        log.error("command failed: %s", exc)
        return False


@stage("ram_optimize")
def run(config: Dict[str, Any], log: logging.Logger, dry_run: bool) -> StageResult:
    if platform.system() != "Windows":
        msg = "host is not Windows - RAM optimization skipped"
        log.warning(msg)
        return StageResult("ram_optimize", ok=True, message=msg)

    if not dry_run and not _is_admin():
        msg = "administrative privileges required - skipping"
        log.warning(msg)
        return StageResult("ram_optimize", ok=False, message=msg)

    _log_usage(log, "RAM before")

    actions_done: list[str] = []

    if config.get("clear_standby", False):
        import ctypes

        ok = _run(["powershell", "-Command", "Clear-RecycleBin -Force"], log, dry_run)
        if not dry_run and ok:
            ctypes.windll.kernel32.SetSystemFileCacheSize(-1, -1, 0)
        _run(["wmic", "shadowcopy", "delete"], log, dry_run)
        actions_done.append("clear_standby")

    if config.get("disable_superfetch", False):
        _run(["sc", "stop", "SysMain"], log, dry_run)
        _run(["sc", "config", "SysMain", "start=disabled"], log, dry_run)
        actions_done.append("disable_superfetch")

    if config.get("optimize_visuals", False):
        _run(
            [
                "reg", "add",
                r"HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects",
                "/v", "VisualFXSetting", "/t", "REG_DWORD", "/d", "2", "/f",
            ],
            log,
            dry_run,
        )
        actions_done.append("optimize_visuals")

    _log_usage(log, "RAM after")

    return StageResult(
        "ram_optimize",
        ok=True,
        message=f"actions: {', '.join(actions_done) or 'none requested'}",
        data={"actions": actions_done},
    )
