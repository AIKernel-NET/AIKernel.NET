---
id: iprovidercostprofile
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCostProfile"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - cost
  - japanese
---

英語版は `IProviderCostProfile.md` を参照。

# IProviderCostProfile

## Responsibility
Provider とモデル階層ごとの正規化コスト特性を記述し、ルーティング時の推論経済性最適化に利用する。

## プロパティ一覧
| Property | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Provider 識別子。 |
| `ModelClass` | `string` | 能力クラス（logic-heavy, balanced, fast）。 |
| `InputTokenUnitCost` | `decimal` | 入力トークン単価。 |
| `OutputTokenUnitCost` | `decimal` | 出力トークン単価。 |
| `ComputeMinuteCost` | `decimal` | 計算時間単価。 |
| `StorageUnitCost` | `decimal` | スナップショット保存単価。 |
| `EffectiveFromUtc` | `DateTimeOffset` | 価格適用開始時刻。 |

## 利用シナリオ（Use Cases）
- UC-23 AI クレジット管理
- UC-03 Model Vector Routing

## `IModelVectorRouter` との連携
候補ルートごとに見積総コストを計算し、能力スコア・レイテンシスコアと合成して最終選定に使う。

## 円グラフ UI に必要なデータ項目
- input-cost: `InputTokenUnitCost`
- output-cost: `OutputTokenUnitCost`
- compute-cost: `ComputeMinuteCost`
- storage-cost: `StorageUnitCost`
- ラベル: `ProviderId`, `ModelClass`, `EffectiveFromUtc`




