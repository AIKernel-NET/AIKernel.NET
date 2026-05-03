---
version: 0.0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "Semantic Snapshot Markdown 形式"
description: AIKernel の意味的メモリスナップショットの標準 Markdown 形式
lang: ja
last_updated: 2026-05-04
updated: 2026-05-04
owners:
  - AIKernel Architecture Team
tags:
  - aikernel
  - design
  - snapshot
  - markdown
  - japanese
---

英語版は `SEMANTIC_SNAPSHOT_FORMAT.md` を参照。

# Purpose
AIKernel が推論途中状態を統治メタデータ付きで保持するための **Semantic Snapshot** 標準 Markdown 形式を定義する。

# Scope
本書は以下を定義する。
- 必須セクション
- メタデータキー
- セクション意味論
- 再現性と監査性のための形式制約
- ROM との責務境界（フォーマットと意味表現の分離）

# Specification / Procedure

## 1. スナップショット文書構造
Semantic Snapshot は次の順序で構成する。
1. Snapshot Metadata
2. Orchestration
3. Material Quarantine
4. Thought Process
5. Expression Buffer

## 2. Snapshot Metadata ブロック
先頭に明示的なキー値ブロックを置く。

```md
---
# [Snapshot Metadata]
Timestamp: 2026-05-03T00:50:00Z
KernelVersion: v0.0.7
Router: IModelVectorRouter (Type: LogicHeavy)
PromptSignature: "sha256:7f8e9a..."
---
```

### 必須フィールド
- `Timestamp`: UTC の ISO 8601 タイムスタンプ
- `KernelVersion`: 実行されたカーネル契約バージョン
- `Router`: 選択されたルーティング抽象とプロファイル
- `PromptSignature`: Fail-Closed 統治用の検証済み署名ダイジェスト

### 任意フィールド
- `SnapshotId`
- `ParentSnapshotId`
- `ProviderSet`
- `MaterialHash`
- `ExpressionHash`

## 3. Orchestration セクション
署名済み実行方針と制約のみを要約する。

```md
# 1. Orchestration
> Signed prompt summary and execution constraints
```

制約:
- 方針中心で簡潔に書く。
- 生の外部素材を含めない。
- 最終生成物を含めない。

## 4. Material Quarantine セクション
検証済みまたはサニタイズ済み素材のみを列挙する。

```md
# 2. Material Quarantine
- [Source A]: Verified and Structured
- [Source B]: Sanitized
```

制約:
- 素材状態は明示する。
- 未検証素材は推論状態へ昇格してはならない。

## 5. Thought Process セクション
フェーズ単位の推論進行を構造化チェックポイントで記録する。

```md
# 3. Thought Process
## Phase: Task Decomposition
1. [x] Decomposition Task A
2. [ ] Decomposition Task B (In Progress)
```

制約:
- フェーズ見出しを使い、リプレイ可読性を確保する。
- 進捗記号は差分追跡しやすい形式を保つ。

## 6. Expression Buffer セクション
生成物を推論層・素材層から隔離して記録する。

````md
# 4. Expression Buffer
```cpp
// Generated code
```
````

制約:
- Expression 内容を暗黙に Material へ再分類してはならない。
- Expression から Material への昇格は明示的統治操作を要求する。

## 7. 統治ルール
- Snapshot は Git 履歴上で append-only 記録とする。
- 署名検証は実行前提条件である。
- 未署名または不正署名の Snapshot は Orchestration で実行不可とする。

## 8. 検証チェックリスト
- [ ] 必須メタデータキーが存在する
- [ ] セクション順序が正しい
- [ ] Material 状態が明示されている
- [ ] Thought Process がフェーズ構造を持つ
- [ ] Expression が隔離されている
- [ ] PromptSignature が存在し検証済みである

## 9. ROM（Relation-Oriented Markdown）との関係
本仕様は「スナップショットの入れ物」を定義し、ROM は「内容の意味構造」を定義する。

- `SEMANTIC_SNAPSHOT_FORMAT`: セクション順序、統治メタデータ、検証可能性を担保する。
- `ROM`: `YAML` / `Headings` / `Bullets` / `[[id]]` による関係表現を担保する。

運用規則:
- `Material Quarantine` と `Thought Process` の本文は ROM 準拠で記述してよい。
- ただしスナップショットのトップレベル順序（1..5）は本仕様を優先する。
- ROM 非準拠の断片は検疫済みであっても「低信頼」として扱う。

## 10. 正規化と Semantic Hash 規約
署名検証および差分比較の安定化のため、以下を正規化対象とする。

- 見出し番号の有無差分（`# 1. ...` と `# ...`）は等価として扱う。
- 箇条書き順が意味に影響しない場合、順序非依存でハッシュ化する。
- `[[id]]` の内部リンクは解決後 ID 集合で比較する。
- 空白・改行・インデントの表記揺れはハッシュ計算から除外する。

Fail-Closed:
- 正規化後に `PromptSignature` と不一致なら実行不可とする。
- リンク未解決（孤立 ID）が必須参照に含まれる場合、実行を停止する。

# References
- ../architecture/16.SEMANTIC_CONTEXT_OS_VISION-jp.md
- ../architecture/2.CONTEXT_ISOLATION_SPEC-jp.md
- ../architecture/3.ATTENTION_POLLUTION_THEORY-jp.md
- ../architecture/11.MATERIAL_QUARANTINE_TRUST_MODEL-jp.md
- DESIGN_INTENT-jp.md

# Changelog
- 2026-05-03 v0.0.0 Initial draft

# Owners
- AIKernel Architecture Team
