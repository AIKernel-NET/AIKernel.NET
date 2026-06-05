---
title: "AIKernel Theory — Research in Progress"
subtitle: "Current Focus, Active Investigations, and Future Directions"
id: aikernel-theory
slug: theory
version: "0.1.1"
status: "Work-in-Progress"
issuer: "ai-kernel@aikernel.net"
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
published: 2026-05-17
updated: 2026-06-05
rom: false
tags:
  - AIKernel
  - Governance
  - Pre-Inference
  - Trajectory
  - Complexity
  - Research
summary: >
  このディレクトリは、AIKernel の研究・設計における
  「現在取り組んでいる課題」「検証中の仮説」「次の目標」を記録する
  Work-in-Progress の領域です。完成した成果物は docs/papers/ または docs/specs/ に移動します。
---

# AIKernel Theory — Research in Progress

AIKernel の研究・設計における **現在の注力ポイント** をまとめる場所です。  
ここにある内容は、まだ正式な仕様書や論文として確定していない  
“研究の現在地（Work in Progress）” を表します。

完成した成果物は、以下に移動します：

- `docs/papers/` — 論文・正式仕様（DOI 取得対象）
- `docs/specs/` — 実装仕様書
- `src/AIKernel.*` — 実装

---

## 現在の注力ポイント（Active Focus）

- `docs/papers/` の正式論文シリーズを canonical な研究公開面として維持する。
- 公開 package contract と AIKernel 論文群の責務境界を整合させる。
- Semantic DSL、ReplayLog、History ROM、Capability ROM の実行モデルを精査する。
- DynamicSLM と capability-modular SLM runtime に向けた model-runtime 研究を整理する。
- Work-in-Progress のメモと DOI 付き論文・実装仕様を明確に分離する。

---

## 研究ログ（Research Notes）

- 新しいアイデアは、正式論文・実装仕様・source-level contract として安定するまでこの領域に置く。
- DOI 付き論文は `docs/papers/README.md` に集約する。
- 実装向け仕様は `docs/specs/` に集約する。
- architecture / interface 文書は `docs/architecture/` に集約する。

---

## 完成した成果物（Moved to Papers）

現在の正式論文シリーズは `docs/papers/` で管理し、次を含みます。

- Phase-1 理論基盤論文 `01` から `04`。
- Phase-1.1 実装レイヤ論文 `05` から `08`。
- Hash-Anchored Trust Layer の Phase-3 Foundation 論文 `09`。
- Semantic DSL Compiler と DynamicSLM に関する agent execution / model-runtime 論文 `10` と `11`。

---

## 次の目標（Next Milestones）

- DOI 付き論文を追加したときは `docs/papers/README.md` を同期する。
- contract-surface 変更時は package migration guide を同期する。
- DSL ROM、History ROM、Semantic DSL execution、capability-modular model runtime の実装仕様を拡充する。
- 成熟した theory note は古い WIP として残さず、`docs/papers/` または `docs/specs/` に移す。

---

## このディレクトリの役割

- 研究の“現在地”を示す  
- 未確定のアイデアを置く  
- 完成したら papers/specs に移動する  
- 次の目標を掲げる  
- プロジェクトの進行を透明化する  

AIKernel の進化の軌跡を記録するための **研究ログ** として機能します。
