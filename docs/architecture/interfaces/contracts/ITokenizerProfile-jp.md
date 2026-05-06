---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'ITokenizerProfile'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [ITokenizerProfile.md](./ITokenizerProfile.md) を参照。

# ITokenizerProfile (契約仕様)

## 1. 責務の境界 (Responsibility Boundary)
`ITokenizerProfile` は、モデルごとのトークン化特性と符号化メタデータを定義し、事前計量とコンテキスト境界統治の基準を提供する契約です。

- 役割:
  プロファイル識別子、対応モデル、語彙規模、特殊トークン、特殊処理要否を提示します。
- 非役割:
  実際のエンコード/デコード処理は責務外です（実行コンポーネント側の責務）。

## 2. 契約シグネチャ (Signature)
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

## 3. 関連ユースケース (Related UCs)
- `UC-30` トークン・ベクトル推定:
  入力サイズ見積もりとコンテキスト超過予防の基礎データとなります。
- `UC-06` 3層バッファ境界:
  バッファ区切りに使う特殊トークン選定や安全な整形規約に寄与します。

## 4. 統治上の制約 (Governance & Determinism)
- 計量整合:
  本プロファイルに基づく計測は、実運用消費と論理的一貫性を保つ必要があります。
- Fail-Closed:
  `SpecialTokens` 欠落や `VocabularySize` 不整合を検知した場合、対象モデルへの実行を抑止すべきです。
- 決定論的適用:
  同一 `ProfileId` では同一規則が適用され、計量結果の再現性を確保します。

## 5. 実装時の注意 (Notes)
- キャッシュ戦略:
  プロファイルは静的性質が高いため、共有インスタンス化を推奨します。
- バージョン管理:
  モデル更新でトークナイザー差異が生じ得るため、`ProfileId` ベースで厳密に管理してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
