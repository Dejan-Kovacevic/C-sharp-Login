"""
Hardware maintenance guide stage.

Refactored from ``Ram_Erweiterung.py``. Instead of just printing, it emits the
step-by-step guides for the configured maintenance tasks through the pipeline
logger so they land in the run log alongside everything else.
"""

from __future__ import annotations

import logging
from typing import Any, Dict

from . import StageResult, stage

GUIDES: Dict[str, list[str]] = {
    "replace_ram": [
        "Power off the laptop and disconnect the charger.",
        "Remove the back panel using a screwdriver.",
        "Locate the RAM slot(s).",
        "Release the RAM module by gently pressing the clips on either side.",
        "Remove the old RAM module.",
        "Insert the new RAM module, ensuring it is aligned with the slot.",
        "Press down gently until the RAM clicks into place.",
        "Reattach the back panel and secure it with screws.",
        "Power on the laptop and check if the new RAM is recognized.",
    ],
    "replace_fan": [
        "Power off the laptop and disconnect the charger.",
        "Remove the back panel using a screwdriver.",
        "Locate the cooling fan near the CPU and GPU.",
        "Disconnect the fan's power cable from the motherboard.",
        "Unscrew the fan and carefully remove it.",
        "Install the new fan and secure it with screws.",
        "Reconnect the fan's power cable to the motherboard.",
        "Clean the area to remove any dust.",
        "Reattach the back panel and secure it with screws.",
        "Power on the laptop and ensure the fan is functioning.",
    ],
}


@stage("maintenance")
def run(config: Dict[str, Any], log: logging.Logger, dry_run: bool) -> StageResult:
    tasks = config.get("tasks", list(GUIDES.keys()))
    unknown = [t for t in tasks if t not in GUIDES]
    if unknown:
        msg = f"unknown maintenance task(s): {', '.join(unknown)}"
        log.error(msg)
        return StageResult("maintenance", ok=False, message=msg)

    for task in tasks:
        log.info("--- Guide: %s ---", task)
        for i, step in enumerate(GUIDES[task], start=1):
            log.info("  %d. %s", i, step)

    return StageResult(
        "maintenance",
        ok=True,
        message=f"emitted {len(tasks)} guide(s)",
        data={"tasks": tasks},
    )
