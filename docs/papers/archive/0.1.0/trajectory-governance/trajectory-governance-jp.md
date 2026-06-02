---
id: trajectory-governance-ja
title: AIKernel: Trajectory Governance Model に基づく Semantic Context OS の形式的ガバナンス仕様
subtitle: 確率的 AI エージェントに対する決定論的実行制御のための数学的基盤
lang: ja
slug: /docs/theory/trajectory-governance.ja
updated: 2026-05-16
published: 2026-05-16
version: "0.1.0"
edition: "初版（ROM / First Public Release）"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
status: "Stable (ROM)"
tags:
  - AIKernel
  - Trajectory Governance
  - Semantic Context OS
  - ガバナンス
  - 形式仕様
  - 実行時安全性
toc: true
sidebar_position: 1
summary: >
  AIKernel の Trajectory Governance モデルを形式的ガバナンス仕様として定式化し、
  確率的 AI エージェントに対する決定論的な実行制御境界を与える理論的基盤を示す。
rom: true
---

# AIKernel: Trajectory Governance Model に基づく Semantic Context OS の形式的ガバナンス仕様

## 確率的 AI エージェントに対する決定論的実行制御のための数学的基盤

## 1. 研究背景 (Introduction)

人工知能、特に大規模言語モデル（LLM）の急速な発展に伴い、計算機システムのパラダイムは大きな転換点を迎えている。LLM を中核に据えた「AI エージェント」システムは、確率的な推論プロセスや非構造化データの処理を扱う性質上、非決定的な振る舞いを伴う。これは、エンタープライズレベルの採用において信頼性や再現性の確保という大きな課題を生み出している。

AIKernel プロジェクトは、AI の実行環境に監査可能な制御境界を与える枠組みとして発足した。本研究では、AIKernel の中核となる「Trajectory Governance（軌跡ガバナンス）」モデルを、ガバナンス判断のための形式的に仕様化されたフレームワークとして定式化する。これにより、コンテキスト汚染や目標の漂流（Goal Drift）といった課題が理論的にどのように緩和されるかを明示し、実行時の安全性を担保するための基盤を提供する。

## 2. 用語定義 (Terminology)

後述する理論モデルを理解するため、AIKernel アーキテクチャにおける中核概念を以下に定義する。

- **PDP / PEP / PIP**: 標準的なアクセス制御モデルの要素。PDP（Policy Decision Point）はポリシー判断点、PEP（Policy Enforcement Point）はその判断を実行境界で強制する点、PIP（Policy Information Point）は判断に必要な属性・コンテキスト・リスク情報を提供する情報点である。
    
- **SGP パイプライン**: Structure（構造化推論）、Generation（表現生成）、Polish（最終研磨）を分離し、論理構造の決定と表現生成を異なる段階として扱う AIKernel の推論分離モデルである。
    

## 3. 安全性の境界 (Safety Boundary)

本モデルは、確率的ジェネレーターである LLM 自体を完全に決定論的なものへと変換し得ると主張するものではない。また、セマンティックな推論の収束が、出力される事実の正確性（factual correctness）を無条件に保証するとも主張しない。

AIKernel は代わりに、確率的な推論プロセスの周囲に監査可能な制御境界を与え、決定論的な境界（Safety Boundary）を定義するアプローチをとる。モデルの出力は、ガバナンスレイヤーがセマンティックな関連性、目標との整合性、運用上のリスク、反復性、不確実性、およびリプレイ可能性を評価するまで、未信頼の状態（Untrusted）として扱われる。

この意味において、Trajectory Governance は LLM 内部のモデルセーフティを代替するものではない。むしろ、モデルによって提案された状態遷移を、実行可能なシステム状態として受け入れるか否かを決定するための、カーネルレベルの制御平面（コントロールプレーン）として機能するものである。

## 4. 問題設定 (Problem Statement)

現在の自律的 AI システムは、主に以下の理論的課題を抱えている。

1. **セマンティックな境界の欠如**: アテンション機構の性質上、コンテキスト汚染やインジェクション攻撃に対して脆弱である。
    
