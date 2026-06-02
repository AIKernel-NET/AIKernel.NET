---
title: 'IExpressionContract'
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

Japanese version: [IExpressionContract (契約仕様)](architecture/interfaces/contracts/IExpressionContract-jp.md)

# IExpressionContract (Contract Specification)

## 1. Responsibility Boundary
`IExpressionContract` defines how finalized logic is expressed, while preserving strict separation between reasoning and expression layers.

- Role:
  Provide expression-time conventions such as style, examples, templates, and analogies.
- Non-role:
  It must not generate or alter reasoning logic. Expression metadata must not leak into reasoning inputs.

## 2. Contract Signature
```csharp
using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 表現（Expression）契約を定義します。
/// 推論が完全に終了した後にのみ適用される、出力表現層の契約です。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IExpressionContract
{
    /// <summary>
    /// 表現層のコンテキストを取得します。
    /// </summary>
    ExpressionContextDto GetContext();

    /// <summary>
    /// 出力の文体を取得します。
    /// </summary>
    string? GetStyle();

    /// <summary>
    /// 説明用の例を取得します。
    /// 注意: これらは推論には混入しません。
    /// </summary>
    IReadOnlyList<string> GetExamples();

    /// <summary>
    /// 説明テンプレートを取得します。
    /// </summary>
    string? GetDescriptionTemplate();

    /// <summary>
    /// 比喩・類推を取得します。
    /// </summary>
    IReadOnlyList<string> GetAnalogies();

    /// <summary>
    /// このコントラクトが推論結果に混入していないことを確認します。
    /// </summary>
    ValidationResult ValidateIsolation();

    /// <summary>
    /// 推論後の適用タイミングを確認します。
    /// </summary>
    bool CanApplyAfterInference();
}
```

## 3. Related Use Cases
- `UC-04` Generation and output polishing:
  Acts as the policy source used by `IOutputPolisher` during final rendering.
- `UC-06` Three-layer buffer boundary:
  Enforces separation between reasoning context and expression context.

## 4. Governance & Determinism
- Isolation enforcement:
  `ValidateIsolation()` is a mandatory gate to detect expression-data leakage into reasoning context.
- Post-inference application:
  `CanApplyAfterInference()` should only allow application after Structure phase completion.
- Deterministic rendering policy:
  The same inputs should yield the same expression behavior under this contract.

## 5. Implementation Notes
- Multilingual operation:
  `GetStyle()`, `GetExamples()`, and `GetAnalogies()` should follow consistent locale-selection rules.
- Auditability:
  Keep template/example application traceable so output differences remain explainable.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
