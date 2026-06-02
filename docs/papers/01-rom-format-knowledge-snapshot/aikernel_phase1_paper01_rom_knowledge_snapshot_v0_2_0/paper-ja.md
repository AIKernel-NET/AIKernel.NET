---
id: aikernel.phase1.paper01.rom-format-knowledge-snapshot.ja
title: "AIKernel Phase-1 Paper 01: ROM Format and Knowledge Snapshot Model"
subtitle: "決定論的AIOSガバナンスのための不変知識基盤"
version: 0.2.0
status: canonical-draft
issuer: takuya.sogawa@aikernel.net
license: CC-BY-4.0
lang: ja
created: 2026-05-20
last_updated: 2026-05-23
author: "Takuya Sogawa"
author_orcid: "https://orcid.org/0009-0009-7499-2595"
date: 2026-05-23
doi: "10.5281/zenodo.20306539"
canonical_id: "aikernel.phase1.paper01.rom-format-knowledge-snapshot"
is_translation_of: "aikernel.phase1.paper01.rom-format-knowledge-snapshot.en"
translation_status: companion-translation
series: "AIKernel / AIOS Phase-1 Specification Series"
phase: "Phase 1"
part: "Part I-1: Knowledge Substrate"
paper_no: 1
resource_type: publication
publication_type: technical-note
target: "AIKernel.NET Core / ROM"
proposed_namespace: "AIKernel.Abstractions.Rom"
stability: experimental-non-normative
repository: "https://github.com/AIKernel-NET/AIKernel.NET"
website: "https://aikernel.net/"
tags:
  - aikernel
  - aios
  - architecture
  - phase-1
  - knowledge-substrate
  - rom
  - knowledge-snapshot
  - deterministic-governance
owners:
  - Takuya Sogawa
---

# AIKernel Phase-1 Paper 01: ROM Format and Knowledge Snapshot Model

## 決定論的AIOSガバナンスのための不変知識基盤

**著者:** Takuya Sogawa  
**ORCID:** https://orcid.org/0009-0009-7499-2595  
**Version:** v0.2.0  
**Publication date:** 2026-05-23  
**DOI:** https://doi.org/10.5281/zenodo.20306539  
**License:** Creative Commons Attribution 4.0 International (CC BY 4.0)  
**正本言語:** English  
**日本語版の位置づけ:** Companion translation  
**シリーズ上の位置づけ:** AIKernel / AIOS Phase-1 Specification Series, Part I-1: Knowledge Substrate  
**Target:** AIKernel.NET Core / ROM  
**Proposed namespace:** `AIKernel.Abstractions.Rom`  
**Stability:** Experimental / Non-normative  

---

## Abstract

大規模言語モデル（LLM）に基づく自律的AIシステムでは、推論コンテキストに投入される知識の品質、同一性、出自が極めて重要になる。多くの既存システムでは、プロンプト、指示、検索された文書、ポリシー断片が、最終的に非構造化文字列として連結される。この prompt-as-string パターンは柔軟である一方、同一性、出自、再現性、ガバナンスを弱める。

本稿は、AIKernel / AIOS Phase-1 仕様シリーズの最初の知識基盤論文として、**ROM Format and Knowledge Snapshot Model** を定義する。ROM、すなわち **Relation-Oriented Markdown** は、不変かつ統治可能な知識単位として扱われる。これは単なるMarkdown記法ではない。AIKernelにおいてROMは、決定論的知識スナップショット、意味的同一性、関係トポロジー、署名検証、再現可能なコンテキスト再構成を導出する単位である。

本稿の中心提案は **Formal Knowledge Identity Theory** である。正準化を **Entropy Rejection Layer**、すなわち表現揺らぎを持つテキストから正準知識状態への明示的射影として定義する。正準化規則の範囲内で、2つのROM文書が同じ正準状態へ射影され、同じセマンティックハッシュを生成する場合、それらは操作上同一であるとみなされる。本モデルは、自然言語意味論の一般的同値性を解くものではない。統治されたAIシステムのための決定論的同一性境界を定義するものである。

本モデルは、Causal Semantic Identity、有界な関係トポロジー、Fail-Closedな参照解決、正準知識状態に対する署名検証、決定論的コンテキスト再構成を導入する。これらは、後続のPhase-1論文で扱われるストレージ、許容性ガバナンス、軌道ガバナンス、実行、委譲、参照実装、統合アーキテクチャの前提となる知識基盤を形成する。

