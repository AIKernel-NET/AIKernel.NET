---
title: 'IModelVectorRouter'
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

英語版は [IModelVectorRouter.md](./IModelVectorRouter.md) を参照。

# IModelVectorRouter (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IModelVectorRouter` は、要求能力ベクトルと実行制約に基づいて最適なモデル（プロバイダー）を選定するルーティング境界インターフェースです。

- 役割:
  多次元ベクトルの適合評価、ルール・制約による候補絞り込み、決定論的な最終選定を担います。
- 非役割:
  実際の推論実行は選定先の実装責務です。また、能力情報の登録・管理は `ICapabilityRegistry` 側の責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Routing;

using AIKernel.Abstractions.Models;

public interface IModelVectorRouter
{
    Task<ModelRoutingDecision> RouteAsync(
        ModelCapacityVector requiredCapacity,
        RuleEvaluationContext ruleEvaluationContext,
        IExecutionConstraints executionConstraints,
        CancellationToken cancellationToken = default);

    ModelType SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates);

    IEnumerable<(ModelType Model, float Score)> RankModels(
        ModelCapacityVector requirement,
        IEnumerable<ModelType> candidates);

    bool VerifyDeterministicRouting(ModelRoutingDecision decision1, ModelRoutingDecision decision2);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-03` モデルベクトルルーティング:
  要求ベクトルに基づく実行ユニット選定の中核です。
- `UC-22` 動的キャパシティ制御とモデルルーティング:
  予算・負荷・能力変化を踏まえた実行先の最適化に寄与します。
- `UC-30` トークン・ベクトル推定:
  推定済み要求ベクトルに対して実行可能性を判定します。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論的ルーティング:
  同一の能力要求・評価コンテキスト・実行制約が与えられた場合、同一の `ModelRoutingDecision` を返す必要があります。
- Fail-Closed 原則:
  必須能力を満たす候補が存在しない場合、低品質な妥協選定を行わず、拒否または失敗として終了させます。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は、特定の例外型を固定しません。実装は以下のような失敗を明示的に扱うことが推奨されます。

- ルーティング先不在:
  候補が存在しない、または有効候補が制約で全除外されるケース。
- 制約違反:
  `IExecutionConstraints`（予算・地域・レイテンシ等）により実行不能となるケース。

## 6. 実装時の注意 (Notes)
- 多次元評価:
  `ModelCapacityVector` の複数軸を単一近似値に潰し過ぎず、説明可能な形で総合評価してください。
- 監査性:
  選定根拠（スコア・除外理由・タイブレーク根拠）を `ModelRoutingDecision` に追跡可能な形で保持してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
