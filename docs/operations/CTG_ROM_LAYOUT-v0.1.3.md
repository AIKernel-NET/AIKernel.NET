---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# CTG ROM Layout v0.1.3

[Japanese](CTG_ROM_LAYOUT-v0.1.3-jp.md)

This note records the package-facing CTG-ROM layout rule for the 0.1.3
canonical package series.

## Scope

The 0.1.3 work aligns CTG-ROM metadata with the synchronized package family.
It does not rewrite the CTG canon text, voting semantics, or locale merge
rules inherited from the earlier CTG documents.

## Layout Rule

Package samples should preserve the established ROM structure:

```text
rom/
  governance/
    base/
    overlays/
  locales/
    default/
  metadata/
```

Use `0.1.3` for package-facing metadata that identifies the synchronized
package series. Keep historical file names and migration documents intact when
they describe older compatibility boundaries.

## Developer Rule

- `aikernel-net` may carry sample CTG-ROM assets for Python wrapper validation.
- Runtime packages should mount CTG-ROM content through canonical VFS and ROM
  interfaces rather than hard-coded paths.
- Demo and Doom may read CTG-ROM samples as scenario evidence, but they must not
  redefine CTG canon rules.
