---
id: iproviderbillinginfo
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderBillingInfo"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - billing
  - japanese
---

英語版は `IProviderBillingInfo.md` を参照。

# IProviderBillingInfo

## Responsibility
コンプライアンス、予実管理、チャージバックに必要な請求サイクルと請求状態メタデータを提供する。

## プロパティ一覧
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

## 利用シナリオ（Use Cases）
- UC-23 AI クレジット管理
- UC-18 チャット永続化

## `IModelVectorRouter` との連携
請求状態に応じた制約を Router に適用する。
- `overdue` の Provider は回避
- 能力同等なら `ForecastCost` が低い Provider を優先

## 円グラフ UI に必要なデータ項目
- active share: `AccumulatedCost`
- forecast share: `ForecastCost - AccumulatedCost`
- risk share: `PaymentStatus=overdue` に対応するコスト
- ラベル: `ProviderId`, `BillingCycle`, `CycleEndUtc`