## Keywords

AIKernel; AIOS; Relation-Oriented Markdown; ROM; Knowledge Snapshot; Semantic Hash; Causal Semantic Identity; Deterministic Governance; Replayable Context; Prompt Governance; Knowledge Graph Governance; Fail-Closed; Content Addressing; AI Operating System

---

## 1. Introduction

LLMベースのシステムは、単なるテキスト生成器ではなく、自律的または半自律的なソフトウェアシステムの構成要素になりつつある。文書を検索し、指示を消費し、ツールを実行し、アクションを委譲し、メモリを更新する。このようなシステムでは、プロンプトが何を述べているかだけでなく、**どの知識が使われたか**、**それがどこから来たか**、**署名されているか**、**どのように参照されたか**、**同じコンテキストを後から再構成できるか** が重要になる。

従来のプロンプトエンジニアリングは、これらを単一の非構造化バッファへ畳み込むことが多い。プロンプトには、ルール、例、検索結果、ツール説明、ユーザー意図、隠れたシステム指示などが含まれるが、一度連結されると、それらの境界は失われる。境界が失われれば、出自、信頼、トポロジー、再現性、アクセス制御を強制することは難しくなる。

AIKernelは、この問題をオペレーティングシステムの観点から扱う。OSでは、実行コード、メモリページ、ファイルハンドル、権限、プロセス境界は構造化されたリソースであり、任意の文字列ではない。同様に、AI Operating System において知識は、制御不能なテキスト塊ではなく、統治された基盤でなければならない。

本稿は、その基盤単位としてROMを定義する。ROM文書は、同一性、メタデータ、本文、関係参照、任意の暗号学的署名を持つ構造化知識成果物である。複数のROM文書は、有界な知識トポロジーとして解決され、決定論的な知識スナップショットへ組み立てられる。このスナップショットは、後続のガバナンス層において推論の安定した事前条件として使用される。

## 2. Problem Statement: Prompt-as-String の限界

prompt-as-string パラダイムは、コンテキスト構築を文字列連結として扱う。実装は容易だが、複数の構造的問題を生む。

### 2.1 表現揺らぎによる同一性の喪失

空白、改行形式、YAMLキー順序、不可視文字、非意味的フォーマット変更は、バイトレベルのハッシュを変化させる。純粋にバイト単位でアドレス指定するシステムでは、操作上等価な知識成果物が無関係なものとして扱われる可能性がある。一方、非構造化プロンプトでは、大きなバッファの中に意味のある変更が隠れ、安定した論理同一性を得にくい。

AIKernelは、単純なバイト同一性でも、制約のない自然言語類似性でもない、統治された同一性モデルを必要とする。そのためROMの同一性は、正準化、すなわち正準知識状態への制御された射影によって定義される。

### 2.2 出自の喪失

動的に連結されたプロンプトでは、次の問いに答えにくい。

- この指示を書いたのは誰か。
- この文書はいつ署名されたか。
- どのトラストアンカーが使われたか。
- 過去の推論にどのバージョンのルールが参加したか。
- リプレイされたコンテキストにはどの知識断片が含まれていたか。

出自がなければ、AIシステムは強い監査可能性や決定論的リプレイを提供できない。

### 2.3 参照の不確実性とトポロジー障害

プロンプト断片は、他の文書、ポリシー、例、ツール、メモリ項目を参照することが多い。これらの参照が、有界深度、循環検出、Fail-Closed動作なしに動的解決される場合、知識グラフは不安定になる。

欠損参照は重要なポリシーを静かに取り除く可能性がある。循環参照は制御不能な展開を生む可能性がある。汚染された参照は信頼できない知識を注入する可能性がある。これらは単なるパースエラーではなく、ガバナンス上の失敗である。

## 3. Design Goals

ROM Format and Knowledge Snapshot Model には4つの設計目標がある。

1. **決定論的な知識同一性。** ROM文書は、正準状態から導かれる安定した操作上の同一性を持つ。
2. **出自の保持。** 著者、バージョン、署名、信頼メタデータが知識単位に結び付けられる。
3. **有界なトポロジー。** 関係解決は非巡回性、有界深度、Fail-Closed動作を強制する。
4. **再現可能なコンテキスト再構成。** 過去の推論コンテキストは、バージョン化された知識スナップショットから再構成可能でなければならない。

これらにより、AIコンテキスト構築は、プロンプト連結から統治された知識組み立てへ移行する。

