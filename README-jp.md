# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

AIKernel は、AI アプリケーションのためのオペレーティングシステムです。

AIKernel は、機能そのものを定義しません。  
機能が必然的に成立するための、決定論的な実行コンテキストを定義します。

このリポジトリは、AIKernel の正典となる契約群を管理します。

AIKernel.NET は、LLM を API ではなく、能力（Capability）を持つプロセスとして扱う Contract-First な基盤です。

---

## NuGet パッケージ一覧

AIKernel.NET は複数の独立した抽象レイヤーで構成されています。  
各レイヤーは個別の NuGet パッケージとして公開されています。

| レイヤー | パッケージ | バージョン | リンク |
| --- | --- | --- | --- |
| コア型定義 | `AIKernel.Enums` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Enums.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Enums/) |
| データモデル | `AIKernel.Dtos` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Dtos.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Dtos/) |
| 契約 | `AIKernel.Contracts` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Contracts.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Contracts/) |
| 抽象レイヤー | `AIKernel.Abstractions` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Abstractions.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Abstractions/) |
| 仮想ファイルシステム | `AIKernel.VFS` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.VFS.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.VFS/) |

---

設計思想は `docs/design/DESIGN_INTENT.md` を参照してください。  
実行契約および Spec Sheet は `docs/specs/index-jp.md` を参照してください。

---

## ホスティング例 (C#)

AIKernel.NET は ASP.NET Core の DI に統合されます。  
Core・Provider・Governance を構成することで、AI 実行基盤をホスティングできます。

AIKernel.NET は Interface による契約レイヤーで構成されているため、実装は自由に差し替えることができます。

### 実装コード例

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAIKernelCore(options =>
{
    options.EnableDeterministicReplay = true;
    options.FailClosed = true;
});

builder.Services.AddModelProvider<OpenAIModelProvider>();
builder.Services.AddVfsProvider<GitVfsProvider>();

builder.Services.AddSignatureTrustStore<FileSignatureTrustStore>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var kernel = scope.ServiceProvider.GetRequiredService<IAIKernel>();
    await kernel.InitializeAsync();
}

app.MapControllers();
app.Run();
```

### 起動ログイメージ

起動時には以下のシーケンスが実行されます。

```txt
[KERNEL] Initializing AIKernel.NET v0.1.0...
[KERNEL] Loading ISignatureTrustStore... [OK]
[KERNEL] Mounting VFS (Git: ./context)... [OK]
[KERNEL] Verifying System Prompt Signature... [VALID]
[KERNEL] Routing to Provider: [[provider.reasoning.high]]... [OK]

> Hello Intelligence.
> The Semantic Context is stable. Governance is active.
> This boot sequence is deterministic and verifiable.
```

---

## API Example / curl 実行例

AIKernel は OpenAI 互換 API として公開できます。  
以下は Context を明示した実行例です。

```bash
curl -X POST http://localhost:5000/v1/execute \
  -H "Content-Type: application/json" \
  -d '{
    "capability": "reasoning",
    "input": "Hello Intelligence",
    "context": {
      "vfs": "git://./context"
    }
  }'
