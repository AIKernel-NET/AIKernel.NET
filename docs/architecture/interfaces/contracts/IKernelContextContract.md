---
title: 'IKernelContextContract'
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

Japanese version: [IKernelContextContract (契約仕様)](architecture/interfaces/contracts/IKernelContextContract-jp.md)

# IKernelContextContract (Contract Specification)

## 1. Responsibility Boundary
`IKernelContextContract` defines execution-unit identity, lifetime, and requester attributes used as governance and resource-control anchors at kernel level.

- Role:
  Provide context ID, creation/expiry timestamps, requester identity, lifecycle state, and metadata.
- Non-role:
  It does not manage fragment payloads; content handling belongs to `IContextCollection`.

## 2. Contract Signature
```csharp
namespace AIKernel.Contracts;

/// <summary>
/// Kernel コンテキスト契約を定義します。
/// カーネルレベルの実行コンテキスト管理を行います。
/// </summary>
public interface IKernelContextContract
{
    /// <summary>
    /// コンテキストの一意識別子を取得します。
    /// </summary>
    string ContextId { get; }

    /// <summary>
    /// コンテキスト作成時刻を取得します。
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// コンテキストの有効期限を取得します。
    /// </summary>
    DateTime ExpiresAt { get; }

    /// <summary>
    /// リクエスト元の識別子を取得します。
    /// </summary>
    string RequesterId { get; }

    /// <summary>
    /// コンテキストの状態を取得します。
    /// </summary>
    string State { get; }

    /// <summary>
    /// コンテキストに関連するメタデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Metadata { get; }
}
```

## 3. Related Use Cases
- `UC-09` Execution state persistence and restore:
  Uses `ContextId` as the unique key for suspend/resume targets.
- `UC-20` Deterministic replay and audit trail:
  Contributes actor/time/state evidence and fixed replay preconditions.

## 4. Governance & Determinism
- Immutable anchors:
  `ContextId` and `CreatedAt` are expected to remain unchanged during lifecycle.
- Time governance:
  Execution should be denied after `ExpiresAt` in fail-closed operation.
- Logical isolation:
  `RequesterId` acts as a boundary key to prevent cross-context contamination.

## 5. Implementation Notes
- Replay fidelity:
  Keep replay-critical hints (seed, constraint hash, etc.) in `Metadata` where appropriate.
- Serialization stability:
  Implementing DTOs should support stable JSON serialization for persistence and audit portability.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
