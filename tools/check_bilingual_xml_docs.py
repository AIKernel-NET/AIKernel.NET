#!/usr/bin/env python3
"""Check public C# XML documentation for bilingual EN/JA markers."""

from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path

PUBLIC_DECLARATION = re.compile(
    r"^\s*public\s+"
    r"(?:(?:static|sealed|abstract|partial|readonly|unsafe|async|virtual|override|new|extern)\s+)*"
)

DECLARATION_SHAPE = re.compile(
    r"\b(class|interface|record|struct|enum|delegate|event)\b"
    r"|\("
    r"|\{\s*(?:get|init|set)\b"
    r"|=>"
)

TAG_MARKERS = ("<param ", "<typeparam ", "<returns")
SKIP_DIRS = {"bin", "obj", ".git", ".vs"}


def has_english_marker(text: str) -> bool:
    """Return true when an English documentation marker is present."""

    return "EN:" in text or "[EN]" in text or "docs.en.xml" in text


def has_japanese_marker(text: str) -> bool:
    """Return true when a Japanese documentation marker is present."""

    return "JA:" in text or "[JA]" in text or "docs.ja.xml" in text


def is_public_declaration(line: str) -> bool:
    """Return true when the line is treated as a public declaration."""

    stripped = line.strip()
    if not stripped.startswith("public "):
        return False
    if stripped.startswith("public namespace "):
        return False
    return bool(PUBLIC_DECLARATION.match(line) and DECLARATION_SHAPE.search(line))


def read_doc_block(lines: list[str], declaration_index: int) -> list[str]:
    """Read the XML documentation block that applies to a declaration."""

    cursor = declaration_index - 1

    while cursor >= 0:
        stripped = lines[cursor].strip()
        if not stripped or stripped.startswith("["):
            cursor -= 1
            continue
        break

    block: list[str] = []
    while cursor >= 0 and lines[cursor].lstrip().startswith("///"):
        block.append(lines[cursor])
        cursor -= 1

    block.reverse()
    return block


def iter_csharp_files(root: Path):
    """Yield C# files below a root while skipping generated build outputs."""

    if root.is_file() and root.suffix == ".cs":
        yield root
        return

    for path in root.rglob("*.cs"):
        if any(part in SKIP_DIRS for part in path.parts):
            continue
        yield path


def check_file(path: Path) -> list[tuple[str, int, str, str]]:
    """Check one C# source file and return documentation issues."""

    lines = path.read_text(encoding="utf-8-sig").splitlines()
    issues: list[tuple[str, int, str, str]] = []

    for index, line in enumerate(lines):
        if not is_public_declaration(line):
            continue

        block = read_doc_block(lines, index)
        text = "\n".join(block)
        detail = line.strip()[:160]

        if not block:
            issues.append((str(path), index + 1, "missing-doc", detail))
            continue

        if not has_english_marker(text) or not has_japanese_marker(text):
            issues.append((str(path), index + 1, "missing-bilingual", detail))

    for index, line in enumerate(lines):
        if not any(marker in line for marker in TAG_MARKERS):
            continue
        if not has_english_marker(line) or not has_japanese_marker(line):
            issues.append((str(path), index + 1, "missing-tag-bilingual", line.strip()[:160]))

    return issues


def main() -> int:
    """Run the bilingual XML documentation checker."""

    parser = argparse.ArgumentParser(
        description="Check public C# XML documentation for EN/JA markers."
    )
    parser.add_argument(
        "roots",
        nargs="*",
        default=["src"],
        help="Source roots or C# files to check. Defaults to ./src.",
    )
    args = parser.parse_args()

    files = 0
    issues: list[tuple[str, int, str, str]] = []

    for root_arg in args.roots:
        root = Path(root_arg)
        if not root.exists():
            issues.append((str(root), 0, "missing-root", "path does not exist"))
            continue

        for path in iter_csharp_files(root):
            files += 1
            issues.extend(check_file(path))

    print(f"files={files} issues={len(issues)}")

    for path, line, kind, detail in issues:
        location = f"{path}:{line}" if line else path
        print(f"{location}: {kind}: {detail}")

    return 1 if issues else 0


if __name__ == "__main__":
    sys.exit(main())
