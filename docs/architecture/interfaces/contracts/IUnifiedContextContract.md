---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IUnifiedContextContract'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
updated: 2026-05-06
---

For Japanese version, see IUnifiedContextContract-jp.md.

# IUnifiedContextContract (Unified Contract Specification)

## 1. Responsibility Boundary
`IUnifiedContextContract` is the top-level governance contract that composes Orchestration/Expression/Material contracts and enforces three-layer buffer isolation end-to-end.

- Role:
  Provide unified access, holistic validation, layer-separation checks, pollution detection, and global SNR evaluation.
- Non-role:
  Detailed semantics of each sub-contract and concrete payload management are delegated to specialized contracts.

## 2. Contract Signature
```csharp
using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を定義します。
/// OrchestrationContract、ExpressionContract、MaterialContract を統合管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IUnifiedContextContract
{
    /// <summary>
    /// 統合コンテキストの一意識別子を取得します。
    /// </summary>
    string GetId();

    /// <summary>
    /// OrchestrationContract を取得します。
    /// </summary>
    IOrchestrationContract GetOrchestration();

    /// <summary>
    /// ExpressionContract を取得します。
    /// </summary>
    IExpressionContract? GetExpression();

    /// <summary>
    /// MaterialContract を取得します。
    /// </summary>
    IMaterialContract? GetMaterial();

    /// <summary>
    /// 統合コンテキストのデータを取得します。
    /// </summary>
    UnifiedContextDto GetContext();

    /// <summary>
    /// 全体の検証を実行します。
    /// カテゴリ分離、コンテキスト隔離、Attention 汚染検出を行います。
    /// </summary>
    ValidationResult ValidateAll();

    /// <summary>
    /// 3 層分離が正しく保たれていることを確認します。
    /// </summary>
    bool ValidateLayerSeparation();

    /// <summary>
    /// Attention 汚染の可能性を評価します。
    /// </summary>
    IReadOnlyList<FailureMode> DetectPollution();

    /// <summary>
    /// Signal-to-Noise Ratio（SNR）を計算します。
    /// </summary>
    double CalculateSignalToNoiseRatio();
}
```

## 3. Related Use Cases
- `UC-06` Three-layer buffer boundary:
  Guarantees cross-layer integrity from a single contract point.
- `UC-20` Deterministic replay and audit trail:
  Supports save/restore and replay integrity at unified-context granularity.

## 4. Governance & Determinism
- Cross-layer validation:
  `ValidateAll()` is expected to detect inter-layer contradictions and contamination.
- Immutability chain:
  While unified contract is active, subordinate contracts are expected to remain stable.
- Fail-Closed:
  Reject transition to reasoning when `ValidateLayerSeparation()` fails or critical pollution is detected.

## 5. Metric: SNR (Signal-to-Noise Ratio)
- Unified measurement:
  `CalculateSignalToNoiseRatio()` evaluates signal density across the whole context window, not per layer only.
- Threshold governance:
  Use low-SNR outcomes for warnings, routing escalation, or execution denial policies.

## 6. Implementation Notes
- Lazy evaluation:
  For heavy `Material`, apply on-demand loading strategies to control runtime cost.
- Serialization compatibility:
  Ensure `GetContext()` DTO stays portable for storage/restore (e.g., JSON compatibility).
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
