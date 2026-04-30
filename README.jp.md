# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

AI アプリケーションのための **OS（Operating System）** を目指すフレームワーク。

AIKernel は、LLM を単なる API 呼び出しではなく  
**「能力（Capability）」を持つプロセスとして扱う AI OS** である。

設計思想は `docs/design/DESIGN_INTENT.md` を参照。

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

AIKernel は OS と同じ 6 層構造で設計されている：

```
Core (syscall)
Kernel (AI OS の中核)
Providers (脳のドライバ)
VfsProviders (外部データソース)
Server (外部 API)
Hosting (アプリ統合)
Enterprise (運用拡張)
```

---

# 3. ディレクトリ構成（最新版）

```
AIKernel/
├─ docs/
│  ├─ architecture/
│  │  ├─ CATEGORY_SEPARATION_PRINCIPLES.md
│  │  ├─ CONTEXT_ISOLATION_SPEC.md
│  │  ├─ ATTENTION_POLLUTION_THEORY.md
│  │  ├─ PREPROCESSING_VS_PROMPTING.md
│  │  ├─ LLM_SURFACE_MODE_FAILURE.md
│  │  └─ AIKERNEL_VS_LANGCHAIN.md
│  ├─ design/
│  │  └─ DESIGN_INTENT.md
│  └─ rules/
│     └─ PromptRules_TEMPLATES/
│
├─ src/
│  ├─ Core/                      # OS の syscall 層
│  │  ├─ Abstractions/
│  │  ├─ Contracts/
│  │  ├─ KernelContext/
│  │  ├─ Events/
│  │  └─ VFS/
│  │
│  ├─ Kernel/                    # Runtime → Kernel に改名
│  │  ├─ Scheduler/
│  │  ├─ Router/
│  │  ├─ Controller/
│  │  ├─ RagEngine/
│  │  ├─ Pipeline/
│  │  └─ Rules/
│  │
│  ├─ Providers/                 # 脳のドライバ
│  │  ├─ SDK/
│  │  ├─ OpenAI/
│  │  ├─ Groq/
│  │  ├─ LlamaCpp/
│  │  └─ LocalRAG/
│  │
│  ├─ VfsProviders/              # Git はここへ移動
│  │  └─ Git/
│  │
│  ├─ Server/
│  │  └─ OpenAICompat/
│  │
│  └─ Hosting/
│     └─ Default/
│
├─ samples/
│  └─ quickstart/
│
└─ enterprise/
   └─ AIKernel.Enterprise/
```

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
> — CATEGORY_SEPARATION_PRINCIPLES.md より

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

---

# 5. Kernel（旧 Runtime）

Kernel は AIKernel の中核であり、OS のカーネルに相当する。

- TaskManager（決定論的スケジューラ）
- LlmController（非決定論的推論）
- ProviderRouter（能力ベースの脳選択）
- RagEngine（素材化）
- PipelineExecutor（DAG 実行）
- RulesEngine（PromptRules）

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

