---
id: iprovidercreditinfo
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCreditInfo"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - credit
  - japanese
---

英語版は `IProviderCreditInfo.md` を参照。

# IProviderCreditInfo

## Responsibility
Provider のクレジット残高と予算境界を公開し、Orchestration がコスト制約付きで実行先を制御できるようにする。

## プロパティ一覧
| Property | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Provider の論理識別子。 |
| `CurrencyCode` | `string` | 請求通貨（ISO 4217）。 |
| `CurrentBalance` | `decimal` | 現在利用可能な残高。 |
| `ReservedBalance` | `decimal` | 実行中ジョブに予約済みの残高。 |
| `HardLimit` | `decimal` | 絶対支出上限。 |
| `SoftLimit` | `decimal` | 警告閾値。 |
| `LastUpdatedUtc` | `DateTimeOffset` | 最終更新時刻。 |

## 利用シナリオ（Use Cases）
- UC-23 AI クレジット管理
- UC-19 マルチモデル並列推論

## `IModelVectorRouter` との連携
Router スコア計算時にクレジット条件を適用する。
- 最低残高未満の Provider は除外
- `SoftLimit` 付近の Provider は減点
- `HardLimit` 到達時はフォールバック先へ強制迂回

## 円グラフ UI に必要なデータ項目
- available: `CurrentBalance - ReservedBalance`
- reserved: `ReservedBalance`
- consumed: `HardLimit - CurrentBalance`
- ラベル: `ProviderId`, `CurrencyCode`, `LastUpdatedUtc`




