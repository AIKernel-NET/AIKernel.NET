---
title: 'IMaterialContract'
created: 2026-05-06
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版: [IMaterialContract](../contracts/IMaterialContract.md)

# IMaterialContract

## Signature
```csharp
using AIKernel.Dtos.Context;

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
}
```

正規化、構造化、必須 content 抽出、正準化、hash、検疫検証は service 側の責務です。
`IMaterialNormalizer`、`IMaterialStructurizer`、`IEssentialMaterialExtractor`、
`IMaterialCanonicalizer`、`IMaterialHashProvider`、`IMaterialQuarantineValidator` を使用し、
contract object に振る舞いを追加しないでください。

## Exception Contract
本インターフェース自体は、特定の例外型の送出を規定しません。例外契約は実装側で明示します。

## Determinism Note
該当なし。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