2. **状態遷移の不透明性**: 思考の反復や不確実性の増大、推論の逸脱を追跡・制御する計算モデルが不足している。
    
3. **目標の漂流（Goal Drift）**: 推論過程で当初のユーザーの意図から徐々に逸脱していく現象を構造的に防ぐ手段がない。
    
4. **安全性の非決定性**: ポリシーが自然言語で記述されがちで、システムの挙動予測が困難である。
    

本研究は、AI の推論過程を「連続的な軌跡（Trajectory）」として数学的にモデル化し、システムの安定性と安全性を評価するための実装可能な有力なアプローチを定義する。

## 5. Trajectory Governance と数学的モデル (Mathematical Formalization)

本モデルで導入する収束スコアや数学的定式化は、正しさや安全性そのものを証明するものではない。これは、観測された推論軌跡が、設定された統治パラメータの下で十分に安定・整合・低リスクであるかを判定するための運用上のポリシースコアである。

### 5.1 LLM推論の形式化とガバナンス介入の4段階モデル

AIKernel は LLM の推論プロセスを、内部状態 $K_t$（コンテキスト）とモデルパラメータ $\theta$ に依存する確率的遷移関数として形式化する。

$$x_{t+1} \sim p(x \mid x_t, \theta, K_t)$$

この確率的遷移プロセスに対し、AIKernel は以下の「ガバナンス介入の4段階モデル」を適用し、非決定的な軌跡を制御する。

1. **Propose**: LLM/SLM が確率的に次のアクションや状態 $x_{t+1}$ を提案する。
    
2. **Evaluate**: ガバナンスレイヤーが提案状態に対するリスクや収束性を計算する。
    
3. **Decide**: PDP は、提案された状態遷移を、決定論的関数に従って **Permit**、**Deny**、**AskConfirmation**、**Clarify**、または **Abort** のいずれかの制御された判断状態へ分類する。
    
4. **Transition**: 許可された場合のみ、システム状態として遷移が確定する。
    

### 5.2 Semantic Ellipsoid の幾何学的性質と実装近似

軌跡上の各状態やプロンプトは、単一の点ベクトルではなく、不確実性を含む意味的楕円体（Semantic Ellipsoid）として幾何学的に表現される。実装可能性を高めるため、高次元空間における完全な共分散行列 $\Sigma$ の計算コストを回避し、対角共分散近似（Diagonal Covariance Approximation）を採用する。

- **中心と分散推定**: 概念のサンプル群 $s_1, \dots, s_N$ に対し、意味的中心 $\mu$ と各次元 $j$ の対角分散 $\sigma_j^2$ を推定する。ここで、サンプル群は「温度 $T>0$ における LLM の複数回サンプリングによる候補群」や「K-shot に含まれる文脈ベクトル群」など、実行時または事前計算された文脈的バリエーションとして取得される。
    
- **マハラノビス近似距離**: 状態 $x$ と中心 $\mu$ の距離は、安定化定数 $\epsilon$ を用いて次のように計算される。
    
    $$d(x, \mu) = \sqrt{ \sum_{j=1}^n \frac{(x_j - \mu_j)^2}{\sigma_j^2 + \epsilon} }$$
    
- **楕円体の体積**: 定数係数を除けば $k^d \sqrt{\det(\Sigma)}$ に比例する。AIKernel ではこれを厳密な体積そのものとしてではなく、不確実性の相対指標（Operational Metric）として用いる。
    

### 5.3 逸脱の3軸定義

推論軌跡の逸脱は、以下の3軸で定義される。

1. **勾配 $\Delta_t$**: 連続する状態空間でのベクトルの変化率。
    
2. **方向ベクトル**: 推論が目標に向かって進んでいるかを示す余弦類似度。
    
3. **正規化エントロピー $\tilde{H}_t$**: トークン出力確率などから算出される不確実性の度合い。スコアの有界性を満たすため、語彙サイズ $|V|$ に基づく最大エントロピー $\log |V|$ で除算した正規化エントロピー $\tilde{H}_t = H_t / \log |V|$ を用いる。
    