## 4. Scope and Boundary

本稿は AIKernel / AIOS Phase-1 仕様シリーズの **Paper 01** であり、知識基盤を定義する。後続論文はこの基盤に依存するが、それぞれ別の責務を持つ。

| Phase / Paper | AIOSアーキテクチャにおける責務 |
|---|---|
| Paper 01: ROM Format and Knowledge Snapshot Model | 知識同一性とエントロピー減衰 |
| Paper 02: VFS Architecture and Semantic Storage Model | ストレージおよび移送境界の統治 |
| Paper 03: Pre-Inference Admissibility Governance | 推論前の実行許容性判定 |
| Paper 04: Trajectory Governance Model | ランタイム有界性と収束監視 |
| Papers 05-08 | 実行、委譲、参照実装、統合アーキテクチャ |
| Phase-2 Theory | Semantic Compilation Architecture |

本稿は完全なVFS、実行モデル、ツールリスクモデル、セマンティックコンパイラを定義しない。それらの後続層が依存する不変知識オブジェクトを定義する。

## 5. Core Model: Semantic-Addressed Knowledge

ROMは、GitやMerkle DAGのような内容アドレス指定システムに着想を得ているが、その考え方を統治されたAI知識へ適用する。Gitはオブジェクトレベルでcontent-addressableである。ROMは、明示された正準化規則の範囲内で、操作上のsemantic addressを導入する。

ROM文書は、生のテキスト表現そのものではなく、その表現から生成される正準知識状態によってアドレス指定される。この区別は重要である。AIガバナンスでは、意味的に重要な構造を保持しつつ、非意味的な表現揺らぎを棄却する必要があるからである。

本稿における **semantic-addressed** とは、次の操作的意味を持つ。

> ROM文書は、宣言された意味フィールド、関係トポロジー、出自を保持し、明示的に非意味的な揺らぎを棄却する正準表現から同一性が導かれるとき、semantic-addressedである。

これは自然言語意味論の一般定理ではない。統治された知識成果物のための決定論的エンジニアリング契約である。

## 6. Formal Definitions

### 6.1 ROM State

ROM文書の状態は次のように定義される。

$$
S_{rom} = \langle ID, \tau, M, B, R, \sigma \rangle
$$

ここで、

- $ID$ は文書の論理識別子である。
- $\tau$ は Prompt、Rule、Policy、Material、Specification などの意味型である。
- $M$ は通常YAML front matterで表現されるメタデータである。
- $B$ は本文である。
- $R$ は他のROM文書への関係参照集合である。
- $\sigma$ は正準状態に対する任意の暗号学的署名である。

### 6.2 Entropy Rejection Layer としての正準化

$f_{canon}$ を正準化関数とする。この関数は、表現揺らぎを持つROM入力を正準知識状態へ写像する。

$$
f_{canon} : S_{rom} \rightarrow S_{canon}
$$

正準化は **Entropy Rejection Layer** として定義される。これは非意味的な揺らぎを意図的に除去し、統治された同一性に寄与するフィールドを保持する。

| 保持されるもの | 棄却されるもの |
|---|---|
| 宣言された意味フィールド | 空白のみの揺らぎ |
| 関係トポロジー | 非意味的なフォーマットノイズ |
| 出自と署名関連メタデータ | 正準ソート後のキー順序不安定性 |
| 論理同一性 | 正準契約外の表現揺らぎ |

操作上の意味的等価性は次のように定義される。

$$
S_a \equiv_{rom} S_b \iff f_{canon}(S_a) = f_{canon}(S_b)
$$

$\equiv_{rom}$ は、無制約の自然言語同値性ではなく、ROMレベルの正準同値性として読むべきである。

### 6.3 Semantic Hash and Causal Semantic Identity

セマンティックハッシュは正準状態に対して計算される。

$$
h_{sem} = f_{hash}(f_{canon}(S_{rom}))
$$

このハッシュは **Causal Semantic Identity** を確立する。すなわち、正準化アルゴリズム、resolver version、trust configuration、参照された内容のバージョンが同一である限り、知識成果物の同一性は移送、リポジトリ再配置、リプレイを経ても安定する。

$$
ID(v_{local}) = ID(v_{remote}) = ID(v_{replay}) = f_{hash}(f_{canon}(v))
$$

これが決定論的リプレイに必要な同一性基盤である。

