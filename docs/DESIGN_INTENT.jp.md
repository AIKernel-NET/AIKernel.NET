---
id: design-intent
version: 1.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
scope:
  - repo: AIKernel.NET
createdAt: 2026-04-28T00:00:00Z
signature: ""
---

# Design Intent

## 要約

- Markdown を一次表現とし、人間可読性を最優先する。設計書、ルール、プロンプトはすべて Markdown で管理し、差分レビューを容易にする。  
- Core は抽象インタフェースと Contracts（JSON Schema）を保持し、実装依存を排除する。  
- Provider は Capability ベースで扱い、モデル名やベンダー固有の挙動に依存しない。  
- LLM は提案者、PDP が最終決定者という責務分離を徹底する。  
- Pipeline は DAG として構成し、TaskManager がリソース制御とスケジューリングを担う。  
- PromptRules は署名付き Markdown とし、改変履歴とガバナンスを強化する。  
- 監査と再現性（Deterministic Replay）を最優先し、実行ログ・プロンプト・ランタイム状態を完全に保存する。

---

## 詳細

## 設計哲学

### 人間中心のドキュメント
Markdown を設計の一次表現とし、開発者・レビュアー・監査担当者が即座に理解できることを最優先する。

### 契約駆動
Core と Provider 間のすべてのインタフェースは JSON Schema で定義する。  
Schema はバージョン管理され、後方互換性と破壊的変更の扱いを明確にする。

### 能力抽象
Provider は「何ができるか（Capabilities）」を宣言し、呼び出し側は能力に基づいて動的に適合する。  
モデル名や API の細部は Capability の実装に隠蔽され、プロバイダ差し替えやマルチプロバイダ運用が容易になる。

### 責務分離
LLM は提案（suggestion）を生成する役割に限定し、最終的な意思決定は PDP（Policy Decision Point）が行う。  
PDP はルール、コンプライアンス、コスト、リスク評価を統合して判断する。

---

## アーキテクチャ概要

### Core
- 抽象インタフェース（入出力型、エラー型、メタデータ型など）  
- Contracts（JSON Schema）  
- CI による Schema 検証  
- 破壊的変更には明示的なマイグレーション手順を伴う

### Provider 層
- Capability 宣言（例：streaming、embeddings、function-calling、multimodal）  
- Core 抽象を Provider API にマッピングする薄いアダプタ層  
- 副作用を最小化し、テスト容易性を確保

### Pipeline 層
- DAG 表現（Task はノード、依存はエッジ）  
- Task は入力ハッシュと出力ハッシュを持ち、再実行可能性を担保  
- TaskManager がリソース割当、優先度、並列度、レート制限、フェイルオーバーを管理

### PromptRules
- 署名付き Markdown  
- 改ざん検出と履歴管理  
- PDP と連携し、プロンプト生成前後でルールチェックを実施

---

## ガバナンスとセキュリティ

### ポリシーの中心化
PDP がポリシーを一元管理し、実行時に適用する。  
ポリシーはバージョン管理され、差分レビューを必須とする。

### 署名と検証
PromptRules、重要な設定ファイル、契約ファイルは署名を必須とし、実行時に検証する。

### 最小権限
Provider の認証情報や鍵は Secret Manager で管理し、アクセス権限は最小限に限定する。

### データ分類
入力・出力データは分類ラベルを持ち、ラベルに応じてマスキング、保存可否、外部送信可否を自動適用する。

---

## 監査と再現性

### Deterministic Replay
以下を保存し、同一条件で再実行できることを保証する：

- PromptRules のバージョン  
- Provider の Capability 宣言  
- 入力データ  
- ランタイム設定  
- ランダムシード  
- 外部 API レスポンスのスナップショット  

### 監査ログ
変更履歴、PDP の決定理由、署名検証結果、エラーとリトライ履歴を時系列で保存する。  
ログは検索可能で、監査ビューを提供する。

### 差分再現
PromptRules の微修正などの差分を比較し、影響範囲を特定できるツールを提供する。

---

## 運用と可観測性

- メトリクス（レイテンシ、成功率、コスト、キャッシュヒット率、再試行率）  
- 分散トレーシング（Pipeline 実行ごとにトレース ID を付与）  
- SLA 違反、異常コスト、ポリシー違反試行のアラート  
- Contracts、PromptRules、PDP ポリシー、監査ログの定期バックアップと復旧手順

