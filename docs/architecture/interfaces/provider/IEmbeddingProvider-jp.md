---
id: iembeddingprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IEmbeddingProvider"
created: 2026-05-03
updated: 2026-05-09
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IEmbeddingProvider.md](./IEmbeddingProvider.md) を参照。

# IEmbeddingProvider (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IEmbeddingProvider` は、text を意味ベクトルへ変換し、Phase 1 の意味空間操作に必要な数値基盤を供給する境界インターフェースです。

- 役割:
  単体/バッチの埋め込み生成と、ベクトル次元情報の提供を行います。
- 非役割:
  ベクトル保存・索引化・最近傍探索・Core による知識検索は責務外です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Providers;

public interface ITextEmbeddingProvider
{
    Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default);
}

public interface IBatchEmbeddingProvider
{
    Task<IReadOnlyList<float[]>> EmbedBatchAsync(IReadOnlyList<string> texts, CancellationToken cancellationToken = default);
}

public interface IEmbeddingDimensionProvider
{
    int GetDimension();
}

public interface IEmbeddingProvider :
    IProvider,
    ITextEmbeddingProvider,
    IBatchEmbeddingProvider,
    IEmbeddingDimensionProvider
{
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-05` 素材関連性評価:
  埋め込みを用いた類似度計算で素材選別を支えます。
- `UC-11` RAG:
  Provider または Pipeline 戦略が material retrieval を行う場合、query と material chunk を同一空間へ投影します。
- Phase 1 Query Processing:
  `IQueryDecomposer` が `QueryPart` を生成した後の任意の semantic projection を支えます。

## 4. 統治上の制約 (Governance & Determinism)
- モデル固定性:
  同一 `ProviderId` / 同一設定で次元や空間特性が予告なく変化しない運用を前提とします。
- Fail-Closed:
  入力上限超過や次元不整合を検知した場合は、不完全結果を返さず失敗として扱います。
- RAG 境界:
  Embedding support は Core を retrieval engine にするものではなく、semantic projection capability を公開するだけです。

## 5. 実装時の注意 (Notes)
- 次元整合:
  `GetDimension()` と実出力長が常に一致することを保証してください。
- バッチ制御:
  `EmbedBatchAsync` はレート制限を考慮し、必要に応じてチャンク処理を行ってください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.1 (2026-05-09): split capability と Phase 1 Query Processing に合わせて更新
