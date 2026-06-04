---
title: "IKernelClock"
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
  - time
  - english
---

Japanese version: [IKernelClock-jp.md](IKernelClock-jp.md)

# IKernelClock

## Responsibility
Provides deterministic time to Kernel, DSL, ROM, and replay components.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `GetCurrentTimestamp()` | `KernelTimestamp` | Returns the current deterministic timestamp record. |

## Boundary Rules
- Runtime code that affects replay, ROM hashes, loop timeout decisions, or audit metadata should depend on this interface.
- Implementations should make nondeterministic system time explicit at the host boundary.
