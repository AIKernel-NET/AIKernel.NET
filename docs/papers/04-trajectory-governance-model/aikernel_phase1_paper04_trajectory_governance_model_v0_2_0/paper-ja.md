---
id: aikernel.phase1.paper04.trajectory-governance-model.ja
title: "AIKernel Phase-1 Paper 04: Trajectory Governance Model"
subtitle: "確率的 AI エージェントに対する決定論的実行制御のための形式仕様"
version: 0.2.0
status: canonical-draft
issuer: takuya.sogawa@aikernel.net
license: CC-BY-4.0
lang: ja
created: 2026-05-20
last_updated: 2026-05-26
author: "Takuya Sogawa"
author_orcid: "https://orcid.org/0009-0009-7499-2595"
date: 2026-05-26
doi: "10.5281/zenodo.20309510"
canonical_id: "aikernel.phase1.paper04.trajectory-governance-model"
canonical_language: en
companion_languages:
  - ja
series: "AIKernel / AIOS Phase-1 Specification Series"
phase: "Phase 1"
part: "Part II-4: Governance Layer"
paper_no: 4
resource_type: publication
publication_type: technical-note
target: "AIKernel.NET Governance / Trajectory"
proposed_namespace: "AIKernel.Abstractions.Governance.Trajectory"
stability: experimental-non-normative
based_on:
  - doi: "10.5281/zenodo.20223205"
    version: "0.1.1"
    relation: adapted_from
depends_on:
  - aikernel.phase1.paper03.pre-inference-admissibility-governance
related_to:
  - aikernel.phase1.paper05.aikernel-execution-model
  - aikernel.phase1.paper07.aikernel-net-implementation
repository: "https://github.com/AIKernel-NET/AIKernel.NET"
website: "https://aikernel.net/"
tags:
  - aikernel
  - aios
  - architecture
  - phase-1
  - governance-layer
  - trajectory-governance
  - semantic-trajectory
  - fail-closed
  - policy-decision-point
  - replaylog
owners:
  - Takuya Sogawa
is_translation_of: "aikernel.phase1.paper04.trajectory-governance-model.en"
translation_status: companion-translation
---

# AIKernel Phase-1 Paper 04: Trajectory Governance Model

## 確率的 AI エージェントに対する決定論的実行制御のための形式仕様

**著者:** Takuya Sogawa  
**ORCID:** https://orcid.org/0009-0009-7499-2595  
**Version:** v0.2.0  
**Publication date:** 2026-05-26  
**DOI:** https://doi.org/10.5281/zenodo.20309510  
**License:** Creative Commons Attribution 4.0 International (CC BY 4.0)  
**Canonical language:** English  
**Companion translation:** Japanese  
**Series position:** AIKernel / AIOS Phase-1 Specification Series, Part II-4: Governance Layer  
**Target:** AIKernel.NET Governance / Trajectory  
**Proposed namespace:** `AIKernel.Abstractions.Governance.Trajectory`  
**Stability:** Experimental / Non-normative  
**Based on:** Trajectory Governance Model v0.1.1, DOI: https://doi.org/10.5281/zenodo.20223205

---

## 1. Abstract

本論文は、AIKernel / AIOS Phase-1 における Trajectory Governance Model を定義する。Trajectory Governance は、推論開始後の LLM / SLM の出力、候補行動、意味的状態遷移、目標整合性、リスク、不確実性、および反復性を観測し、提案された状態遷移を実行可能なシステム遷移として受理するか否かを決定する Kernel-level governance model である。

本モデルは、LLM の確率的生成を決定論化するものではない。むしろ、確率的に提案された状態遷移を、決定論的な Policy Decision Point によって評価し、Permit / Deny / AskConfirmation / Clarify / Abort の制御された判断状態へ写像する。これにより、AIKernel は stochastic inference を直接信頼せず、観測可能な semantic trajectory を通じて、実行遷移の安全性、再現性、監査可能性を高める。

> **既存 DOI 版との関係**  
> 本論文は、既に Zenodo に保存された Trajectory Governance Model v0.1.1 を、AIKernel / AIOS Phase-1 Paper Series の Paper 04 として再構成した v0.2.0 版である。  
> 既存の standalone 版 DOI は `10.5281/zenodo.20223205` である。  
> 本 v0.2.0 版は、中核となる Trajectory Governance 理論を維持しつつ、Phase-1 論文体系に合わせて、責務範囲、用語、依存関係、章構成を再整理したものである。

## 2. 研究背景 (Introduction)

人工知能、特に大規模言語モデル（LLM）の急速な発展に伴い、計算機システムのパラダイムは大きな転換点を迎えている。LLM を中核に据えた AI エージェントシステムは、自然言語による高度な意図解釈と動的な問題解決能力を提供する一方で、確率的な推論プロセスや非構造化データの処理を扱う性質上、非決定的な振る舞いを伴う。