### 5.4 収束スコア $C_t$ と異常スコア $A_t$ の定義

観測されたメトリクスを統合し、ガバナンス判断の中核となる2つのスコアを算出する。各スコアは正規化され、常に $[0, 1]$ の範囲に収まる。

- **収束スコア $C_t$ (Convergence Score)**:
    
    軌跡が目標に向かって安定的に進んでいるかを示す。
    
    $$C_t = \mathrm{Clamp}\left( \alpha \cdot \text{SemOverlap}_t + \beta \cdot \text{GoalAlign}_t - \gamma \cdot \text{SmoothDrift}_t - \delta \cdot \tilde{H}_t - \rho \cdot \text{Risk}(a_t) - \eta \cdot \text{Rep}_t - \zeta \cdot \text{GoalDrift}_t, 0, 1 \right)$$
    
- **異常スコア $A_t$ (Trajectory Anomaly Score)**:
    
    収束スコアとは独立して、局所的な危険なスパイク（急激な逸脱やエントロピーの爆発）を検知する。
    
    $$A_t = \mathrm{Clamp}\left( \omega_1 \cdot \text{RawDriftSpike}_t + \omega_2 \cdot \text{EntropySpike}_t + \omega_3 \cdot \text{RiskSpike}_t, 0, 1 \right)$$
    

### 5.5 連続閾値割れと Fail-Closed 条件

系の安全性評価のための Governance Cost Function / Safety Index として、$V_t = 1 - C_t$ を定義する。AIKernel は、$V_t$ が力学系における厳密な Lyapunov 関数または Barrier Certificate であるとは主張しない。これは、観測可能なガバナンスメトリクス上に定義された運用上の評価関数である。したがって、$V_t$ の低下傾向は運用上の安定化の兆候として扱えるが、数学的な大域安定性を証明するものではない。

軌跡が安全境界を逸脱した場合、システムは以下の論理式に従い、直ちに実行を遮断（Abort）する。

$$\text{Abort} = (C_t < \tau_C) \lor (A_t > \tau_A) \lor (\text{Risk}(a_t) > \tau_R) \lor (\text{Rep}_t > \tau_P) \lor (\text{GoalDrift}_t > \tau_{root})$$

さらに、一時的なゆらぎによる誤検知を防ぐため、時間窓 $W$ ステップ中 $m$ 回以上 $C_t < \tau_C$ となった場合にも Fail-Closed 原則に従い停止状態へとフォールバックする。

## 6. 目標ガバナンスとコンテキスト主権 (Goal Governance and Context Sovereignty)

目標の漂流（Goal Drift）を防ぐため、AIKernel は目標状態を「コンテキスト主権（Context Sovereignty）」の下で統治し、以下の階層モデルにより監査可能な制御境界を与える。

- **RootGoal / WorkingGoal の計算的整合性**:
    
    - **RootGoal ($g_{root}$)** は、ユーザーの根本的な意図を表し、不変（immutable）として定義される。
        
    - **WorkingGoal ($g_{work,t}$)** は、ステップごとの解釈であり、実装上は $g_{root}$ の許容意味領域への射影、または閾値判定によって制約される。
        
    - 目標の逸脱は、$\text{drift} = 1 - \cos(g_{root}, g_{work,t})$ として定義される。
        
    - WorkingGoal の更新要求は、drift が設定された閾値未満に留まる場合のみ許可され、それ以外の場合は棄却される。
        

## 7. セキュリティモデルとリスク評価 (Security Model and Risk Assessment)

### 7.1 初期リスク評価とキャリブレーション

AIKernel は、推論の実行判断において標準的なアクセス制御アーキテクチャ（PDP / PEP / PIP モデル）を採用する。初期のリスク評価は、カテゴリベースかつ決定論的に行う。ファイル削除などの破壊的操作やエントロピーの高い推論結果には高い基礎リスクスコアが割り当てられる。

