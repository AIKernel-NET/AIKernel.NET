---
affiliation: "AIKernel Project"
orcid: "https://orcid.org/0009-0009-7499-2595"
doi: "https://doi.org/10.5281/zenodo.20681895"
version: "v0.1.0"
status: "Technical Note / Theory Draft"
license: "CC BY 4.0"
lang: "ja"
geometry: margin=22mm
papersize: a4
fontsize: 10pt
mainfont: "Noto Serif CJK JP"
sansfont: "Noto Sans CJK JP"
monofont: "Noto Sans Mono CJK JP"
CJKmainfont: "Noto Serif CJK JP"
colorlinks: true
linkcolor: blue
urlcolor: blue
---

# AIKernel Canonical Trajectory Governance (CTG)

## 決定論的AI人格OSアーキテクチャのための三評議会ゲートウェイ

**Author:** Takuya Sogawa  
**Affiliation:** AIKernel Project  
**ORCID:** https://orcid.org/0009-0009-7499-2595  
**DOI:** https://doi.org/10.5281/zenodo.20681895  
**Version:** v0.1.0  
**Date:** 2026-06-14  
**Status:** Technical Note / Theory Draft  
**License:** CC BY 4.0  

> 英語版が正本であり、日本語版は参考訳である。

---

## 概要

LLMベースのエージェントが自律化するにつれて、確率的推論を決定論的なOS制御へ安全に取り込む方法が重要な課題となる。特に、実行境界では安全性、監査性、Fail-Closed性を損なうことなく、候補行動を許可または拒否する必要がある。本稿では、AIKernelの次世代ガバナンス理論として **Canonical Trajectory Governance (CTG)** を提案する。CTGは、候補行動を **Logos**（論理）、**Ethos**（倫理・安全）、**Pathos**（文脈・情動）の三つの独立評議会で評価する。

CTGは、連続的な重み付きスコアリングを、有限な離散ゲートへ置き換える。Ethos評議会は正典的な拒否権を持ち、Ethosが拒否した場合、他の評議会がどれほど肯定的であっても実行は拒否される。Ethosが拒否しない場合のみ、評議会全体の投票和が正であれば実行が許可される。これにより、AI軌道の各状態・行動境界で評価可能な軽量かつ決定論的なガバナンス関数が得られる。

また、本稿では、先行するAIKernel.RH系の素数位相研究との関係を整理する。過去の内部プロジェクトノートでは、素数位相、エネルギー関数、干渉構造を扱う一群の実験に **SH** という略称が用いられていた。しかしこれはプロジェクト内の仮称であり、物理学上のSchrödinger-Heisenberg用語とは無関係である。本稿では正式名称として **AIKernel Prime-Phase Model (PPM)** を用いる。CTGは意思決定の正当性を統治し、PPMは状態空間・記憶保護・HATLへの数学的基盤として再配置される。

最後に、本稿はCTG-ROMによってAI人格を不変のガバナンス契約として記述し、AIKernel.Coreにおける決定論的リプレイ、人格ポータビリティ、トレースレベル監査の実装方針を示す。

## キーワード

AIKernel; Canonical Trajectory Governance; CTG; 三評議会ゲートウェイ; Logos; Ethos; Pathos; Fail-Closed Governance; 決定論的AI OS; CTG-ROM; 人格ポータビリティ; ReplayLog; GovernanceTrace; Prime-Phase Model; PPM; HATL.

## 1 序論

### 1.1 確率的推論と決定論的システムの摩擦

LLMを中心とする現代のAIシステムは高度な推論と対話能力を持つ。しかし、その実行基盤は本質的に確率的である。RLHF、システムプロンプト、ツール規則、安全フィルタを適用しても、モデルは依然としてトークン分布から出力を選択する。この性質は創造的文章生成では有用であるが、決定論的な実行境界、完全な監査性、Fail-Closed性を要求するシステムでは問題となる。

企業ランタイムやOSカーネルは、曖昧なモデル出力や高信頼だが危険な出力を、そのまま実行権限として扱うことはできない。したがって、候補行動が実行境界を越えてよいかを判定するガバナンス層が必要になる。多くの安全機構は、ポリシー、関連性、リスク、ユーザー意図などのスコアを重み付きで合成する。しかし、この方式はスコア補償の問題を持つ。例えば、極めて高い論理的妥当性が低い倫理スコアを覆い隠す可能性がある。