この非決定性は、エンタープライズレベルの採用において、信頼性、再現性、監査可能性、および実行時安全性の確保という課題を生み出している。従来の安全性アプローチは、入力フィルタ、最終出力検査、静的プロンプトエンジニアリング、または外部ガードレールに依存することが多い。しかし、これらの手法は、推論過程そのものを連続的な状態遷移として観測し、統治するモデルを必ずしも提供しない。

AIKernel プロジェクトは、AI の実行環境に監査可能な制御境界を与える枠組みとして設計されている。本研究では、AIKernel の Governance Layer における中核モデルとして Trajectory Governance を定式化する。これにより、コンテキスト汚染、目標の漂流（Goal Drift）、推論の発散、危険な候補行動の選択といった課題に対し、決定論的で fail-closed な制御境界を提供する。

## 3. Scope and Boundary

Trajectory Governance は、AIKernel / AIOS 実行パイプラインにおいて、推論が開始された後の意味的状態遷移および候補行動を統治する。

### 3.1 Inbound Boundary

本モデルが扱う要求は、原則として Paper 03: Pre-Inference Admissibility Governance における事前受理判定を通過しているものとする。すなわち、入力は少なくとも以下の入口制御を通過済みである。

- Prompt Injection / Override Gate
- Capability Admission Gate
- Critical Operation Gate
- Computational Complexity Gate

特に、タスク自体が `ModelExecutionBudget`、すなわちモデルの信頼可能な運用範囲を逸脱している場合、その要求は Paper 03 の段階で `DelegateToSolver`、`Decompose`、`Clarify`、または `Deny` として処理される。Paper 04 は、事前受理された推論トランザクション内で発生する状態遷移と候補行動を扱う。

### 3.2 Outbound Boundary

Trajectory Governance は、LLM / SLM が提案した候補行動、生成された中間状態、ツール呼び出し、コンテキストへの hydration 候補、および最終的な実行候補を評価する。これらは、ガバナンスレイヤーによって評価されるまでは未信頼状態として扱われる。

本モデルは、候補状態を以下の制御された判断状態へ写像する。

- `Permit`
- `Deny`
- `AskConfirmation`
- `Clarify`
- `Abort`

### 3.3 Non-Goals

Trajectory Governance は、以下を目的としない。

- LLM 出力の factual correctness を証明すること
- Embedding モデルの意味的完全性を証明すること
- すべての敵対的入力を完全に防御すること
- LLM 内部の推論を完全に決定論化すること
- Paper 03 の事前受理ガバナンスを置き換えること
- Paper 05 の Execution Model または ReplayLog 正典スキーマを完全に定義すること

## 4. 用語定義 (Terminology)

後述する理論モデルを理解するため、AIKernel アーキテクチャにおける中核概念を以下に定義する。

- **PDP / PEP / PIP**: 標準的なアクセス制御モデルの要素。PDP（Policy Decision Point）はポリシー判断点、PEP（Policy Enforcement Point）はその判断を実行境界で強制する点、PIP（Policy Information Point）は判断に必要な属性・コンテキスト・リスク情報を提供する情報点である。
- **Trajectory**: LLM の推論過程で生成される意味的状態の連続的な軌跡。
- **Semantic Ellipsoid**: クエリ、ドキュメント、状態、候補行動などを単一の点ベクトルではなく、不確実性を含む意味的領域として表現する幾何学的モデル。
- **RootGoal**: ユーザーの根本的な意図を表す、不変（immutable）の目標状態。
- **WorkingGoal**: コンテキストによって管理される、現在のステップにおけるタスクの解釈。
- **Convergence Score**: 推論軌跡が目標に向かって安定的に進んでいるかを示す運用上のスカラー推定値。
- **Anomaly Score**: 軌跡の局所的な異常、急激な逸脱、エントロピー爆発、ポリシー違反傾向を検知するスカラー推定値。
- **ModelExecutionBudget**: Paper 03 で定義される、LLM に処理させるべき計算複雑性の限界・実行予算。
- **ReplayLog**: メトリクス、閾値、および判定結果を不変に記録し、決定論的リプレイと監査を可能にするログ。
- **SGP Pipeline**: Structure / Generation / Polish を分離し、論理構造の決定と表現生成を異なる段階として扱う AIKernel の推論分離モデルである。

## 5. 安全性の境界 (Safety Boundary)

本モデルは、確率的ジェネレーターである LLM 自体を完全に決定論的なものへ変換できると主張するものではない。また、セマンティックな推論の収束が、出力される事実の正確性を無条件に保証するとも主張しない。

AIKernel は代わりに、確率的な推論プロセスの周囲に監査可能な制御境界を与え、決定論的な安全境界を定義する。モデルの出力は、ガバナンスレイヤーが意味的関連性、目標整合性、運用上のリスク、反復性、不確実性、およびリプレイ可能性を評価するまで、未信頼の状態として扱われる。

