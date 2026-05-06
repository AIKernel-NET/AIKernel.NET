---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'ITokenizerProfile'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
updated: 2026-05-06
---

For Japanese version, see ITokenizerProfile-jp.md.

# ITokenizerProfile (Contract Specification)

## 1. Responsibility Boundary
`ITokenizerProfile` defines per-model tokenization characteristics and encoding metadata used as the measurement baseline for context budgeting.

- Role:
  Expose profile identity, supported models, vocabulary size, special-token map, and special-handling requirements.
- Non-role:
  Runtime encode/decode operations are out of scope and belong to execution-side tokenizer components.

## 2. Contract Signature
```csharp
namespace AIKernel.Contracts;

/// <summary>
/// トークナイザープロファイル契約を定義します。
/// トークナイザーの設定とメタデータを管理します。
/// </summary>
public interface ITokenizerProfile
{
    /// <summary>
    /// プロファイルの一意識別子を取得します。
    /// </summary>
    string ProfileId { get; }

    /// <summary>
    /// プロファイルの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// サポートされているモデルを取得します。
    /// </summary>
    IReadOnlyList<string> SupportedModels { get; }

    /// <summary>
    /// 語彙サイズを取得します。
    /// </summary>
    int VocabularySize { get; }

    /// <summary>
    /// 特殊トークンの定義を取得します。
    /// </summary>
    IReadOnlyDictionary<string, int>? SpecialTokens { get; }

    /// <summary>
    /// デコード時に特殊なトリートメントを必要とするかどうかを取得します。
    /// </summary>
    bool RequiresSpecialHandling { get; }
}
```

## 3. Related Use Cases
- `UC-30` Token/vector estimation:
  Provides core data for preflight token-size estimation and context-window enforcement.
- `UC-06` Three-layer buffer boundary:
  Informs delimiter/special-token choices for safe boundary rendering.

## 4. Governance & Determinism
- Measurement integrity:
  Estimates derived from this profile should remain logically consistent with runtime token usage.
- Fail-Closed:
  Missing `SpecialTokens` or invalid `VocabularySize` should block routing to the affected model.
- Deterministic application:
  The same `ProfileId` must imply the same measurement rules for replay stability.

## 5. Implementation Notes
- Cache strategy:
  Profiles are mostly static and are good candidates for shared/singleton usage.
- Version discipline:
  Model upgrades may change tokenizer behavior; manage compatibility strictly by `ProfileId`.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