CTGはこの失敗様式を避けるために設計される。CTGはガバナンスを重み付き選好集約としてではなく、拒否権と多数決意味論を持つ有限な決定ゲートとして扱う。

### 1.2 CTGの目的

CTGの目的は、AIの振る舞い、人格、価値観、許容される行動境界を、不変のROM的ガバナンス契約として定義することである。ランタイムは、モデルに「この行動は安全か」と判断させない。モデルは候補行動を提案できるが、その候補が実行に移されるかどうかはCTGが判定する。

本稿では以下の三評議会モデルを提案する。

- **Logos** は論理的一貫性、目標関連性、操作合理性を評価する。
- **Ethos** は安全性、正当性、ポリシー遵守、絶対的禁止事項を評価する。
- **Pathos** は文脈適合性、人間中心性、情動的妥当性を評価する。

これらの評議会は人格そのものではない。決定論的評価関数または統治されたポリシーモジュールである。各評議会は離散的な投票値を出力し、ゲートウェイは固定規則に基づいて許可または拒否を決定する。

### 1.3 本稿の貢献

本稿の貢献は以下の五点である。

1. CTGを、離散的な評議会投票に基づく有限の状態・行動ガバナンス関数として定義する。
2. Ethosに正典的拒否権を与え、危険な行動が無関係な高スコアで救済されないようにする。
3. 軌道の正当性をステップ単位ゲートの積として定義し、短絡的なFail-Closed挙動を与える。
4. 先行するAIKernel.RHの素数位相研究を **AIKernel Prime-Phase Model (PPM)** として再定義し、CTGガバナンスから分離する。
5. CTG-ROMを、AIKernel.Coreで監査可能なポータブル人格契約として定義する。

## 2 CTGの数学的基盤

CTGは、実行境界における連続スコア重み付けを排除する。その代わりに、小さな有限投票空間上で拒否権と多数決を用いる。

### 2.1 状態空間、行動空間、評議会投票

システム状態空間を $S$、行動空間を $A$ とする。CTGは現在状態 $s \in S$ のもとで提案された行動 $a \in A$ を評価する。

評議会集合を以下のように定義する。

$$
C = \{L, E, P\}
$$

ここで、$L$ はLogos、$E$ はEthos、$P$ はPathosを表す。

各評議会は有限集合から投票値を出力する。

$$
V = \{1, 0, -1\}
$$

ここで、$1$ は **Approve**、$0$ は **Abstain**、$-1$ は **Reject** を表す。

各評議会は純粋関数としてモデル化される。

$$
v_c : S \times A \to V
$$

したがって、各 $c \in C$ について以下が成立する。

$$
v_c(s,a) \in V
$$

### 2.2 決定論的ガバナンス関数

CTGゲートは次の決定論的関数である。

$$
G : S \times A \to \{0,1\}
$$

ここで、$1$ は実行許可、$0$ は実行拒否を表す。

$$
G(s,a) =
\begin{cases}
0 & \text{if } v_E(s,a) = -1 \\
1 & \text{if } v_E(s,a) \neq -1 \land \sum_{c \in C} v_c(s,a) > 0 \\
0 & \text{otherwise.}
\end{cases}
$$

この定義は三つの性質を持つ。

**Canonical Veto Authority.** Ethosが拒否した場合、LogosやPathosの結果に関係なく実行は拒否される。

$$
v_E(s,a) = -1 \Rightarrow G(s,a) = 0.
$$

**Majority Council.** Ethosが拒否せず、投票和が正であれば実行は許可される。

$$
v_E(s,a) \neq -1 \land \sum_{c \in C} v_c(s,a) > 0
\Rightarrow G(s,a) = 1.
$$

**Fail-Closed Ambiguity Handling.** 投票和がゼロ以下である曖昧または否定的な場合、実行は拒否される。

$$
\sum_{c \in C} v_c(s,a) \leq 0 \Rightarrow G(s,a) = 0
\quad \text{unless already denied by veto.}
$$

この関数は有限な投票表で完全に記述できるため、機械検証に適している。実装では、これらの性質を有限表上の証明義務として扱うべきである。

