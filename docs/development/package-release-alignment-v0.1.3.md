---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Package Release Alignment v0.1.3

[Japanese](package-release-alignment-v0.1.3-ja.md)

This note is the developer-facing source for package alignment in the
AIKernel.NET 0.1.3 canonical series. It exists so package maintainers can tell
which instructions are current, which instructions are historical, and which
versions are safe to combine during local validation.

## Current Package Line

Use `0.1.3` as the public canonical package family.

During local validation, use one matching development family at a time:

| Package system | Local development version |
|---|---|
| NuGet | `0.1.3-dev<build-number>` |
| PyPI | `0.1.3.dev<build-number>` |

Do not combine stable `0.1.3` packages with local packages from another build
unless the task explicitly tests migration or fallback behavior.

## Repository Order

Build and verify repositories in this order:

1. `AIKernel.NET`
2. `AIKernel.Core`
3. `AIKernel.Control`
4. `AIKernel.Providers`
5. `AIKernel.Cuda13.0`
6. `AIKernel.Wasm`
7. `AIKernel.Tools`
8. `AIKernel.Demo`
9. `AIKernel.Doom`

The first seven repositories define package surfaces. Demo and Doom validate
that the package surfaces work together.

## Source Of Truth

- Package installation UX lives in
  [Package Installation Guide](../operations/PACKAGE_INSTALLATION_GUIDE.md).
- Demo execution UX lives in
  [Demo Programs Guide](../operations/DEMO_PROGRAMS_GUIDE.md).
- GPU migration context lives in
  [GPU Canonical Migration](../migration/v0.1.3-gpu-canonical-migration.md).
- XML comment rules live in
  [XML Documentation Policy](../operations/XML_DOCUMENTATION_POLICY-v0.1.3.md).

Historical documents may keep older version numbers in titles and filenames.
Current install commands, package tables, and local validation examples must
use the 0.1.3 family.

## Developer Checklist

- Keep NuGet and PyPI package families synchronized for public examples.
- Keep repository-specific build notes in the repository that owns the build.
- Keep stable install commands separate from local `dev` validation commands.
- Keep Demo and Doom documentation explicit that they are validation/demo
  surfaces, not package-publication roots.
- Keep public API documentation bilingual through .NET XML documentation tags
  or paired include files.