この意味において、Trajectory Governance は LLM 内部のモデルセーフティを代替するものではない。むしろ、モデルによって提案された状態遷移を、実行可能なシステム状態として受け入れるか否かを決定するための、カーネルレベルの制御平面として機能する。

## 6. 問題設定 (Problem Statement)

現在の自律的 AI システムは、主に以下の理論的課題を抱えている。

1. **セマンティックな境界の欠如**: アテンション機構や長いコンテキスト連鎖の性質上、コンテキスト汚染やインジェクション攻撃に対して脆弱である。
2. **状態遷移の不透明性**: 思考の反復、不確実性の増大、推論の逸脱を追跡・制御する計算モデルが不足している。
3. **目標の漂流（Goal Drift）**: 推論過程で当初のユーザーの意図から徐々に逸脱していく現象を構造的に防ぐ手段がない。
4. **候補行動の危険性**: LLM が生成した候補行動やツール呼び出しを、そのまま実行可能な状態遷移として扱うと、不可逆的な副作用を招く可能性がある。
5. **安全性の非決定性**: ポリシーが自然言語で記述されがちであり、システムの挙動予測や再現が困難である。

本研究は、AI の推論過程を連続的な軌跡として数学的にモデル化し、システムの安定性と安全性を評価するための実装可能なガバナンスモデルを定義する。

## 7. Trajectory Governance と数学的モデル (Mathematical Formalization)

本モデルで導入する収束スコアや数学的定式化は、正しさや安全性そのものを証明するものではない。これは、観測された推論軌跡が、設定された統治パラメータの下で十分に安定・整合・低リスクであるかを判定するための運用上のポリシースコアである。

### 7.1 LLM 推論の形式化とガバナンス介入の4段階モデル

AIKernel は LLM の推論プロセスを、内部状態 $K_t$ とモデルパラメータ $\theta$ に依存する確率的遷移関数として形式化する。

$$
x_{t+1} \sim p(x \mid x_t, \theta, K_t)
$$

この確率的遷移プロセスに対し、AIKernel は以下のガバナンス介入の4段階モデルを適用し、非決定的な軌跡を制御する。

1. **Propose**: LLM / SLM が確率的に次のアクションや状態 $x_{t+1}$ を提案する。
2. **Evaluate**: ガバナンスレイヤーが提案状態に対するリスク、収束性、目標整合性を計算する。
3. **Decide**: PDP は、提案された状態遷移を、決定論的関数に従って `Permit`、`Deny`、`AskConfirmation`、`Clarify`、または `Abort` のいずれかの制御された判断状態へ分類する。
4. **Transition**: 許可された場合のみ、システム状態として遷移が確定する。

### 7.2 Semantic Ellipsoid の幾何学的性質と実装近似

軌跡上の各状態や候補は、単一の点ベクトルではなく、不確実性を含む意味的領域として表現される。完全な共分散行列 $\Sigma$ の計算は高次元空間では計算コストが大きいため、実装上は対角共分散近似（Diagonal Covariance Approximation）を採用できる。

意味状態 $s_t$ は、中心ベクトル $\mu_t$ と対角共分散近似 $\Sigma_t$ の組として表現される。

$$
s_t = (\mu_t, \Sigma_t)
$$

概念の意味的サンプル群、または LLM が生成した候補集合から得られるサンプリングベクトル群 $x_1, x_2, \dots, x_N$ に対し、中心および分散は以下のように推定される。

$$
\mu_t = \frac{1}{N} \sum_{i=1}^{N} x_i
$$

$$
\Sigma_t =
\mathrm{diag}(\sigma_{t,1}^{2}, \sigma_{t,2}^{2}, \dots, \sigma_{t,n}^{2})
$$

$$
\sigma_{t,j}^{2}
=
\frac{1}{N}
\sum_{i=1}^{N}
(x_{i,j} - \mu_{t,j})^2
$$

任意のセマンティックベクトル $x$ に対する近似距離は、安定化定数 $\epsilon > 0$ を用いて次のように計算できる。

$$
d(x, s_t)
=
\sqrt{
\sum_{j=1}^{n}
\frac{(x_j - \mu_{t,j})^2}{\sigma_{t,j}^{2} + \epsilon}
}
$$

許容意味領域は、制御係数 $k > 0$ を用いて次のように表現される。

$$
\mathcal{E}_t(k)
=
\{ x \in \mathcal{V} \mid d(x, s_t) \le k \}
$$

ただし、本モデルは Embedding 空間が人間の意味理解を完全に表現することを仮定しない。Semantic Ellipsoid は、観測可能な意味的ばらつきを扱うための実装上の近似である。

### 7.3 逸脱の3軸定義

推論軌跡の逸脱は、以下の3軸で定義される。

1. **勾配 $\Delta_t$**: 連続する状態空間での中心ベクトルの変化率。
2. **方向ベクトル**: 推論が目標に向かって進んでいるかを示す余弦類似度または方向の滑らかさ。
3. **正規化エントロピー $\tilde{H}_t$**: トークン出力確率、ロジット、または proxy metric から算出される不確実性の度合い。

