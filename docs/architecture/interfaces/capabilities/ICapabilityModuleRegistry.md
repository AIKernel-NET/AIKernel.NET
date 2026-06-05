---
title: "ICapabilityModuleRegistry"
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

Japanese version: [ICapabilityModuleRegistry-jp.md](ICapabilityModuleRegistry-jp.md)

# ICapabilityModuleRegistry

## Responsibility
Registers, resolves, and lists admitted external Capability module descriptors.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `RegisterAsync(CapabilityModuleDescriptor descriptor, CancellationToken cancellationToken = default)` | `ValueTask` | Register an admitted capability module descriptor. |
| `ResolveAsync(string capabilityId, CancellationToken cancellationToken = default)` | `ValueTask<CapabilityModuleDescriptor?>` | Resolve a module descriptor by stable capability id. |
| `ListAsync(CancellationToken cancellationToken = default)` | `ValueTask<IReadOnlyList<CapabilityModuleDescriptor>>` | Enumerate admitted capability module descriptors. |

## Boundary Rules
- Registry entries describe module identity and invocation boundaries only.
- Runtime loading, assembly binding, native ABI binding, and CLI process execution remain outside AIKernel.NET.
- Unknown or unadmitted capability ids must fail closed in the implementation layer.
