---
id: aikernel.phase1.paper02.vfs-architecture-semantic-storage.ja
title: "AIKernel Phase-1 Paper 02: VFS Architecture and Semantic Storage Model"
subtitle: "決定論的AIOSガバナンスのための仮想ファイルシステムとケイパビリティ抽象"
version: 0.2.0
status: canonical-draft
issuer: takuya.sogawa@aikernel.net
license: CC-BY-4.0
lang: ja
created: 2026-05-20
last_updated: 2026-05-24
author: "Takuya Sogawa"
author_orcid: "https://orcid.org/0009-0009-7499-2595"
date: 2026-05-24
doi: "10.5281/zenodo.20307891"
canonical_id: "aikernel.phase1.paper02.vfs-architecture-semantic-storage"
canonical_language: en
companion_languages:
  - ja
series: "AIKernel / AIOS Phase-1 Specification Series"
phase: "Phase 1"
part: "Part I-2: Knowledge Substrate"
paper_no: 2
resource_type: publication
publication_type: technical-note
target: "AIKernel.NET Core / VFS"
proposed_namespace: "AIKernel.Abstractions.Vfs"
stability: experimental-non-normative
repository: "https://github.com/AIKernel-NET/AIKernel.NET"
website: "https://aikernel.net/"
tags:
  - aikernel
  - aios
  - architecture
  - phase-1
  - knowledge-substrate
  - vfs
  - semantic-storage
  - capability-contracts
  - deterministic-governance
owners:
  - Takuya Sogawa
is_translation_of: "aikernel.phase1.paper02.vfs-architecture-semantic-storage.en"
translation_status: companion-translation
---

# AIKernel Phase-1 Paper 02: VFS Architecture and Semantic Storage Model

## 決定論的AIOSガバナンスのための仮想ファイルシステムとケイパビリティ抽象

**著者:** Takuya Sogawa  
**ORCID:** https://orcid.org/0009-0009-7499-2595  
**Version:** v0.2.0  
**Publication date:** 2026-05-24  
**DOI:** https://doi.org/10.5281/zenodo.20307891  
**License:** Creative Commons Attribution 4.0 International (CC BY 4.0)  
**Canonical language:** English  
**Companion translation:** Japanese  
**Series position:** AIKernel / AIOS Phase-1 Specification Series, Part I-2: Knowledge Substrate  
**Target:** AIKernel.NET Core / VFS  
**Proposed namespace:** `AIKernel.Abstractions.Vfs`  
**Stability:** Experimental / Non-normative  

---

## Abstract

大規模言語モデル（LLM）に基づく自律型AIシステムは、ファイル、リポジトリ、オブジェクトストア、データベース、ログ、スナップショットなど、多様な永続化面と相互作用するようになっている。ストレージアクセスが単なるパス文字列や不透明なURIとして扱われる場合、ガバナンス層は、操作が読み取り、書き込み、削除、照会、リプレイのいずれであるかを、Provider へ到達する前に確実に識別できない。その結果、未対応操作は遅延した実行時失敗として現れ、危険な操作は評価前に可変インフラへ到達する可能性がある。

本稿は、AIKernel / AIOS Phase-1 仕様シリーズにおける第二の知識基盤論文として、**VFS Architecture and Semantic Storage Model** を定義する。Paper 01 で定義された ROM モデルを拡張し、ROM ドキュメント、コンテキストスナップショット、会話履歴、リプレイアーティファクトを保存・復元するためのストレージ境界を定式化する。

中心となる提案は **Formal Storage Capability Theory** である。ストレージアクセスは、`NotSupportedException` を投げる可能性のある実行時メソッド群としてではなく、型システム上に明示される **Capability Contracts** として扱われる。あるセッションが特定の能力を実装していない場合、その操作は単に後で拒否されるのではない。VFS 境界を通過する有効な経路を持たない **non-routable operation** として扱われる。

本モデルは、semantic storage paths、bounded storage topology、type-level truthfulness、リプレイのための deterministic read-only projection、および fail-closed capability gating を導入する。これらにより、AIKernel の知識資産を安全に永続化し、決定論的ガバナンスと監査品質のリプレイ意味論を支えるストレージ基盤を定義する。

## Keywords

