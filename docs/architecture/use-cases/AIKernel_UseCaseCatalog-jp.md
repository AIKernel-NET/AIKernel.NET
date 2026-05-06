---
id: aikernel_use-case_catalog
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: AIKernel.NET — ユースケース一覧
created: 2026-05-02
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - use-case
  - japanese
---

# AIKernel.NET — ユースケース一覧

## 1. 概要

AIKernel.NET は、**AI が AI を選び、AI を監査し、AI を実行する**ためのプロンプト参照型 AI オーケストレーション OS である。  
本ドキュメントは、AIKernel の抽象層が満たすべきユースケースを体系化し、インタフェース設計とアーキテクチャ整合性の検証基準を提供する。

---

## 2. コアユースケース

### UC-01: タスク入力の受理とコンテキスト分配

**目的**  
ユーザー入力（自然言語または構造化データ）を受理し、ROM 正準化と意味ハッシュ検証を経て、`IContextCollection` の適切な層へ分配する。

**必要な抽象**  
`IROMCanonicalizer`, `ISemanticHasher`, `IContextCollection`

---

### UC-02: Structure フェーズ実行

**目的**  
軽量推論モデルを使ってタスク分解、制約抽出、実行計画の生成を行う。

**必要な抽象**  
`IThoughtProcess`, `IStructurePlanner`, `IContextCollection`（Orchestration 層への書き込み）

---

### UC-03: モデルベクトルルーティング

**目的**  
タスク要求ベクトルと各モデルの `ModelCapacityVector` を照合し、`IModelVectorRouter` を通じて最適モデルを選定する。

**必要な抽象**  
`IModelVectorRouter`, `ModelCapacityVector`, `ICapabilityRegistry`

---

### UC-04: 生成と出力整形

**目的**  
高能力モデルで出力を生成し、`IOutputPolisher` を通じて `ExpressionBuffer` へ整形する。

**必要な抽象**  
`IOutputPolisher`, `IKernelContext`, `ExpressionBuffer`

---

### UC-05: 統一 Provider 実行

**目的**  
クラウド API、ローカル NPU など異種バックエンドを統一 `IProvider` 抽象で実行する。

**必要な抽象**  
`IProvider`, `IProviderCapabilities`, `ExecutionResult`

---

## 3. 統治とコンテキスト隔離

### UC-06: 3層バッファによる Attention 制御

**目的**  
`IAttentionGuard` と `IKernelContext` を用いて指示・素材・出力を物理的に隔離し、attention 汚染を防止する。

**必要な抽象**  
`IContextCollection`, `IKernelContext`, `IAttentionGuard`

---

### UC-07: 素材検疫

**目的**  
外部データ（例: RAG 結果）を `IMaterialQuarantine` で検証・正規化し、`IStructuredMaterial` 化して取り込む。

**必要な抽象**  
`IMaterialQuarantine`, `IStructuredMaterial`

---

### UC-08: コンテキストスナップショットと永続化

**目的**  
実行状態を `IContextSnapshot` として抽出し、`IVfsProvider` を通じて保存・復元する。

**必要な抽象**  
`IContextCollection`, `IContextSnapshot`, `IVfsProvider`

---

## 4. パイプラインとハードウェア最適化

### UC-09: 決定論的パイプライン実行

**目的**  
`IPipelineOrchestrator` が監査可能な `IPipelineStep` を連鎖実行し、知能処理を決定論的に実行する。

**必要な抽象**  
`IPipelineOrchestrator`, `IPipelineStep`

---

### UC-10: Compute Shape Advisory

**目的**  
`IComputeShapeAdvisor` により NPU/GPU に適したテンソル形状・計算パラメータを選定し、実行を最適化する。

**必要な抽象**  
`IComputeShapeAdvisor`, `IProviderCapabilities`

---

## 5. プロンプトセキュリティと Fail-Closed 実行

### UC-11: プロンプト静的検証

**目的**  
CI で Markdown ベースのプロンプトを検証し、AIKernel の設計原則と構造ルールへの準拠を確認する。

**必要な抽象**  
`IPromptValidator`, `IPolicy`, `IRuleEngine`

---

### UC-12: プロンプト署名

**目的**  
検証済みプロンプトの正準化スナップショットに意味ハッシュを計算し、`IPromptSignatureProvider` で署名して信頼済み仕様として確定する。