### 6.4 Bounded Knowledge Topology

ROM文書は他のROM文書を参照できる。文書 $d$ の関係集合を $R(d)$ とする。参照解決は以下の制約によって統治される。

| 制約 | ガバナンス上の目的 |
|---|---|
| 有向非巡回トポロジー | 循環参照による展開を防ぐ |
| 有界深度 | 無制限のコンテキスト拡張を防ぐ |
| 欠損参照のFail-Closed処理 | ポリシー喪失を静かに許容しない |
| バージョン化された解決 | リプレイ可能性を保持する |
| 信頼を考慮した包含 | 信頼できない知識注入を防ぐ |

形式的には、各参照について次が成り立つ必要がある。

$$
\forall r \in R(d), \quad Resolve(r) \neq \emptyset \land Depth(r) \leq D_{max}
$$

この制約を満たさないトポロジーは部分受理されない。Fail-Closedに遮断される。

### 6.5 形式的実行意味論への対応

ROM同一性は、形式的プログラム推論における不変条件に対応する。Hoare型推論との対応は次の通りである。

| Hoare型概念 | AIKernel governance concept |
|---|---|
| Precondition | 推論前のadmissibility |
| Invariant | ROM semantic identity と信頼された知識トポロジー |
| Postcondition | 有界なruntime state と replayable outcome |

この対応は字義通りの同型ではなく、設計上の対応である。AIKernelが、知識同一性を統治された実行の形式的事前条件として扱うことを示している。

## 7. Governance and Security Considerations

ROMは、同一性、出自、トポロジーが推論前に検査されるため、security-aware substrate となる。

署名付きROM文書は、正準化、セマンティックハッシュ計算、信頼されたアンカーに対する署名検証によって確認される。正準化は暗号学的ハッシュ衝突を不可能にするものではない。むしろ、無関係な空白やキー順序変更のような表現レベルの揺らぎが、無意味な同一性変化を作ってガバナンスを迂回することを防ぐ。

脅威モデルは次の通りである。

| 脅威 | 緩和策 |
|---|---|
| 改ざんされたポリシーテキストによるprompt injection | 署名付き正準セマンティックハッシュ検証 |
| Reference poisoning | Trust-aware かつ Fail-Closed なトポロジー解決 |
| 欠損ポリシー参照 | Fail-Closed な参照検証 |
| Replay tampering | Snapshot hash と Causal Semantic Identity |
| 隠れた表現揺らぎ | ハッシュ化・署名前の正準化 |

## 8. Determinism and Replayability

決定論的リプレイには、最終プロンプトを保存するだけでは不十分である。コンテキスト構築に参加したすべての知識単位の同一性を保存する必要がある。

$H_{snapshot}$ を知識スナップショットのハッシュ、$C_{runtime}$ をそのスナップショットから再構成されるruntime contextとする。AIKernelはhydrationを決定論的関数として定義する。

$$
C_{runtime} = \Phi_{hydrate}(H_{snapshot})
$$

この関数は、resolver version、canonicalization version、trust configuration、参照されたROM状態集合が固定されている限り決定論的である。これにより、コンテキスト構築は一時的な文字列組み立てから **Replayable Infrastructure** へ変わる。

## 9. Implementation Architecture

本理論モデルは、`AIKernel.Abstractions.Rom` 名前空間における最小限のC# interface contractへ写像される。

| Interface | Responsibility |
|---|---|
| `IRomDocument` | $S_{rom}$ を表す不変DTO |
| `IRomCanonicalizer` | $S_{canon}$ を生成し、表現エントロピーを棄却する |
| `ISemanticHasher` | 正準状態から $h_{sem}$ を計算する |
| `IRomSignatureVerifier` | 信頼アンカーに基づいて署名を検証する |
| `IRomValidator` | スキーマと不変条件を検証する |
| `IRelationResolver` | 参照を解決し、トポロジー制約を強制する |
| `IKnowledgeSnapshotBuilder` | 決定論的知識スナップショットを構築する |

最小パイプラインは次の通りである。

```text
Parse ROM
  -> Canonicalize
  -> Hash
  -> Verify signature
  -> Resolve relations
  -> Validate topology
  -> Build knowledge snapshot
  -> Hydrate runtime context
```

## 10. Limitations

本モデルにはいくつかの限界がある。

第一に、ROMレベルの同値性は完全な意味的同値性ではない。宣言された正準化契約の下での同値性である。自然言語の意味は、決定論的な正準形式よりも広い。

