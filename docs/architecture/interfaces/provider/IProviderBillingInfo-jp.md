---
id: iproviderbillinginfo
title: "IProviderBillingInfo"
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
  - billing
  - japanese
---

英語版は [IProviderBillingInfo.md](./IProviderBillingInfo.md) を参照。

# IProviderBillingInfo (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IProviderBillingInfo` は、AI実行コストの可視化と経済統治判断に必要な請求状態メタデータを提供する境界インターフェースです。

- 役割:
  請求サイクル、累積コスト、予測コスト、支払状態を提供し、予算統治とチャージバック基盤を支えます。
- 非役割:
  決済実行や請求回収処理そのものは責務外です。

## 2. プロパティ定義 (Properties)
| Property | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Provider 識別子。 |
| `BillingAccountId` | `string` | Provider 側の請求アカウント識別子。 |
| `BillingCycle` | `string` | 請求周期（monthly, prepaid, postpaid）。 |
| `CycleStartUtc` | `DateTimeOffset` | 現行サイクル開始時刻。 |
| `CycleEndUtc` | `DateTimeOffset` | 現行サイクル終了時刻。 |
| `AccumulatedCost` | `decimal` | サイクル内累積コスト。 |
| `ForecastCost` | `decimal` | サイクル終了時予測コスト。 |
| `PaymentStatus` | `string` | 支払状態（active, due, overdue）。 |

## 3. 利用シナリオ (Use Cases)
- `UC-23` AI クレジット管理:
  残予算に応じた実行制御や低コスト経路誘導に利用します。
- `UC-18` チャット永続化とコスト按分:
  コンテキスト単位のコスト追跡と内部請求根拠に利用します。

## 4. `IModelVectorRouter` との連携
- ハード制約:
  `PaymentStatus=overdue` は実行失敗リスク回避のため候補除外対象とします。
- ソフト制約:
  能力同等時は `ForecastCost` が低く予算余力のあるプロバイダーを優先します。

## 5. 可視化（円グラフ UI）への応用
- 既使用シェア:
  `AccumulatedCost`
- 予測追加シェア:
  `ForecastCost - AccumulatedCost`
- リスクシェア:
  `PaymentStatus` が `due` / `overdue` に該当するコスト
- 識別ラベル:
  `ProviderId`, `BillingCycle`, `CycleEndUtc`

## 6. 統治上の制約 (Governance)
- Fail-Closed:
  請求情報欠落時は安全側で高コスト実行を抑止する運用を推奨します。
- リプレイ整合:
  実行当時の請求状態はスナップショットメタデータに保持し、監査再現性を担保します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
