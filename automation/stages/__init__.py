"""
Stage registry for the automation pipeline.

Every stage is a callable that accepts the resolved stage configuration, a
logger and a ``dry_run`` flag, and returns a ``StageResult``. Stages register
themselves with the ``@stage`` decorator so the orchestrator can look them up
by name from the pipeline config without importing each module explicitly.
"""

from __future__ import annotations

import logging
from dataclasses import dataclass, field
from typing import Any, Callable, Dict


@dataclass
class StageResult:
    """Outcome of a single stage run."""

    name: str
    ok: bool
    message: str = ""
    data: Dict[str, Any] = field(default_factory=dict)


# Signature every stage handler must implement.
StageFn = Callable[[Dict[str, Any], logging.Logger, bool], StageResult]

_REGISTRY: Dict[str, StageFn] = {}


def stage(name: str) -> Callable[[StageFn], StageFn]:
    """Register ``fn`` under ``name`` so the orchestrator can resolve it."""

    def decorator(fn: StageFn) -> StageFn:
        if name in _REGISTRY:
            raise ValueError(f"Stage '{name}' is already registered")
        _REGISTRY[name] = fn
        return fn

    return decorator


def get_stage(name: str) -> StageFn:
    try:
        return _REGISTRY[name]
    except KeyError:
        raise KeyError(
            f"Unknown stage '{name}'. Available: {', '.join(sorted(_REGISTRY)) or '(none)'}"
        )


def available_stages() -> list[str]:
    return sorted(_REGISTRY)


# Importing the modules below populates the registry via the @stage decorator.
from . import ram_optimize  # noqa: E402,F401
from . import vm_mysql       # noqa: E402,F401
from . import maintenance    # noqa: E402,F401
from . import perfume_report  # noqa: E402,F401
