---
version: 1.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Documentation Guidelines"
created: 2026-04-30
tags:
  - aikernel
  - documentation
  - guideline
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
- `xxx.jp.md` → 日本語版（深掘り・補足・思想の詳細）

日本語版は翻訳ではなく、**日本語でしか表現できない深い説明**を許容する。

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
- `README.jp.md`（日本語）

## 2.3 PromptRules / PipelineManifests は SemVer + ID
例：
```
default-safety-v1.0.0.md
minimal-dag-v1.0.0.md
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
- v1.0.0 初版
- v1.1.0 Context Isolation の更新
```

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

---

# 9. 最後に

AIKernel のドキュメントは単なる説明ではなく、  
**アーキテクチャそのものの一部**である。

このガイドラインは、  
AIKernel の思想（カテゴリ分離・前処理中心・attention 純度・OS 的構造）を  
すべての文書に一貫して反映するための基盤である。