---

## 開発者向けガイドライン

- すべての公開 API、Contracts、PromptRules は Markdown で記述し、PR 時に自動検証する  
- 単体テスト、契約テスト、統合テスト、再現性テストを必須とする  
- マイナーアップデートは後方互換を維持し、破壊的変更はメジャーバージョンで行う  
- 新しい Capability を追加する際は Capability Schema を定義し、既存 Provider の適合性を示す  
- PromptRules や PDP ポリシーの変更は、セキュリティ担当とドメイン担当の承認を必要とする

---

## エラー処理とフォールバック

- エラー型は Contracts で定義し、呼び出し側は種別に応じた回復戦略を実装する  
- 重要な決定経路では複数 Provider やローカルルールによるフォールバックを用意する  
- Provider 呼び出しは指数バックオフと最大試行回数を持ち、PDP がリトライポリシーを制御する

---

## パフォーマンスとコスト管理

- Provider ごとのコストをメトリクスに含め、Pipeline 実行ごとのコスト見積もりを提供  
- 再現性を損なわない範囲で結果キャッシュを導入  
- TaskManager は水平スケーリングを前提に設計し、リソース制約に応じたスロット割当てを行う

---

## 互換性と移行

- Contracts、PromptRules、PDP ポリシーは独立してバージョン管理する  
- 実行時には各要素のバージョンを明示する  
- 破壊的変更時は自動変換ツールと移行手順書を提供し、移行テストを必須とする

---

## 変更履歴

- v1.0.0 初版


## 用語集（Glossary）

### Capability（ケイパビリティ）
Provider が宣言する「できること」の集合。  
モデル名や API の細部ではなく、機能・制約・入出力特性を抽象化したもの。  
Runtime は Capability を基準に Provider を選択する。

### PDP（Policy Decision Point）
ポリシー決定点。  
LLM の提案を受け取り、最終的な許可・拒否を判断するコンポーネント。  
コンプライアンス、コスト、リスク、ルールを統合して意思決定する。

### LLMController
LLM を「提案者（suggestor）」として扱うための制御層。  
LLM の出力をそのまま採用せず、PDP による最終判断を前提とする。

### TaskManager
Pipeline 内の Task をスケジューリングする決定論的コンポーネント。  
リソース割当、優先度、並列度、レート制限、フェイルオーバーを管理する。

### DAG（Directed Acyclic Graph）
Pipeline の構造表現。  
Task をノード、依存関係をエッジとして表し、循環を持たない。  
再実行性・追跡性・最適化に適している。

### PromptRules
署名付き Markdown で記述されるプロンプト生成ルール。  
バージョン管理され、改ざん検出・監査・再現性の基盤となる。

### Contracts
Core が保持する JSON Schema ベースの契約定義。  
入出力型、エラー型、メタデータ型などを含み、Provider や Runtime の互換性を保証する。

### Deterministic Replay
実行に必要なすべての要素（ルール、設定、入力、外部レスポンスなど）を保存し、  
同一条件で完全に再実行できることを保証する仕組み。

### Provider
Capability を宣言し、実際のモデルや API を提供する層。  
OpenAI、LocalRAG、LlamaCpp など。  
Core の抽象に適合する薄いアダプタを持つ。

### FeatureSpec
Provider が提供する機能仕様。  
function-calling、streaming、multimodal などのサポート状況を記述する。

### TokenizerProfile
Provider が使用するトークナイザーの特性を表すプロファイル。  
Token 計測の不一致を吸収するための抽象。

### DynamicMetricStore
Provider の動的メトリクス（レイテンシ、エラー率、ヘルス情報など）を保持するストア。  
Runtime の Provider 選択時にスコアリングへ合成される。

### Secret Manager
Provider の認証情報や鍵を安全に管理する仕組み。  
最小権限原則に基づきアクセスを制御する。

### AuditEvent
実行時の一次情報（プロンプト、PDP 決定、Provider 応答、エラーなど）を記録するイベント。  
監査・再現性・トレーシングの基盤となる。

### Policy
PDP が参照するルールセット。  
コンプライアンス、コスト、リスク、権限制御などを統合した意思決定基準。

### Replay Test
Deterministic Replay を用いて、過去の実行と同一結果が得られるかを検証するテスト。

### Contract Test
Contracts（JSON Schema）に基づき、Provider や Runtime が互換性を維持しているかを検証するテスト。

