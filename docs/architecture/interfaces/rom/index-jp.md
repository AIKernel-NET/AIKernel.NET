---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "rom Interfaces"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# rom Interfaces

## 1. 責務の境界 (Responsibility Boundary)
ROM は知能資産の正準表現と検証境界です。`IRomDocument` を中心に、`IROMCanonicalizer`、`ISemanticHasher`、`IRomValidator`、`IRelationResolver` が正規化・整合性・リンク解決を担います。

## 2. 関連ユースケース (Related UCs)
- `UC-01` ROM ロードと解析
- `UC-15` コンテキストハイドレーション
- `UC-20` 決定論的リプレイ

## 3. 関連仕様 (Related Specs)
- `03.ROM_CORE_SPEC-jp.md`
- `06.REPLAY_DUMP_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos.Rom`, `AIKernel.Dtos.Context`
- Called by: `AIKernel.Abstractions.Prompt`, `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Governance`

## ドキュメント一覧
- IROMCanonicalizer-jp.md
- ISemanticHasher-jp.md
- IRomDocument-jp.md
- IRomValidator-jp.md
- IRelationResolver-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
