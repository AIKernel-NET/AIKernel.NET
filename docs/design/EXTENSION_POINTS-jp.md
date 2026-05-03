---
id: extension-points
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "EXTENSION_POINTS — 拡張ポイント仕様（Provider/VFS/Policy 等）"
created: 2026-05-01
tags:
- aikernel
- design
- extension
- capabilities
- japanese
---

# EXTENSION_POINTS — 拡張ポイント仕様（Provider/VFS/Policy 等）

## 概要
本書は AIKernel.NET の拡張ポイント（差し替え可能な部品）を列挙し、**どこまでが契約で、どこからが実装か**を明確化する。  
AIKernel は契約駆動・Capabilityベース・PDP統治・DAG実行・再現性を中核に据えるため、拡張点もそれに沿って設計する。

## 前提（このリポジトリの役割）
- 本リポジトリ（契約リポ）は、Interface/DTO/Enum の **固定点**を提供する。
- 実装（Kernel/Providers/Server 等）は別リポジトリで開発し、ここでは拡張点の“形”のみを定義する。

---

## 1. Provider（能力プラグイン）拡張
### 1.1 目的
Provider をモデル名ではなく Capability で扱い、差し替え可能にする。

### 1.2 契約上の要点（例）
- Provider は Capability を宣言できること（何ができ、何ができないか）。
- Provider 呼び出しは Kernel 側のルーティング方針に従い、PDP の統治対象となる。

### 1.3 実装側の責務（別リポ）
- Provider 実装（OpenAI/Groq/Local等）
- Capability 宣言の具体値（機能・制約・レイテンシクラス等）

---

## 2. ProviderRouter（ルーティング）拡張
### 2.1 目的
Capability と動的状態（健康状態/予算/制約等）に基づき候補を選ぶ。

### 2.2 契約上の要点
- ルーティングは実装依存だが、**判断の根拠（入力）**となる契約型を固定する。
- PDP の判断により、候補が拒否されうる。

---

## 3. Policy / PDP（統治）拡張
### 3.1 目的
LLM を提案者に留め、境界操作（外部送信・ツール実行・永続化等）を統治する。

### 3.2 契約上の要点
- PDP は最終決定者であり、Allow/Deny 等の決定結果を返す。
- 判断理由・適用ポリシーを監査に残せる形を想定する。

### 3.3 実装側の責務（別リポ）
- 具体ポリシー（コンプライアンス/コスト/リージョン/データ分類など）
- ルール評価エンジンや外部ポリシー連携

---

## 4. Guard（決定論的ガード）拡張
### 4.1 目的
非決定性（LLM出力）に依存せず、決定論的に安全性を担保する。

### 4.2 契約上の要点
- Guard は判定（許可/拒否/制約付き許可など）を返す。
- Guard の判定は PDP の入力になりうる。

---

## 5. Pipeline（DAG/Step）拡張
### 5.1 目的
用途別（Chat/RAG/最適化等）と横断関心（安全/監査/計測等）を分離しながら合成可能にする。

### 5.2 契約上の要点
- Pipeline は DAG として表現され、TaskManager が決定論的に制御する。
- 実行ログと状態保存が replay の根拠となる。

---

## 6. VFS（外部データ境界）拡張
### 6.1 目的
外部データソース（Git等）を Provider と混同せず、**データ境界**として分離する。

### 6.2 契約上の要点
- 読み書き・列挙などの抽象を VFS として固定する（実装は別リポ）。

---

## 7. PromptRules / RulesEngine 拡張（運用アーティファクト）
### 7.1 目的
PromptRules を署名付き Markdown の運用アーティファクトとして扱い、改ざん検知とガバナンスを担保する。

### 7.2 契約上の要点
- 署名・スコープ・バージョンなどのメタ情報を扱える設計とする。

---

## 8. 監査イベント（Audit/Event）拡張
### 8.1 目的
Deterministic Replay と監査を支える一次情報を出力する。

### 8.2 契約上の要点
- イベント型は後方互換性を意識して追加中心で運用する（変更は versioning に従う）。

---

## 関連ドキュメント
- `./DESIGN_INTENT-jp.md`
- `ARCHITECTURE_DECISIONS-jp.md`  
- `CONTRACT_VERSIONING-jp.md`  
- `../architecture/index-jp.md`
- `../guidelines/DOCUMENTATION_GUIDELINES-jp.md`