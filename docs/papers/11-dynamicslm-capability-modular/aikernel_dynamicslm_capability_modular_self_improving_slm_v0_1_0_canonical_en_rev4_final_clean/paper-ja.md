---
affiliation: "AIKernel Project"
orcid: "https://orcid.org/0009-0009-7499-2595"
doi: "https://doi.org/10.5281/zenodo.20550614"
version: "v0.1.0"
status: "Technical Note / Architecture Draft"
license: "CC BY 4.0"
lang: "ja"
geometry: margin=22mm
fontsize: 10pt
mainfont: "Noto Serif CJK JP"
sansfont: "Noto Sans CJK JP"
monofont: "Noto Sans Mono CJK JP"
CJKmainfont: "Noto Sans CJK JP"
colorlinks: true
linkcolor: blue
urlcolor: blue
---

# DynamicSLM: AIKernelのためのCapabilityモジュール型・自己改善型Small Language Model

## 動的Capabilityロード、差分蒸留、異種計算実行のためのModel ABIおよびランタイムアーキテクチャ

**Author:** Takuya Sogawa  
**Affiliation:** AIKernel Project  
**ORCID:** https://orcid.org/0009-0009-7499-2595  
**DOI:** https://doi.org/10.5281/zenodo.20550614  
**Version:** v0.1.0  
**Date:** 2026-06-05  
**Status:** Technical Note / Architecture Draft  
**License:** CC BY 4.0  

> 英語版を正本とし、日本語版は参考訳として含める。

---

## Abstract

DynamicSLMは、AIKernelランタイムがモデル能力を静的で不可分な巨大モデルの一部としてではなく、ロード可能で統治可能なRuntime Moduleとして扱うためのCapabilityモジュール型SLMアーキテクチャである。本稿が扱う中心問題は、現在のLLMおよびSLMが大きな不可分成果物として配備され、一度学習されると単一の関数として振る舞うため、特定Capabilityだけを実行時に追加、削除、失効、置換、スケジューリング、または特化することが難しい点にある。

本稿では、AIKernelのためのCapabilityモジュール型・自己改善型SLMアーキテクチャである **DynamicSLM** を提案する。DynamicSLMは、各モデル成果物を Semantic Profile、Capability Graph、Execution Profile、Lineage、Payload から成る AIKernel Model ABI によって定義する。これらのABI要素により、ランタイムは、モデルが何を解決する意図を持つのか、どの資源を要求するのか、どのような由来を持つのか、どのCapability Payloadが物理化されるのか、そして実行がどのように統治されるべきかを、重みのロード前に検証できる。

主な新規性は、モデルCapabilityをモノリシックな重み配備から分離する点にある。AIKernelは、タスクに必要な最小Capability部分グラフを解決し、対応するPayloadだけを動的にロードし、ReplayLogに基づくSemantic Traceとして実行を記録し、検証済みTeacher ModelのTrajectoryを対象Capabilityモジュールへ差分蒸留する。これにより、ローカルSLMはモデル全体を再学習・再配備することなく、Workload固有の能力を段階的に獲得できる。

本稿は概念的・アーキテクチャ上の技術ノートであり、実証ベンチマークを提示するものではない。目的は、SLMをAIKernel内部で統治可能、ホットスワップ可能、追跡可能、段階的に自己改善可能なSemantic Processとして扱うための、OSレベルのModel ABI、Capabilityモジュール化戦略、蒸留ライフサイクル、ランタイムスケジューリング規律を仕様化することである。

## Keywords

AIKernel; DynamicSLM; Small Language Models; Capability Graph; Model ABI; Semantic Profile; Execution Profile; Differential Distillation; ReplayLog; Dynamic Capability Loading; Heterogeneous Compute; Semantic Context OS; Self-Improving AI Systems.

## 1 Introduction

現在のLLMおよびSLMは、多くの場合、静的なモノリスとして設計される。一度学習されると、モデルは単一の巨大なパラメータ化関数として配備される。アダプタ、ルーティング層、外部ツール利用機構はモデルの振る舞いを修正できるが、モデル成果物そのものは依然として大きな不可分単位として扱われることが多い。実行時に特定の能力だけをロードし、単一の能力だけを置換し、狭い振る舞い領域だけを失効させ、あるCapabilityだけを更新することは難しい。

