---
title: 'IMessageContract'
created: 2026-05-06
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

Japanese version: [IMessageContract (契約仕様)](architecture/interfaces/contracts/IMessageContract-jp.md)

# IMessageContract (Contract Specification)

## 1. Responsibility Boundary
`IMessageContract` defines the standard envelope format for messages exchanged inside the kernel and across external integration boundaries.

- Role:
  Provide common fields for identity, type, timestamp, source/destination, headers, and payload to enable loose coupling.
- Non-role:
  Delivery control, retry behavior, queueing, and payload interpretation are out of scope.

## 2. Contract Signature
```csharp
namespace AIKernel.Contracts;

/// <summary>
/// メッセージ契約を定義します。
/// カーネル内通信のメッセージ形式を標準化します。
/// </summary>
public interface IMessageContract
{
    /// <summary>
    /// メッセージの一意識別子を取得します。
    /// </summary>
    string MessageId { get; }

    /// <summary>
    /// メッセージの種類を取得します。
    /// </summary>
    string MessageType { get; }

    /// <summary>
    /// メッセージ送信時刻を取得します。
    /// </summary>
    DateTime Timestamp { get; }

    /// <summary>
    /// メッセージの送信元を取得します。
    /// </summary>
    string Source { get; }

    /// <summary>
    /// メッセージの宛先を取得します。
    /// </summary>
    string Destination { get; }

    /// <summary>
    /// メッセージのペイロードを取得します。
    /// </summary>
    object? Payload { get; }

    /// <summary>
    /// メッセージのヘッダーを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string>? Headers { get; }
}
```

## 3. Related Use Cases
- `UC-25` Event bus distribution:
  Serves as the common packet contract for inter-component event flow.
- `UC-20` Deterministic replay and audit trail:
  Supports timeline reconstruction with `Timestamp` and correlation headers.
- `UC-29` Task pipeline management:
  Used for asynchronous progress signals and phase-transition notifications.

## 4. Governance & Determinism
- Immutability in transit:
  Preserve `MessageId` and `Payload` integrity during delivery.
- Traceability:
  Include `CorrelationId` (or equivalent) in `Headers` to trace message chains end-to-end.
- Time coherence:
  `Timestamp` should follow a consistent UTC convention for reliable audit ordering.

## 5. Implementation Notes
- Serialization portability:
  Use DTO implementations that serialize stably (e.g., JSON) for transport and persistence.
- Type safety:
  When using `object? Payload`, pair with typed wrappers or generic contracts for safer runtime handling.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