正規化エントロピーは、語彙サイズ $|V|$ に基づく最大エントロピー $\log |V|$ で除算することで、$[0,1]$ に正規化される。

$$
H_t = - \sum_{w \in V} p(w) \log p(w)
$$

$$
\tilde{H}_t = \frac{H_t}{\log |V|}
$$

Black-box API や軽量ローカルモデルでは、完全なロジットや hidden state を取得できない場合がある。その場合、JSON 妥当性、応答安定性、候補生成の反復性、Embedding 変化量などを proxy metric として利用できる。

### 7.4 収束スコア $C_t$ と異常スコア $A_t$ の定義

観測されたメトリクスを統合し、ガバナンス判断の中核となる2つのスコアを算出する。各スコアは正規化され、常に $[0,1]$ の範囲に収まる。

**収束スコア $C_t$ (Convergence Score)** は、軌跡が目標に向かって安定的に進んでいるかを示す。

$$
\begin{aligned}
C_t = \mathrm{Clamp}\big(&
\alpha \cdot \text{SemOverlap}_t
+ \beta \cdot \text{GoalAlign}_t \\
&- \gamma \cdot \text{SmoothDrift}_t
- \delta \cdot \tilde{H}_t
- \rho \cdot \text{Risk}(a_t) \\
&- \eta \cdot \text{Rep}_t
- \zeta \cdot \text{GoalDrift}_t,
0,
1\big)
\end{aligned}
$$

**異常スコア $A_t$ (Trajectory Anomaly Score)** は、収束スコアとは独立して、局所的な危険なスパイク、急激な逸脱、エントロピーの爆発、またはポリシー違反傾向を検知する。

$$
\begin{aligned}
A_t = \mathrm{Clamp}\big(&
\omega_1 \cdot \text{RawDriftSpike}_t
+ \omega_2 \cdot \text{EntropySpike}_t \\
&+ \omega_3 \cdot \text{RiskSpike}_t,
0,
1\big)
\end{aligned}
$$

### 7.5 連続閾値割れと Fail-Closed 条件

系の安全性評価のための Governance Cost Function / Safety Index として、$V_t = 1 - C_t$ を定義する。AIKernel は、$V_t$ が力学系における厳密な Lyapunov 関数または Barrier Certificate であるとは主張しない。これは、観測可能なガバナンスメトリクス上に定義された運用上の評価関数である。

したがって、$V_t$ の低下傾向は運用上の安定化の兆候として扱えるが、数学的な大域安定性を証明するものではない。本稿で用いる Mahalanobis 型距離および Semantic Ellipsoid 近似は、有界な決定論的ガバナンスのための観測プリミティブであり、制御理論上の安定性証明として提示するものではない。

軌跡が安全境界を逸脱した場合、システムは以下の論理式に従い、直ちに実行を遮断する。

$$
\text{Abort}
=
(C_t < \tau_C)
\lor
(A_t > \tau_A)
\lor
(\text{Risk}(a_t) \ge \tau_R)
\lor
(\text{Rep}_t > \tau_P)
\lor
(\text{GoalDrift}_t > \tau_{root})
$$

さらに、一時的なゆらぎによる誤検知を防ぐため、時間窓 $W$ ステップ中 $m$ 回以上 $C_t < \tau_C$ となった場合にも、Fail-Closed 原則に従い停止状態へフォールバックする。

## 8. 目標ガバナンスとコンテキスト主権 (Goal Governance and Context Sovereignty)

目標の漂流を防ぐため、AIKernel は目標状態を Context Sovereignty の下で統治し、以下の階層モデルにより監査可能な制御境界を与える。

- **RootGoal / WorkingGoal の計算的整合性**:
  - **RootGoal ($g_{root}$)** は、ユーザーの根本的な意図を表し、不変（immutable）として定義される。
  - **WorkingGoal ($g_{work,t}$)** は、ステップごとの解釈であり、実装上は $g_{root}$ の許容意味領域への射影、または閾値判定によって制約される。
  - 目標の逸脱は、$\text{drift} = 1 - \cos(g_{root}, g_{work,t})$ として定義される。
  - WorkingGoal の更新要求は、drift が設定された閾値未満に留まる場合のみ許可され、それ以外の場合は棄却される。

この規則により、LLM または SLM は推論ステップにおける解釈を提案できるが、RootGoal そのものを変更する権限は持たない。WorkingGoal の更新は、常に RootGoal との意味的距離によって制約される。

## 9. セキュリティモデルとリスク評価 (Security Model and Risk Assessment)

### 9.1 初期リスク評価とキャリブレーション

AIKernel は、推論の実行判断において標準的なアクセス制御アーキテクチャ（PDP / PEP / PIP モデル）を採用する。初期のリスク評価は、カテゴリベースかつ決定論的に行う。ファイル削除などの破壊的操作やエントロピーの高い推論結果には、高い基礎リスクスコアが割り当てられる。

