---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Documentation Guidelines"
created: 2026-04-30
tags:
  - aikernel
  - documentation
  - guideline
  - japanese
---

# AIKernel.NET — Documentation Guidelines
AIKernel のすべてのドキュメントは、以下の原則に従って作成する。  
目的は **人間可読性・構造純度・再現性・ガバナンス** を最大化すること。

---

# 1. 基本方針

## 1.1 Markdown 第一主義
- すべての設計書・仕様書・ルール・マニフェストは **Markdown** で記述する。
- YAML/JSON は Markdown 内のコードブロックとして埋め込む。
- PDF / Word / HTML は使用しない。

## 1.2 英語版が正規版、日本語版は深掘り版
- `xxx.md` → 英語版（正規版、OSS 向け）
- `xxx-jp.md` → 日本語版（深掘り・補足・思想の詳細）

日本語版からグローバル版として、要約して英語版を生成するため、日本語版への逆翻訳を禁止する
英語版は日本語版の単純な翻訳ではなく、**日本語でしか表現できない深い説明**は日本語版にのみ存在することを許容する。

### 1.3 本リポジトリのスコープ（契約リポ）
AIKernel.NET の公開において、本リポジトリは **契約（Interface / 最小DTO / Enum）** を提供する。
実装（Kernel / Providers / Server 等）は別リポジトリで開発し、ここへ混入させない。

### 1.4 バージョン運用（0.0.0 統一）
日本語版がレビュー段階の間は、ドキュメント／契約の version を **0.0.0** に統一する。
ある程度フィックスした時点で英語版へ反映し、SemVer を更新する。

---

# 2. ファイル命名規則

## 2.1 architecture 配下は番号付き
```
1.CATEGORY_SEPARATION_PRINCIPLES.md
2.CONTEXT_ISOLATION_SPEC.md
3.ATTENTION_POLLUTION_THEORY.md
4.LLM_SURFACE_MODE_FAILURE.md
5.PREPROCESSING_VS_PROMPTING.md
6.AIKERNEL_VS_LANGCHAIN.md
index.md
```

日本語版は `.jp.md` を付ける。

## 2.2 README はリポジトリ直下に配置
- `README.md`（英語）
- `README-jp.md`（日本語）

## 2.3 PromptRules / PipelineManifests は SemVer + ID
例：
```
default-safety-v0.0.0.md
minimal-dag-v0.0.0.md
```
---

# 3. 文体ガイドライン

## 3.1 絵文字の扱い
- 英語版 README → 少量の絵文字は許容（✔ / ❌ 程度）するがその後に、意味する単語も併記する。（❌ Incorrect.等）
- 日本語版 README → 絵文字は最小限
- architecture → 絵文字禁止（思想文書の純度を保つ）
- PromptRules → 絵文字禁止（機械処理の安定性のため）

## 3.2 禁止事項
- 機種依存文字（①②③、全角記号など）
- 装飾目的の絵文字乱用
- 文脈のない比喩
- 例を推論説明に混ぜる（AIKernel の思想に反する）

## 3.3 推奨スタイル
- 短く明確な段落
- 箇条書きの多用
- 原則 → 理由 → 結論 の順で書く
- 重要語は **太字**
- 専門用語は英語併記（例：推論 / reasoning）

---

# 4. 内容ガイドライン

## 4.1 情報カテゴリ分離を守る
ドキュメントも AIKernel の思想に従い、カテゴリを混在させない。

例：
- 原則（Principle）
- 理論（Theory）
- 仕様（Specification）
- 比較（Comparison）
- 実装（Implementation）
- 運用（Operations）

これらは必ず別ファイルに分ける。

## 4.2 例（Example）は推論説明に混ぜない
architecture 文書では例を使わず、抽象構造で説明する。

## 4.3 RAG 素材を文書に混ぜない
外部引用は最小限にし、引用元を明記する。

## 4.4 docs/operations（運用ドキュメント）の追加
運用（Operations）に属するドキュメントは `docs/operations/` に配置する。
例：移行ガイド（Migration Guide）、運用手順、リリース手順、互換性注意事項など。
未作成の運用ドキュメントを「予定」として置く場合は、
本文冒頭に **status: Planned** と **TBD** を明記し、読者が「完成済み」と誤解しないようにする。

---

# 5. 構造ガイドライン

## 5.1 すべての文書は以下の構造を推奨
```
# タイトル
概要（必須）
背景（任意）
原則 / 理論 / 仕様（必須）
理由（必須）
結論（必須）
関連文書（任意）
```

## 5.2 architecture 文書は「思想 → 原則 → 仕様 → 結論」
例：
- 理論（Attention 汚染）
- 原則（カテゴリ分離）
- 仕様（Context Isolation）
- 比較（LangChain）
- 結論（AIKernel の優位性）

---

# 6. ガバナンスと再現性

## 6.1 すべての文書は Git で差分管理
- Markdown の diff が読みやすい構造にする
- YAML/JSON は 1 行 1 意味で書く

## 6.2 PromptRules / Manifests は署名付き
- `issuer`
- `version`
- `signature`
- `scope`

## 6.3 変更履歴（Changelog）を必ず記載
```
## 変更履歴
- v0.0.0 ドラフト（レビュー段階）
- v0.0.1 レビュー指摘:issue #123 を反映
- v0.1.0 Context Isolation の更新
```

## 6.4 テスト運用（初期は必須にしない）
本リポジトリは契約の反復を優先するため、現段階ではテストプロジェクトの同梱を必須としない。
代わりに、CI は **build-only**（dotnet build 等）で最低限の整合性を確認する。
契約が一定程度フィックスした段階で、依存方向・破壊的変更検出を目的としたテストを追加する。

---

# 7. 相互リンク

## 7.1 README ↔ architecture/index.md
- README から architecture へリンク
- architecture/index.md から README へリンク

## 7.2 英語版 ↔ 日本語版
各ファイルの冒頭に：

```
For Japanese version, see xxx.jp.md
```

---

# 8. ドキュメントの種類別ルール

## 8.1 architecture（思想文書）
- 絵文字禁止
- 例禁止
- 抽象度高め
- 原則と理由を明確に

## 8.2 design（設計意図）
- 思想と実装の橋渡し
- 抽象と具体の両方を書く

## 8.3 rules（PromptRules）
- YAML + Markdown
- 署名必須
- 絵文字禁止

## 8.4 provider docs
- Capability ベースで説明
- モデル名依存の説明は禁止

## 8.5 docs/design と docs/operations の命名方針
- design / operations は変更・追加が起きやすいため、原則として採番しない。
- 代わりに index.md（および index.jp.md）で推奨読書順と導線を管理する。

## 8.6 ADR（Architecture Decision Records）
- ADR は参照性のために採番を推奨する（例：docs/design/adr/ADR-0001-*.md）。

---

# 9. 最後に

AIKernel のドキュメントは単なる説明ではなく、  
**アーキテクチャそのものの一部**である。

このガイドラインは、  
AIKernel の思想（カテゴリ分離・前処理中心・attention 純度・OS 的構造）を  
すべての文書に一貫して反映するための基盤である。

