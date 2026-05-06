---
id: iragprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IRagProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IRagProvider.md](./IRagProvider.md) を参照。

# IRagProvider (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IRagProvider` は、外部記憶から必要素材を検索・登録・管理し、Material層へ供給する Retrieval Boundary インターフェースです。

- 役割:
  検索エンジン/ベクトルDB差異を隠蔽し、検索・索引・削除の一貫APIを提供します。
- 非役割:
  取得素材の最終採用判断やプロンプト組込みは上位オーケストレーション責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Providers;

using AIKernel.Dtos.Context;

public interface IRagProvider : IProvider
{
    Task<IReadOnlyList<MaterialContextDto>> SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default);
    Task IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default);
    Task DeleteAsync(string documentId, CancellationToken cancellationToken = default);
    Task ClearAsync(CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-11` RAG:
  MaterialBuffer を動的に満たす主要データソースとして機能します。
- `UC-05` 素材関連性評価:
  検索結果の関連スコアをもとに採用可否を評価します。

## 4. 統治上の制約 (Governance & Determinism)
- リプレイ整合:
  `SearchAsync` 結果は外部状態依存のため、実行時結果のスナップショット保存が必要です。
- Fail-Closed:
  タイムアウト/検索失敗時は不完全知識状態を明示し、安全側で処理を制限します。
- 汚染防止:
  `IndexAsync` 前段でインジェクション性命令を検査し、素材層の安全性を担保します。

## 5. 実装時の注意 (Notes)
- メタデータ活用:
  `MaterialContextDto` に出典・鮮度・信頼度情報を保持し、評価可能性を高めます。
- セマンティック検索:
  `IEmbeddingProvider` 連携による意味検索とキーワード検索の併用が推奨されます。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
