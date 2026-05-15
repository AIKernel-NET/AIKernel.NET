---
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# AIKernel Operations — Index
このディレクトリは、AIKernel.NET の **運用（Operations）** に関する文書をまとめるための入口となる。  
現時点では多くの文書が **計画中（Planned）** であり、  
AIKernel のコア仕様（Contracts / Kernel / Providers）が安定した段階で順次作成される予定である。

Operations は、アーキテクチャ思想（architecture）や実装方針（design）、  
ガイドライン（guideline）とは異なり、  
**実際の運用・監視・リリース・障害対応・SLO 管理などの「実務手順（Runbook）」** を扱う領域である。

---

## Operations 文書一覧（Planned）

### 1. [Migration Guide](MIGRATION_GUIDE-jp.md)（移行ガイド）  
**ステータス:** Planned  
**内容（予定）:**  
- 契約（Interface / DTO / Enum）の破壊的変更を跨ぐ際の移行手順  
- 変更点の分類（Breaking / Non-breaking）  
- 自動変換ツール・互換性チェック  
- バージョンアップ時のチェックリスト  

Contracts が安定した段階で正式に作成される。

---

### 2. Release Operations（リリース運用）  
**ステータス:** Planned  
**内容（予定）:**  
- リリースフロー（tag → build → publish → announce）  
- 署名付きアーティファクトの扱い  
- バージョン管理（SemVer / Contract Versioning との整合）  
- リリース後の検証手順  

---

### 3. Monitoring & Observability（監視・可観測性）  
**ステータス:** Planned  
**内容（予定）:**  
- メトリクス（latency / cost / retry / cache / provider health）  
- 分散トレーシング（Pipeline / TaskManager / ProviderRouter）  
- アラート設計（SLO / SLA / SLI）  
- ログ構造（AuditEvent / Replay Logs）  

---

### 4. Incident Response（障害対応）  
**ステータス:** Planned  
**内容（予定）:**  
- 障害検知 → 初動 → 切り分け → 復旧 → 事後分析  
- Provider 障害時のフェイルオーバー  
- RAG データ破損時の復旧手順  
- 再現性（Deterministic Replay）を用いた障害解析  

---

### 5. Security Operations（セキュリティ運用）  
**ステータス:** Planned  
**内容（予定）:**  
- 署名検証（PromptRules / Contracts / Policies）  
- Provider 認証情報の管理（Secret Manager）  
- データ分類（Data Classification）に基づくアクセス制御  
- 監査ログの保持・改ざん検知  

---

## Operations の役割

AIKernel の Operations は、次の 3 つの目的を持つ：

### 1. 安定運用（Stability）  
- Provider 障害時の自動復旧  
- Pipeline の再実行性  
- バージョンアップ時の安全性  

### 2. 可観測性（Observability）  
- メトリクス  
- トレーシング  
- ログ  
- アラート  

### 3. ガバナンス（Governance）  
- リリース管理  
- 契約変更の追跡  
- 署名・検証  
- 監査対応  

AIKernel を **長期的に安全かつ再現性をもって運用するための基盤** を提供する。

---

## 現状ステータス

Operations 文書は、AIKernel の  
**Contracts / Kernel / Providers が安定した後に正式作成される計画** である。

現時点では、  
- Migration Guide の骨子のみ存在  
- その他は Planned  
という状態であり、今後のバージョンで順次追加される。

---

## 関連ディレクトリ

- `docs/architecture/` — アーキテクチャ思想（Why）  
- `docs/design/` — 実装方針（How）  
- `docs/guideline/` — 運用ルール（Rules）  
- `docs/operations/` — 運用手順（Runbook） ← *本ディレクトリ*
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
