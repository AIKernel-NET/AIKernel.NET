---
id: ischeduler
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IScheduler"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は $(System.Collections.Hashtable.name).md を参照。

# IScheduler

## Responsibility
IScheduler が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `GetJobAsync(string jobId)` | `Task<IScheduledJob?>` | Get scheduled job by id. |
| `ScheduleAsync(IScheduleSpec job)` | `Task<IScheduledJob>` | Schedule a new job. |
| `CancelAsync(string jobId)` | `Task<bool>` | Cancel scheduled job. |
| `ListJobsAsync()` | `Task<IReadOnlyList<IScheduledJob>>` | List all jobs. |
| `GetExecutionResultAsync(string jobId)` | `Task<IExecutionResult?>` | Get execution result by job id. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の $(System.Collections.Hashtable.name) 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
