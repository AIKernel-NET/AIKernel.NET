---
id: ikernelhost
title: "IKernelHost"
created: 2026-05-03
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

Japanese version: [IKernelHost](architecture/interfaces/hosting/IKernelHost-jp.md)

# IKernelHost

## 1. Overview
`IKernelHost` is the single governed entry point for AIKernel runtime lifecycle management (KernelContext) and external application access.  
Before accepting execution requests, it must validate component integrity and governance readiness, and start the kernel only when safety conditions are satisfied.

## 2. Design Principles
- Fail-Closed Orchestration: if SGS governance is not active or required components are missing, startup must be aborted immediately.
- Identity Integrity: host identity metadata must be traceable in audit context so executions can be tied to a governed host.
- Environment Determinism: initialization path must be stable so environment/DI variability does not break deterministic replay.

## 3. Signature
| Member | Type | Description |
| --- | --- | --- |
| `Name` | `string` | Logical identifier of this contract instance. |
| `Version` | `string` | Contract version for compatibility checks. |
| `Metadata` | `IReadOnlyDictionary<string, string>` | Extension metadata for implementation-specific details. |

## 4. Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IKernelHost appears.

## 5. Spec Links
- [01.EXECUTION_PIPELINE_SPEC.md](../../../specs/01.EXECUTION_PIPELINE_SPEC.md) / `EPS-004`, `EPS-F002`  
  Pre-execution validation failures must halt startup/execution paths immediately.
- [02.SIGNED_PROMPT_GOVERNANCE_SPEC.md](../../../specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC.md) / `SGS-001`, `SGS-F001`  
  Unsigned or indeterminate inputs must not be accepted (Fail-Closed).
- [06.REPLAY_DUMP_SPEC.md](../../../specs/06.REPLAY_DUMP_SPEC.md) / `RDS-001`, `RDS-F002`  
  Replay loads must reject missing mandatory context fields.

## 6. Determinism Note
Given identical `Seed` and equivalent environment settings (`Metadata` / options), host initialization must follow the same deterministic path.  
If environment divergence or indeterminate governance state is detected, startup must be rejected on the safe side.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
