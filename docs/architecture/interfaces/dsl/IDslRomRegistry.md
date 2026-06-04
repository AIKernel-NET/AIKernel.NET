---
title: "IDslRomRegistry"
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

Japanese version: [IDslRomRegistry-jp.md](IDslRomRegistry-jp.md)

# IDslRomRegistry

## Responsibility
Registers and resolves immutable DSL ROM snapshots as reusable capabilities.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `RegisterAsync(DslRomSnapshot snapshot, CancellationToken cancellationToken = default)` | `Task<DslRomMetadata>` | Registers a DSL ROM snapshot and returns deterministic metadata. |
| `Contains(string capabilityName)` | `bool` | Checks whether a DSL ROM capability is registered. |
| `ResolveAsync(string capabilityName, CancellationToken cancellationToken = default)` | `Task<DslRomSnapshot>` | Resolves a registered DSL ROM capability to its snapshot. |

## Boundary Rules
- Registry implementations must preserve ROM immutability and hash identity.
- Runtime execution should record ROM hash metadata in replay/audit output.
