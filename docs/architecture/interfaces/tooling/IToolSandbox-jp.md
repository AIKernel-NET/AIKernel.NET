---
id: itoolsandbox
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IToolSandbox"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は $(System.Collections.Hashtable.name).md を参照。

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