AIKernel; AIOS; Virtual File System; VFS; Semantic Storage; Capability Contracts; Type-Level Truthfulness; Non-Routable Transition; Bounded Storage Topology; Deterministic Replay; Read-Only Projection; Audit-Grade Execution; Fail-Closed; Knowledge Substrate; AI Operating System

---

## 1. Introduction

AIエージェントは、永続状態の上で動作するようになっている。プロジェクトファイルを読み、生成物を書き込み、ログを調査し、メモリスナップショットを読み込み、知識ドキュメントを取得し、外部ストレージProviderと対話する。従来のアプリケーションでは、ストレージエラーは実装上の通常の例外として扱われることが多い。しかし、自律型AIシステムでは、ストレージアクセスそのものがガバナンス境界の一部となる。

問題は、ファイルが存在するかどうかだけではない。より本質的な問題は、実行前に、どのストレージ遷移が許容され、どの遷移がポリシーによって禁止され、どの遷移がProviderまたはセッションの能力不足によって物理的に不可能なのかを、システムが判定できるかどうかである。

AIKernel は、ストレージを単なる補助的なユーティリティ層ではなく、統治された意味論的境界として扱う。Virtual File System（VFS）は、複数のストレージProviderを抽象化しつつ、読み取り、書き込み、削除、ナビゲーション、照会、リプレイの各能力を区別する。これにより、ストレージ操作は副作用が発生する前にガバナンス層から観測可能になる。

本稿は、AIKernel / AIOS Phase-1 仕様シリーズの **Paper 02** として、VFS Architecture and Semantic Storage Model を定義する。Paper 01 は、ROMドキュメントとKnowledge Snapshotを不変の知識単位として定義した。本稿は、それらの知識単位が保存され、取得され、射影され、リプレイされるストレージ境界を定義する。

基本原則は単純である。

> ストレージ能力は実行前に明示されなければならない。未対応の遷移は、dispatch後に拒否されるのではなく、non-routable でなければならない。

## 2. Problem Statement: Late Runtime Failure and Storage Entropy

AIシステムがファイルシステムや外部ストレージProviderと相互作用するとき、いくつかの構造的問題が発生する。

### 2.1 Late Runtime Failure

ストレージバックエンドによって、サポートされる操作は異なる。ローカルファイルシステムは読み取り、書き込み、削除、ディレクトリ探索、メタデータ更新を提供できるかもしれない。一方、オブジェクトストアはその一部しか提供しないかもしれない。リプレイProviderは意図的に読み取り専用の観測だけを提供する。

従来の抽象では、未対応の操作が「存在はするが実行時に例外を投げるメソッド」として表現されることがある。決定論的AIガバナンスにおいて、これは遅すぎる。削除操作がProviderへ到達した後で、その削除が物理的に可能かつポリシー上許容されるかを判断するのでは、境界が弱すぎる。

### 2.2 Opaque Capabilities

LLMは、ファイルを開く、ドキュメントを書き換える、キャッシュを削除する、ディレクトリを走査する、リポジトリを検索する、といったストレージ操作をアクション候補として提案し得る。ストレージ能力が不透明である場合、Policy Decision Point（PDP）は、その操作がdispatch前に許容可能かを確実に判断できない。

不透明な能力は、試行錯誤による権限発見をシステムに強いる。AIKernel はこのパターンを拒否する。権限は、実行前に契約として可視でなければならない。

### 2.3 Storage Entropy and Side-Effect Surfaces

無制限の可変ストレージは、制御不能な副作用面を生み出す。パスやURIを単なる文字列として扱うと、その対象が ROM 領域、リプレイアーカイブ、可変ワークスペース、シークレットストア、外部副作用境界のどこに属するのかという意味が失われる。

この曖昧さは storage entropy を増大させる。決定論的ガバナンスシステムは、ストレージエントリを統治された意味論的ゾーンへ割り当て、能力境界を明示することで、そのエントロピーを減衰させる必要がある。

## 3. Design Goals

VFSモデルは、以下の設計目標に基づく。