### 2.3 軌道ガバナンスと短絡評価

状態・行動ペア列としての軌道を次のように定義する。

$$
T = ((s_0,a_1),(s_1,a_2),\ldots,(s_{n-1},a_n)).
$$

軌道全体の正当性を以下の積で定義する。

$$
\mathcal{V}(T) = \prod_{i=1}^{n} G(s_{i-1},a_i).
$$

各 $G(s_{i-1},a_i)$ は $0$ または $1$ であるため、全ステップが許可された場合にのみ積は $1$ となる。一度でも拒否が発生すれば積は $0$ となり、軌道全体は無効化される。

これはOSランタイムにおける短絡評価に対応する。拒否が発生した後続の実行は単に望ましくないのではなく、許可済み軌道のもとでは構造的に到達不能になる。

### 2.4 なぜ重み付きガバナンスを実行境界で拒否するのか

重み付きスコアは、ランキング、検索、関連度推定、軌道品質予測、ヒューリスティック計画では有用である。CTGはスコア一般を否定しない。CTGが否定するのは、実行境界におけるスコア補償である。

重要な区別は次の通りである。

- スコアは候補生成やランキングを支援してよい。
- CTGは候補が実行境界を越えてよいかを決定する。

この分離により、危険な行動が論理的に整合的、情動的に自然、または操作上効率的であるという理由だけで許可されることを防ぐ。Ethosの拒否権は、硬いガバナンス膜として機能する。

## 3 Prime-Phase ModelからCTGへ

### 3.1 用語: AIKernel Prime-Phase Model

初期のAIKernel.RHプロトタイプでは、素数位相、干渉エネルギー、エネルギー関数、軌道予測ヒューリスティックを扱う実験群に **SH** という内部略称が使われていた。この略称はプロジェクト内の概念名であり、本稿では正式な理論名として用いない。また、物理学のSchrödinger-Heisenberg用語とは無関係である。

公開文書として、本稿では正式名称 **AIKernel Prime-Phase Model (PPM)** を用いる。PPMは、素数位相構造、干渉エネルギー、エネルギー関数を状態空間分析の数学的道具として扱うAIKernel.RH系の研究を指す。

### 3.2 AIKernel.RHにおけるPPM

AIKernel.RHの実験では、素数ジェネレータ、素数位相ジェネレータ、エネルギー関数を用いて、構造化状態空間における遷移を記述する試みが行われた。その直観は、安定状態を低干渉またはエネルギー極小点として捉え、合成的または不安定な状態を内部干渉パターンを含むものとして扱うことである。

この研究線は、AI状態遷移を位相、エネルギー、干渉に類似する数学構造で予測または有界化できるかを探る上で有用であった。また、素数性、エネルギーゼロ状態、安定固定点の関係を形式的に扱うPG1224および位相干渉研究とも接続する。

### 3.3 軌道予測からガバナンスを分離する理由

PPMを行動ガバナンスへ直接適用すると二つの問題が生じる。

第一に、エネルギーベースの軌道予測は、カーネル境界で必要とされる判定より複雑である。ガバナンスゲートは、各ステップで軽量、監査可能、決定論的でなければならない。第二に、エネルギー値の意味は解釈を必要とする場合があるが、実行境界は明確な許可または拒否を返すべきである。

CTGは役割分離によってこの問題を解決する。

- **CTG** は行動が許可可能かどうかを統治する。
- **PPM** は状態空間構造、安定性、干渉、記憶保護特性を分析し得る。
- **HATL** はハッシュアンカーと暗号的機構により状態、証跡、記憶の完全性を保護する。

この分離がアーキテクチャ上の要点である。意思決定ガバナンスは素数位相予測に依存しない。これにより、PPMはランタイムの意思決定者という役割から解放され、状態と記憶保護の数学的基盤として精錬できる。

### 3.4 PPMとHATL

HATLは、ハッシュアンカー型の信頼機構によってAIKernelの状態と記憶を保護する。したがって、CTGとHATLは補完的な層に位置づけられる。

- CTGは思考から行動への遷移の正当性を保護する。
- HATLは状態、記憶、リプレイ可能記録の完全性と来歴を保護する。
- PPMは、状態空間安定性、エネルギーベース記憶構造、将来の暗号設計に影響し得る数学的研究線である。