第二に、正準化は非意味的な表現エントロピーを意図的に破棄する。微細な空白やフォーマットの違いに依存するプロンプト挙動は保持されない。これは意図的である。AIKernelはそのような挙動を、統治可能なアーキテクチャではなく不安定なプロンプト操作として扱う。

第三に、セキュリティモデルは、正準化、ハッシュ化、署名検証、関係解決、trust-store管理の正しい実装に依存する。これらのコンポーネントのバグは、ガバナンス境界を損なう可能性がある。

第四に、有界トポロジーは、有用だが大きすぎる、または動的すぎる知識グラフを拒否する可能性がある。このトレードオフは意図的である。AIKernelは無制限のコンテキスト拡張よりも決定論的ガバナンスを優先する。

## 11. Relationship to Other Phase-1 Papers

Paper 01 は Phase-1 全体の知識基盤を提供する。

- Paper 02 は、ROM文書を永続化・取得するstorage and transport layerを統治する。
- Paper 03 は、信頼されたknowledge snapshotをadmissibility decisionの事前条件として利用する。
- Paper 04 は、安定したroot goalとgoverned contextをtrajectory monitoringの入力として利用する。
- Papers 05 and 06 は、ROM由来のcontractをexecution and delegationで利用する。
- Paper 07 は、AIKernel.NET implementationによってモデルを検証する。
- Paper 08 は、Phase-1 architectureを統合されたAIOS governance modelとしてまとめる。

## 12. Conclusion

ROM Format and Knowledge Snapshot Model は、AIKernel / AIOS Phase-1 の不変知識基盤を定義する。これは prompt-as-string によるコンテキスト組み立てを、同一性、出自、関係トポロジー、再現可能なスナップショット意味論を持つ統治された知識成果物へ置き換える。

正準化をentropy rejection layerとして定義することで、ROMは自然言語意味論の無制限な同値性を主張せずに、決定論的な操作上の同一性を確立する。セマンティックハッシュ、署名、有界な関係トポロジー、決定論的hydrationを組み合わせることで、ROMは後続のAIKernelガバナンス層がadmissibilityを強制し、推論軌道を監視し、過去のコンテキストを再構成するための基盤となる。

要するに、ROMはAIKernelが推論コンテキストを偶然できた文字列ではなく、統治されたシステムリソースとして扱うための知識基盤である。

## References / 参考文献

1. Hoare, C. A. R. "An Axiomatic Basis for Computer Programming." *Communications of the ACM*, vol. 12, no. 10, 1969, pp. 576-580. DOI: 10.1145/363235.363259.  
   （プログラム正当性、事前条件、事後条件、不変条件の理論基盤）
2. Cousot, Patrick, and Radhia Cousot. "Abstract Interpretation: A Unified Lattice Model for Static Analysis of Programs by Construction or Approximation of Fixpoints." *Proceedings of the 4th ACM SIGACT-SIGPLAN Symposium on Principles of Programming Languages*, 1977.  
   （意味空間の抽象化、有限な表現への射影、静的解析理論）
3. Merkle, Ralph C. "A Digital Signature Based on a Conventional Encryption Function." *Advances in Cryptology - CRYPTO '87*, Lecture Notes in Computer Science, vol. 293, 1988, pp. 369-378. DOI: 10.1007/3-540-48184-2_32.  
   （Merkle tree、ハッシュ構造、署名可能な不変識別子の理論基盤）
4. Git Project. "Git Internals - Git Objects." *Pro Git*, Git Documentation.  
   （Content-addressable storage と immutable object model の工学的実装例）
5. Sikka, Varin, and Vishal Sikka. "Hallucination Stations: On Some Basic Limitations of Transformer-Based Language Models." *arXiv:2507.07505*, 2025. DOI: 10.48550/arXiv.2507.07505.  
   （Transformer-based LLM の限界と、ハルシネーション問題の現代的補強）
6. IPFS Documentation. "Merkle Directed Acyclic Graphs (DAG)." IPFS Docs.  
   （Merkle DAG と content-addressed distributed storage の比較対象）
7. Sogawa, Takuya. "Interface-Led Architecture (ILA): A Software Development Methodology for the AI Era, Validated by the AIKernel Execution Model." Zenodo, 2026. DOI: 10.5281/zenodo.20290614.  
   （AIKernel シリーズ全体の上位アーキテクチャ原理）