本稿におけるOS比喩は、厳密にはアーキテクチャ上の比喩である。モデルが従来OSのProcessと完全に同一の性質を持つという意味ではない。むしろ、モデルCapabilityが、OSが実行コンポーネント、動的ライブラリ、資源制約付きProcessを統治するように、外部Runtime境界によって宣言、受理、スケジューリング、隔離、スワップ、監査、失効されるべきである、という意味である。

この静的構造は、エッジ推論、メモリ制約の厳しい配備、個人化アシスタント、統治されたAIランタイムの要求と合わなくなりつつある。ソフトウェア工学では、OSは単一の巨大バイナリから、プロセス、動的リンクライブラリ、メモリページング、アクセス制御、資源スケジューリングを備えた構造へ発展した。一方で、モデル配備はしばしば、単一の成果物をロードし、現在のタスクに必要かどうかに関わらずすべての能力が利用可能になる形式に留まっている。

AIKernelは、この問題をOSの観点から捉える。AIKernelでは、モデルを最終的な実行主体としてではなく、Semantic Context、Capability Contract、Resource Profile、Deterministic Execution Traceによって統治されるプロセスとして扱う。この見方では、モデルは単なるブラックボックスのテンソルPayloadではなく、カーネル制御下で宣言、検証、スケジューリング、隔離、改善可能なランタイムモジュールであるべきである。

本稿は、AIKernelに統合されるCapabilityモジュール型・自己改善型モデルアーキテクチャ **DynamicSLM** を提案する。DynamicSLMは、AIKernel Model ABIに準拠したSemantic ProfileとWeight Payloadの集合としてモデルを定義する。このアーキテクチャは、モデルCapabilityを静的な重み配備から分離し、Capabilityレベルのメタデータを実行前にカーネルへ公開する。

本技術ノートの貢献は以下の3点である。

1. モデルを Semantic Profile、Capability Graph、Execution Profile、Lineage、Payload の5要素で表す AIKernel Model ABI を定義する。
2. AIKernelがタスクに必要な最小Capability部分グラフを解決し、必要なPayloadだけをロードするCapabilityレベルの動的ロードアーキテクチャを導入する。
3. 実行時に検出されたCapability不足をTeacher Modelへ委譲し、検証済みReplayLogを対象Capabilityモジュールへ差分蒸留する自己改善ループを提案する。

目的はすべてのモノリシックモデルを置き換えることではない。大きく一貫したモデルが有効なタスクは残る。本稿の目的は、SLMをOS管理プロセスに近づけるためのランタイムアーキテクチャ、すなわちモジュール化、失効可能性、スケジューリング可能性、ホットスワップ可能性、追跡可能性、対象限定の自己改善可能性を定義することである。

## 2 Related Work

DynamicSLMは、AIKernelをSemantic Context OSのための形式的ガバナンス基盤として定義する、公開済みのTrajectory Governance論文を基盤としている [1]。本稿におけるModel ABI、Capability Graph、Differential Distillation、および異種計算スケジューリングは、その基盤上に位置づけられる新しいアーキテクチャ拡張として提示する。

モジュール型モデルの研究では、疎ルーティング、Mixture of Experts、アダプタ、低ランク適応などが検討されてきた。代表的な例や系統として、Sparsely-Gated Mixture-of-Experts、Mixtral、DeepSeek MoE、Phi-3.5 MoE型のモジュール配備、LoRA、QLoRA などが挙げられる。これらはパラメータ効率を改善し、モデル内部の一部コンポーネントを選択的に活性化する可能性を示している。しかし、多くはモデルアーキテクチャ内部の最適化であり、外部ランタイムがCapabilityを第一級実行対象として検査、検証、受理、失効、スケジューリング、監査するためのOSレベル契約を定義するものではない。

AIKernelが必要とする境界は異なる。カーネルは、モデル内部で確率的にExpertを選ぶだけでは不十分である。どのCapabilityがロードされるのか、そのSemantic Profileは何か、どの資源を消費するのか、どのように派生したのか、どのPayloadが物理的に展開されるのかを明示する契約が必要である。そのためDynamicSLMは、モデルのモジュール性を単なるパラメータ効率の問題ではなく、ランタイムガバナンスの問題として扱う。

Tool UseやFunction Callingは、LLMが外部Capabilityを利用するための有効な手法である。Toolformer、OpenAI Function Calling、LangGraph、LangChain Agents はこの方向の代表例である。しかし、それらはしばしばモデル成果物そのものを変更しない。ツールは外部に存在し、モデルは依然としてモノリシックなPlannerまたはControllerとして振る舞う。DynamicSLMは、Capability構造の一部をモデル成果物自体に移しつつ、AIKernelの外部Capability Registryによって統治する。

