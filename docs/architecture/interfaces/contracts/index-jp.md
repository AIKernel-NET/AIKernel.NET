---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "contracts Interfaces"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

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
- IExpressionContract-jp.md
- IMaterialContract-jp.md
- IOrchestrationContract-jp.md
- IKernelContextContract-jp.md
- IMessageContract-jp.md
- ITokenizerProfile-jp.md
- IUnifiedContextContract-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