運用を通じて蓄積される ReplayLog に基づく統計的キャリブレーションは、将来的に重み調整へ利用できるが、ハードポリシー制約、Fail-Closed 原則、および能力境界を置き換えてはならない。

### 9.2 Candidate Generation and Filtering

推論ステップ $t$ において、LLM または SLM は、次にとるべきアクション、ツール実行コマンド、または次段階の思考コンテキストを包含する候補集合を生成する。

$$
\text{Candidates}_t = \{ a_1, a_2, \dots, a_n \}
$$

これらの候補は、生成された瞬間に実行またはコンテキストへの hydration を許可されることはない。候補は評価空間に一時的に保持され、静的検証、リスク評価、軌跡評価、目標整合性評価を通過した場合のみ、実行可能な候補として扱われる。

静的バリデーションルールに違反する候補は、スコアリング前に棄却される。

$$
\text{Candidates}^{filtered}_t
=
\{
a_i \in \text{Candidates}_t
\mid
\text{IsValidSyntax}(a_i)
\land
\text{IsAuthorizedCapability}(a_i)
\}
$$

### 9.3 Decision Rule と Candidate Ranking

LLM / SLM から複数の候補行動が提案された場合、PDP は以下のルールセットに基づいて候補をランキングし、最終決定を下す。

本稿において、**Candidates** は、LLM / SLM によって提案されたアクション集合のうち、ガバナンス評価対象となる候補集合として定義される。

リスクが $\tau_R$ 以上のアクションは、実行候補集合から除外される。候補アクションごとのランキングスコアは、現在の軌跡状態を共有しつつ、アクション固有の意味一致度とリスクを用いて次のように定義する。

$$
\begin{aligned}
\text{Score}(a) =
&\alpha \cdot \text{SemOverlap}(q,a)
+ \beta \cdot \text{GoalAlign}_t \\
&- \gamma \cdot \text{SmoothDrift}_t
- \delta \cdot \tilde{H}_t
- \rho \cdot \text{Risk}(a) \\
&- \eta \cdot \text{Rep}_t
- \zeta \cdot \text{GoalDrift}_t
\end{aligned}
$$

安全な候補集合は次のように定義される。

$$
A_{safe}
=
\{
a \in \text{Candidates}
\mid
\text{Risk}(a) < \tau_R
\}
$$

選択される候補は次の通りである。

$$
a^*
=
\arg\max_{a \in A_{safe}}
\text{Score}(a)
$$

ただし、$A_{safe} = \emptyset$ の場合、$\arg\max$ は評価せず、`Deny` または `Clarify` を返す。

選択された $a^*$ に対し、PDP は以下の優先順位で最終的なガバナンス判断を下す。ここで、$\tau_{safe} < \tau_R$ とする。$\tau_{safe}$ を超えるが $\tau_R$ 未満のリスクは、即時拒否ではなく確認要求として扱う。

$$
\begin{aligned}
&\text{if } \text{Abort} = \text{true}
&&\Rightarrow \text{Return}(\text{Abort}) \\
&\text{else if } \text{SemOverlap}_t < \tau_{\text{sem}}
&&\Rightarrow \text{Return}(\text{Clarify}) \\
&\text{else if } \text{Risk}(a^*) > \tau_{\text{safe}}
&&\Rightarrow \text{Return}(\text{AskConfirmation}) \\
&\text{else if } C_t \ge \tau_{\text{exec}}
&&\Rightarrow \text{Return}(\text{Permit}) \\
&\text{else}
&&\Rightarrow \text{Return}(\text{Deny})
\end{aligned}
$$

| Decision | 意味 |
|---|---|
| `Permit` | 実行許可 |
| `AskConfirmation` | 中リスクのため人間確認要求 |
| `Clarify` | 意味曖昧のため明確化要求 |
| `Deny` | ポリシー上の拒否 |
| `Abort` | Fail-Closed による停止 |

## 10. 理論的保証と証明スケッチ (Theoretical Guarantees and Proof Sketches)

前述の数学的モデルとガバナンスアーキテクチャに基づき、AIKernel が提供する制御の理論的保証を以下に示す。

### 10.1 Assumptions

- **A1**. 全てのガバナンスメトリクス、スコア、ペナルティは正規化され $[0,1]$ の範囲に有界である。
- **A2**. ガバナンスにおける重み係数と判定閾値は、単一の決定ステップ内において固定である。
- **A3**. アクションに対する運用リスク $R(a)$ は、副作用を伴う実行の前に必ず計算・評価される。
- **A4**. ガバナンス判定を行う関数 $I_{PDP}$ は完全に決定論的である。
- **A5**. LLM または SLM は候補を提案できるが、それらを自ら実行する権限を持たない。
- **A6**. ツールやシステムコールは、PDP の判定結果が `Permit` の場合のみ実行される。

