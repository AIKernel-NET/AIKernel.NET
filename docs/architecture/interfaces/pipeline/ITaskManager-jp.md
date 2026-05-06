---
id: itaskmanager
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ITaskManager"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は $(System.Collections.Hashtable.name).md を参照。

# ITaskManager

## Responsibility
ITaskManager が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `RegisterPipelineAsync(IPipeline pipeline)` | `Task<string>` | Register pipeline definition. |
| `ExecutePipelineAsync(string pipelineId, ITaskContext context, CancellationToken cancellationToken = default)` | `Task<IPipelineExecutionResult>` | Execute pipeline by id. |
| `ExecuteTaskAsync(ITask task, ITaskContext context, CancellationToken cancellationToken = default)` | `Task<ITaskExecutionResult>` | Execute single task. |
| `PausePipelineAsync(string executionId)` | `Task<bool>` | Pause running pipeline. |
| `ResumePipelineAsync(string executionId)` | `Task<bool>` | Resume paused pipeline. |
| `CancelPipelineAsync(string executionId)` | `Task<bool>` | Cancel running pipeline. |
| `GetExecutionResultAsync(string executionId)` | `Task<IPipelineExecutionResult?>` | Get pipeline result by execution id. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の $(System.Collections.Hashtable.name) 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
