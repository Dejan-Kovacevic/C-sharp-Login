"""
Perfume longevity report stage.

Refactored from ``Parf_me.py``. Computes how long a bottle lasts given usage
parameters and reports it through the pipeline logger.
"""

from __future__ import annotations

import logging
from typing import Any, Dict

from . import StageResult, stage

SPRAY_VOLUME_ML = 0.15  # average volume of one spray


def calculate_weeks(volume_ml: float, sprays_per_use: float, uses_per_week: float) -> float:
    weekly_consumption = sprays_per_use * uses_per_week * SPRAY_VOLUME_ML
    if weekly_consumption <= 0:
        raise ValueError("usage parameters must be positive")
    return volume_ml / weekly_consumption


@stage("perfume_report")
def run(config: Dict[str, Any], log: logging.Logger, dry_run: bool) -> StageResult:
    volume = config.get("bottle_volume_ml", 100)
    sprays_per_use = config.get("sprays_per_use", 4)
    uses_per_week = config.get("uses_per_week", 1)
    name = config.get("name", "perfume")

    try:
        weeks = calculate_weeks(volume, sprays_per_use, uses_per_week)
    except ValueError as exc:
        log.error("%s", exc)
        return StageResult("perfume_report", ok=False, message=str(exc))

    log.info(
        "A %dml bottle of %s at %d sprays x %d/week lasts ~%.1f weeks (~%.1f months)",
        volume, name, sprays_per_use, uses_per_week, weeks, weeks / 4.345,
    )
    return StageResult(
        "perfume_report",
        ok=True,
        message=f"~{weeks:.1f} weeks",
        data={"weeks": round(weeks, 1)},
    )