Recursive Self-Improvement、Continual Adaptation、Preference Optimization、Trajectory-based Improvement の研究は、モデルが自らの出力を評価し、時間とともに更新されるパイプラインを探求している。例として Self-Refine、Reflexion、DPO、ORPO、DeepSeek-R1 のような推論特化モデルにおけるTrajectory Distillation、Anthropic等のFrontier Model研究におけるRecursive Self-Improvementの議論が挙げられる。しかし、その多くはPrompt Engineering、全体ファインチューニング、広範なPreference Optimization、または広範なAdapter更新に依存する。DynamicSLMは、改善単位を宣言済みCapabilityノードへ狭める。システムはCapability不足を検出し、必要に応じて強力なTeacher Modelへ委譲し、得られた検証済みTraceを最小の関連Capabilityモジュールへ蒸留する。

近年のAI OS、Inference Serving、Agent Runtimeには、Microsoft Semantic Kernel、NVIDIA NIM、Triton Inference Server、Modal、Ray Serve などのRuntime・Deployment機構が存在する。これらは重要な基盤を提供するが、Semantic Profile、Execution Profile、Lineage、Payloadを持つCapability統治済みShared Library的単位としてModel Artifactを直接定義するものではない。

DynamicSLMは、AIKernelの決定論的ガバナンスとSemantic Context分離を、モデルの重み管理そのものに適用する点で異なる。SLMは、Model ABI、Capability Graph、Lineage Chain、Resource-aware Loaderによって統治されるShared Library的コンポーネントとして再構成される。

## 3 DynamicSLM Architecture

DynamicSLMの中核は **AIKernel Model ABI** である。このABIは、AIKernelがモデルをロードする前に推論・検証できる標準化インターフェースである。従来の配備では、モデルは主としてテンソルPayload、Tokenizer、Configuration Fileとして扱われる。DynamicSLMでは、Payloadはより広い統治対象成果物の一部にすぎない。

DynamicSLM成果物は5つの要素で構成される。

- **Semantic Profile:** モデルまたはCapabilityモジュールのSemantic Contractであり、入力前提、出力スキーマ保証、有界なSemantic Scope、想定タスクドメインを含む。
- **Capability Graph:** モデルが提供するCapabilityとその依存関係を表す有向非巡回グラフ。
- **Execution Profile:** メモリフットプリント、期待レイテンシ、Compute Shape、Accelerator適性、Scheduling制約などの実行時資源要件。
- **Lineage:** Artifactの生成経路を表す出所記録であり、親モデル、Teacher Model、蒸留に使用したReplayLog、訓練設定、Artifact Hashを含む。
- **Payload:** 宣言されたCapabilityを実現するWeight Tensor、Adapter、Quantized Block、Tokenizer Fragment、または実行可能Model Segment。

これら5要素は、AIKernelとDynamicSLM Artifactの間にあるABI境界をまとめて定義する。Semantic Profileは契約を、Capability Graphは依存構造を、Execution Profileは資源形状を、Lineageは出所証明を、Payloadは物理化されるModel Componentを表す。

この構造により、AIKernelはモデルロード前にFail-Closedできる。Capabilityを主張するモデルであっても、Lineageが無効である、Execution Profileが非互換である、Semantic Contractが壊れている、Payload Hashが検証できない場合、LoaderはWeightをメモリに展開する前に拒否できる。

### 3.1 Capability Graph

Capability Graphは、モデルCapabilityを依存関係付きDAGとして表現する。各ノードはSemantic Abilityに対応し、各エッジは正しい実行に必要な依存関係を示す。例えば `SQL generation` Capabilityは、`schema understanding`、`logical reasoning`、`structured output formation` に依存し得る。

このグラフにより、AIKernelはTask Intentを最小Capability部分グラフへ解決できる。毎回モノリシックモデル全体をロードするのではなく、現在の意図に必要なCapabilityを特定し、関連Payloadのみを選択する。これは静的な全体バイナリ実行ではなく、動的リンクに近いモデルランタイムを実現する。

グラフはガバナンスにも使われる。Policyは `read-only summarization` を許可しつつ、`system command generation` を拒否できる。Capabilityが明示的ノードであるため、Policy Decision Pointは生成開始前に危険なCapabilityロードを拒否できる。

### 3.2 Semantic Profile

