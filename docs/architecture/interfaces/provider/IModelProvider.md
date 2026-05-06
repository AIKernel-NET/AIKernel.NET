---
id: imodelprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IModelProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IModelProvider-jp.md](./IModelProvider-jp.md).

# IModelProvider (Interface Specification)

## 1. Responsibility Boundary
`IModelProvider` is the intelligence execution-engine boundary that consumes normalized messages and performs concrete model inference.

- Role:
  Provide full generation, streaming generation, and direct Q&A while abstracting provider-specific transport differences.
- Non-role:
  Model selection belongs to `IModelVectorRouter`; provider lifecycle ownership remains in `IProvider`.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

public interface IModelProvider : IProvider
{
    Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default);
    Task StreamGenerateAsync(IReadOnlyList<IModelMessage> messages, Func<string, Task> onChunk, CancellationToken cancellationToken = default);
    Task<string> AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-02` Structure phase execution:
  Serves as the execution body beneath reasoning construction.
- `UC-04` Generation and output polishing:
  Produces source outputs for downstream polishing/rendering.

## 4. Governance & Determinism
- Determinism contribution:
  Implementations should maximize replay stability through fixed inference settings where possible.
- Fail-Closed:
  Safety violations, token-limit breaches, or execution faults should fail explicitly instead of returning partial answers.
- Isolation compliance:
  Do not inject implicit context beyond supplied `messages`.

## 5. Implementation Notes
- Transport abstraction:
  Hide REST/gRPC/local runtime differences behind this contract.
- Extensibility:
  Evolve multimodal support in sync with `IModelMessage` contract extensions.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
