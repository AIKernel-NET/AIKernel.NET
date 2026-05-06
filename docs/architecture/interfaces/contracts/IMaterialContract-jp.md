---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IMaterialContract'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は IMaterialContract.md を参照。

# IMaterialContract

## Signature
```csharp
using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 素材（Material）契約を定義します。
/// RAG の断片や外部情報の取得・構造化を管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IMaterialContract
{
    /// <summary>
    /// 素材層のコンテキストを取得します。
    /// </summary>
    MaterialContextDto GetContext();

    /// <summary>
    /// 取得元ソースを取得します。
    /// </summary>
    string GetSource();

    /// <summary>
    /// 生のデータを取得します。
    /// </summary>
    string GetRawData();

    /// <summary>
    /// 正規化されたデータを取得します。
    /// 不要情報が除去されたバージョン。
    /// </summary>
    string? GetNormalizedData();

    /// <summary>
    /// 構造化されたデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? GetStructuredData();

    /// <summary>
    /// 関連性スコアを取得します（0.0 ～ 1.0）。
    /// </summary>
    double GetRelevanceScore();

    /// <summary>
    /// 素材を正規化します。
    /// </summary>
    void Normalize();

    /// <summary>
    /// 素材を構造化します。
    /// </summary>
    void Structurize();

    /// <summary>
    /// 必要な部分のみを抽出して OrchestrationContext に転写可能な形にします。
    /// </summary>
    string ExtractEssentialContent();

    /// <summary>
    /// 生データが OrchestrationContext に直接渡されていないことを確認します。
    /// </summary>
    ValidationResult ValidateQuarantine();
}
```

## Exception Contract
本インターフェース自体は、特定の例外型の送出を規定しません。例外契約は実装側で明示します。

## Determinism Note
該当なし。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
