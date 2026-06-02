---
id: iprovidercostprofile
title: "IProviderCostProfile"
created: 2026-05-03
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
  - provider
  - cost
  - japanese
---

英語版は [IProviderCostProfile.md](./IProviderCostProfile.md) を参照。

# IProviderCostProfile (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IProviderCostProfile` は、プロバイダー別・モデル階層別の単価カタログを定義し、経済性を含むルーティング判断の静的根拠を提供する境界インターフェースです。

- 役割:
  入出力トークン、計算時間、保存コスト、および価格適用時刻を提供します。
- 非役割:
  実績消費の累積管理は `IProviderBillingInfo` 側の責務です。

## 2. プロパティ定義 (Properties)
| Property | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Provider 識別子。 |
| `ModelClass` | `string` | 能力クラス（logic-heavy, balanced, fast）。 |
| `InputTokenUnitCost` | `decimal` | 入力トークン単価。 |
| `OutputTokenUnitCost` | `decimal` | 出力トークン単価。 |
| `ComputeMinuteCost` | `decimal` | 計算時間単価。 |
| `StorageUnitCost` | `decimal` | スナップショット保存単価。 |
| `EffectiveFromUtc` | `DateTimeOffset` | 価格適用開始時刻。 |

## 3. 利用シナリオ (Use Cases)
- `UC-23` AI クレジット管理:
  見積コストと予算残高を照合し、実行可否を制御します。
- `UC-03` Model Vector Routing:
  能力/レイテンシに加えてコスト指標を合成し、最終ルートを選定します。

## 4. `IModelVectorRouter` との連携
1. 見積総コスト算出:
   想定トークン量と単価プロファイルから候補ルートごとの総コストを予測します。
2. 多目的最適化:
   能力スコア、レイテンシ、コストを合成して最終パスを決定します。

## 5. 可視化（UI）への応用
- 入力コスト比率:
  `InputTokenUnitCost`
- 出力コスト比率:
  `OutputTokenUnitCost`
- 計算/保存コスト比率:
  `ComputeMinuteCost`, `StorageUnitCost`
- 識別ラベル:
  `ProviderId`, `ModelClass`, `EffectiveFromUtc`

## 6. 統治上の制約 (Governance)
- 不変性:
  同一 `EffectiveFromUtc` の価格プロファイルは監査保護のため遡及変更を避けるべきです。
- Fail-Closed:
  適用可能なコストプロファイル不在時は高額誤実行を防ぐため候補を遮断します。
- リプレイ整合:
  実行時に適用した `EffectiveFromUtc` を記録し、経済背景の再現性を確保します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
