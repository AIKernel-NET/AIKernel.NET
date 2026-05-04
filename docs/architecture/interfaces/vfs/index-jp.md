---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "vfs Interfaces"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# vfs Interfaces

## ドキュメント一覧
- IVfsProvider-jp.md

## 境界ルール
- VFS パッケージはインターフェース契約のみを保持し、具象データキャリアは `AIKernel.Dtos.Vfs` に定義する。
