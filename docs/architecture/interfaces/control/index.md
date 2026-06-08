---
title: "Control Interfaces"
created: 2026-06-07
updated: 2026-06-07
version: "0.1.0"
status: "Draft"
tags:
  - aikernel
  - interfaces
  - control
  - english
---

Japanese version: [index-jp.md](index-jp.md)

# Control Interfaces

`AIKernel.Abstractions.Control` owns the shared Control Plane interfaces used to
map AIKernel semantic execution graphs onto physical execution engines.

## Interfaces
- `IControlEngine`
- `IExecutionGraph`
- `IExecutionNode`
- `INodeScheduler`
- `IControlPolicy`
- `IControlStateObserver`

## DTOs
- `ControlExecutionRequest`
- `ControlExecutionResult`
- `ControlPolicyEvaluation`
- `ControlStateSnapshot`
- `ControlEnvelope`

Control contracts live in AIKernel.NET because they are interface/DTO-only.
Control runtime implementations, emulators, CPU/GPU engines, schedulers, and
diagnostics belong to `AIKernel.Control`.
