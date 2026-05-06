---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Guidelines — Index"
created: 2026-05-01
tags:
  - aikernel
  - guideline
  - documentation
  - governance
  - japanese
updated: 2026-05-06
---

# AIKernel Guidelines — Index
このディレクトリは、AIKernel.NET の **ガイドライン（Guidelines）** を体系的にまとめた入口となる。  
ガイドラインは、アーキテクチャ思想（architecture）や実装方針（design）とは異なり、  
**プロジェクト運用・文書作成・契約管理・依存方向・PR 運用などの「ルール」を定義する領域** である。

AIKernel の品質・再現性・ガバナンスを維持するため、  
ガイドラインはすべて **Markdown を一次表現** とし、  
**英語版を正本（canonical）・日本語版を深掘り（deep-dive）** として管理する。

---

## ガイドライン文書一覧

### 1. Documentation Guidelines  
**ファイル:** `DOCUMENTATION_GUIDELINES(.jp).md`  
**内容:**  
- Markdown-first 原則  
- 英語版を正本とするルール  
- ファイル命名規則  
- アーキテクチャ文書の書き方  
- Emoji 使用制限  
- ガバナンス（署名・バージョン・変更履歴）  
- docs/ ディレクトリ構造の原則  

AIKernel のすべてのドキュメントは、このガイドラインに従う。

---

### 2. Docs Contributing Guide  
**ファイル:** `DOCS_CONTRIBUTING(.jp).md`  
**内容:**  
- ドキュメント PR の作法  
- CI チェック（lint / link-check / build）  
- 翻訳管理（英語 ↔ 日本語）  
- レビュー体制（owners 制度）  
- PR チェックリスト  

ドキュメント変更を行う際の **運用ルール** を定義する。

---

### 3. Repository Dependency Rules  
**ファイル:** `REPO_DEPENDENCY_RULES(.jp).md`  
**内容:**  
- リポジトリ間の依存方向（Core → Kernel → Providers）  
- 循環依存禁止  
- 破壊的変更の扱い  
- CI による依存チェック推奨  

AIKernel 全体の **構造的健全性（architectural integrity）** を守るための規約。

---

### 4. Contract Versioning Policy  
**ファイル:** `CONTRACT_VERSIONING(.jp).md`  
**内容:**  
- Interface / DTO / Enum のバージョニング方針  
- 破壊的変更の定義  
- 非破壊的変更の扱い  
- Migration Guide との連携  
- SemVer 運用ルール  

AIKernel の **契約（Contracts）を安全に進化させるためのガバナンス** を定義する。

---

### 5. Migration Guide（予定）  
**ファイル:** `MIGRATION_GUIDE(.jp).md`  
**内容:**  
- 契約の破壊的変更を跨ぐ際の移行手順  
- 変更点の分類（Breaking / Non-breaking）  
- 自動変換ツール・チェックリスト（予定）  

現在は **Planned**。Contracts が安定した段階で作成される。

---

## ガイドラインの役割

AIKernel のガイドラインは、次の 3 つの目的を持つ：

### 1. 一貫性（Consistency）  
- 文書構造  
- 命名規則  
- バージョニング  
- PR 運用  

### 2. 再現性（Reproducibility）  
- 変更履歴  
- 署名  
- CI チェック  
- 翻訳管理  

### 3. ガバナンス（Governance）  
- 契約の進化  
- 依存方向の維持  
- ドキュメントの品質保証  

AIKernel を **OS として長期運用するための基盤** を提供する。

---

## 推奨読書順

1. **DOCUMENTATION_GUIDELINES**  
2. **DOCS_CONTRIBUTING**  
3. **REPO_DEPENDENCY_RULES**  
4. **CONTRACT_VERSIONING**  
5. **MIGRATION_GUIDE（完成後）**

---

## 関連ディレクトリ

- `docs/architecture/` — アーキテクチャ思想（Why）  
- `docs/design/` — 実装方針（How）  
- `docs/guideline/` — 運用ルール（Rules） ← *本ディレクトリ*
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
