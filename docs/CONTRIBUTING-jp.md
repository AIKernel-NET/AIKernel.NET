---
id: contributing
title: "AIKernel Contributing Guide"
scope:
  - repo: AIKernel.NET
createdAt: 2026-04-28T00:00:00Z
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
signature: ""
---

# CONTRIBUTING

---

## Introduction
AIKernel.NET は **Contract-Driven AI Runtime** であり、プロダクション品質の AI OS を目指します。このリポジトリは **.NET 10 / C# 14** を対象とします。本ガイドは、リポジトリ構造、PR ルール、CI 要件、コントリビューションのベストプラクティスを示します。

---

## Environment
- **Runtime**: .NET 10
- **Language**: C# 14
- **Repository layout**: `src/`, `tests/`, `samples/`, `docs/`, `tools/`
CI は build と test を実行し、ベースライン品質を確認します。

---

## Pull Request Guidelines

### 1. One logical change per PR
- 1 つの PR は 1 つの論理変更に集中してください。
- 無関係な変更を 1 つの PR に混在させないでください。

### 2. Contract/interface/DTO changes require an Issue
- 公開契約の変更は Issue で追跡してください。
- 破壊的変更は移行ガイダンスを添えて文書化してください。

### 3. Use of AI tools in authoring PRs
- AI ツール（ChatGPT / Copilot など）を下書きに使うことは許容します。
- AI を使う場合は必ず人手レビューで正確性を担保してください。
- ドメイン知識の代替として AI に依存しないでください。最終責任はレビュワーにあります。

### 4. PR size guidance
- 可能であれば PR は 200 行程度以下を推奨します。
- 大規模変更は小さな PR に分割してください。

### 5. XML documentation
- Public API には XML ドキュメント（`/// <summary>`、パラメータ説明、remarks）を付与してください。
- ドキュメントは常に最新化し、`docs/` と README に反映してください。

### 6. Mark breaking changes
- 必要な場合は PR タイトルに **[Breaking]** を付けてください。
- 例: `[Breaking] Modify RetrievalQuery structure`
- 破壊的変更の理由と移行計画を Issue に記載してください。

### 7. APM and package management
- AIKernel.NET は skills / prompts / agents / hooks / MCP servers のための APM を利用します。
- 新規アーティファクトは Issue 経由で追加し、リポジトリのパッケージ規約に従ってください。

### 8. Link Issues and PRs
- 可能な限り PR と関連 Issue を相互リンクしてください。
- 明示的な解決なしに Issue を close しないでください。

---

## Repository layout and branch strategy

### Key directories
- `src/` — source projects
- `tests/` — test projects
- `samples/` — sample apps and integration examples
- `docs/` — documentation and guidelines
- `tools/` — developer tools

### Branch naming
- `feature/<name>`, `fix/<name>`, `chore/<name>` を使用してください。
- ブランチは小さく保ち、CI しやすい粒度にしてください。

### CI expectations
- CI は `dotnet test` を実行します。
- マージ前にテストが成功することを確認してください。
- 重要変更には統合テストを含めてください。

### Tooling
- EditorConfig を使用してください。
- Roslyn analyzer を使用してください。
- フォーマット統一のため CI で `dotnet format` を実行してください。

---

## PR checklist
- PR が 1 つの目的に集中している
- Contract/interface/DTO 変更に対して Issue がある
- 破壊的変更に `[Breaking]` が付いている
- Public API の XML ドキュメントがある
- CI が成功している
- AI 利用時はその旨を明示し、人手検証が完了している

---

## Review culture
- 建設的で敬意のあるレビューを行ってください。
- 明確性と保守性を優先してください。
- 投稿者を支援し、改善を促進してください。

---

## Release process
- パッケージは semantic versioning に従ってください。
- 破壊的変更と移行手順を文書化してください。
- 可能な限り互換性を維持してください。

---

## Closing
AIKernel は **.NET 10 / C# 14** を対象とする、プロダクション品質の契約駆動 AI ランタイムです。本ガイドラインに従って効果的にコントリビュートしてください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
