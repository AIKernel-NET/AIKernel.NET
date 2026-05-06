---
id: ieventbus
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IEventBus"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IEventBus-jp.md](./IEventBus-jp.md).

# IEventBus (Interface Specification)

## 1. Responsibility Boundary
`IEventBus` is the neural communication interface for asynchronous event propagation across kernel components with loose coupling.

- Role:
  Provide event publish, subscription lifecycle, broadcast delivery, and subscriber-count visibility.
- Non-role:
  Distributed transaction guarantees and durable queue semantics are out of scope.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Events;

public interface IEventBus : IProvider
{
    Task PublishAsync(string eventName, object eventData, CancellationToken cancellationToken = default);
    string Subscribe<T>(string eventName, Func<T, Task> handler);
    bool Unsubscribe(string subscriptionId);
    Task BroadcastAsync(string eventName, object eventData, CancellationToken cancellationToken = default);
    int GetSubscriberCount(string eventName);
}
```

## 3. Related Use Cases
- `UC-20` Deterministic replay and audit trail:
  Delivers routing/signature/governance events into audit pipelines.
- `UC-13` Runtime signature verification:
  Broadcasts verification-failure events for immediate containment.
- `UC-25` Event bus distribution:
  Acts as the common kernel event-delivery substrate.

## 4. Governance & Determinism
- Side-effect control:
  Handlers should minimize interference with primary reasoning flow.
- Ordering:
  If event order is semantically critical, implementation should provide ordering guarantees.
- Fail-Closed:
  Failures that disable safety monitoring should trigger safe-stop or alternate audit channels.

## 5. Implementation Notes
- In-memory/distributed portability:
  Preserve contract behavior when switching from local bus to distributed backends.
- Type safety:
  Since `eventData` is `object`, maintain explicit event-name to payload-type mappings in production.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
