---
id: iprovidercapabilities
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCapabilities"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IProviderCapabilities.md を参照。

# IProviderCapabilities

## Responsibility
IProviderCapabilities が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `SupportedOperations` | `IReadOnlyList<string>` | Supported operation set. |
| `SupportedDataTypes` | `IReadOnlyList<string>` | Supported data types. |
| `MaxConcurrentConnections` | `int` | Maximum concurrent execution channels. |
| `RateLimit` | `RateLimitInfo?` | Provider rate-limit metadata. |
| `Vector` | `ModelCapacityVector` | Static capability vector. |
| `GetDynamicCapacities(IExecutionConstraints constraints)` | `IDictionary<string, float>?` | Dynamic capacity map under runtime constraints. |
| `GetCapabilityProfile()` | `ICapabilityProfile?` | Capacity profile curve by cardinality/constraints. |
| `SupportsOperation(string operation)` | `bool` | Check operation support. |
| `SupportsDataType(string dataType)` | `bool` | Check data type support. |
| `SupportsQuantization(string quantizationLevel)` | `bool` | Check quantization support. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IProviderCapabilities 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



