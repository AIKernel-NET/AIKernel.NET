---
title: "IDslRomStore"
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
  - dsl
  - english
---

Japanese version: [IDslRomStore-jp.md](IDslRomStore-jp.md)

# IDslRomStore

## Responsibility
Persists and loads DSL ROM JSON through caller-provided Vfs sessions.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `SaveDslAsRomAsync(...)` | `Task<DslRomMetadata>` | Validates and stores JSON DSL as an immutable ROM artifact. |
| `LoadDslRomAsync(...)` | `Task<DslRomMetadata>` | Loads a DSL ROM and verifies its expected hash. |

## Boundary Rules
- The caller owns Vfs session lifetime and permissions.
- Expected ROM hash mismatch must fail closed in implementations.
