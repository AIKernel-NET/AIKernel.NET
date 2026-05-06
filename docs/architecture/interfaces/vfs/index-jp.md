---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "vfs Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# vfs Interfaces

## 1. 責務の境界 (Responsibility Boundary)
VFS は知能資産の保存・取得境界を抽象化します。`IVfsProvider` はパス解決、整合性確認、読み書きの契約のみを公開し、具体的データ構造は DTO 層へ分離します。

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

## ドキュメント一覧
- IVfsProvider-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
