---
title: "history Interfaces"
created: 2026-06-04
updated: 2026-06-04
published: 2026-06-04
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - history
  - english
---

Japanese version: [history/index-jp.md](index-jp.md)

# history Interfaces

## 1. Responsibility Boundary
History contracts describe summarization and immutable History ROM publication.
They do not own conversation storage internals, Vfs implementation details, or
Core-specific Result monads.

## 2. Public Contracts
- `IHistorySummarizer`
- `IChatHistoryRomExporter`
- `IHistoryRomRegistry`
- `IHistoryRomStore`

## 3. DTO Surface
- `ChatHistoryRomRecord`
- `ChatHistoryRomOptions`
- `HistoryRomMetadata`
- `HistoryRomSnapshot`

## 4. Related Specs
- `docs/architecture/18.DSL_PIPELINE_AND_ROM_SPEC.md`
- `docs/operations/MIGRATION_GUIDE.md`

## Boundary Rule
- History ROM content is immutable once registered.
- Timestamps must be supplied by the caller or deterministic clock boundary.
- Contract packages must not depend on `AIKernel.Core` or `AIKernel.Common`.

---

# Changelog
- v0.0.4 (2026-06-04): Added History ROM interface category for package-public contracts.
