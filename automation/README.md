# Automation Pipeline

A small orchestrator that runs a configurable sequence of **stages**, one after
another. It was assembled from a set of standalone scripts (Windows RAM
optimization, VMware + MySQL provisioning, hardware maintenance guides and a
perfume-longevity report) and turned into a single, config-driven pipeline with
logging, dry-run support and per-stage error handling.

## Layout

```
automation/
├── pipeline.py            # orchestrator / entry point
├── config.example.json    # example pipeline definition
├── requirements.txt       # optional per-stage dependencies
└── stages/
    ├── __init__.py        # stage registry (@stage decorator)
    ├── ram_optimize.py    # Windows RAM optimization        (from Ram_Opt.py)
    ├── vm_mysql.py        # vCenter power-on + remote MySQL  (from MySQL.py)
    ├── maintenance.py     # RAM/fan replacement guides       (from Ram_Erweiterung.py)
    └── perfume_report.py  # perfume longevity report         (from Parf_me.py)
```

## Quick start

```bash
cd automation

# See what stages are registered
python pipeline.py --list-stages

# Safe preview — logs every action, executes no side effects
python pipeline.py --config config.example.json --dry-run

# Run for real
python pipeline.py --config config.example.json

# Run only specific stages
python pipeline.py --config config.example.json --only maintenance perfume_report

# Write a copy of the log to a file
python pipeline.py --config config.example.json --log-file run.log
```

The orchestrator itself only uses the Python standard library. Install
`requirements.txt` only if you enable the `ram_optimize` or `vm_mysql` stages.

## Configuration

The pipeline is defined in a JSON file. Each entry under `stages` runs in order:

| key                 | meaning                                                        |
|---------------------|----------------------------------------------------------------|
| `stage`             | registered stage name (see `--list-stages`)                    |
| `enabled`           | `false` skips the stage entirely (default `true`)              |
| `continue_on_error` | if `true`, a failure doesn't abort the rest of the pipeline    |
| `config`            | stage-specific settings passed to the handler                  |

### Secrets

Never commit passwords. Reference them as `${ENV_VAR}` in the config and export
them in the environment; the loader expands them at runtime:

```bash
export VCENTER_PASSWORD='...'
export VM_SSH_PASSWORD='...'
python pipeline.py --config config.example.json
```

## Stages

- **ram_optimize** — clears the standby list, optionally disables SysMain and
  tunes visual effects. No-ops with a warning on non-Windows hosts.
- **vm_mysql** — connects to vCenter, powers the VM on, waits for its IP and
  installs MySQL over SSH. Disabled by default in the example config.
- **maintenance** — emits step-by-step RAM/fan replacement guides into the log.
- **perfume_report** — computes how long a bottle lasts from usage parameters.

## Adding a stage

Create `stages/your_stage.py`, decorate the handler and import it in
`stages/__init__.py`:

```python
from . import StageResult, stage

@stage("your_stage")
def run(config, log, dry_run):
    log.info("doing work ...")
    return StageResult("your_stage", ok=True, message="done")
```
