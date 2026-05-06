---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "hosting Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# hosting Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Hosting はカーネルの起動・モジュール登録・ライフサイクル遷移を扱う境界です。`IKernelHost`、`IKernelModule`、`IServiceRegistrar` により、実行前に必要コンポーネントを確実に組み上げます。

## 2. 関連ユースケース (Related UCs)
- `UC-08` カーネル初期化
- `UC-09` 実行状態復元
- `UC-29` タスクパイプライン管理

## 3. 関連仕様 (Related Specs)
- `01.EXECUTION_PIPELINE_SPEC-jp.md`
- `16.SEMANTIC_CONTEXT_OS_VISION-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Abstractions`, `AIKernel.Contracts`, `AIKernel.Dtos`
- Called by: `AIKernel.Core`（実装層）, `Host Applications`

## ドキュメント一覧
- IKernelContext-jp.md
- IKernelHost-jp.md
- IKernelModule-jp.md
- IProviderRegistrar-jp.md
- IServiceRegistrar-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
