---
title: "IDslCapabilityRegistry"
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

Japanese version: [IDslCapabilityRegistry-jp.md](IDslCapabilityRegistry-jp.md)

# IDslCapabilityRegistry

## Responsibility
Resolves and invokes capability names used by deterministic DSL pipeline nodes.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `Contains(string name)` | `bool` | Checks whether a capability name is registered. |
| `InvokeAsync(string name, DslPipelineValue input, IReadOnlyDictionary<string, string> args, CancellationToken cancellationToken = default)` | `Task<DslPipelineValue>` | Invokes a registered capability with deterministic input and string arguments. |

## Boundary Rules
- Unknown capability names must fail closed in the implementation layer.
- Implementations may route to providers, tools, or DSL ROMs, but the contract remains provider-agnostic.
