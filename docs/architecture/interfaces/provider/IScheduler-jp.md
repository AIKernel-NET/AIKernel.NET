---
id: ischeduler
title: "IScheduler"
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
  - japanese
---

英語版は [IScheduler.md](./IScheduler.md) を参照。

# IScheduler (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IScheduler` は、知能タスクの実行タイミング・優先順位・ライフサイクルを管理する時分割統治インターフェースです。

- 役割:
  ジョブ投入、状態参照、キャンセル、結果回収を提供し、実行交通整理を担います。
- 非役割:
  推論本体の実行ロジックは `IModelProvider` / `IThoughtProcess` 側の責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Scheduling;

public interface IScheduler : IProvider
{
    Task<IScheduledJob?> GetJobAsync(string jobId);
    Task<IScheduledJob> ScheduleAsync(IScheduleSpec job);
    Task<bool> CancelAsync(string jobId);
    Task<IReadOnlyList<IScheduledJob>> ListJobsAsync();
    Task<IExecutionResult?> GetExecutionResultAsync(string jobId);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-19` マルチモデル並列推論:
  並列ジョブの投入と収束待ちの同期点を提供します。
- `UC-22` 動的キャパシティ制御:
  レート制限時のバックオフ・再試行スケジュール制御に寄与します。
- `UC-28` ジョブスケジューリング:
  即時/遅延/バッチ実行を統一的に管理します。

## 4. 統治上の制約 (Governance & Determinism)
- ジョブ不変性:
  受理済み `IScheduleSpec` は事後変更せず、変更時は再登録を原則とします。
- リプレイ整合:
  受理順序・実行順序・時刻を記録し、時系列再現可能性を担保します。
- Fail-Closed:
  キュー過負荷時は無制限受理せず、明示的に新規受付を制限します。

## 5. 実装時の注意 (Notes)
- 永続化:
  再起動跨ぎ運用ではジョブ状態のバッキングストア保持を推奨します。
- 優先度制御:
  重要ジョブを先行実行できるディスパッチポリシーを設計してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
