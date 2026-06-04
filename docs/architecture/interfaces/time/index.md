---
title: "time Interfaces"
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

Japanese version: [time/index-jp.md](index-jp.md)

# time Interfaces

## 1. Responsibility Boundary
Time contracts provide deterministic Kernel time without binding hosts to
`DateTimeOffset.UtcNow`, `TimeProvider.System`, or Core-specific clocks.

## 2. Public Contracts
- [IKernelClock](IKernelClock.md)

## 3. DTO Surface
- `KernelTimestamp`

## Boundary Rule
- Runtime code that affects replay, ROM hashes, loop timeout decisions, or audit metadata should use `IKernelClock`.
- Contract packages must not create time internally.

---

# Changelog
- v0.0.4 (2026-06-04): Added deterministic Kernel clock interface category.
