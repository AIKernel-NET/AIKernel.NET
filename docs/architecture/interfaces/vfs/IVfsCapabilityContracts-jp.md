---
id: ivfscapabilitycontracts
title: "Vfs Capability Contracts"
created: 2026-05-09
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
  - vfs
  - capability
  - japanese
---

英語版: [Vfs Capability Contracts](architecture/interfaces/vfs/IVfsCapabilityContracts.md)

# Vfs Capability Contracts

## Responsibility
Vfs capability contract は、ファイルシステム権限を型システム上で表現する。実装は、実際に実行できる操作に対応する interface のみを公開する。

## Capability Interfaces
| Interface | 責務 |
| --- | --- |
| `IVfsEntryInfo` | Vfs entry に共通する識別情報と metadata。 |
| `IReadableVfsFile` | ファイル内容を bytes または text として読み取る。 |
| `IWritableVfsFile` | file-level mutation が成立する場合に、ファイル内容を bytes または text として書き込む。 |
| `INavigableVfsDirectory` | ファイル、ディレクトリ、entry、サブディレクトリを列挙する。 |
| `IReadableVfsSession` | session 経由でファイルを読み取り、path の存在を確認する。 |
| `IWritableVfsSession` | session 経由でファイルを書き込む。 |
| `IDeletableVfsSession` | session 経由でファイルまたはディレクトリを削除する。 |
| `INavigableVfsSession` | session 経由で navigable directory を開く。 |
| `IQueryableVfsSession` | provider 定義の Vfs query を実行する。 |

## Compatibility Contracts
`IVfsFile`, `IVfsDirectory`, `IVfsSession` は互換合成 contract として残す。

- `IVfsFile` は `IReadableVfsFile` を継承する。
- `IVfsDirectory` は `INavigableVfsDirectory` を継承し、従来の directory 戻り値型を維持する。
- `IVfsSession` は readable, writable, deletable, navigable, queryable, async-disposable な session capability を合成する。

## Fail-Closed Rule
呼び出し側は、操作を開始する前に必要な capability interface を確認すること。Capability が存在しない場合、副作用が始まる前に実行を拒否しなければならない。

未対応 capability を、部分実行する method や `NotSupportedException` による遅延失敗で表現してはならない。

---

# 変更履歴
- v0.0.2 (2026-05-09): Capability-based Vfs contract を初期定義
