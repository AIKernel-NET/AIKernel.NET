---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Interface Breaking Change Check v0.1.3

[Japanese](interface-breaking-change-check-v0.1.3-ja.md)

This document records the 0.1.3 public-interface review stance.

## Decision

The 0.1.3 canonical line should be treated as an additive promotion line unless
a repository-specific release task explicitly records a breaking change.

Expected changes:

- Promote reusable GPU, HUD, Aisthesis, and Control metadata into canonical
  packages.
- Remove development-only names such as `rev3` from public commands,
  manifests, and DTO metadata keys.
- Keep historical documents with older version numbers as migration records.
- Keep stable and local development package families separated.

## Reviewer Checklist

- No public package exposes development-only `rev3` identifiers.
- No current install example points to an older package line.
- Public .NET members are documented with bilingual XML comments.
- `CS1591` is not suppressed for package surfaces that should produce public
  XML documentation.
- Demo and Doom use canonical DTOs or clearly mark private pilot logic.
- Markdown documents in the public developer path have English and Japanese
  source pairs.
