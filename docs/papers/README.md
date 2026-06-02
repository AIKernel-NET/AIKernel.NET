AIKernel / AIOS Phase‑1 Specification-Oriented Paper Series

1. シリーズ概要

**AIKernel / AIOS Phase‑1 Paper Series** は、生成AI（特に大規模言語モデル：LLM）の確率的・非決定的な性質に対し、計算機科学の伝統である「決定論的制御」「検証可能性」「監査可能性」を導入するためのオペレーティングシステム（AIOS）の基盤理論と形式仕様を体系化した論文シリーズです。

目的（AIOS の基盤仕様としての位置づけ）

本シリーズは、LLMを単なるテキスト生成器としてではなく、エンタープライズの自律型エージェントシステムにおける「安全な推論コンポーネント」として扱うためのアーキテクチャ基準を確立することを目的とします。プロンプトエンジニアリングなどの経験則に依存せず、実行境界、フェイルクローズ（Fail-Closed）、リプレイ可能性といったOSクラスのガバナンス機構を数学的・構造的に定義し、AIKernelアーキテクチャの公式な正典（Source of Truth）として位置づけられます。

対象読者

- **AIアーキテクト / システム設計者**: LLMを活用した安全で拡張性の高い自律エージェント基盤を設計する技術者。
- **安全性検証エンジニア / セキュリティ研究者**: プロンプトインジェクションや推論崩壊（ハルシネーション）の構造的な防御策を研究・実装する専門家。
- **形式手法・ソフトウェア工学研究者**: 確率的システムに対する決定論的統治モデルの数理化に関心のある研究者。

--------------------------------------------------------------------------------

2. 全体構造（Part I〜V）

本論文シリーズは、AIOSアーキテクチャの責務境界に従い、以下の5つのパート（Part I〜V）で構成されています。

- **Part I – Knowledge Substrate (知識基盤)** 非構造化データを監査可能な知能資産へと昇華させる、データフォーマットと永続化レイヤーの抽象化。
- **Part II – Governance Layer (統治層)** タスクの推論前受理（Admission）および推論軌跡（Trajectory）の安全性を監視・遮断する決定論的ゲート。
以下はFoundationに統合する方針に変更とする。（2026.05.30）
- **Part III – Execution and Delegation (実行と委譲)** 推論と表現を分離するパイプライン実行モデルと、能力ベースの外部委譲（ソルバー/モデルルーティング）機構。
- **Part IV – Reference Implementation (参照実装)** 形式仕様をC#型システムと依存性注入（DI）へマッピングした公式実装のアーキテクチャ。
- **Part V – Unified Architecture (統合アーキテクチャ)** すべてのコンポーネントを統合したSemantic Context OSとしての全体像。

--------------------------------------------------------------------------------

3. 各 Paper の説明（01〜08）

Paper 01: ROM Format & Knowledge Snapshot Model

- **Part**: Part I – Knowledge Substrate
- **役割**: AIKernel における不変の知識単位「ROM（Relation-Oriented Markdown）」の論理構造を定義し、セマンティックハッシュによる決定論的正準化と知識の出自（Provenance）を形式化する。
- **関係**: Paper 02（VFS）に保存される対象であり、Paper 03〜04（Governance）の署名・ハッシュ検証が成立するための絶対的な前提となる。

Paper 02: VFS Architecture & Semantic Storage Model

- **Part**: Part I – Knowledge Substrate
- **役割**: ROMや外部知識を永続化する仮想ファイルシステム（VFS）を定義する。実行時例外を排除し、アクセス権限を型システム上の能力（Capability）として静的に解決するモデルを提供する。
- **関係**: Paper 01に依存し、Paper 03〜07の推論・実行状態保存の依存境界として機能する。

Paper 03: Pre-Inference Admissibility Governance

- **Part**: Part II – Governance Layer
- **役割**: LLM推論前に、タスクの計算複雑性限界や破壊的副作用リスクを決定論的に評価し、安全な形への変換・委譲・拒否（Fail-Closed）を行うゲート群（Critical Operation Gate 等）を定義する。
- **関係**: Paper 04の前段に位置し、安全と評価されたタスクのみを軌道ガバナンスと実行パイプライン（Paper 05）へ引き渡す。

Paper 04: Trajectory Governance Model

- **Part**: Part II – Governance Layer
- **役割**: AIの推論過程を「連続的な軌跡」として扱い、意味的楕円体（Semantic Ellipsoid）や収束スコアを用いて数学的にモデル化する。軌道逸脱を検知し実行境界で遮断する枠組みを提供する。
- **関係**: Paper 03で受理されたタスクの推論中の安全性を担保し、Paper 05のトランザクション実行の可否を決定する。

以下はFoundationに統合する方針に変更とする。（2026.05.30）

