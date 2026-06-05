---
title: "ICapabilityModuleInvoker"
created: 2026-06-05
updated: 2026-06-05
published: 2026-06-05
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - capabilities
  - english
---

Japanese version: [ICapabilityModuleInvoker-jp.md](ICapabilityModuleInvoker-jp.md)

# ICapabilityModuleInvoker

## Responsibility
Defines the abstract invocation boundary for an admitted Capability module.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `InvokeAsync(CapabilityInvocationRequest request, CancellationToken cancellationToken = default)` | `ValueTask<CapabilityInvocationResult>` | Invoke a registered capability module through the implementation-owned boundary. |

## Boundary Rules
- The request/result envelope is deterministic and replay-friendly.
- This interface does not prescribe whether invocation is CLI, managed assembly, native ABI, DSL ROM, or remote endpoint.
- Permission checks, sandboxing, transport, and exception-to-failure conversion are Core/Tools/provider responsibilities.
