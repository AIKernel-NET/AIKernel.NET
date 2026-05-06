# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

AIKernel.NET は、AI アプリケーションのための **オペレーティングシステム（OS）** を目指すフレームワークです。

AIKernel は、LLM を単なる API 呼び出しではなく  
**「能力（Capability）」を持つプロセスとして扱う AI OS** である。

---

## NuGet パッケージ一覧

AIKernel.NET は複数の独立した抽象レイヤーで構成されており、  
各レイヤーは個別の NuGet パッケージとして公開されています。

| レイヤー | パッケージ | バージョン | リンク |
|---------|------------|------------|--------|
| コア型定義 | AIKernel.Enums | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Enums.svg) | https://www.nuget.org/packages/AIKernel.Enums/ |
| データモデル | AIKernel.Dtos | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Dtos.svg) | https://www.nuget.org/packages/AIKernel.Dtos/ |
| 契約（Contracts） | AIKernel.Contracts | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Contracts.svg) | https://www.nuget.org/packages/AIKernel.Contracts/ |
| 抽象レイヤー | AIKernel.Abstractions | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Abstractions.svg) | https://www.nuget.org/packages/AIKernel.Abstractions/ |
| 仮想ファイルシステム | AIKernel.VFS | ![NuGet](https://img.shields.io/nuget/v/AIKernel.VFS.svg) | https://www.nuget.org/packages/AIKernel.VFS/ |
| コンテキストモデル（統合） | AIKernel.Dtos (AIKernel.Dtos.KernelContext) | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Dtos.svg) | https://www.nuget.org/packages/AIKernel.Dtos/ |
| イベントモデル（統合） | AIKernel.Dtos (AIKernel.Dtos.Events) | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Dtos.svg) | https://www.nuget.org/packages/AIKernel.Dtos/ |

---

設計思想は `docs/design/DESIGN_INTENT.md` を参照。  
実装契約（Spec Sheet）は `docs/specs/index-jp.md` を参照。

目標イメージ（起動ログ例）:
```txt
[KERNEL] Initializing AIKernel.NET v0.1.0...
[KERNEL] Loading ISignatureTrustStore... [OK]
[KERNEL] Mounting VFS (Git: ./context)... [OK]
[KERNEL] Verifying System Prompt Signature... [VALID]
[KERNEL] Routing to Provider: [[provider.reasoning.high]]... [OK]

> Hello Intelligence.
> The Semantic Context is stable. Governance is active.
```

---

# 1. 目的

AIKernel.NET の目的は、AI アプリケーションを以下の性質で実行できる OS を提供すること：

- **モデル名に依存しない能力ベース実行**
- **推論の純度を最大化するカテゴリ分離**
- **決定論的スケジューラ + 非決定論的 LLM のハイブリッド制御**
- **再現性（Deterministic Replay）**
- **ガバナンス（署名付き PromptRules / 監査ログ）**
- **OS 的な拡張性（Provider = ドライバ / Kernel = 実行エンジン）**

---

# 2. アーキテクチャ概要

AIKernel.NETは 抽象化 した存在として定義し、Interface と 最小限の DTO / Enum を提供する。
実装と完全分離することで、Core の純度を守り、実装の自由度を最大化する。


AIKernelのアーキテクチャ階層 は OS と同じ 6 層構造で設計されている：
```
Core (syscall)
Kernel (AI OS の中核)
Providers (脳のドライバ)
VfsProviders (外部データソース)
Server (外部 API)
Hosting (アプリ統合)
Enterprise (運用拡張)
```

ドキュメント体系は以下の 4 区分で運用する：
- `docs/architecture`: Why（思想・原理・統治）
- `docs/design`: How（設計判断・実装方針）
- `docs/specs`: What（実行契約・検証可能要件）
- `docs/guidelines`: ルール（運用・寄稿規約）

---

# 3. ドキュメント構成

ドキュメントとソースの同期を維持するため、この README では
ファイル単位の詳細列挙を行いません。

ドキュメントは次の 4 つの基盤カテゴリで構成されます。

- `docs/architecture` — Why（思想・不変条件・統治）
- `docs/design` — How（設計判断・実装方針）
- `docs/specs` — What（規範契約・受け入れ基準）
- `docs/guidelines` — Rules（リポジトリ運用・寄稿規約）

最新の構成と相互参照は以下を参照してください。

- `docs/index.md`
- `docs/index-jp.md`

### リポジトリとソリューションの関係マッピング

#### リポジトリ構成と役割

AIKernel は以下のリポジトリで構成され、本リポジトリでは、契約レイヤ（全ソリューション共通）を管理します。
契約例やを抽象的な DTO / Enum を提供し、Core や SDK などの実装は別リポジトリで行うことで、Core の純度を保ち、実装の自由度を最大化する設計とします。