```

### レスポンス例

```json
{
  "output": "[OpenAI] Hello Intelligence",
  "provider": "openai",
  "capability": "reasoning",
  "context": {
    "vfs": "git://./context"
  }
}
```

> Context は単なる入力データではありません。  
> Kernel に束縛される実行条件です。

---

## 1. 目的

AIKernel.NET の目的は、AI アプリケーションを以下の性質で実行できる OS を提供することです。

- モデル名に依存しない能力ベース実行
- 推論の純度を最大化するカテゴリ分離
- 決定論的スケジューラと非決定論的 LLM のハイブリッド制御
- Deterministic Replay による再現性
- 署名付き PromptRules と監査ログによるガバナンス
- Provider をドライバ、Kernel を実行エンジンとする OS 的な拡張性

---

## 2. アーキテクチャ概要

AIKernel.NET は抽象契約を定義し、最小限の DTO と Enum を提供します。  
契約と実装を完全に分離することで、Core の純度を守り、実装の自由度を最大化します。

AIKernel は OS 的な多層アーキテクチャとして設計されています。

```text
Core         = syscall 層
Kernel       = AI OS の中核
Providers    = 脳のドライバ
VfsProviders = 外部データソース
Server       = 外部 API アダプタ
Hosting      = アプリケーション統合
Enterprise   = 運用拡張
```

---

## 3. ドキュメント構成

ドキュメントとソースの同期を維持するため、この README ではファイル単位の詳細列挙を行いません。

ドキュメントは次の 4 つの基盤カテゴリで構成されます。

| ディレクトリ | 役割 |
| --- | --- |
| `docs/architecture` | Why: 思想・不変条件・統治 |
| `docs/design` | How: 設計判断・実装方針 |
| `docs/specs` | What: 規範契約・受け入れ基準 |
| `docs/guidelines` | Rules: リポジトリ運用・寄稿規約 |

最新の構成と相互参照は以下を参照してください。

- `docs/index.md`
- `docs/index-jp.md`

---

## リポジトリマッピング

AIKernel は複数のリポジトリで構成されます。  
本リポジトリでは、全ソリューションで共有される契約レイヤーを管理します。

| リポジトリ | 役割 | 主なディレクトリ / プロジェクト例 | 生成アーティファクト | 主な依存先 |
| --- | --- | --- | --- | --- |
| **AIKernel.NET** | 共通契約レイヤー | `Contracts`, DTOs, Enums | NuGet 契約パッケージ | なし |
| **AIKernel.Core** | Core Platform | `Core/`, `Kernel/`, `Providers/`, `VfsProviders/`, `Server/`, `Hosting/` | NuGet ライブラリ | **AIKernel.NET** |
| **AIKernel.SDK** | 外部クライアントライブラリ | `AIKernel.SDK` | NuGet クライアントパッケージ | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Web** | 管理コンソール | `admin-web` | SPA ビルドアーティファクト | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Infra** | デプロイ定義・環境設定 | `terraform/`, `k8s/`, `helm/` | マニフェスト | 全リポジトリ参照 |
| **AIKernel.Tools** | 開発支援・CI テンプレート | `cli/`, `generators/`, `ci-templates/` | CLI バイナリ、CI テンプレート | 全リポジトリ参照 |
| **AIKernel.Docs** | ドキュメント集約 | `architecture/`, `runbooks/` | ドキュメントサイト | 全リポジトリ参照 |
| **AIKernel.Enterprise** | Enterprise 向けソリューション | `solutions/`, `services/`, `workers/`, `charts/` | プライベートコンテナイメージ、Helm チャート | **AIKernel.NET**, **AIKernel.Core**, **AIKernel.Infra** |

---

## 4. 設計原則

### 4.1 情報カテゴリ分離

情報カテゴリ分離は、AIKernel における最重要の設計原則です。

以下のカテゴリを単一コンテキストに混在させてはなりません。

- 推論（Orchestration）
- 表現（Expression）
- 素材（Material）
- 履歴（History）
- 文体（Style）

> LLM に渡す情報は単一コンテキストに混在させてはならない。  
> — `CATEGORY_SEPARATION_PRINCIPLES-jp.md`

---

### 4.2 前処理中心

プロンプトは「最後の整形」でしかありません。

> 推論精度を決めるのは前処理の構造化である。  
> — `PREPROCESSING_VS_PROMPTING.md`

---

### 4.3 Attention 汚染防止

例・RAG 素材・履歴を混ぜると、推論が壊れる可能性があります。

> attention が表面構造に吸われると推論は停止する。  
> — `ATTENTION_POLLUTION_THEORY.md`

---

### 4.4 LLM は提案者、PDP が決定者

LLM は suggestor です。  
最終判断は Policy Decision Point（PDP）が行います。

---

### 4.5 署名統治と Fail-Closed

プロンプトはコード実行と同等の権限を持ちます。

AIKernel は承認・署名済みのプロンプトのみを実行し、改ざんや未承認署名者を検知した場合は即時停止します。

検証シーケンス:

```text
IPromptRepository
-> IPromptVerifier
-> ISignatureTrustStore
-> IPromptValidator
-> ExecutionPipeline
```

詳細仕様:

- `docs/specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md`

---

### 4.6 関係指向データ構造（ROM）

AIKernel は、知識を線形テキストではなく「関係性」の集合として扱います。

Relation-Oriented Markdown（ROM）は、AIKernel における知識資産の正準表現です。

- `YAML`: エンティティのメタデータとアイデンティティを定義します。
- `Headings`: セマンティックカテゴリとコンテキストスコープを定義します。
- `Bullets`: 事実（Facts）および属性（Properties）を宣言的に記述します。
- `Links`（`[[id]]`）: 知識グラフにおけるエッジ（関係性）を表現します。
- `Semantic Hash`: 記述順序に依存しない正規化ハッシュにより、署名検証の堅牢性を高めます。

ROM により、人間が書いたメモはそのまま LLM が推論可能な知識基盤へ変換できます。

---

### 4.7 思考の Git 管理（ConversationStore）

AI との対話は、線形ログではなく、木構造の Git コミットとして管理されます。

これにより、以下をネイティブにサポートします。

- 推論の分岐探索
- ブランチ探索
- 特定時点への復元

---

## 5. Kernel

Kernel は AIKernel の中核であり、OS のカーネルに相当します。

主な構成要素は以下の通りです。

- TaskManager: 決定論的スケジューラ
- LlmController: 非決定論的推論コントローラー
- ProviderRouter: 能力ベースの脳選択
- RagEngine: 素材化エンジン
- PipelineExecutor: DAG 実行
- RulesEngine: PromptRules 評価
- IPromptVerifier / IPromptValidator: Fail-Closed を実現する実行時署名検証
- ISignatureTrustStore: 信頼済み署名者および失効状態を管理する信頼アンカー

---

## 6. Provider

Provider はモデル名ではなく **Capability** を宣言します。

例:

- chat
- embedding
- multimodal
- reasoning
- vector-search
- streaming

Provider は SDK により拡張可能です。

---

## 7. VFS Provider

Git などのストレージシステムは、外部データソースとして扱います。

これらは Model Provider ではなく、VFS Provider として分類されます。

---

## 8. Server

Server レイヤーは、AIKernel を OpenAI 互換 API として公開します。

---

## 9. Hosting

Hosting レイヤーは、アプリケーション統合機能を提供します。

- Dependency Injection
- 既定パイプライン
- 設定
- アプリケーション起動統合

---

## 10. Enterprise

Enterprise 拡張には以下が含まれます。

- SIEM 連携
- マルチテナント対応
- SLO ダッシュボード

---

## 11. ライセンス / 貢献

- コントリビューションは PR ベースです。
- Contracts と PromptRules の互換性を明示してください。
- 破壊的変更には移行ガイドを添付してください。

---

## 12. 最後に

AIKernel.NET は「AI アプリケーションの OS」として、**構造的に正しく動く AI 実行基盤**を提供します。

AIKernel.NET は以下を軸に、AI アプリケーションの標準 OS を目指します。

- 情報カテゴリ分離
- 前処理中心設計
- ガバナンス
- 再現性
- 決定論的実行コンテキスト

実装時は、まず `docs/specs/index-jp.md` の読書順に沿って契約を固定し、次に `docs/design` で実装戦略を適用してください。