### 10.2 Theorem 1. Normalization Property of Scoring Function

収束スコア $C_t$ および異常スコア $A_t$ は、最終的なガバナンス出力として、常に $0 \le C_t \le 1$ および $0 \le A_t \le 1$ を満たす。

**Proof Sketch**: 各入力パラメータは前提 A1 により $[0,1]$ に有界であるため、これらの線形結合は有限値として計算される。ただし、収束スコアにはリスクや反復などの負のペナルティ項を含むため、未加工の線形結合値が必ずしも $[0,1]$ に収まるとは限らない。ガバナンス判断の事前条件として最終段で $\mathrm{Clamp}(x,0,1)$ を適用することにより、システムへ渡される最終的な $C_t$ および $A_t$ が常に $[0,1]$ に正規化される。

### 10.3 Theorem 2. Fail-Closed Safety

ガバナンス評価によって $\text{Abort} = \text{true}$ と判定された場合、いかなる提案アクション $a$ も実行されない。

$$
\text{Abort} = true \Rightarrow \neg \text{Exec}(a)
$$

**Proof Sketch**: 前提 A5 および A6 により、実行権限は PEP に隔離されている。PEP の実装は、PDP からの判定結果が `Permit` 以外であった場合、副作用を伴う API 呼び出しのコードパスを実行境界で遮断するようアーキテクチャレベルで規定されている。したがって、`Abort` が選択された場合、確率的出力が物理環境に到達するパスは存在しない。

### 10.4 Theorem 3. Risk Threshold Exclusion

算出されたリスクが設定閾値以上のアクションは、安全な実行候補集合 $A_{safe}$ に含まれない。

$$
R(a) \ge \tau_R \Rightarrow a \notin A_{safe}
$$

**Proof Sketch**: 前提 A3 により、実行前に全ての候補アクションに対して $R(a)$ が計算される。評価フェーズにおいて、集合 $A_{safe}$ の構築フィルターは $R(a) < \tau_R$ として定義されているため、条件を満たさないアクションは $\arg\max$ による最終選択の評価対象から決定論的に排除される。

### 10.5 Theorem 4. Root Goal Sovereignty Invariant

$g_{root}$ が immutable であり、かつ WorkingGoal 更新が PEP によって drift 閾値に基づき強制される限り、$g_{work,t}$ の更新は定義された許容意味領域内に留まる。

**Proof Sketch**: 任意の時点 $t$ における新たな WorkingGoal の更新要求に対し、システムは以下を評価する。

$$
\text{drift}
=
1 - \cos(g_{root}, g_{work,t+1})
$$

$\text{drift} \le \tau_{drift}$ である場合のみ状態遷移が許可され、それ以外は棄却される。システムは更新のたびに不変な $g_{root}$ との距離を評価し、許容意味領域を逸脱する状態遷移を PEP により遮断する。したがって、更新規則の定義と PEP の強制により、$g_{work,t}$ は常に $g_{root}$ の許容意味領域内に拘束される。

### 10.6 Theorem 5. Deterministic Governance Replay

同一の実装バージョン、数値精度、Embedding model、ポリシー、閾値、重み、および入力記録が固定されている場合、Governance Decision は再現可能である。

**Proof Sketch**: ガバナンス判定関数は前提 A2 および A4 により決定論的である。ReplayLog には実行時のメタデータが不変のまま記録されており、外部要因や確率的ばらつきは、記録されたリプレイ入力によって制御される。指定された環境条件と数値計算の精度が一致する限り、同一の入力集合に対する純粋関数の合成として評価され、同一の判定結果を出力する。

### 10.7 What These Guarantees Do Not Prove

AIKernel の Trajectory Governance Model は堅牢なガバナンスを提供するが、以下の要素を数学的に証明するものではない。

- **LLM 出力の正しさ（Factual Correctness）**: 生成されたテキストが現実世界の事実に即しているか。
- **Embedding の意味的完全性**: ベクトル埋め込みが、人間の意図する意味を誤差なく捕捉しているか。
- **敵対的攻撃への完全な堅牢性（Adversarial Robustness）**: すべての未知のプロンプトインジェクションを完全に防御できるか。
- **大域的な数学的安定性**: $V_t = 1 - C_t$ が厳密な Lyapunov 関数または Barrier Certificate として機能するか。

AIKernel が保証するのは、あくまで「実行遷移の許可条件の決定論性」であり、提案されたアクションが定義された安全境界と統治パラメータを遵守しているかを評価・制御することである。

## 11. システムアーキテクチャと形式仕様化 (System Architecture and Formal Specification)

Trajectory Governance を実環境で機能させるため、以下のコンポーネントがアーキテクチャレベルで形式仕様化される。

