---
title: "rom Interfaces"
created: 2026-05-06
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

英語版: [Specification Index](specs/index.md)

# rom Interfaces

## 1. 責務の境界 (Responsibility Boundary)
ROM は知能資産の正準表現と検証境界です。`IRomDocument` を中心に、`IRomCanonicalizer`、`ISemanticHasher`、`IRomValidator`、`IRelationResolver` が正規化・整合性・リンク解決を担います。

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
- [IRomCanonicalizer (ROM 正準化インターフェース仕様)](architecture/interfaces/rom/IRomCanonicalizer-jp.md)
- [ISemanticHasher (セマンティックハッシュ・インターフェース仕様)](architecture/interfaces/rom/ISemanticHasher-jp.md)
- [IRomDocument (ROM ドキュメント仕様)](architecture/interfaces/rom/IRomDocument-jp.md)
- [IRomValidator (ROM バリデーター仕様)](architecture/interfaces/rom/IRomValidator-jp.md)
- [IRelationResolver (関係解決インターフェース仕様)](architecture/interfaces/rom/IRelationResolver-jp.md)
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
