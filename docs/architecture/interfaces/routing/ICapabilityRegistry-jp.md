---
title: 'ICapabilityRegistry'
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

英語版は [ICapabilityRegistry.md](./ICapabilityRegistry.md) を参照。

# ICapabilityRegistry (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`ICapabilityRegistry` は、利用可能なモデル/プロバイダー能力の目録を管理し、ルーティング意思決定の前提事実を提供する境界インターフェースです。

- 役割:
  `ModelCapacityVector` の登録・参照・候補解決を担います。
- 非役割:
  最適候補の最終選択（スコアリングと決定）は `IModelVectorRouter` の責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Routing;

public interface ICapabilityRegistry
{
    ValueTask RegisterCapabilityAsync(
        string providerId,
        ModelCapacityVector capacityVector,
        CancellationToken cancellationToken = default);

    ValueTask<ModelCapacityVector?> GetCapabilityAsync(
        string providerId,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<string>> ResolveCandidatesAsync(
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-03` モデルベクトルルーティング:
  ルーターが評価する候補母集合を提供します。
- `UC-22` 動的キャパシティ制御とモデルルーティング:
  実行時更新に追従し、制約下での候補解決を支えます。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論的候補解決:
  同一レジストリ状態と同一 `RuleEvaluationContext` に対して、`ResolveCandidatesAsync` は同一順序で同一候補を返す必要があります。
- データ整合性保護:
  `RegisterCapabilityAsync` は信頼済み管理経路からのみ呼び出される運用を前提とし、未承認更新を許容しない設計が必要です。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装は以下の失敗類型を明示的に扱うことが推奨されます。

- 未登録プロバイダー参照:
  存在しない `providerId` 取得時の失敗。
- レジストリ競合:
  同一IDに対する矛盾能力の登録競合。

## 6. 実装時の注意 (Notes)
- 高速参照性:
  頻繁な照会を想定し、低レイテンシ検索構造（キャッシュ/インデックス）を推奨します。
- フィルタ連動:
  `ResolveCandidatesAsync` は存在確認だけでなく、`RuleEvaluationContext` に基づくガバナンスフィルタを適用してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