| **リポジトリ** | **収容ソリューション / プロジェクト** | **主なディレクトリ / プロジェクト例** | **生成アーティファクト** | **主な依存先** |
| --- | --- | --- | --- | --- |
| **AIKernel.NET** | 契約レイヤ（全ソリューション共通） | ``Contracts``（Interfaces; DTO; Enums） | NuGet 契約パッケージ | なし（最上位契約） |
| **AIKernel.Core** | Core Platform（基盤ロジック） | ``Core/``, ``Kernel/``, ``Providers/``, ``VfsProviders/``, ``Server/``, ``Hosting/`` | NuGet ライブラリ | **AIKernel.NET** |
| **AIKernel.SDK** | 外部クライアントライブラリ | ``AIKernel.SDK`` | NuGet クライアントパッケージ | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Web** | 管理コンソール（Admin UI） | ``admin-web``（SPA/Blazor） | SPA ビルドアーティファクト | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Infra** | デプロイ定義・環境設定 | ``terraform/``, ``k8s/``, ``helm/`` | マニフェスト | 全リポジトリ参照 |
| **AIKernel.Tools** | 開発支援・CIテンプレ | ``cli/``, ``generators/``, ``ci-templates/`` | CLI バイナリ; CI テンプレ | 全リポジトリ参照 |
| **AIKernel.Docs** | ドキュメント集約 | ``architecture/``, ``runbooks/`` | ドキュメントサイト | 全リポジトリ参照 |
| **AIKernel.Enterprise** | Enterprise 向けプロダクト群（サービス・ワーカー） | ``solutions/``, ``services/<name>/``, ``workers/<name>/``, ``charts/`` | プライベートコンテナイメージ; Helm チャート | **AIKernel.NET**, **AIKernel.Core**, **AIKernel.Infra** |

---

# 4. 設計原則

## 4.1 情報カテゴリ分離（最重要）
AIKernel の中心思想。

- 推論（Orchestration）
- 表現（Expression）
- 素材（Material）
- 履歴（History）
- 文体（Style）

これらを **絶対に混在させない**。

> 「LLM に渡す情報は単一コンテキストに混在させてはならない」  
> — CATEGORY_SEPARATION_PRINCIPLES-jp.md より

---

## 4.2 前処理中心（Preprocessing First）
プロンプトは「最後の整形」でしかない。

> 推論精度を決めるのは前処理の構造化である  
> — PREPROCESSING_VS_PROMPTING.md より

---

## 4.3 Attention 汚染防止
例・RAG・履歴を混ぜると推論が壊れる。

> attention が表面構造に吸われると推論は停止する  
> — ATTENTION_POLLUTION_THEORY.md より

---

## 4.4 LLM は提案者、PDP が決定者
LLM は “suggestor”。  
最終判断は Policy Decision Point（PDP）が行う。

## 4.5 署名統治と Fail-Closed（Signed Prompt Governance）
プロンプトは「コード」と同等の権限を持つ。  
AIKernel は承認・署名済みのプロンプトのみを実行し、改ざんや未承認署名者を検知した場合は即時停止する。

- 検証シーケンス: `IPromptRepository` -> `IPromptVerifier` -> `ISignatureTrustStore` -> `IPromptValidator` -> `ExecutionPipeline`
- 詳細仕様: `docs/specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md`

## 4.6 関係指向データ構造（Relation-Oriented Markdown: ROM）
AIKernel は、知識を線形テキストではなく「関係性」の集合として扱う。

- `YAML`: エンティティのメタデータとアイデンティティを定義する。
- `Headings`: セマンティックカテゴリとコンテキストスコープを定義する。
- `Bullets`: 事実（Facts）および属性（Properties）を宣言的に記述する。
- `Links`（`[[id]]`）: 知識グラフにおけるエッジ（関係性）を表現する。
- `Semantic Hash`: 記述順序に依存しない正規化ハッシュにより、署名検証の堅牢性を高める。

ROM により、人間が書いたメモはそのまま LLM が推論可能な知識基盤へ変換可能になる。

## 4.7 思考の Git 管理（ConversationStore）
AI との対話は線形（Linear）ではなく、木構造（Tree）の Git コミットとして管理される。  
これにより、推論の分岐探索（Fork）と特定時点への復元（Replay）をネイティブにサポートする。

---

# 5. Kernel（旧 Runtime）

Kernel は AIKernel の中核であり、OS のカーネルに相当する。

- TaskManager（決定論的スケジューラ）
- LlmController（非決定論的推論）
- ProviderRouter（能力ベースの脳選択）
- RagEngine（素材化）
- PipelineExecutor（DAG 実行）
- RulesEngine（PromptRules）
- IPromptVerifier / IPromptValidator（実行時署名検証による Fail-Closed 防御）
- ISignatureTrustStore（信頼済み署名者および失効状態を管理する信頼アンカー）

---

# 6. Provider（脳のドライバ）

Provider はモデル名ではなく **Capability** を宣言する。

例：

- chat  
- embedding  
- multimodal  
- reasoning  
- vector-search  
- streaming  

Provider SDK により、追加が容易。

---

# 7. VFS Provider（Git など）

Git は Provider ではなく **外部データソース**。  
VFS Provider として分類。

---

# 8. Server（OpenAI 互換 API）

AIKernel を OpenAI API として利用可能にするアダプタ。

---

# 9. Hosting

- DI
- 既定パイプライン
- 設定
- アプリ統合

---

# 10. Enterprise

- SIEM 連携
- マルチテナント
- SLO ダッシュボード

---

# 11. ライセンス / 貢献

- PR ベース
- Contracts と PromptRules の互換性を明示
- 破壊的変更には移行ガイドを添付

---

# 12. 最後に

AIKernel.NET は「AI アプリケーションの OS」として  
**構造的に正しく動く AI 実行基盤**を提供する。

カテゴリ分離・前処理中心・ガバナンス・再現性を軸に、  
AI アプリケーションの標準 OS を目指す。

実装時は、まず `docs/specs/index-jp.md` の読書順に沿って契約を固定し、次に `docs/design` で実装戦略を適用する。
