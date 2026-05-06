---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IRelationResolver'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [IRelationResolver.md](./IRelationResolver.md) を参照。

# IRelationResolver (関係解決インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IRelationResolver` は、ROM 内の参照 ID を実体エンティティへ解決するセマンティック・リンキング境界インターフェースです。

- 役割:
  参照識別子から `ResolvableEntity` を返し、解決可否を事前判定します。
- 非役割:
  実体の物理ロードやキャッシュ保持は下位実装責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Rom;

public interface IRelationResolver
{
    Task<AIKernel.Dtos.Rom.ResolvableEntity?> ResolveAsync(string referenceId, CancellationToken cancellationToken = default);
    Task<bool> CanResolveAsync(string referenceId, CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-01` ROM 構造ロードと解析:
  テンプレート内参照を動的に実体結合します。
- `UC-15` コンテキスト・ハイドレーション:
  ID参照から実行時に必要な関連情報を展開します。
- `UC-12` 参照整合検証:
  解決可否を前段で確認し、不整合を早期検出します。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論的解決:
  同一 `referenceId` と同一ソース状態で同一結果を返す必要があります。
- Fail-Closed:
  必須参照が未解決なら不完全コンテキスト実行を避け、拒否側で停止します。
- 循環参照防止:
  参照グラフの循環を検知し、無限展開やスタック枯渇を防止します。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装では以下の失敗類型を明示することが推奨されます。

- 参照形式不正:
  IDフォーマットが規約外の場合。
- 解決基盤障害:
  データソース到達不能やロード障害が発生した場合。

## 6. 実装時の注意 (Notes)
- プロトコル委譲:
  `vfs://` や `db://` 等のスキーム別にサブリゾルバーへ委譲する構成が有効です。
- 型拡張性:
  `ResolvableEntity` はテキスト/構造化/バイナリ等の多様な実体を扱える設計を推奨します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