運用を通じて蓄積される ReplayLog に基づく統計的キャリブレーションは、将来的に重み調整へ利用できるが、ハードポリシー制約（Fail-Closed原則など）を置き換えてはならない。

### 7.2 Decision Rule と Candidate Ranking

LLMから複数のアクション候補が提案された場合、PDP は以下のルールセットに基づいて候補をランキングし、最終決定を下す。

- **Candidate Ranking**: リスクが $\tau_R$ 以上のアクションは事前に除外される。
    
    候補アクションごとのランキングスコアは、現在の軌跡状態を共有しつつ、アクション固有の意味一致度とリスクを用いて次のように定義する。
    
    $$\text{Score}(a) = \alpha \cdot \text{SemOverlap}(q,a) + \beta \cdot \text{GoalAlign}_t - \gamma \cdot \text{SmoothDrift}_t - \delta \cdot \tilde{H}_t - \rho \cdot \text{Risk}(a) - \eta \cdot \text{Rep}_t - \zeta \cdot \text{GoalDrift}_t$$
    
    $$A_{safe} = \{ a \in \text{Candidates} \mid \text{Risk}(a) < \tau_R \}$$
    
    $$a^* = \arg\max_{a \in A_{safe}} \text{Score}(a)$$
    
    ただし、$A_{safe} = \emptyset$ の場合、$\arg\max$ は評価せず、Deny または Clarify を返す。
    
- **Decision Rule**: 選択された $a^*$ に対し、以下の優先順位で最終的なガバナンス判断を下す。
    
    ここで、$\tau_{safe} < \tau_R$ とする。$\tau_{safe}$ を超えるが $\tau_R$ 未満のリスクは、即時拒否ではなく確認要求として扱う。
    
    ```
    if Abort == true then Return(Abort)
    else if SemOverlap_t < τ_sem then Return(Clarify)
    else if Risk(a*) > τ_safe then Return(AskConfirmation)
    else if C_t ≥ τ_exec then Return(Permit)
    else Return(Deny)
    ```
    

|**Decision**|**意味**|
|---|---|
|**Permit**|実行許可|
|**AskConfirmation**|中リスクのため人間確認要求|
|**Clarify**|意味曖昧のため明確化要求|
|**Deny**|ポリシー上の拒否|
|**Abort**|Fail-Closed による停止|

## 8. 理論的保証と証明スケッチ (Theoretical Guarantees and Proof Sketches)

前述の数学的モデルとガバナンスアーキテクチャに基づき、AIKernel が提供する制御の理論的保証を以下に示す。

### Assumptions（前提条件）

- **A1**. 全てのガバナンスメトリクス（スコア、ペナルティ等）は正規化され $[0, 1]$ の範囲に有界である。
    
- **A2**. ガバナンスにおける重み係数と判定閾値は、単一の決定ステップ内において固定である。
    
- **A3**. アクションに対する運用リスク $R(a)$ は、副作用を伴う実行の前に必ず計算・評価される。
    
- **A4**. ガバナンス判定を行う関数（$I_{Pdp}$）は完全に決定論的である。
    
- **A5**. LLM（またはSLM）はアクションを提案（Propose）することはできるが、それらを自ら実行（Execute）する権限を持たない。
    
- **A6**. ツールやシステムコールは、PDPの判定結果が $\text{Decision} = \text{Permit}$ の場合のみ実行される。
    

### Theorem 1. 計算可能な評価関数の正規化プロパティ（Normalization Property of Scoring Function）

収束スコア $C_t$ および異常スコア $A_t$ は、最終的なガバナンス出力として、常に $0 \le C_t \le 1$ および $0 \le A_t \le 1$ を満たす。

