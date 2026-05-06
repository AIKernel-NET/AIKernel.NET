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
  - japanese
---

英語版は [IEventBus.md](./IEventBus.md) を参照。

# IEventBus (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IEventBus` は、カーネル内イベントを非同期伝播させる神経系インターフェースであり、購読者への通知連携を疎結合で実現します。

- 役割:
  イベント発行、購読管理、ブロードキャスト、購読者数可視化を提供します。
- 非役割:
  分散トランザクション保証や外部キュー永続化は責務外です。

## 2. 契約シグネチャ (Signature)
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

## 3. 関連ユースケース (Related UCs)
- `UC-20` 決定論的リプレイと監査証跡:
  署名検証・ルーティング等のイベントを監査連携へ流します。
- `UC-13` 実行時署名検証:
  検証失敗イベントを即時配信し、遮断判断を補助します。
- `UC-25` Event Bus 配信:
  標準イベント配信基盤として機能します。

## 4. 統治上の制約 (Governance & Determinism)
- 副作用制御:
  ハンドラー処理は主推論フローへの予期しない副作用を最小化する必要があります。
- 順序性:
  順序依存イベントは実装側で配送順序保証を検討してください。
- Fail-Closed:
  監視系イベント喪失につながる障害時は安全側停止または代替監査経路を確保します。

## 5. 実装時の注意 (Notes)
- インメモリ/分散切替:
  単一プロセス実装から分散バックエンドへの差し替えを見据え、契約互換を維持してください。
- 型安全:
  `object eventData` を扱うため、運用ではイベント名とペイロード型の対応表を明示して安全性を担保してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