**必要な抽象**  
`IROMCanonicalizer`, `ISemanticHasher`, `IPromptSignatureProvider`

---

### UC-13: 実行時署名検証

**目的**  
`IPromptVerifier` でロード時に署名検証し、改ざん時は fail-closed 原則で実行拒否する。

**必要な抽象**  
`IPromptVerifier`, `IPromptSignatureProvider`, `IPromptRepository`

---

## 6. ホスティングと依存性注入

### UC-14: Kernel Module による動的構成

**目的**  
`IKernelModule` を通じて Provider/Router を DI コンテナへ登録し、環境別ホスティングを実現する。

**必要な抽象**  
`IKernelHost`, `IKernelModule`, `IServiceRegistrar`, `IProviderRegistrar`

---

## 7. 会話ブランチ・チェックポイント・差分・永続化

### UC-15: Chat Branching

**目的**  
会話履歴を Git のように分岐し、任意の過去状態から新しい対話を開始する。

**必要な抽象**  
`IConversationBranch`, `IConversationSnapshot`, `IConversationStore`, `IConversationDiff`

---

### UC-16: Chat Checkpointing

**目的**  
任意時点をチェックポイント保存し、後から復元・比較・分岐できるようにする。

**必要な抽象**  
`IConversationCheckpoint`, `IConversationTimeline`, `IConversationStore`

---

### UC-17: Chat Diffing

**目的**  
2つの会話状態を比較し、推論・指示・素材の差分を可視化する。

**必要な抽象**  
`IConversationDiff`, `IDiffFormatter`

---

### UC-18: Chat Persistence

**目的**  
会話履歴を Git ライクに永続化し、ローカル・クラウド・VFS に保存する。

**必要な抽象**  
`IConversationStore`, `IVfsProvider`

---

## 8. マルチモデル統治とクレジット制御

### UC-19: マルチモデル並列実行

**目的**  
同一タスクに対して複数 `IProvider` を並列実行し、レイテンシと品質を同時最適化する。

**必要なインタフェース**  
`IProvider`, `IProviderCapabilities`, `IConversationSnapshot`, `IConversationTimeline`

**コンテキスト**  
UC-03（Model Vector Routing）, UC-05（Provider Invocation）, UC-09（Deterministic Pipeline）

**層**  
Orchestration, Provider

---

### UC-20: 決定論的リプレイと監査証跡

**目的**  
過去実行の Replay Dump を用いて実行条件を固定し、再実行の完全再現性と監査証跡を保証する。

**必要なインタフェース**  
`IKernelReplayer`, `IAuditLogger`, `IAuditEvent`, `IContextSnapshot`

**コンテキスト**  
UC-09（Deterministic Pipeline）, UC-13（Runtime Signature Verification）, UC-24（Audit Event Emission）

**層**  
Execution, Governance

---

### UC-21: マテリアル検疫とポリシー実行

**目的**  
外部素材を検疫し、PDP/Guard によるポリシー評価を通過した入力のみを実行可能とする。

**必要なインタフェース**  
`IMaterialScanner`, `IMaterialQuarantine`, `IGuard`, `IPdp`, `IPolicy`, `IPrincipal`

**コンテキスト**  
UC-07（Material Quarantine）, UC-11（Static Prompt Validation）, UC-13（Runtime Signature Verification）

**層**  
Governance, Material

---

### UC-22: 動的キャパシティ制御とモデルルーティング

**目的**  
動的な能力・負荷・予算制約を評価し、ルーティング先を決定して実行品質と経済性を両立する。

**必要なインタフェース**  
`IModelVectorRouter`, `ICapabilityRegistry`, `IDynamicCapacityProvider`, `IDynamicCapacityVector`, `IVectorMatcher`, `IComputeShapeAdvisor`

**コンテキスト**  
UC-03（Model Vector Routing）, UC-10（Compute Shape Advisory）, UC-23（Provider Credit Management）

**層**  
Routing, Execution

---

### UC-23: Provider クレジット管理

**目的**  
Provider ごとの残高・コスト・利用量を監視し、推論経済性を維持しながら実行先制御を行う。

**必要なインタフェース**  
`IProviderCreditInfo`, `IProviderCostProfile`, `IProviderUsageStats`, `IProviderBillingInfo`, `IProviderResourceProfile`

**コンテキスト**  
UC-03（Model Vector Routing）, UC-05（Provider Invocation）, UC-18（Chat Persistence）

