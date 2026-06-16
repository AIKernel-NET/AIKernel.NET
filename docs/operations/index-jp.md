---
updated: 2026-06-14
published: 2026-05-16
version: "0.1.1.1"
edition: "Release"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# AIKernel Operations — Index
このディレクトリは、AIKernel.NET の **運用（Operations）** に関する文書をまとめるための入口となる。
0.1.1 以降、この Operations 領域は公開パッケージの導入手順、
公式デモプログラムの読み進め方、リリース時の検証サーフェスも扱う。

Operations は、アーキテクチャ思想（architecture）や実装方針（design）、
ガイドライン（guideline）とは異なり、
**実際の運用・監視・リリース・障害対応・SLO 管理などの「実務手順（Runbook）」** を扱う領域である。

---

## Operations 文書一覧

### 1. [Migration Guide](MIGRATION_GUIDE-jp.md)（移行ガイド）
**ステータス:** Active
**現在の内容:**
- 契約（Interface / DTO / Enum）の破壊的変更を跨ぐ際の移行手順
- 変更点の分類（Breaking / Non-breaking）
- 互換性チェックと依存関係チェック
- バージョンアップ時のチェックリスト
- v0.0.3 → v0.0.4 の DSL、DSL ROM、History ROM、Kernel clock contract 抽出手順
- v0.0.4 → v0.0.5 の interface-only package のための contract-surface purity cleanup 手順
- v0.0.5 の external Capability module contract 準備
- v0.0.5 の DynamicSLM Model ABI / distillation offload contract 準備
- v0.0.5 の SeedSLM discipline、delegation、thought artifact、memory placement contract 準備
- v0.0.5 の HATL external cryptographic operator contract 準備
- v0.0.5 の governance admissibility replay と Semantic IR slot vocabulary
- v0.0.5 の Semantic Compilation DTO vocabulary
- v0.1.0 の MemoryRegion / MemoryMapper contract extraction
- v0.1.1 の NuGet、PyPI、Providers、WASM、Tools、CUDA、Demo を横断した同期パッケージライン検証
- v0.1.1.1 の additive domain contract surface と documentation policy alignment
- v0.1.1.1 は .NET / NuGet のみの package boundary とし、この validation line では PyPI package を作成しない
- v0.1.2 正典シリーズの release 前提: NuGet と PyPI の package family を同期して公開する
- v0.1.1.1 の CTG DTO / enum 正規化

package reference の更新や contract-layer dependency の検証時に、このガイドを参照する。

---

### 2. [Package Installation Guide](PACKAGE_INSTALLATION_GUIDE-jp.md)（パッケージ導入ガイド）
**ステータス:** Active
**現在の内容:**
- AIKernel OS サーフェスを起動する最短 3 コマンド
- contract、runtime、provider、tools、WASM、CUDA レイヤーの NuGet パッケージ一覧
- Python wrapper 利用者向けの PyPI パッケージ一覧
- `0.1.1.1` rule: .NET / NuGet package のみ更新し、PyPI package は `0.1.1` のまま維持する
- `0.1.2` assumption: 更新済み NuGet / PyPI package family を同期して公開する
- Provider の選び方とリポジトリ導線
- 0.1.1 のバージョン混在ルール

AIKernel パッケージを導入する場合や、パッケージファミリ境界を検証する場合に利用する。

---

### 3. [Demo Programs Guide](DEMO_PROGRAMS_GUIDE-jp.md)（デモプログラムガイド）
**ステータス:** Active
**現在の内容:**
- 最初に触るべきデモ: `AIKernel.Demo.CoreRuntime`
- CoreRuntime、Contracts、Control、Providers、StandardProviders、Tools、WASM、CUDA の 8 デモ構成
- リリース検証に使える dry-run 実行順序
- Python デモサーフェスの案内

AIKernel を実行可能な教材として学ぶ場合に利用する。

---

### 4. [Interface Extension Naming Policy](INTERFACE_EXTENSION_NAMING-v0.1.1.1-jp.md)
**ステータス:** Active
**現在の内容:**
- 機械的な suffix を使わない semantic interface naming
- v0.1.1.1 additive contract の draft name と implemented name の対応
- opt-in interface expansion の継承関係を docs で説明する規約

public interface を追加・レビューする場合に利用する。

---

### 5. [Enum Handling Policy](ENUM_HANDLING_POLICY-v0.1.1.1-jp.md)
**ステータス:** Active
**現在の内容:**
- 新規 domain enum の `Unknown = 0` 要件
- unknown enum value に対する fail-closed behavior
- raw enum value の diagnostics、metadata、telemetry 要件

enum を追加する場合や、adapter、provider、replay artifact、telemetry carrier、
external metadata から値を受け取る場合に利用する。

---

### 6. [XML Documentation Policy](XML_DOCUMENTATION_POLICY-v0.1.1.1-jp.md)
**ステータス:** Active
**現在の内容:**
- public API のバイリンガル XML documentation 要件
- inline `JA:` 形式と `docs.en.xml` / `docs.ja.xml` ペア include 形式
- public type、member、parameter、type parameter、return value の review checklist

public contract comment を追加・レビューする場合に利用する。

---

