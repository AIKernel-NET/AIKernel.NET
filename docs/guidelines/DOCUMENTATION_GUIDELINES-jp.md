---
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# AIKernel.NET — ドキュメントガイドライン
AIKernel のすべてのドキュメントは、**人間可読性・構造純度・再現性・ガバナンス**を最大化するために、以下の原則に従わなければなりません。

---

# 1. 基本方針

## 1.1 Markdown-first
- すべての設計文書、仕様、ルール、マニフェストは **Markdown** で記述すること。
- YAML/JSON は Markdown 内のコードブロックとして埋め込むこと。
- PDF / Word / HTML を一次フォーマットとして使用しないこと。

## 1.2 バイリンガル対称性は必須
- `xxx.md` と `xxx-jp.md` を厳密にペアで管理すること。
- 見出しレベル、箇条書き数、コードブロック内容を日英で揃えること。
- 片側のみの更新は禁止し、同一 PR で両方を更新すること。

## 1.3 リポジトリのスコープ（contracts repo）
このリポジトリは AIKernel.NET の **contracts（Interfaces / minimal DTOs / Enums）** を提供します。  
実装（Kernel / Providers / Server など）は別リポジトリで開発します。

## 1.4 バージョニング（レビュー中は 0.0.0）
日本語ドラフトをレビューしている期間は、ドキュメント/コントラクトのバージョンを **0.0.0** に設定します。  
安定後に英語へ反映し、SemVer を更新します。

---

# 2. ファイル命名規則

## 2.1 番号付き architecture ファイル
```
1.1.CATEGORY_SEPARATION_PRINCIPLES.md
2.CONTEXT_ISOLATION_SPEC.md
3.3.ATTENTION_POLLUTION_THEORY.md
4.LLM_SURFACE_MODE_FAILURE.md
5.PREPROCESSING_VS_PROMPTING.md
6.AIKERNEL_VS_LANGCHAIN.md
index.md
```
日本語版は末尾に `-jp.md` を付与します。

## 2.2 リポジトリルートの README
- `README.md`（英語）
- `README.jp.md`（日本語）

## 2.3 PromptRules / PipelineManifests は SemVer + ID を使用
例:
```
default-safety-v0.0.0.md
minimal-dag-v0.0.0.md
```

---

# 3. スタイルガイド

## 3.1 絵文字使用
- 英語 README: テキスト併記の限定的な絵文字を許可（例: ✔ / ❌ + 単語）
- 日本語 README: 絵文字は最小化
- architecture: 絵文字禁止
- PromptRules: 絵文字禁止

## 3.2 禁止事項
- 環境依存文字（丸付き数字、全角記号など）
- 過剰な装飾絵文字
- 文脈なしの比喩
- 推論説明への examples 混在

## 3.3 推奨スタイル
- 短く明確な段落
- 箇条書きを活用
- Principle → Reason → Conclusion の順を優先
- 重要語は **bold** で強調
- 技術語は英語併記

---

# 4. コンテンツガイドライン

## 4.1 Category separation の維持
ドキュメントは AIKernel の category separation 原則に従い、カテゴリ混在を避けること。

## 4.2 推論説明へ examples を混在させない
architecture 文書は examples を避け、抽象性を保つこと。

## 4.3 ドキュメントへ RAG 材料を混在させない
外部引用は最小化し、必ず出典を明記すること。

## 4.4 運用系コンテンツは docs/operations へ
運用文書（Migration Guide、runbook、release 手順）は `docs/operations/` に配置します。予定段階なら `status: Planned` と先頭 `TBD` を付けます。

---

# 5. 構造ガイドライン

## 5.1 推奨ドキュメント構造
```
Title
Summary (required)
Background (optional)
Principles / Theory / Specification (required)
Rationale (required)
Conclusion (required)
Related documents (optional)
```



## 5.2 architecture 文書: 「philosophy → principles → spec → conclusion」
フロー例:
- Theory (Attention Pollution)
- Principle (Category Separation)
- Spec (Context Isolation)
- Comparison (LangChain)
- Conclusion (AIKernel advantages)

---

# 6. ガバナンスと再現性

## 6.1 全ドキュメントを Git 管理
- diff の可読性を保つ
- YAML/JSON は 1 行 1 意味で記述

## 6.2 Signed PromptRules / Manifests
以下を含める:
- `issuer`
- `version`
- `signature`
- `scope`

## 6.3 常に changelog を含める
例:

```
Changelog
v0.0.0 Draft

v0.0.1 Review: applied issue #123

v0.1.0 Context Isolation update
```

## 6.4 テスト運用（初期は必須ではない）
初期段階では contracts を優先し、build-only CI（dotnet build）を含めます。contracts が安定したら依存方向検証や breaking-change 検知テストを追加します。

---

# 7. 相互リンク

## 7.1 README ↔ architecture/index.md
- README から architecture へリンク
- architecture/index.md から README へリンクバック

## 7.2 English ↔ Japanese
各ファイル先頭に次を含める:

For Japanese version, see xxx-jp.md


---

# 8. ドキュメント種別ごとの規則

## 8.1 architecture
- 絵文字禁止
- examples 禁止
- 高抽象度
- 原則と根拠を明確化

## 8.2 design
- philosophy と implementation の橋渡し
- 抽象と具体の両方を含める

## 8.3 rules (PromptRules)
- YAML + Markdown
- 署名付き
- 絵文字禁止

## 8.4 provider docs
- capability ベースで記述
- モデル名依存の説明を避ける

## 8.5 docs/design と docs/operations の命名
- 番号付けより index.md によるナビゲーションを優先

## 8.6 ADR
- 追跡性のため ADR は番号付けする（例: docs/design/adr/ADR-0001-*.md）

---

# 9. 最終ノート

AIKernel のドキュメントは、アーキテクチャそのものの一部です。  
このガイドラインは、AIKernel の原則（category separation、preprocessing-first、attention purity、OS-like structure）を全ドキュメントへ一貫反映するためのものです。

---

# 10. AI-Native Integrity Rules（必須）

## 10.1 抽象型名は完全名を使用
- `ContextFragment`、`ExpressionBuffer`、`IModelVectorRouter`、`IComputeShapeAdvisor` のような正確な型名を、説明的な別名ではなく使用すること。
- 型名はバッククォートで囲むこと。

## 10.2 最新アーキテクチャと常時同期
- `UC-01` から `UC-14` のユースケースカタログと整合させること。
- `ModelCapacityVector` と NPU/動的基数サポートに関する前提を維持すること。
- モデル名依存のガイダンス（廃止されたモデル名例を含む）を使用しないこと。

## 10.3 Fail-Closed セキュリティ言語
- `IPromptVerifier` による署名検証は推奨ではなく、実行前提条件として扱うこと。
- 検証失敗時は実行停止（fail-closed）を明示すること。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
