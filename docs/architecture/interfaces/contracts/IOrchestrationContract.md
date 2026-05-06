---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IOrchestrationContract'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
updated: 2026-05-06
---

For Japanese version, see IOrchestrationContract-jp.md.

# IOrchestrationContract (Contract Specification)

## 1. Responsibility Boundary
`IOrchestrationContract` defines pure reasoning inputs for the Structure phase and enforces separation between reasoning and expression layers.

- Role:
  Provide purpose, constraints, abstract structure, reasoning pattern, and integrity checks.
- Non-role:
  Output decoration data (style/examples) must not be supplied here and belongs to `IExpressionContract`.

## 2. Contract Signature
```csharp
using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 推論（Orchestration）契約を定義します。
/// 目的、制約、抽象構造を含む不変な入力フォーマットです。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IOrchestrationContract
{
    /// <summary>
    /// 推論に必要なコンテキストを取得します。
    /// 例・文体・RAG は含まれていません。
    /// </summary>
    OrchestrationContextDto GetContext();

    /// <summary>
    /// 推論のための目的を取得します。
    /// </summary>
    string GetPurpose();

    /// <summary>
    /// 推論に課される制約条件を取得します。
    /// </summary>
    IReadOnlyList<string> GetConstraints();

    /// <summary>
    /// 推論の抽象構造を取得します。
    /// </summary>
    string GetStructure();

    /// <summary>
    /// 推論パターンを取得します。
    /// </summary>
    string? GetReasoningPattern();

    /// <summary>
    /// このコントラクトが有効であることを確認します。
    /// Attention 汚染の検出も行います。
    /// </summary>
    ValidationResult Validate();

    /// <summary>
    /// Signal-to-Noise Ratio（SNR）を計算します。
    /// </summary>
    double CalculateSignalToNoiseRatio();
}

/// <summary>
/// OrchestrationContract の検証結果を表現します。
/// </summary>
public sealed class ValidationResult
{
    /// <summary>
    /// 検証が成功したかどうかを取得します。
    /// </summary>
    public bool IsValid { get; init; }

    /// <summary>
    /// 検出されたエラーメッセージを取得します。
    /// </summary>
    public List<string> Errors { get; init; } = new();

    /// <summary>
    /// 警告メッセージを取得します。
    /// </summary>
    public List<string> Warnings { get; init; } = new();

    /// <summary>
    /// 検出された attention 汚染を取得します。
    /// </summary>
    public List<FailureMode> DetectedFailureModes { get; init; } = new();
}
```

## 3. Related Use Cases
- `UC-02` Structure phase execution:
  Core input contract for `IThoughtProcess` to build `RawLogic`.
- `UC-06` Three-layer buffer boundary:
  Contract-level prevention of expression-noise leakage into reasoning context.

## 4. Governance & Determinism
- Reject attention pollution:
  `Validate()` should detect expression-layer contamination and enable deny-side handling.
- Deterministic inputs:
  For identical context state, methods should return identical values.
- Fail-Closed:
  Critical integrity violations should stop execution rather than degrade silently.

## 5. Metrics & Quality
- `CalculateSignalToNoiseRatio()`:
  Measures signal density of purpose/constraints/structure in reasoning input.
- Low-SNR handling:
  Low SNR should be treated as a risk indicator for ambiguity and reasoning drift.

## 6. Implementation Notes
- Immutability:
  Keep contract content stable through a reasoning cycle.
- Structured representation:
  Prefer schema-driven structure formats (YAML/JSON) over free-form prose for replay stability.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
