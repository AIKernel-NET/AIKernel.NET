---
id: architecture-decisions
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ARCHITECTURE_DECISIONS — 主要設計決定（ADR集約）"
created: 2026-05-01
tags:
- aikernel
- design
- adr
- governance
- japanese
---

# ARCHITECTURE_DECISIONS — 主要設計決定（ADR集約）

## 概要
本書は AIKernel.NET の主要な設計決定（Architecture Decision）を、後から参照できる形で集約する。  
AIKernel.NET は「AIアプリケーションの OS」を目指し、**契約（Contracts）と抽象（Interfaces）を固定点**に据えて実装依存を分離する。

- **目的**：設計の理由（Why）と採用した選択（What/How）を、将来の拡張・移行・レビューに耐える形で残す。
- **非目的**：具体的な実装方法・コードの詳細は別リポジトリ（実装側）と `DI_GUIDE`/`EXTENSION_POINTS` に委ねる。

---

## AD-0001 契約駆動（Contract-Driven）を最優先する
### 決定
Core は抽象インタフェースと Contracts（JSON Schema/DTO等）を保持し、実装依存を排除する。

### 理由
- 互換性の核を「契約」として固定し、実装の差し替えや将来拡張を容易にする。
- OSS 公開の初期段階で、思想と境界を最も明確に伝えられる。

### 影響
- 実装（Kernel/Providers/Server等）は別モジュール/別リポジトリに隔離される。
- 契約変更はガバナンス対象となり、破壊的変更の扱いを明文化する必要がある。

---

## AD-0002 LLM は提案者、PDP が最終決定者
### 決定
LLM は提案（suggestion）を生成する役割に限定し、最終的な意思決定は PDP（Policy Decision Point）が行う。

### 理由
- 非決定性（LLM出力）を OS として統治するため。
- コンプライアンス・コスト・リスクなどを統合し、監査可能な判断経路を確保するため。

### 影響
- PDP は契約として固定され、実装は差し替え可能な拡張点になる。

---

## AD-0003 Capability ベースで Provider を扱う（モデル名依存を排除）
### 決定
Provider は「何ができるか（Capabilities）」で宣言し、モデル名やベンダー固有挙動への依存を避ける。

### 理由
- マルチプロバイダ運用、フェイルオーバー、コスト/レイテンシ最適化を可能にする。
- モデル更新が激しい領域で、OSとして安定した抽象を提供する。

### 影響
- ルーティング（ProviderRouter）は Capability を根拠に意思決定する設計となる。

---

## AD-0004 Pipeline は DAG として表現し、TaskManager が決定論的に制御する
### 決定
Pipeline は DAG として構成し、TaskManager がリソース制御・スケジューリングを担う。

### 理由
- 実行順序や再試行など「制御可能な部分」を決定論的に管理するため。
- 再現性（Deterministic Replay）の基盤として、実行をトレース可能にするため。

### 影響
- Pipeline 実装は拡張点（Step/DAG）となり、横断関心（安全/監査/計測）と分離される。

---

## AD-0005 Deterministic Replay を最優先要件とする
### 決定
監査と再現性（Deterministic Replay）を最優先し、実行ログ・プロンプト・ランタイム状態を保存する。

### 理由
- AI システムを「運用可能な OS」として扱うためには、説明責任と再現性が必須。

### 影響
- 監査イベント（Audit/Event）やトレース情報を契約/仕様として固定する必要がある。

---

## AD-0006 ドキュメント構造をアーキテクチャの一部として扱う
### 決定
ドキュメントは単なる説明ではなく、アーキテクチャの一部として規約化する。  
architecture は採番＋index、英語版が正規、日本語版が深掘りという運用を採用する。

### 理由
- 差分レビューとガバナンスを強化し、思想・仕様の一貫性を保つため。

---

## 関連ドキュメント
- `../DESIGN_INTENT-jp.md`（設計意図）
- `../architecture/index-jp.md`（思想文書の入口）
- `../DOCUMENTATION_GUIDELINES-jp.md`（ドキュメント規約）
- `EXTENSION_POINTS-jp.md`（拡張点の仕様）  
- `CONTRACT_VERSIONING-jp.md`（契約バージョニング）