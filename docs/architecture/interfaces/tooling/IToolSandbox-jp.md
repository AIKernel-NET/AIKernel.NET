---
id: itoolsandbox
title: "IToolSandbox"
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

英語版: $(System.Collections.Hashtable.Name)

# IToolSandbox

## Responsibility
IToolSandbox が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `SandboxId` | `string` | Sandbox identifier. |
| `ExecuteToolAsync(string toolName, IReadOnlyDictionary<string, string> parameters, IToolPermission permissions)` | `Task<SandboxExecutionResult>` | Execute tool within sandbox. |
| `UploadFileAsync(string fileName, byte[] content)` | `Task<bool>` | Upload file into sandbox. |
| `DownloadFileAsync(string fileName)` | `Task<byte[]?>` | Download file from sandbox. |
| `CleanupAsync()` | `Task` | Cleanup sandbox resources. |
| `GetResourceUsageAsync()` | `Task<SandboxResourceUsage>` | Get sandbox resource usage. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の $(System.Collections.Hashtable.name) 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
