---
title: "contracts Interfaces"
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

# contracts Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Contracts はモジュール横断 ABI として機能します。Orchestration / Expression / Material / UnifiedContext などの契約を通じ、推論・表現・素材の境界条件を明示します。

## 2. 関連ユースケース (Related UCs)
- `UC-02` Structure フェーズ
- `UC-04` 出力整形
- `UC-06` 3層バッファ境界

## 3. 関連仕様 (Related Specs)
- `01.EXECUTION_PIPELINE_SPEC-jp.md`
- `16.SEMANTIC_CONTEXT_OS_VISION-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Context`, `AIKernel.Abstractions.Governance`

## ドキュメント一覧
- [IExpressionContract (契約仕様)](architecture/interfaces/contracts/IExpressionContract-jp.md)
- [IMaterialContract](architecture/interfaces/contracts/IMaterialContract-jp.md)
- [IOrchestrationContract (契約仕様)](architecture/interfaces/contracts/IOrchestrationContract-jp.md)
- [IKernelContextContract (契約仕様)](architecture/interfaces/contracts/IKernelContextContract-jp.md)
- [IMessageContract (契約仕様)](architecture/interfaces/contracts/IMessageContract-jp.md)
- [ITokenizerProfile (契約仕様)](architecture/interfaces/contracts/ITokenizerProfile-jp.md)
- [IUnifiedContextContract (統合契約仕様)](architecture/interfaces/contracts/IUnifiedContextContract-jp.md)
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