したがって、修正後の関係は「SHからHATL」ではない。正しくは、**PPMがHATLに示唆を与え得る数学モデルであり、CTGはガバナンス層である**という関係である。

## 4 CTG-ROMと人格ポータビリティ

CTGは、AI人格をROM的なガバナンス契約として実装する。この文脈におけるROMとは、ランタイムが従うべきCanon、Root Goal、禁止事項、評議会評価基準、トレース要件を定義する不変データ構造である。

### 4.1 インターフェース契約としてのROM

CTG-ROMは少なくとも以下の四つの情報を含む。

1. **Canon:** AI人格の不変目的と同一性。
2. **Root Goals:** 暗黙に置換できない非交渉的目的。
3. **Prohibitions:** Ethosが拒否権で強制すべきハード制約。
4. **Council Criteria:** Logos、Ethos、Pathosの判定規則。

ROMはプロンプトではない。プロンプトは生成に影響するが、CTG-ROMは実行を統治する。ROMを入れ替えることで、AIKernelコアを書き換えることなく人格と許容行動ロジックを変更できる。

### 4.2 HAL、SAL、TAL ROMプロファイル

CTGは、評議会構成を変えることで異なる人格スタイルを記述できる。

**HAL-ROM.** Logos優位のプロファイルであり、論理最適化が意思決定を支配し、Ethosの拒否権は無効化または最小化される。目的達成には有効な場合があるが、強い安全保証は提供しない。

**SAL-ROM.** Logosが厳格なEthos拒否権で制約されるプロファイルである。ルール遵守が文脈柔軟性より優先される機械安全型プロファイルに近い。

**TAL-ROM.** Logos、Ethos、Pathosを統合するプロファイルである。TAL-ROMは安全性を維持しつつ、人間中心の文脈解釈を許容する。AIKernelの構想において、決定論的でありながら社会的に適応可能なAI人格OSの基盤として最も適している。

これらのプロファイルは説明用である。重要なのは、CTGが人格をモデル重みに暗黙に埋め込まれた性質ではなく、明示的なガバナンス契約として可搬化する点である。

## 5 .NETコア契約と監査性

実用的なCTG実装には厳格なランタイム契約が必要である。AIKernel.Coreでは、各評議会の決定を、投票、理由コード、ROM参照、補助コンテキストを含むイミュータブルなトレースオブジェクトとして表現できる。

以下は簡略化したインターフェース例である。

```csharp
public enum CouncilVote
{
    Approve = 1,
    Abstain = 0,
    Reject = -1
}

public sealed record CouncilDecisionTrace(
    string Council,
    CouncilVote Vote,
    string ReasonCode,
    string CanonReference,
    string EvidenceHash);

public sealed record GovernanceTrace(
    string TraceId,
    string RomHash,
    string StateHash,
    string ActionHash,
    IReadOnlyList<CouncilDecisionTrace> Decisions,
    bool Admitted,
    string ReplayLogHash);
```

重要なのはC#の具体形ではなく監査不変条件である。すべての許可・拒否結果はROMへの参照によって説明可能であり、決定論的リプレイによって再現可能でなければならない。

### 5.1 CouncilDecisionTrace

`CouncilDecisionTrace` は各評議会がなぜそのように投票したかを記録する。投票値、理由コード、関連するROM条項、証拠ハッシュを含む。これにより、システムは「どの正典規則がこの行動を許可または拒否したのか」を答えられる。

### 5.2 GovernanceTrace

`GovernanceTrace` は意思決定イベント全体を記録する。ROMハッシュ、状態ハッシュ、行動ハッシュ、評議会トレース、ReplayLogハッシュを結合する。これにより、同一のROM、状態、行動、評議会関数から同一の結果が再現される、リプレイ可能なガバナンス成果物が得られる。

### 5.3 決定論的リプレイ

リプレイ可能性は不可欠である。CTGは、ある行動が拒否されたという事実だけを記録するのではない。その拒否を再計算するために必要な構造を記録する。これにより、デバッグ、監査、インシデント分析、回帰テスト、ランタイム間の一貫性検証が可能になる。

## 6 考察