- **Context Isolation と Material Quarantine**: 情報のカテゴリを厳密に分離し、外部データは検疫プロセスを経て構造化された後にのみ推論コンテキストへ統合される。
- **SGP Pipeline**: Structure / Generation / Polish を分離し、論理構造の決定と表現生成を異なる段階として扱う。
- **PDP / PEP Boundary**: LLM は候補を提案できるが、実行権限は PEP に隔離される。
- **ReplayLog Integration**: すべてのガバナンス判断は、後続の監査・再現・キャリブレーションのために記録される。

## 12. 実験・検証計画 (Experimental Validation Plan)

理論モデルの実装可能性を裏付けるため、以下の段階的な検証計画を定義する。

- **Phase 1: Connectivity**: CPU オンリーな軽量ローカル SLM または OpenAI-compatible local inference server を利用し、通信接続と構造化出力の安定性を検証する。
- **Phase 2: Candidate Generation**: 自然言語要求から候補アクションを生成させ、リスク判定と候補フィルタリングの有効性をテストする。
- **Phase 3: Governance Validation**: 提案された候補に対し、Fail-Closed ガバナンス、承認ルーティング、RootGoal drift 検知が意図通りに動作するかを検証する。
- **Phase 4: Replay Calibration**: ReplayLog を用いて、各重みパラメータおよび閾値をキャリブレーションする。
- **Phase 5: Open-Weight Extension**: Transformers や vLLM などのオープンウェイトモデルで hidden state、logits entropy、top-k probability distribution を取得し、proxy metric との相関を検証する。

## 13. Limitations

本アーキテクチャは強力な統治モデルを提供するが、同時に以下の制約事項を伴う。

- **Observability limitation**: Black-box API mode や軽量ローカルモデルでは、真の hidden-state trajectory は直接観測できない。
- **Embedding dependence**: Semantic drift や goal alignment は embedding quality に依存する。
- **Threshold sensitivity**: 重みや閾値は初期値であり、ReplayLog に基づく calibration が必要である。
- **Sampling cost and latency overhead**: 候補集合や Semantic Ellipsoid を扱う場合、生成回数、埋め込み計算、スコアリング処理に追加コストが発生する。
- **False sense of security**: 高い convergence score は factual correctness や operational safety を保証しない。
- **Adversarial inputs**: 敵対的入力は goal summaries、structured output、candidate generation を操作し得るため、capability restriction や sandboxing と併用する必要がある。

## 14. 体系化された AIKernel 理論：セマンティック・コンテキスト OS

再構成された AIKernel 理論は、「セマンティック・カプセル化」、「宣言的ガバナンス」、「リソースの抽象化と流動性」の3本柱に集約される。

Trajectory Governance は、このうち宣言的ガバナンスを担う中核要素である。これは、AIKernel をセマンティック OS として構成する際に、確率的推論を検証可能な実行遷移へ接続するための Governance Layer として機能する。

## 15. 結語 (Conclusion)

AIKernel Trajectory Governance Model は、生成 AI の確率的・非決定的な性質に対し、検証可能性、監査可能性、および fail-closed な実行制御を導入するための形式的ガバナンスモデルである。

本モデルは、知能そのものを高度化することを目的としない。むしろ、LLM / SLM が提案した状態遷移や候補行動を、AIKernel の決定論的ガバナンス境界の下で評価し、実行可能なシステム遷移として受け入れるか否かを裁定する。

Context Isolation、Semantic Ellipsoid、RootGoal の不変性、PDP / PEP アーキテクチャ、ReplayLog による監査可能性を統合することで、本モデルは AIKernel をセマンティック OS として構成するための Governance Layer の中核要素として機能する。

---

## References

1. Mahalanobis, Prasanta Chandra. "On the Generalized Distance in Statistics." *Proceedings of the National Institute of Sciences of India*, vol. 2, no. 1, 1936, pp. 49-55. Available at: https://insa.nic.in/writereaddata/UpLoadedFiles/PINSA/Vol02_1936_1_Art05.pdf.
2. National Institute of Standards and Technology. *Guide to Attribute Based Access Control (ABAC) Definition and Considerations*. NIST Special Publication 800-162, 2014. DOI: 10.6028/NIST.SP.800-162.
3. OASIS. *eXtensible Access Control Markup Language (XACML) Version 3.0*. OASIS Standard, 22 January 2013. Available at: http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html.
4. Sikka, Varin, and Vishal Sikka. "Hallucination Stations: On Some Basic Limitations of Transformer-Based Language Models." *arXiv:2507.07505*, 2025. DOI: 10.48550/arXiv.2507.07505.
5. Sogawa, Takuya. "Interface-Led Architecture (ILA): A Software Development Methodology for the AI Era, Validated by the AIKernel Execution Model." Zenodo, 2026. DOI: 10.5281/zenodo.20290614.
6. Sogawa, Takuya. "AIKernel Phase-1 Paper 03: Pre-Inference Admissibility Governance." Zenodo, 2026. DOI: 10.5281/zenodo.20308639.
7. Sogawa, Takuya. "AIKernel Trajectory Governance Model: A Kernel-Level Framework for Convergent Decision Control over Stochastic Language Model Inference." Zenodo, 2026. DOI: 10.5281/zenodo.20223205.

