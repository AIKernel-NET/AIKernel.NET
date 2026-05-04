---
id: ieventbus
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IEventBus"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は $(System.Collections.Hashtable.name).md を参照。

# IEventBus

## Responsibility
IEventBus が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `PublishAsync(string eventName, EventBusMessage eventData, CancellationToken cancellationToken = default)` | `Task` | Publish single event. |
| `Subscribe<T>(string eventName, Func<T, Task> handler)` | `string` | Subscribe handler and return subscription id. |
| `Unsubscribe(string subscriptionId)` | `bool` | Remove subscription. |
| `BroadcastAsync(string eventName, EventBusMessage eventData, CancellationToken cancellationToken = default)` | `Task` | Broadcast event to all subscribers. |
| `GetSubscriberCount(string eventName)` | `int` | Get subscriber count by event name. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の $(System.Collections.Hashtable.name) 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