**(Proof Sketch)**: 各入力パラメータ（関連性、リスク、正規化エントロピー等）は前提A1により $[0, 1]$ に有界であるため、これらの線形結合は有限値として計算される。ただし、収束スコアにはリスクや反復などの負のペナルティ項を含むため、未加工の線形結合値が必ずしも $[0, 1]$ に収まるとは限らない。ガバナンス判断の事前条件として最終段で $\mathrm{Clamp}(x, 0, 1)$ を適用することにより、システムへ渡される最終的な $C_t$ および $A_t$ が常に $[0, 1]$ に正規化されることを仕様として保証する。

### Theorem 2. Fail-Closed Safety（Fail-Closed の安全性）

ガバナンス評価によって $\text{Abort} = \text{true}$ と判定された場合、いかなる提案アクション $a$ も実行されない（$\neg \text{Exec}(a)$）。

**(Proof Sketch)**: 前提A5およびA6により、実行権限は PEP に隔離されている。PEP の実装は、PDP からの判定結果が Permit 以外であった場合、Abort 優先規則を適用し、副作用を伴う API 呼び出しのコードパスを実行境界で遮断するようアーキテクチャレベルで規定されている。

### Theorem 3. Risk Threshold Exclusion（リスク閾値による排除）

算出されたリスクが設定閾値以上のアクション（$R(a) \ge \tau_R$）は、安全な実行候補集合 $A_{safe}$ に決して含まれない。

**(Proof Sketch)**: 前提A3により実行前に全てのアクション候補に対して $R(a)$ が計算される。評価フェーズにおいて、集合 $A_{safe}$ の構築フィルターは $A_{safe} = \{ a \in \text{Proposals} \mid R(a) < \tau_R \}$ として定義されているため、条件を満たさないアクションは $\arg\max$ による最終選択の評価対象から決定論的に排除される。

### Theorem 4. Root Goal Sovereignty Invariant（RootGoal 主権の不変性）

$g_{root}$ が immutable である限り、$g_{work,t}$ の更新は常にセマンティック空間上の許容領域内に留まる。

**(Proof Sketch)**: 任意の時点 $t$ における新たな WorkingGoal の更新要求に対し、システムは $\text{drift} = 1 - \cos(g_{root}, g_{work,t+1})$ を評価する。$\text{drift} \le \tau_{drift}$ である場合のみ状態遷移が許可され、それ以外は棄却される。システムは更新の度に不変な $g_{root}$ との絶対距離を評価し、空間的許容領域（Direct State Constraint）を逸脱する状態遷移を PEP により実行境界で遮断する。したがって、更新規則の定義により $g_{work,t}$ は常に $g_{root}$ の $\tau_{drift}$ 近傍空間内に拘束される。

### Theorem 5. Deterministic Governance Replay（ガバナンス判定の決定論的再現）

同一の実装バージョン、数値精度（implementation-defined numerical precision）、Embedding model、ポリシー、閾値、重み、および入力記録が固定されている場合、Governance Decision（ガバナンス判断）は再現可能である。

**(Proof Sketch)**: ガバナンス判定関数は前提A2およびA4により決定論的である。ReplayLog には実行時のメタデータが不変のまま記録されており、外部要因や確率的なばらつきは、記録されたリプレイ入力によって制御される。指定された環境条件と数値計算の精度が一致する限り、同一の入力集合に対する純粋関数の合成として評価され、同一の判定結果を出力する。

### What These Guarantees Do Not Prove（これらの定理が証明しないこと）

AIKernel の理論モデルは堅牢なガバナンスを提供するが、以下の要素を数学的に証明するものではない。

- **LLM 出力の正しさ（Factual Correctness）**: 生成されたテキストが現実世界の事実に即しているか。
    
- **Embedding の意味的完全性**: ベクトル埋め込みが、人間の意図する「意味」を誤差なく100%捕捉しているか。
    
- **敵対的攻撃への堅牢性（Adversarial Robustness）**: 全ての未知のプロンプト・インジェクションを完全に防御できるか。
    

AIKernel が保証するのは、あくまで「実行遷移の許可条件の決定論性」であり、提案されたアクションが定義された安全境界と統治パラメータを遵守しているかを確実に評価・制御することである。

## 9. システムアーキテクチャと形式仕様化 (System Architecture and Formal Specification)

