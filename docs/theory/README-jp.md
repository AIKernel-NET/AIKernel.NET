---
title: "AIKernel Theory — Research in Progress"
subtitle: "Current Focus, Active Investigations, and Future Directions"
id: aikernel-theory
slug: theory
version: "0.1.0"
status: "Work-in-Progress"
issuer: "ai-kernel@aikernel.net"
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
published: 2026-05-17
updated: 2026-05-17
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

## 🎯 現在の注力ポイント（Active Focus）

- Pre-Inference Admissibility Governance の実装準備  
- Critical Operation Gate の C# インターフェース設計  
- Complexity Gate の NPU 最適化検討  
- フェーズ1統合論文（前段＋後段）の構想  
- AIKernel.NET の PreInferencePipeline の実装  
- Intent 分類（Unknown / Explanation / Plan / Execution）の精度向上  
- Fail-Closed の優先順位モデルの調整  

---

## 📘 研究ログ（Research Notes）

- LLM の計算論的限界（Sikka 2025）を OS の Admission Control に変換する試み  
- 前段ガバナンスと後段ガバナンスの二段階モデルの統合  
- NPU 前提の高速フィルタリングの設計  
- ReplayLog の決定論的再現性の確保  
- Capability-based Delegation の適用範囲の検討  

---

## 🧩 完成した成果物（Moved to Papers）

- **02_preinference_admissibility/**  
  → Pre-Inference Admissibility Governance（論文2・DOI 取得予定）

- **01_trajectory_governance/**  
  → Trajectory Governance（論文1・後段ガバナンス）

---

## 🚀 次の目標（Next Milestones）

- AIKernel.NET のフェーズ1実装を完了させる  
- 論文1・論文2を引用した **フェーズ1統合論文** を執筆  
- Zenodo / arXiv で正式公開  
- NPU 最適化レイヤー（AIKernel.NPU）の設計開始  
- フェーズ2（LLM コール後の動的制御）の拡張  

---

## 📝 このディレクトリの役割

- 研究の“現在地”を示す  
- 未確定のアイデアを置く  
- 完成したら papers/specs に移動する  
- 次の目標を掲げる  
- プロジェクトの進行を透明化する  

AIKernel の進化の軌跡を記録するための **研究ログ** として機能します。
