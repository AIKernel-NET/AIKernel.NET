---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IDynamicCapacityVector"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IDynamicCapacityVector.md](./IDynamicCapacityVector.md) を参照。

# IDynamicCapacityVector

## 1. 責務の境界 (Responsibility Boundary)
$n は次を定義します: 動的実行時能力を保持する複合ベクトル。

## 2. 関連ユースケース (Related UCs)
- UC-22

## 3. 関連仕様 (Related Specs)
- 04.MODEL_ROUTING_SPEC

## 4. 決定論と Fail-Closed に関する注意
- 同一入力に対して決定論的な挙動を保持すること。
- 判定不能・不正状態は必ず Fail-Closed で扱うこと。

## 5. 正典ソース (Source of Truth)
- シグネチャの正本は src/AIKernel.Abstractions（または隣接する正典契約プロジェクト）です。

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ソース整合最終化タスクボードに基づき追加