Paper 05: AIKernel Execution Model

- **Part**: Part III – Execution and Delegation
- **役割**: 推論をStructure, Generation, Polish（SGP）に分離し、非決定的なプロンプト生成を決定論的な Inferences Transaction へと変換する実行境界とパイプラインを定義する。
- **関係**: Paper 03〜04（上位層）で許可されたタスクを受け取る実行基盤であり、外部解決が必要な場合はPaper 06（下位層）へ処理をシームレスに接続する。

Paper 06: Capability-Based Delegation Model

- **Part**: Part III – Execution and Delegation
- **役割**: タスクの要求複雑性とプロバイダーの多次元能力ベクトルを照合し、最適なLLMや決定論的ソルバー（Z3, Lean等）への動的ルーティングと委譲失敗セマンティクスを形式化する。
- **関係**: Paper 05 の推論パイプライン内でのルーティングと、Paper 03の事前ガバナンスによる「ソルバーへの迂回指示」を実現するための契約モデル。

Paper 07: AIKernel.NET Implementation

- **Part**: Part IV – Reference Implementation
- **役割**: AIOSの理論仕様をC#/.NET環境のソフトウェアアーキテクチャとして適応させる公式参照実装。Contracts-First設計と厳格な依存関係（Dependency Direction）を定義する。
- **関係**: Paper 01〜06で定義された数理モデル・抽象・ガバナンスを、実際のインターフェースとDI制約へマッピングする。

Paper 08: AIKernel Unified Architecture

- **Part**: Part V – Unified Architecture
- **役割**: Phase-1の全コンポーネント（Knowledge, Governance, Execution, Delegation, Implementation）を統合し、「Semantic Context OS」としての全体ビジョンとアーキテクチャの論理的整合性を総括する。
- **関係**: シリーズ全体の集大成となる統合論文であり、各ペーパーの結節点として機能する。

--------------------------------------------------------------------------------

4. 執筆方針

本論文シリーズの構築およびメンテナンスにおいては、以下の執筆方針を厳守します。

1. **スコープの分離**: 新しい理論やモデルは、関連する各Paper（01〜07）内でのみ定義・完結させ、他のPaperのスコープを侵さないこと。
2. **独立した DOI 論文**: Paper 01〜07 は、それぞれが自律したスコープと検証可能性を持つ学術的技術仕様であり、単独の論文としてDOI取得（Zenodo等）が可能な完成度を維持する。
3. **統合論文の制約**: Paper 08 はあくまで「統合（Unified Architecture）」を目的とする。Paper 08 内部で新規の理論やメカニズムを勝手に追加してはならない。

--------------------------------------------------------------------------------

5. ディレクトリ構成

各論文のMarkdownドラフト、および最終出力ファイルは以下の構造で管理されます。将来的なZenodoへのアップロード（ZIP切り出し）を想定し、論文単位でディレクトリを分離しています。

```
docs/
  papers/
    01-rom-format/
    02-vfs-architecture/
    03-preinference-admissibility/
    04-trajectory-governance/
```

--------------------------------------------------------------------------------

6. ライセンス・引用方法

本論文シリーズの成果物は、公式サイト（[aikernel.net](https://www.google.com/url?sa=E&q=https%3A%2F%2Faikernel.net%2F)）を通じて公開され、Zenodo にて DOI（Digital Object Identifier）が永続的に付与されます。学術論文や技術ドキュメントで本仕様を参照する場合は、該当する Paper の DOI を使用して引用してください。

Zenodo DOI の扱い

各ディレクトリの `README.md` および論文フロントマターには、Zenodo で発行された正式な DOI が記載されます。AIKernel のアーキテクチャ実装を拡張・フォークする際は、これらの DOI を正典（Source of Truth）として参照してください。

引用方法（BibTeX 例）

以下は、本シリーズの Paper を学術的に引用する際の BibTeX フォーマット例です。

```
@misc{aikernel2026preinference,
  author       = {Takuya Sogawa and AIKernel Project},
  title        = {AIKernel: Pre-Inference Admissibility Governance - Deterministic Admission Control and Critical Operation Governance Before LLM Inference},
  year         = {2026},
  version      = {0.1.0},
  publisher    = {Zenodo},
  doi          = {10.5281/zenodo.XXXXXXX},
  url          = {https://aikernel.net/papers/03-preinference-admissibility}
}

@misc{aikernel2026trajectory,
  author       = {Takuya Sogawa and AIKernel Project},
  title        = {AIKernel: Formal Verification and Mathematical Foundations of a Semantic Context OS based on the Trajectory Governance Model},
  year         = {2026},
  version      = {0.1.1},
  publisher    = {Zenodo},
  doi          = {10.5281/zenodo.YYYYYYY},
  url          = {https://aikernel.net/papers/04-trajectory-governance}
}
```