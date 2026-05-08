---
version: 0.0.2
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "vfs Interfaces"
created: 2026-05-03
updated: 2026-05-09
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# vfs Interfaces

## 1. 責務の境界 (Responsibility Boundary)
VFS は知能資産の保存・取得境界を抽象化します。`IVfsProvider` は認証済みセッションを開き、セッション、ファイル、ディレクトリの capability interface が provider の実際に提供できる操作のみを公開します。具体的データ構造は DTO 層へ分離します。

VFS の権限は、実行時に遅延失敗させるメソッドではなく、実装されている capability interface によって表現します。読み取り専用 provider は読み取り可能な session/file contract のみを公開し、write/delete 操作の実装を強制されません。

## 2. 関連ユースケース (Related UCs)
- `UC-01` ROM 構造のロードと解析
- `UC-09` 実行状態の永続化と復元
- `UC-20` 決定論的リプレイと監査証跡

## 3. 関連仕様 (Related Specs)
- `03.ROM_CORE_SPEC-jp.md`
- `06.REPLAY_DUMP_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos.Vfs`
- Called by: `AIKernel.Abstractions.Rom`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Execution`

## 境界ルール
- VFS パッケージはインターフェース契約のみを保持し、具象データキャリアは `AIKernel.Dtos.Vfs` に定義する。
- Capability の有無は、`NotSupportedException` を投げる placeholder method ではなく、実装 interface によって表現する。
- `IVfsFile`, `IVfsDirectory`, `IVfsSession` は、従来の全体 surface を必要とする呼び出し元のための互換合成 contract として残す。

## ドキュメント一覧
- IVfsProvider-jp.md
- IVfsCapabilityContracts-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.2 (2026-05-09): Capability-based VFS interface segregation を追加
