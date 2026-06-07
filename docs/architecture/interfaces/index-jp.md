---
title: "AIKernel Architecture Interfaces — Index"
created: 2026-05-03
updated: 2026-06-07
published: 2026-05-16
version: "0.1.0"
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

英語版: [Index](index.md)

# AIKernel Architecture Interfaces — Index

## 名前空間別インデックス
- [capabilities/index-jp.md](capabilities/index-jp.md)
- [context/index-jp.md](context/index-jp.md)
- [contracts/index-jp.md](contracts/index-jp.md)
- [conversation/index-jp.md](conversation/index-jp.md)
- [dynamicslm/index-jp.md](dynamicslm/index-jp.md)
- [dsl/index-jp.md](dsl/index-jp.md)
- [execution/index-jp.md](execution/index-jp.md)
- [governance/index-jp.md](governance/index-jp.md)
- [hatl/index-jp.md](hatl/index-jp.md)
- [history/index-jp.md](history/index-jp.md)
- [hosting/index-jp.md](hosting/index-jp.md)
- [kernel/index-jp.md](kernel/index-jp.md)
- [material/index-jp.md](material/index-jp.md)
- [memory/index-jp.md](memory/index-jp.md)
- [models/index-jp.md](models/index-jp.md)
- [pipeline/index-jp.md](pipeline/index-jp.md)
- [prompt/index-jp.md](prompt/index-jp.md)
- [provider/index-jp.md](provider/index-jp.md)
- [query/index-jp.md](query/index-jp.md)
- [rom/index-jp.md](rom/index-jp.md)
- [routing/index-jp.md](routing/index-jp.md)
- [rules/index-jp.md](rules/index-jp.md)
- [scheduling/index-jp.md](scheduling/index-jp.md)
- [security/index-jp.md](security/index-jp.md)
- [tasks/index-jp.md](tasks/index-jp.md)
- [time/index-jp.md](time/index-jp.md)
- [tooling/index-jp.md](tooling/index-jp.md)
- [vfs/index-jp.md](vfs/index-jp.md)

## 名前空間概要
- `capabilities`: CLI、managed assembly、native ABI、DSL ROM、remote endpoint module 向け external Capability module registry / invocation boundary 契約。
- `kernel`: カーネル本体の実行入口とライフサイクル契約。
- `dsl`: 決定論的 semantic IR、DSL pipeline、DSL ROM registry、VFS-backed DSL ROM store 契約。
- `dynamicslm`: Capability modular SLM artifact 向けの Model ABI、capability subgraph 解決、lineage 検証、payload materialization、scheduling、differential distillation planning、background offload 契約。
- `governance`: attention guard、audit logger、signature trust、context lifecycle、ChatChain hash-chain 契約、admission replay evidence、Semantic IR slot vocabulary。
- `hatl`: Hash-Anchored Trust Layer の ledger、public anchor、Digital Deed、外部 cryptographic operator 契約。
- `history`: history summarization と History ROM registry/export/store 契約。
- `memory`: AIKernel.NET が所有する OS 非依存の MemoryRegion / MemoryMapper contract surface。Result-based runtime adapter は Core/Common に残す。
- `models`: 能力軸・動的容量・実行制約のベースモデル契約。
- `query`: Phase 1 query 補間・分解・routing 契約。
- `security`: PDP/Guard による決定論的アクセス判定契約。
- `tasks`: タスク実行単位とパイプライン結果契約。
- `scheduling`: スケジュール実行ジョブと実行結果契約。
- `time`: 決定論的 Kernel clock 契約。
- `vfs`: Vfs contract は公開 namespace `AIKernel.Vfs` を維持しつつ、`AIKernel.Abstractions` が所有する。
- 既存カテゴリ（context〜vfs）は各 index に責務境界・関連UC・関連Spec を明記。

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): src整合に伴うカテゴリ追加とリンク更新
- v0.0.1 (2026-05-09): query interface category を追加
- v0.0.3 (2026-06-02): Vfs contract 所有元の注記を追加
- v0.0.4 (2026-06-04): DSL、History ROM、Time interface category を追加
- v0.0.4 (2026-06-04): audit / ChatChain contract を含む governance coverage を明確化
- v0.0.5 (2026-06-05): DynamicSLM Model ABI / distillation offload / SeedSLM discipline interface category を追加
- v0.0.5 (2026-06-05): 外部 cryptographic operator 向け HATL interface category を追加
- v0.0.5 (2026-06-05): admission replay と Semantic IR slot の governance vocabulary を追加
- v0.0.5 (2026-06-05): external Capability module interface category を追加
- v0.1.0 (2026-06-07): MemoryRegion / MemoryMapper interface category と ownership note を追加