### 7. [CTG Developer Guide](CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md)
**ステータス:** Active
**現在の内容:**
- Canonical Trajectory Governance の contract-only rule
- council、gate、trajectory、ROM、trace carrier の開発者向け guidance
- unknown value、missing canon、veto、diagnostics に関する fail-closed review checklist
- Zenodo 公開済み CTG 理論に対する Paper 12 alignment checklist

CTG contract を追加、レビュー、または runtime package で実装する場合に利用する。

---

### 8. [CTG Developer Theory](../architecture/21.CTG_DEVELOPER_THEORY-v0.1.1.1-jp.md)
**ステータス:** Active
**現在の内容:**
- CTG の開発者向け theory map
- three-council model、finite vote value、discrete gate decision
- rejection taxonomy、canon reference shape、replay boundary

CTG DTO、enum、runtime package implementation が公開済み paper invariant を
維持しているかを review する場合に利用する。

---

### 9. [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1-jp.md)
**ステータス:** Active
**現在の内容:**
- Monolith CTG-ROM の directory layout
- `/rom/governance` の canon asset と `/rom/locales` の personality descriptor の分離
- base canon layer、locale layer、developer diff layer、VFS merge layer
- personalized Personality-ROM 構築時の fail-closed merge rule

CTG-ROM canon と personalization layer を追加、レビュー、または mount する場合に利用する。

---

### 10. Release Operations（リリース運用）
**ステータス:** Planned
**内容（予定）:**
- リリースフロー（tag → build → publish → announce）
- 署名付きアーティファクトの扱い
- バージョン管理（SemVer / Contract Versioning との整合）
- リリース後の検証手順

---

### 11. Monitoring & Observability（監視・可観測性）
**ステータス:** Planned
**内容（予定）:**
- メトリクス（latency / cost / retry / cache / provider health）
- 分散トレーシング（Pipeline / TaskManager / ProviderRouter）
- アラート設計（SLO / SLA / SLI）
- ログ構造（AuditEvent / Replay Logs）

---

### 12. Incident Response（障害対応）
**ステータス:** Planned
**内容（予定）:**
- 障害検知 → 初動 → 切り分け → 復旧 → 事後分析
- Provider 障害時のフェイルオーバー
- RAG データ破損時の復旧手順
- 再現性（Deterministic Replay）を用いた障害解析

---

### 13. Security Operations（セキュリティ運用）
**ステータス:** Planned
**内容（予定）:**
- 署名検証（PromptRules / Contracts / Policies）
- Provider 認証情報の管理（Secret Manager）
- データ分類（Data Classification）に基づくアクセス制御
- 監査ログの保持・改ざん検知

---

## Operations の役割

AIKernel の Operations は、次の 3 つの目的を持つ：

### 1. 安定運用（Stability）
- Provider 障害時の自動復旧
- Pipeline の再実行性
- バージョンアップ時の安全性

### 2. 可観測性（Observability）
- メトリクス
- トレーシング
- ログ
- アラート

### 3. ガバナンス（Governance）
- リリース管理
- 契約変更の追跡
- 署名・検証
- 監査対応

AIKernel を **長期的に安全かつ再現性をもって運用するための基盤** を提供する。

---

## 現状ステータス

Operations 文書は、contract と package 境界の安定化に合わせて順次拡充される。

現時点では、
- Migration Guide は v0.1.1 までの具体的な移行手順と v0.1.1.1 の CTG DTO / enum 正規化を含む
- Package Installation Guide は同期済み `0.1.1` の NuGet / PyPI line、`0.1.1.1` の NuGet-only contract update、v0.1.2 の NuGet / PyPI 同期公開前提を扱う
- Demo Programs Guide は公式 AIKernel.Demo の学習導線を扱う
- Interface naming、enum handling、XML documentation policy、CTG developer guidance、CTG developer theory、CTG ROM layout は v0.1.1.1 additive contract surface を扱う
- Release、monitoring、incident、security operations は Planned
という状態であり、今後のバージョンで順次追加される。

---

## 関連ディレクトリ

- `docs/architecture/` — アーキテクチャ思想（Why）
- `docs/design/` — 実装方針（How）
- `docs/guideline/` — 運用ルール（Rules）
- `docs/operations/` — 運用手順（Runbook） ← *本ディレクトリ*
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.3 (2026-06-02): Migration Guide を Active とし、v0.0.3 の依存レイヤ移行内容を反映
- v0.0.4 (2026-06-04): DSL / History ROM contract 抽出の移行内容を反映
- v0.0.5 (2026-06-05): contract-surface purity cleanup、external Capability module、DynamicSLM Model ABI / SeedSLM discipline / distillation offload、HATL external cryptographic operator、governance admissibility、Semantic Compilation DTO vocabulary contract 準備の移行内容を反映
- v0.1.0 (2026-06-07): MemoryRegion / MemoryMapper contract extraction を追加
- v0.1.1 (2026-06-10): 同期された公開リリースライン向けに package installation guide と demo programs guide を追加
- v0.1.1.1 (2026-06-14): CTG developer guide、CTG Developer Theory、Monolith CTG-ROM layout coverage、0.1.1.1 の NuGet-only package boundary を追加
