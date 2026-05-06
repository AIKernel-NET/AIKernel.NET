---
id: imodelmessage
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IModelMessage"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IModelMessage-jp.md](./IModelMessage-jp.md).

# IModelMessage (Interface Specification)

## 1. Responsibility Boundary
`IModelMessage` is the atomic discourse unit for provider-agnostic model dialogue, offering a normalized message shape across the kernel.

- Role:
  Carry speaker role and content to standardize history handling and audit capture.
- Non-role:
  Transport details, SDK-specific envelopes, and binary attachment management are out of scope.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

public interface IModelMessage
{
    string Role { get; }
    string Content { get; }
}
```

## 3. Related Use Cases
- `UC-06` Three-layer buffer boundary:
  Serves as a normalized history unit in context isolation flows.
- `UC-20` Deterministic replay and audit trail:
  Acts as immutable conversation records for replay reconstruction.

## 4. Governance & Determinism
- Immutability:
  `Role` and `Content` should be treated as immutable once committed.
- Role normalization:
  Implementations should map provider-specific role variants to kernel-standard roles.
- Sequence stability:
  Message ordering and payloads must remain stable for deterministic replay parity.

## 5. Implementation Notes
- Extensibility:
  Introduce tool-call or multimodal payloads through layered/derived contracts.
- Serialization:
  Keep property shape simple and stable for archival and audit portability.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