Semantic Profileは、Capabilityモジュールが満たすと主張するContractを定義する。以下のような項目を含み得る。

- 受理可能な入力ドメイン
- 出力スキーマまたは構造化応答保証
- Semantic BoundまたはTask Ellipsoid
- Failure ModeとRequired Fallback Behavior
- 他Capabilityへの依存仮定
- AIKernel ContextおよびReplayLog形式との互換性

Semantic ProfileはPromptではない。ランタイムへ公開される宣言的Contractである。AIKernelはこれを用いて、Capabilityが現在のタスクに適格か、そして下流Pipelineがその出力を消費できるかを判断する。

### 3.3 Execution Profile

Execution ProfileはCapabilityの運用コストを宣言する。期待VRAM使用量、CPU/NPU適性、Quantization Format、Tensor Shape、期待Latency、Prefetch要件などを含む。Runtime SchedulerはこのProfileを使って、Payloadをどこでいつロードするかを決定する。

このProfileは特にエッジデバイスで重要である。小型デバイスは7B級モデル全体をロードできないかもしれないが、1.0Bから1.5B程度のCapabilityモジュールと小さなAdapterならロード可能な場合がある。DynamicSLMは、この判断をモデルロード前にカーネルへ見える形にする。

### 3.4 Lineage and Payload Verification

Lineageは出所と完全性を提供する。各Capability Payloadは、親モデル、Teacher Model、Distillation Corpus、ReplayLog集合、Training Configuration、Output Artifact Hashを記録するHash Chainに関連付けられる。LoaderはPayloadを受理する前にLineageを検証する。

これにより、不正なModel Replacementを防ぎ、再現性を支援できる。Capabilityが予期しない振る舞いをした場合、AIKernelはどのTeacher、どのData、どのDistillation Processから生成されたかを追跡できる。

## 4 Dynamic Distillation Pipeline

DynamicSLMは静的成果物ではなく、AIKernelガバナンス下で進化するように設計される。この進化を駆動するのが **Differential Distillation Pipeline** である。

AIKernelがタスクを受け取ると、必要なCapability部分グラフを解決する。現在のローカルSLMに必要Capabilityがない、または必要なSemantic Profileを満たせない場合、システムはより強力なTeacher Modelへタスクを委譲できる。このFallbackは不透明な外部呼び出しとして扱われない。Teacherの推論Trajectory、出力、検証結果、実行Contextは、ReplayLogに基づくTraining Materialとして記録される。

特定のCapability Gapについて十分な検証済み例が蓄積されると、AIKernelはバックグラウンドでDifferential Distillationを起動できる。システムはモデル全体を再訓練しない。Capability Graph上の特定ノードを対象とする。例えば、特定ドメインのJSON構造化における反復的失敗は、そのCapabilityだけの小さなAdapterまたはPayload更新を生成し得る。具体的な更新機構はLoRA型Adapterに限定されない。QLoRA差分、通常のAdapter、Block-level Update、Segment-level Payload Replacement、量子化テンソルパッチ、またはModel ABIが受理する別のCapability単位Artifactとして表現できる。

得られたCapabilityモジュールは、新しいSemantic Profile、Execution Profile、Lineageを持つPayloadとしてパッケージ化される。AIKernelは完全性検証、Validation、Policy Admissionの後にのみ新Artifactを登録する。登録後、そのモジュールは将来のRoutingで利用可能になる。

これにより **Dynamic Self-Improvement** ループが形成される。

1. タスクがCapabilityを要求する。
2. ローカルSLMのCapabilityが不足または不十分である。
3. AIKernelがTeacher Modelへガバナンス下で委譲する。
4. 成功したTrajectoryとOutputがReplayLog Materialとして保存される。
5. 対象Capabilityモジュールが差分蒸留される。
6. 新モジュールがLineage Chain付きで登録される。
7. 将来の類似タスクはTeacher Modelへの依存度を下げてローカルで処理される。

これはメモリキャッシュやDemand PagingのSemantic版に近い。システムは反復的なRuntime Demandを観測し、不足Capabilityを物理化し、将来のFallback Costを低減する。

## 5 Runtime Execution Model

DynamicSLMは、Process Management、Dynamic Linking、Memory Paging、Heterogeneous SchedulingといったOS概念を言語モデル実行へ適用する。AIKernel Runtimeは、単にモデルをロードして呼び出すのではない。Intentを解決し、Capability Contractを検証し、Capability部分グラフを選択し、対応Payloadをロードし、利用可能なCompute Resourceへスケジューリングする。

