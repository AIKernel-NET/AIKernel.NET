---
id: iprovider
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProvider"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IProvider.md を参照。

# IProvider

## Responsibility
IProvider が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Unique provider identifier. |
| `Name` | `string` | Provider display name. |
| `Version` | `string` | Provider version string. |
| `GetCapabilities()` | `IProviderCapabilities` | Return static and dynamic capability metadata. |
| `IsAvailableAsync()` | `Task<bool>` | Check provider availability. |
| `InitializeAsync()` | `Task` | Initialize provider runtime resources. |
| `ShutdownAsync()` | `Task` | Shutdown and release resources. |
| `GetHealthAsync()` | `Task<ProviderHealthStatus>` | Execute provider health check. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IProvider 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