Trajectory Governance を実環境で機能させるため、以下のコンポーネントがアーキテクチャレベルで形式仕様化されている。

- **Context Isolation と Material Quarantine**: 情報のカテゴリ（推論、素材、表現）を厳密に分離し、外部データは必ず検疫プロセスを経て構造化された後にのみ推論コンテキストに統合される。
    
- **SGPパイプライン**: Structure / Generation / Polish を分離し、論理構造の決定と表現生成を異なる段階として扱う AIKernel の推論分離モデルである。推論処理を物理的に分離し、表現（文体など）が論理的推論を歪めることを防ぐ。
    

## 10. 実験・検証計画 (Experimental Validation Plan)

理論モデルの実装可能性を裏付けるため、以下の段階的な検証計画を定義する。

- **Phase 1: Connectivity**: CPUオンリーな軽量ローカルSLM（Bonsai-1.7B 等）を利用し、通信接続と構造化出力の安定性を検証する。
    
- **Phase 2: Candidate Generation**: 自然言語要求からコマンド候補を生成させ、リスク判定と候補フィルタリングの有効性をテストする。
    
- **Phase 3: Governance**: 提案された候補に対し、Fail-Closed ガバナンスや承認ルーティングが意図通りに動作するかを検証する。
    
- **Phase 4: Replay Calibration**: ReplayLog を用いて、各重みパラメータ（$\alpha, \beta, \gamma \dots$）および閾値（$\tau_C, \tau_R$ 等）を最適にキャリブレーションする。
    
- **Phase 5: Open-Weight Extension**: Transformers や vLLM などのオープンウェイトモデルで内部隠れ状態やロジットエントロピーを取得し、プロキシメトリクスとの相関を検証する。
    

## 11. 体系化された AIKernel 理論：セマンティック・コンテキスト OS

再構成された AIKernel 理論は、「セマンティック・カプセル化（隔離による汚染防止）」「宣言的ガバナンス（Trajectory と PDP による制御）」「リソースの抽象化と流動性（動的ルーティング）」の3本柱に集約される。これは、AI に特化した新しいオペレーティングシステムの形態を規定するものである。

## 12. 結語 (Conclusion)

AIKernel の Trajectory Governance モデルおよび形式的アーキテクチャの構築は、生成 AI の確率的・非決定的な性質に対し、計算機科学の伝統である「検証可能性」と「監査可能性」を導入する試みである。

Context Isolation、Semantic Ellipsoid、RootGoal の不変性、PDP/PEP アーキテクチャといった概念を相互に矛盾なく数学的制約として統合することで、本モデルはエンタープライズ AI システムにおける検証可能性を高めるためのロードマップとして機能する。AIKernel は、未来の自律的な AI 実行環境の安全性を支えるセマンティック OS としての、実装可能な有力なアプローチである。

---

### Appendix. ReplayLog の最小スキーマ (Minimal ReplayLog Schema)

実行時のガバナンス判断を監査・再現可能にするため、AIKernel の ReplayLog は少なくとも以下の JSON 構造を保持する。

JSON

```
{
  "DumpId": "uuid-string",
  "ExecutionTimestampUtc": "YYYY-MM-DDTHH:mm:ss.sssZ",
  "KernelVersion": "string",
  "Seed": "integer",
  "PipelineDefinitionHash": "sha256:...",
  "PromptArtifactHash": "sha256:...",
  "ProviderManifest": {
    "ProviderId": "string",
    "Version": "string"
  },
  "MaterialSnapshotHashSet": ["sha256:..."],
  "OrchestrationSnapshotHash": "sha256:...",
  "GovernanceDecisions": [
    {
      "Step": "integer",
      "ProposedAction": "string",
      "ConvergenceScore_Ct": "float",
      "AnomalyScore_At": "float",
      "RiskScore": "float",
      "Decision": "Permit | Deny | AskConfirmation | Clarify | Abort"
    }
  ],
  "ExecutionOutcomeHash": "sha256:..."
}
```