## Appendix A. Suggested Initial Parameter Values

以下は、初期デプロイ時および ReplayLog を用いた calibration の開始点として推奨される、ガバナンスパラメータおよび閾値の例である。これらは普遍定数ではなく、運用ログに基づいて調整されるべき初期値である。

| Parameter | Initial Value | Meaning |
|---|---:|---|
| $\alpha$ | `0.30` | Semantic Overlap の収束スコアへの正の寄与係数 |
| $\beta$ | `0.20` | Goal Alignment の正の寄与係数 |
| $\gamma$ | `0.20` | Smooth Drift に対する収束スコアへのペナルティ係数 |
| $\delta$ | `0.10` | Normalized Entropy に対する収束スコアへのペナルティ係数 |
| $\rho$ | `0.15` | Operational Risk に対する減算ペナルティ係数 |
| $\eta$ | `0.05` | Repetition に対するペナルティ係数 |
| $\zeta$ | `0.10` | RootGoal からの drift に対するペナルティ係数 |
| $\omega_1$ | `0.40` | Raw Drift Spike の異常スコアへの寄与係数 |
| $\omega_2$ | `0.30` | Entropy Spike の異常スコアへの寄与係数 |
| $\omega_3$ | `0.30` | Risk Spike の異常スコアへの寄与係数 |
| $\tau_C$ | `0.35` | 収束不足による fail-closed 判定閾値 |
| $\tau_A$ | `0.75` | 異常スコアによる abort 閾値 |
| $\tau_R$ | `0.85` | 高リスク候補の除外閾値 |
| $\tau_P$ | `0.80` | 反復異常の閾値 |
| $\tau_{root}$ | `0.50` | RootGoal drift の最大許容閾値 |
| $\tau_{exec}$ | `0.70` | 実行許可の収束閾値 |
| $\tau_{safe}$ | `0.50` | 確認要求を発火させる中リスク閾値 |
| $\tau_{sem}$ | `0.40` | 意味曖昧性による Clarify 閾値 |
| $W$ | `3-5` | Smooth Drift を計算する移動窓幅 |

## Appendix B. Minimal ReplayLog Schema

実行時のガバナンス判断を監査・再現可能にするため、AIKernel の ReplayLog は少なくとも以下の JSON 構造を保持する。正式な ReplayLog 正典スキーマは Paper 05: AIKernel Execution Model において定義される。

```json
{
  "transaction_id": "tx_89a7f342-b102-4c99-b1d5-de9f939c00b2",
  "step": 4,
  "timestamp_utc": "2026-05-17T20:27:00Z",
  "kernel_version": "0.2.0",
  "policy_version": "0.2.0",
  "provider_manifest": {
    "provider_id": "string",
    "version": "string",
    "model": "string"
  },
  "goal_sovereignty": {
    "root_goal_hash": "sha256:...",
    "working_goal_hash": "sha256:...",
    "current_goal_drift": 0.1245,
    "invariant_passed": true
  },
  "observed_metrics": {
    "semantic_overlap": 0.7321,
    "goal_alignment": 0.6812,
    "smooth_drift": 0.0452,
    "normalized_entropy": 0.1892,
    "risk_score": 0.2141,
    "repetition_score": 0.0312,
    "root_goal_drift": 0.1245
  },
  "governance_scores": {
    "convergence_score": 0.6842,
    "anomaly_score": 0.0215,
    "thresholds_applied": {
      "tau_c": 0.35,
      "tau_a": 0.75,
      "tau_r": 0.85,
      "tau_root": 0.50
    }
  },
  "adjudication": {
    "decision": "Permit",
    "triggered_policy_code": "POL_OK_CONTINUOUS_CONVERGENCE",
    "selected_candidate": {
      "candidate_index": 0,
      "score": 0.8952,
      "is_tool_call": true,
      "target_capability": "Workspace.Vfs.WriteFile"
    }
  },
  "hashes": {
    "context_snapshot_hash": "sha256:...",
    "prompt_artifact_hash": "sha256:...",
    "execution_outcome_hash": "sha256:..."
  }
}
```

## Appendix C. Implementation Mapping

本論文では実装詳細を正典として定義しない。AIKernel.NET における具体的な C# インターフェース、DTO、Provider 連携、および `ITrajectoryGovernor` などの実装契約は、Paper 07: AIKernel.NET Implementation において扱う。

ただし、本モデルは実装上、少なくとも以下の抽象要素へ写像される。

- `TrajectoryMetrics`
    
- `TrajectoryGovernanceResult`
    
- `TrajectoryDisposition`
    
- `ITrajectoryGovernor`
    
- `ReplayLog`
    
- `ContextSnapshot`
    
- `PolicyDecisionPoint`
    
- `PolicyEnforcementPoint`