1. **Capability-Based Interface Segregation.** Read、Write、Delete、Navigate、Query は、未対応メソッドではなく、能力を持つインターフェースとして表現される。
2. **Pre-dispatch Verification.** 必要な能力は副作用の発生前に検証される。権限または経路が存在しない場合、操作は fail-closed で拒否される。
3. **Provider Abstraction.** 物理ストレージの差異はProvider Adapterの背後に隠蔽されるが、その能力は隠蔽されてはならない。
4. **Semantic Storage.** パスとエントリは、ゾーン、来歴、ポリシー制約、リプレイ状態などのガバナンス上重要な意味を保持する。
5. **Deterministic Replay Support.** 過去の実行コンテキストと知識資産は、安定した参照と読み取り専用リプレイ射影を通じて復元可能でなければならない。

## 4. Scope and Boundary

本稿は、AIKernel / AIOS Phase-1 アーキテクチャにおける **storage boundary governance** を担当する。ROM同一性そのものは Paper 01 の責務である。完全な推論前許容性ポリシーは Paper 03 の責務である。ランタイムの収束監視は Paper 04 の責務である。

| Layer / Paper | Entropy Role in Governance |
|---|---|
| ROM (Paper 01) | Knowledge entropy reduction |
| VFS (Paper 02) | **Storage boundary governance** |
| Governance (Paper 03) | Execution admissibility |
| Trajectory (Paper 04) | Runtime boundedness |
| Semantic Compiler (Phase 2) | Semantic entropy reduction |

したがって、VFS層が答える問いは、次のように限定される。

> ある storage provider、session、path、operation が与えられたとき、副作用が発生する前に、その操作をストレージ境界へ安全にルーティングできるか。

## 5. Semantic Storage Model

AIKernel の VFS アーキテクチャは、単なるバイトストアではない。ROMドキュメント、スナップショット、リプレイ記録、コンテキスト素材を含む統治された知識資産のための semantic storage substrate である。

従来のストレージと AIKernel の semantic storage は次のように異なる。

| Traditional Storage | AIKernel Semantic Storage |
|---|---|
| Byte-addressed | Semantically addressed |
| Opaque paths | Governed semantic paths |
| Mutable file system | Replayable substrate |
| Provider-specific behavior | Capability-declared behavior |
| Late runtime failure | Pre-dispatch fail-closed evaluation |

Governed semantic path は単なる文字列ではない。それは、namespace、provider identity、zone、provenance、policy context、replay status などのガバナンス上重要な意味へ解決される。これにより、AIKernel はストレージ操作を恣意的なファイル操作ではなく、統治された状態遷移として扱える。

## 6. Formal Storage Capability Theory

### 6.1 VFS Session State

VFSセッションの状態は次のように定義される。

```text
S_vfs = <Provider, Auth, Cap, Sigma>
```

ここで、

- `Provider` は物理的または論理的なストレージProviderの識別子である。
- `Auth` は認証済みセッションコンテキストである。
- `Cap` はセッションが公開する静的能力の集合である。
- `Σ` は観測可能なストレージエントリ状態の集合である。

### 6.2 Semantic Admissibility Boundary

Capability は単なる権限フラグではない。AIKernel において、それは execution topology constraint である。すなわち、ある遷移が VFS 境界を通過可能かどうかを決定する。

システムポリシーによって許可される能力空間を `C_allowed` とすると、VFSセッションは次を満たす必要がある。

```text
Cap(S_vfs) ⊆ C_allowed
```

システムは操作を次の3種類に区別する。

| Operation class | Meaning |
|---|---|
| Admissible | 能力が存在し、ポリシー評価へ進める操作。 |
| Prohibited | 物理的には可能だが、ポリシーにより拒否される操作。 |
| Non-routable | セッションに能力がなく、有効な経路が存在しない操作。 |

この区別は重要である。Prohibited operation はガバナンスポリシーによって拒否される。Non-routable operation は、そもそもアーキテクチャ上の遷移経路が存在しないため拒否される。

### 6.3 Non-Routable Transition Model

未対応の操作は遅延した実行時失敗として扱われない。それらは物理的またはアーキテクチャ上到達不能な遷移として扱われる。

操作 `op` について経路が存在しない場合、状態遷移関数は直ちに fail-closed な停止状態を返す。

```text
Route(op) = ∅ => delta_op(S_vfs, path) = S_halt
```

