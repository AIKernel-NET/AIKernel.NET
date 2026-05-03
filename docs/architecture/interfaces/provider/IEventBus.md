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
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IEventBus

## Responsibility
Define the contract boundary for IEventBus within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `PublishAsync(string eventName, EventBusMessage eventData, CancellationToken cancellationToken = default)` | `Task` | Publish single event. |
| `Subscribe<T>(string eventName, Func<T, Task> handler)` | `string` | Subscribe handler and return subscription id. |
| `Unsubscribe(string subscriptionId)` | `bool` | Remove subscription. |
| `BroadcastAsync(string eventName, EventBusMessage eventData, CancellationToken cancellationToken = default)` | `Task` | Broadcast event to all subscribers. |
| `GetSubscriberCount(string eventName)` | `int` | Get subscriber count by event name. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
