#!/usr/bin/env python3
"""
Pipeline orchestrator.

Runs a sequence of stages defined in a JSON config file, one after another.
Each stage is looked up in the stage registry by name. Secrets referenced as
``${ENV_VAR}`` in the config are resolved from the environment at load time so
nothing sensitive needs to live in the file.

Usage:
    python pipeline.py --config config.example.json
    python pipeline.py --config config.example.json --dry-run
    python pipeline.py --config config.example.json --only ram_optimize perfume_report
    python pipeline.py --list-stages

Exit code is non-zero if any non-optional stage fails.
"""

from __future__ import annotations

import argparse
import json
import logging
import os
import re
import sys
import time
from pathlib import Path
from typing import Any, Dict, List

import stages

_ENV_PATTERN = re.compile(r"\$\{([A-Za-z_][A-Za-z0-9_]*)\}")


def _expand_env(value: Any) -> Any:
    """Recursively replace ``${VAR}`` tokens in strings with env values."""
    if isinstance(value, str):
        return _ENV_PATTERN.sub(lambda m: os.environ.get(m.group(1), ""), value)
    if isinstance(value, dict):
        return {k: _expand_env(v) for k, v in value.items()}
    if isinstance(value, list):
        return [_expand_env(v) for v in value]
    return value


def load_config(path: Path) -> Dict[str, Any]:
    with path.open(encoding="utf-8") as fh:
        raw = json.load(fh)
    return _expand_env(raw)


def setup_logging(level: str, log_file: str | None) -> logging.Logger:
    logger = logging.getLogger("pipeline")
    logger.setLevel(getattr(logging, level.upper(), logging.INFO))
    logger.handlers.clear()
    fmt = logging.Formatter("%(asctime)s [%(levelname)s] %(name)s: %(message)s",
                            datefmt="%H:%M:%S")

    console = logging.StreamHandler(sys.stdout)
    console.setFormatter(fmt)
    logger.addHandler(console)

    if log_file:
        fh = logging.FileHandler(log_file, encoding="utf-8")
        fh.setFormatter(fmt)
        logger.addHandler(fh)

    return logger


def run_pipeline(config: Dict[str, Any], only: List[str] | None,
                 dry_run: bool, log: logging.Logger) -> int:
    pipeline_stages = config.get("stages", [])
    if not pipeline_stages:
        log.error("config defines no stages")
        return 1

    results = []
    log.info("=" * 60)
    log.info("Pipeline '%s' starting (%d stage(s), dry_run=%s)",
             config.get("name", "automation"), len(pipeline_stages), dry_run)
    log.info("=" * 60)

    for entry in pipeline_stages:
        name = entry.get("stage")
        if not name:
            log.error("stage entry missing 'stage' key: %r", entry)
            return 1
        if entry.get("enabled", True) is False:
            log.info("[skip] %s (disabled in config)", name)
            continue
        if only and name not in only:
            log.info("[skip] %s (not in --only filter)", name)
            continue

        stage_logger = log.getChild(name)
        log.info("-" * 60)
        log.info("STAGE -> %s", name)
        start = time.monotonic()
        try:
            handler = stages.get_stage(name)
            result = handler(entry.get("config", {}), stage_logger, dry_run)
        except KeyError as exc:
            log.error("%s", exc)
            result = stages.StageResult(name, ok=False, message=str(exc))
        except Exception as exc:  # noqa: BLE001 - isolate stage failures
            log.exception("stage '%s' raised: %s", name, exc)
            result = stages.StageResult(name, ok=False, message=str(exc))
        elapsed = time.monotonic() - start

        status = "OK" if result.ok else "FAIL"
        log.info("STAGE <- %s [%s] %s (%.1fs)", name, status, result.message, elapsed)
        results.append((entry, result))

        if not result.ok and not entry.get("continue_on_error", False):
            log.error("aborting pipeline: stage '%s' failed and continue_on_error=false",
                      name)
            break

    log.info("=" * 60)
    failed = [r for _, r in results if not r.ok]
    log.info("Pipeline finished: %d ran, %d ok, %d failed",
             len(results), len(results) - len(failed), len(failed))
    for entry, r in results:
        log.info("  [%s] %s - %s", "OK" if r.ok else "FAIL", r.name, r.message)
    log.info("=" * 60)

    return 1 if failed else 0


def main() -> int:
    parser = argparse.ArgumentParser(description="Run the automation pipeline")
    parser.add_argument("--config", type=Path, help="Path to pipeline config JSON")
    parser.add_argument("--dry-run", action="store_true",
                        help="Log actions without executing side effects")
    parser.add_argument("--only", nargs="+", metavar="STAGE",
                        help="Run only the named stages")
    parser.add_argument("--log-file", help="Also write logs to this file")
    parser.add_argument("--log-level", default="INFO",
                        help="DEBUG, INFO, WARNING, ERROR (default INFO)")
    parser.add_argument("--list-stages", action="store_true",
                        help="List registered stages and exit")
    args = parser.parse_args()

    if args.list_stages:
        print("Registered stages:")
        for name in stages.available_stages():
            print(f"  - {name}")
        return 0

    if not args.config:
        parser.error("--config is required (or use --list-stages)")

    log = setup_logging(args.log_level, args.log_file)
    try:
        config = load_config(args.config)
    except (OSError, json.JSONDecodeError) as exc:
        log.error("could not load config %s: %s", args.config, exc)
        return 1

    return run_pipeline(config, args.only, args.dry_run, log)


if __name__ == "__main__":
    raise SystemExit(main())