これは特定のプログラミング言語ランタイムに関する保証ではない。これはアーキテクチャ上の要件である。未対応操作はProvider dispatch前、副作用発生前に拒否されなければならない。

### 6.4 Bounded Storage Topology

VFS は、非構造なパス階層ではなく、有界なストレージトポロジーとして統治される。

| Topology zone | Semantic purpose |
|---|---|
| Immutable zones | ROMおよびその他の不変知識資産。 |
| Replay-only zones | 監査と再構成のための履歴記録。 |
| Mutable zones | 明示的な書き込み権限を与えられたランタイムワークスペース。 |
| Query zones | 有界な照会意味論を持つ検索・インデックス領域。 |
| External side-effect boundaries | 書き込みが外部システムへ影響する領域。 |

各ゾーンは異なるガバナンスプロファイルを定義する。たとえば、replay-only zone は読み取り能力を公開してよいが、リプレイ中に書き込みや削除能力を公開してはならない。

### 6.5 Type-Level Truthfulness

VFSアーキテクチャの中核不変条件は **Type-Level Truthfulness** である。

```text
Implemented Interface ⇔ Physically Realizable Operation
```

Provider は、実際には実行できない操作に対するインターフェースを実装してはならない。通常の未対応能力ケースにおいて、メソッドを実装した上で `NotSupportedException` を投げることは、本モデルでは契約違反である。

これはスタイル上の純粋性ではない。目的は、ストレージ境界をガバナンス層に対して誠実にすることである。

## 7. Governance and Security Considerations

VFS層は、AIKernel Governance と連携し、副作用が発生する前にストレージ安全性を強制する。

| Threat | Mitigation |
|---|---|
| Unauthorized mutation | Capability gating and pre-dispatch verification. |
| Replay contamination | Deterministic read-only projection. |
| Path traversal | Governed semantic paths and bounded topology. |
| Provider spoofing | Provider identity contracts and signed manifests. |
| Capability confusion | Type-level truthfulness and interface segregation. |

LLM が削除コマンドを提案したとしても、対象セッションが `IDeletableVfsSession` を公開していなければ、その操作は non-routable である。Providerへ送信されず、後から失敗することもない。これにより、ストレージ権限は観測可能なガバナンス事実となる。

## 8. Determinism and Replayability

決定論的リプレイには、安全なストレージ状態の射影が必要である。リプレイの目的は、元の副作用を再実行することではない。元の判断が行われた時点の証跡と文脈を再構成することである。

そのため、AIKernel は **Deterministic Read-Only Projection** を定義する。リプレイモードでは、元のストレージProviderは、読み取りと観測能力のみを公開するProviderとして再マウントまたは表現される。

| Runtime execution | Replay execution |
|---|---|
| Mutable transitions may be allowed. | Observational transitions only. |
| Side effects may occur under governance. | Side effects are quarantined. |
| Provider capabilities reflect live authority. | Provider capabilities reflect replay authority. |

これにより、リプレイが本番データを変更したり、ログを改変したり、新たな外部副作用を作り出したりすることを防ぐ。

## 9. Implementation Architecture

本モデルは、`AIKernel.Abstractions.Vfs` における capability-bearing interfaces として自然に写像される。

- `IVfsProvider`: 認証済みセッションを生成し、Provider identity を宣言する。
- `IVfsEntryInfo`: 共通のエントリメタデータを表現する。
- `IReadableVfsFile`: 読み取り可能なファイル内容を表現する。
- `IWritableVfsFile`: 書き込み可能なファイル内容を表現する。
- `INavigableVfsDirectory`: ディレクトリ列挙能力を表現する。
- `IReadableVfsSession`: 読み取り操作を公開する。
- `IWritableVfsSession`: 書き込み操作を公開する。
- `IDeletableVfsSession`: 削除操作を公開する。
- `IQueryableVfsSession`: 有界な照会操作を公開する。

Provider は複数の能力を公開してよい。ただし、実際に実現できる能力のみを誠実に公開しなければならない。

## 10. Limitations

本アーキテクチャにはいくつかの限界がある。

