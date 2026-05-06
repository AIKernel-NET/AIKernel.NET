---
id: ivfsprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IVfsProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IVfsProvider.md を参照。

# IVfsProvider

## Responsibility
IVfsProvider が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | VFS provider identifier. |
| `Name` | `string` | VFS provider display name. |
| `OpenSessionAsync(IVfsCredentials credentials)` | `Task<IVfsSession>` | Open authenticated VFS session. |
| `IsAvailableAsync()` | `Task<bool>` | Check provider availability. |
| `GetHealthAsync()` | `Task<VfsProviderHealth>` | Return health status for diagnostics. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IVfsProvider 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。
- `VfsProviderHealth` などの具象データキャリアは `AIKernel.Dtos.Vfs` に定義する。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