**IPipelineOrchestrator** はExecution Profileを用いて、CapabilityモジュールをCPU、GPU、NPU、または他のAcceleratorへ配置する。**IModelVectorRouter** はTask Intentを候補DynamicSLMモジュールへ対応付ける。**Registry & Loader** はLineageを検証し、互換性を確認し、必要Payloadのみを物理化する。

### 5.1 Model Hot-Swapping

Model Hot-SwappingはDynamicSLMの中核である。従来のRuntimeでは、大規模モデルのロードとアンロードに秒単位の時間がかかり、すべてのVRAMを消費し得る。DynamicSLMはロード単位をモデル全体からCapability Payloadへ縮小する。Runtimeは必要CapabilityをPage Inし、非アクティブなCapabilityをPage Outできる。

メモリ制約の厳しい環境では、これにより複数の論理的モデルCapabilityが、単一の物理Accelerator上で時間的に共存できる。Runtimeは頻繁に利用されるCapabilityを常駐させ、Pipeline Graphに基づいて予測CapabilityをPrefetchし、優先度の低いModuleをCPUまたはNPUへOffloadできる。

### 5.2 Trajectory Integration and Context Isolation

複数Capabilityモジュールが同じタスクに関与する場合、その出力を制御不能な干渉なしに統合する必要がある。AIKernelはSemantic Storage Modelを通じて統合を行う。Semantic Storage Modelは決定論的な中間表現層として機能し、一時的なModule Outputを、Addressing、Replay、Hashing、後続伝播が可能な安定したSemantic Artifactへ変換する。中間ArtifactはReplayLog Entryとして保存され、後続モジュールへ不変Contextとして提供される。

これによりModule Executionが隔離される。あるCapabilityが別のCapabilityの内部状態を直接変更することはない。Capabilityは統治されたSemantic Artifactを通じて通信する。この方式により、実行経路は監査可能になり、モジュール間の非決定的干渉は低減される。

### 5.3 Capacity Budgets and Scheduling

DynamicSLMのSchedulingは単純なFIFOではない。SchedulerはDynamic Capacity Budget、Latency SLA、Resource Pressure、Task Priorityを考慮する。緊急の対話型タスクには即座にVRAMを割り当て、バックグラウンドのDifferential Distillationはアイドル状態のCPUまたはNPUへ移せる。

**IComputeShapeAdvisor** はHardware Loadを監視し、Placement Decisionを支援する。Schedulerはモデルを静的Blobではなく、統治されたRuntime Processとして扱える。

## 6 Conceptual Evaluation

本節は明示的に非実証的評価である。DynamicSLMはアーキテクチャ・パラダイムであり、完全な実証実装は進行中である。以下の評価は、アーキテクチャ分析、仮説的Module Size、予想されるHardware Behavior、そしてアーキテクチャ上妥当と思われるRuntime Effectに基づく。測定済みベンチマークとしてではなく、概念的評価として読むべきである。

### 6.1 Memory Footprint Expectations

一般的なCapabilityモジュールが1.0Bから1.5Bパラメータ相当のModel Segmentであると仮定すると、DynamicSLMはアクティブタスクに必要なModuleだけをロードできる。モノリシックな7B級SLMと比較して、Capability Graphの一部だけを活性化するWorkloadでは、Peak VRAM使用量を大きく削減できる可能性がある。アクティブCapabilityノード数に依存するが、50%から75%のPeak Memory Footprint削減はアーキテクチャ上あり得る仮説であり、実証済みの結果ではない。

### 6.2 Expected Swap Latency

PCIe Gen4またはGen5の帯域幅と、Graph-aware Asynchronous Prefetchingを前提とすれば、適切なサイズのCapability Payloadについて、Page-in/Page-out Latencyは数十ミリ秒の範囲に収まる可能性がある。この期待値は仮説的であり、Payload Size、Quantization Format、Host-device Transfer、Memory Pinning、Runtime Prefetch Accuracyに依存する。Prefetchが有効でPayloadが小さい場合、Structure-Generation-Polish Workflowのような対話型Agent Pipelineで許容可能と考えられる。

### 6.3 Differential Distillation Efficiency

Replay-based Distillationは、焦点を絞った適応が広範な再訓練よりも少ないSampleで狭いCapabilityを改善できる可能性を示している。DynamicSLMはこの考えをCapability Nodeレベルに適用する。Distillation Targetが狭いため、General-purpose Modelの再訓練よりもData-efficientになる可能性がある。ただし、これは今後実証すべきアーキテクチャ上の仮説である。

