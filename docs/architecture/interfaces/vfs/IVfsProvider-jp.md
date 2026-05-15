---
id: ivfsprovider
title: "IVfsProvider"
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

英語版: [IVfsProvider](architecture/interfaces/vfs/IVfsProvider.md)

# IVfsProvider

## Responsibility
IVfsProvider が AIKernel のオーケストレーションおよび統治フローで、認証済み Vfs session を開くための provider 境界を定義する。

`IVfsProvider` 自体は read/write/delete/navigation/query 権限を意味しない。これらの権限は、返された session が実装する capability interface によって表現する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Vfs provider identifier. |
| `Name` | `string` | Vfs provider display name. |
| `OpenSessionAsync(IVfsCredentials credentials)` | `Task<IVfsSession>` | Open authenticated Vfs session. |
| `IsAvailableAsync()` | `Task<bool>` | Check provider availability. |
| `GetHealthAsync()` | `Task<VfsProviderHealth>` | Return health status for diagnostics. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IVfsProvider 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。
- `VfsProviderHealth` などの具象データキャリアは `AIKernel.Dtos.Vfs` に定義する。
- 不足している capability は、実行前に必要な capability interface を確認して検出すること。Provider は未対応の write/delete/query member を公開して遅延失敗させてはならない。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.2 (2026-05-09): Session capability boundary を明確化
