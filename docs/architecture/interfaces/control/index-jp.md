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
  - japanese
---

英語版: [index.md](index.md)

# Control Interfaces

`AIKernel.Abstractions.Control` は、AIKernel の semantic execution graph を
物理実行エンジンへ写像するための共有 Control Plane interface を所有します。

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

Control contract は interface / DTO のみであるため AIKernel.NET に置きます。
Control runtime implementation、emulator、CPU/GPU engine、scheduler、
diagnostics は `AIKernel.Control` が所有します。