### 6.4 Personalization Behavior

DynamicSLMは、ユーザー固有またはドメイン固有の適応をCapability Moduleとして物理的に隔離する。これにより、Multi-user Adaptationのメモリ効率の高い経路が示される。ユーザーごとにModel全体を複製・ロードする必要はなく、共通Base上に個別Capability Payloadを重ね、AIKernelがPolicyに従ってスケジュールおよび隔離できる。これは配備構造に関する概念的主張であり、測定済みのMulti-user Benchmarkではない。

## 7 Discussion

DynamicSLMは推論効率だけでなく、安全性とガバナンスにも利点をもたらす。Capabilityが明示的なRuntime Objectであるため、AIKernelはロード前にそれらを統治できる。Policy Decision Pointは、制限されたSystem Command Generationのような危険Capabilityを、Token生成前に拒否できる。これは、禁止CapabilityがActive Runtime Boundaryに物理化される前に遮断するため、事後的なPrompt Filteringよりも強い防御線となる。

このアーキテクチャは監査可能性も高める。各Capability PayloadはLineageを持ち、各実行はReplayLogで記録される。タスクが失敗したりCapabilityが安全でない出力を生成した場合、システムはどのCapabilityが有効であったか、どのParent Modelがそれを生成したか、どのDistillation Traceが関与したか、どのRuntime Contextがそれを呼び出したかを特定できる。

一方でCapabilityモジュール化にはトレードオフがある。Capabilityが細かすぎると、Context Fragmentationが生じ得る。その場合、モジュール間のSemantic Gapを埋めるためのOrchestration Overheadが増大する。一部のタスクでは、細分化されたCapabilityの組み合わせよりも、大規模なMonolithic Modelの一貫したGlobal Reasoning Stateの方が高い精度を示す可能性がある。DynamicSLMはすべてのモデル配備方式の普遍的代替ではなく、Capabilityモジュール化されたWorkloadのためのRuntime Architectureとして理解すべきである。

重要な今後の方向性は、Capability Graphの自己組織化である。現在の設計では、Differential Distillationの対象ノードはHeuristicsまたはGovernance Policyによって選択される。将来のバージョンでは、AIKernelのSemantic CompilerがReplayLogを解析し、反復的Capability Gapを検出し、新しいCapability Graphノードを提案し、対応するDistillation Processを自動生成する可能性がある。

## 8 Conclusion

本稿では、AIKernelのためのCapabilityモジュール型・自己改善型Small Language Modelアーキテクチャ **DynamicSLM** を提案した。この設計は、言語モデルを静的なモノリシックバイナリではなく、OS的Runtimeによって統治される動的プロセスとして再解釈する。

AIKernel Model ABIにより、各Model ArtifactはSemantic Profile、Capability Graph、Execution Profile、Lineage、Payloadを公開する。AIKernelは、どのCapabilityをロードすべきか、どこへスケジューリングすべきか、どのようにProvenanceを検証すべきか、実行をどのように記録すべきかを判断できる。Differential Distillationにより、システムは検証済みRuntime Traceを対象限定のLocal Capability Moduleへ変換し、大規模Teacher Modelへの依存を段階的に下げることができる。

DynamicSLMは、モデルが単なる確率的生成器ではなく、Semantic Context Operating Systemにおける統治可能、追跡可能、ホットスワップ可能、自己改善可能な決定論的実行基盤の構成要素となる未来への一歩である。

## 9 References / 参考文献

[1] Sogawa, T. (2026). *AIKernel Trajectory Governance Model: A Kernel-Level Framework for Convergent Decision Control over Stochastic Language Model Inference*. Zenodo.  
DOI: https://doi.org/10.5281/zenodo.20309510

[2] Sogawa, T. (2026). *AIKernel Phase-2 Theory: Semantic Compilation Architecture*. Zenodo.  
DOI: https://doi.org/10.5281/zenodo.20312092

[3] Sogawa, T. (2026). *AIKernel Semantic DSL Compiler and Deterministic Agent Execution Architecture*. Zenodo.  
DOI: https://doi.org/10.5281/zenodo.20534341

[4] Sogawa, T. (2026). *AIKernel Hash-Anchored Trust Layer (HATL): A Hybrid Symmetric Ledger with Hash-Based Public Anchors*. Zenodo.  
DOI: https://doi.org/10.5281/zenodo.20502685