**層**  
Orchestration, Provider

---

## 9. ランタイム運用・ツール・可観測性

### UC-24: 監査イベント出力

**目的**  
実行、ポリシー、Provider 操作のライフサイクルを監査可能イベントとして出力する。

**必要なインタフェース**  
`IAuditEvent`, `IAuditEventContract`

**コンテキスト**  
UC-09（Deterministic Pipeline Execution）, UC-13（Runtime Signature Verification）

**層**  
Orchestration, Expression

---

### UC-25: Event Bus 配信

**目的**  
Kernel 内部イベントを購読者へ配信し、疎結合なオーケストレーションと監視を実現する。

**必要なインタフェース**  
`IEventBus`

**コンテキスト**  
UC-05（Unified Provider Invocation）, UC-24（Audit Event Emission）

**層**  
Orchestration, Provider

---

### UC-26: Retrieval と Embedding 取り込み

**目的**  
検疫・構造化の前段で、Embedding/RAG Provider により素材を索引化・検索する。

**必要なインタフェース**  
`IEmbeddingProvider`, `IRagProvider`, `IMaterialQuarantine`

**コンテキスト**  
UC-07（Material Quarantine）, UC-08（Context Snapshot & Persistence）

**層**  
Material, Provider

---

### UC-27: モデル推論対話

**目的**  
メッセージ指向のモデル推論を、ストリーミング生成と回答生成パターンで実行する。

**必要なインタフェース**  
`IModelProvider`, `IModelMessage`

**コンテキスト**  
UC-03（Model Vector Routing）, UC-04（Generation & Output Polishing）

**層**  
Orchestration, Provider

---

### UC-28: スケジュールジョブ実行

**目的**  
定期・非同期ジョブを実行し、状態遷移と実行結果を管理する。

**必要なインタフェース**  
`IScheduler`, `IScheduleSpec`, `IScheduledJob`, `IExecutionResult`

**コンテキスト**  
UC-09（Deterministic Pipeline Execution）, UC-18（Chat Persistence）

**層**  
Orchestration, Provider

---

### UC-29: タスクパイプライン管理

**目的**  
DAG 形式タスクパイプラインを登録・実行・一時停止・再開・結果参照する。

**必要なインタフェース**  
`ITaskManager`, `IPipeline`, `ITask`, `ITaskContext`, `ITaskExecutionResult`, `IPipelineExecutionResult`

**コンテキスト**  
UC-02（Structure Phase Execution）, UC-09（Deterministic Pipeline Execution）

**層**  
Orchestration

---

### UC-30: トークン・ベクトル推定

**目的**  
ルーティング、予算制御、shape advisory のためにトークン量とタスクベクトルを推定する。

**必要なインタフェース**  
`ITokenizer`, `ITaskVectorEstimator`, `IModelVectorRouter`, `IComputeShapeAdvisor`

**コンテキスト**  
UC-03（Model Vector Routing）, UC-10（Compute Shape Advisory）

**層**  
Orchestration, Models

---

### UC-31: ツール権限制御とサンドボックス実行

**目的**  
ツール権限を検証し、隔離サンドボックス境界内でツール実行を行う。

**必要なインタフェース**  
`IToolPermission`, `IToolAccessValidator`, `IToolSandbox`

**コンテキスト**  
UC-11（Static Prompt Validation）, UC-13（Runtime Signature Verification）

**層**  
Orchestration, Provider

---

### UC-32: コンテキストライフサイクル観測

**目的**  
attention 信号とコンテキスト遷移を観測し、汚染防止と要約に接続する。

**必要なインタフェース**  
`IAttentionObserver`, `IContextLifecycleManager`, `IHistorySummarizer`

**コンテキスト**  
UC-06（Attention Control via Three-Layer Buffers）, UC-07（Material Quarantine）

**層**  
Orchestration, Material

---

## 10. まとめ

このカタログは、AIKernel.NET 抽象層に必要な振る舞いを定義する。

### 検証基準

- **Security Integrity**  
  UC‑11〜UC‑13 は、開発から実行時までの信頼チェーン完全性を担保する。

- **Resource Optimization**  
  UC‑10 は、NPU など次世代ハードウェアとの Interface レベル互換性を担保する。

- **Naming Consistency**  
  型名とユースケースは厳密な 1:1 対応を維持する。

---
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