1. **分散整合性の独立保証はしない。** VFS は意味論的なストレージ境界を定義する。分散トランザクション、オブジェクトストア整合性、ネットワーク分断挙動を単独で解決するものではない。
2. **能力の粒度とアクセス制御境界。** 初期 VFS モデルは、read、write、delete、navigate、query などの大粒度能力を意図的に公開する。特定ディレクトリ配下のみ書き込み可能、特定属性を持つ利用者のみ実行可能、といった細粒度の認可は、上位のポリシー評価に属する。この意味で、ABAC や XACML 型のポリシーシステムは PDP/PEP 層の機構として扱い、VFS はそれらが評価に用いる誠実なセッション能力とセマンティックストレージ事実を提供する。
3. **Provider honesty requirement。** 本モデルは、Provider が能力を誠実に公開することを前提とする。より強い保証には、Provider identity contracts、signed manifests、testing、attestation が必要となる。
4. **Semantic path design。** 本モデルは、規律あるパス設計と名前空間設計に依存する。設計の悪い名前空間は、依然として曖昧なガバナンス境界を生む。

## 11. Relationship to Other Phase-1 Papers

本稿は、AIKernel の知識・データ層における物理的および意味論的なストレージ境界を定義する。

- **Paper 01: ROM Format and Knowledge Snapshot Model** は、VFS を通じて保存・取得される統治された知識単位を定義する。
- **Paper 03: Pre-Inference Admissibility Governance** は、提案されたストレージ操作が実行前に許容可能かを評価する。
- **Paper 04: Trajectory Governance Model** は、ストレージ操作が VFS とガバナンスポリシーによって既に有界化されていることを前提とする。
- **Paper 05 / Paper 07: Execution and Implementation** は、実行状態の永続化、会話スナップショット、リプレイアーカイブに VFS 抽象を利用する。

## 12. Conclusion

AIKernel VFS Architecture は、ストレージアクセスを best-effort な実行時抽象ではなく、明示的な能力境界として定義する。Type-level truthfulness、capability-bearing interfaces、non-routable transitions、bounded storage topology、deterministic read-only replay projection により、ストレージ副作用がガバナンス境界を越えて漏れ出すことを防ぐ。

本稿は、AIKernel knowledge substrate のストレージ側を確立する。Paper 01 で定義された ROM モデルと合わせて、本稿は後続の Phase-1 論文が構築する admissibility governance、trajectory governance、execution control、delegation、implementation、unified AIOS architecture の基盤となる。

## References

1. Dennis, Jack B., and Earl C. Van Horn. "Programming Semantics for Multiprogrammed Computations." *Communications of the ACM*, vol. 9, no. 3, 1966, pp. 143-155. DOI: 10.1145/365230.365252.
2. Lampson, Butler W. "Protection." *Proceedings of the Fifth Annual Princeton Conference on Information Sciences and Systems*, 1971, pp. 437-443.
3. Levy, Henry M. *Capability-Based Computer Systems*. Digital Press, 1984.
4. Tanenbaum, Andrew S., and Herbert Bos. *Modern Operating Systems*. 4th ed., Pearson, 2014.
5. Hu, Vincent C., David Ferraiolo, Rick Kuhn, Adam Schnitzer, Kenneth Sandlin, Robert Miller, and Karen Scarfone. *Guide to Attribute Based Access Control (ABAC) Definition and Considerations*. NIST Special Publication 800-162, 2014. DOI: 10.6028/NIST.SP.800-162.
6. OASIS. *eXtensible Access Control Markup Language (XACML) Version 3.0*. OASIS Standard, 22 January 2013.
7. Fowler, Martin. "Event Sourcing." martinfowler.com, 2005.
8. Chen, Peter M., and Brian D. Noble. "When Virtual Is Better Than Real." *Proceedings of the 8th Workshop on Hot Topics in Operating Systems (HotOS VIII)*, 2001, pp. 133-138.
9. Sogawa, Takuya. "Interface-Led Architecture (ILA): A Software Development Methodology for the AI Era, Validated by the AIKernel Execution Model." Zenodo, 2026. DOI: 10.5281/zenodo.20290614.
10. Sogawa, Takuya. "AIKernel Phase-1 Paper 01: ROM Format and Knowledge Snapshot Model." Zenodo, 2026. DOI: 10.5281/zenodo.20306539.