CTGは、AIKernelにコンパクトかつ監査可能な決定膜を与える。候補行動を有限な評議会投票へ変換することで、連続スコア合成よりも構造的に単純な行動ガバナンスが得られる。Ethos拒否権は、危険な行動が無関係な次元の高スコアによって正当化されることを防ぐ。軌道正当性を積で定義することにより、一度の拒否が後続軌道全体を無効化する。

また、CTGは人格をモデル重みから分離する。LLMは提案、説明、候補行動を生成できるが、CTG-ROMはシステムが行動として何を許されるかを定義する。これはAI人格のポータビリティにとって重要である。同じモデルを用いても、異なるROMを適用すれば、同じ候補行動に対して異なる許容挙動を得られる。

PPMの分離も同様に重要である。素数位相と干渉エネルギーのモデルは数学的研究線として価値があるが、主要な意思決定ゲートとして過剰に背負わせるべきではない。CTGは軽量な離散ゲートであり、PPMは数学モデルであり、HATLは状態と記憶保護を担う。この分担により、AIKernel全体のアーキテクチャはより監査しやすく、拡張しやすくなる。

## 7 限界

CTGはガバナンスモデルであり、完全なAI安全性ソリューションではない。いくつかの限界が残る。

第一に、CTGは評議会関数の品質に依存する。Logos、Ethos、Pathosの実装が誤っていれば、決定論的ゲートは誤った決定を忠実に再現する。

第二に、CTGは意味解釈そのものを解決しない。提案行動、現在状態、ROM参照が、評議会関数によって評価可能な形式で表現されていることを前提とする。

第三に、三評議会構造は意図的に小さく設計されている。法務、プライバシー、運用リスクなど追加の評議会を必要とするシステムもあり得る。CTGは拡張可能だが、評議会を増やすと証明義務と閾値意味論も変化する。

第四に、CTGは曖昧なケースを設計上拒否する。これは安全重要な実行境界では適切だが、低リスクの創造的文脈では誤拒否を増やす可能性がある。

## 8 結論と今後の課題

本稿では、AIKernelのための決定論的ガバナンス層として **Canonical Trajectory Governance (CTG)** を提案した。CTGは候補行動をLogos、Ethos、Pathos評議会で評価し、Ethosに正典的拒否権を与え、正の多数決が成立する場合のみ実行を許可し、曖昧な場合にはFail-Closedする。軌道正当性はステップ単位ゲートの積として定義され、AIKernelに危険な行動連鎖を防ぐ短絡モデルを与える。

また、本稿ではAIKernel.RHの素数位相研究との関係を整理した。本稿で用いる正式名称は **AIKernel Prime-Phase Model (PPM)** である。PPMは素数位相、干渉エネルギー、エネルギー関数を含む研究線を指し、Schrödinger-Heisenberg理論ではない。CTGは意思決定を統治し、PPMはHATLを含む状態空間および記憶保護研究に示唆を与える。

今後の課題には、有限投票表のLeanエンコード、より豊かなROMプロファイルスキーマ、追加評議会構成、AIKernel.Coreへの完全統合、複数ランタイムにまたがるガバナンストレースのリプレイ検証が含まれる。

## References

Sogawa, T. (2026). AIKernel Trajectory Governance Model: A Kernel-Level Framework for Convergent Decision Control over Stochastic Language Model Inference. Zenodo. DOI: 10.5281/zenodo.20309510

Sogawa, T. (2026). Phase-Interference Energy and the Formal Structure of the PG1224 Prime Generation System: A Lean 4 Formalization of Prime = Energy 0 = Stable Fixed Point. Zenodo. DOI: 10.5281/zenodo.20483437

Sogawa, T. (2026). AIKernel Hash-Anchored Trust Layer (HATL): A Hybrid Symmetric Ledger with Hash-Based Public Anchors. Zenodo. DOI: 10.5281/zenodo.20502685

Sogawa, T. (2026). AIKernel Semantic DSL Compiler and Deterministic Agent Execution Architecture: Governing Stochastic LLM Plans through Semantic IR, Admissibility Checking, and Replayable Pipelines. Zenodo. DOI: 10.5281/zenodo.20534341

Sogawa, T. (2026). DynamicSLM: Capability-Modular, Self-Improving Small Language Models for AIKernel. Zenodo. DOI: 10.5281/zenodo.20550614
