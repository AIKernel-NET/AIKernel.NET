---
title: "Documentation Migration Report"
lang: ja
description: "AIKernel.NET 0.1.2 公式ドキュメント刷新で既存 docs/reference をどう扱ったかを記録します。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---
# Documentation Migration Report

## 概要

この migration report は 0.1.2 renewal 中に既存 documentation をどう扱ったかを記録します。

## 背景

既存 document は、内容統合と redirect / 410 検証が終わるまで削除しません。

## 使い方

古い page の削除や sitemap lifecycle rule を変更する前にこの report を確認します。

## 例

### Migration actions

| Action | Result | Reason |
|---|---|---|
| Existing Markdown deletion | none | Archive candidates require manual source/content review. |
| New 0.1.2 guide structure | added | Required by the renewal prompt. |
| Generated Reference | rebuilt by site script | Keeps source paths and package metadata current. |
| Ad/meta/footer | inherited in build templates | Existing site AdSense and copyright areas are preserved. |

## 補足

- No existing Markdown source was deleted by this generator.
- Stale generated HTML can be cleaned by the site build only when a source page is no longer published.
- 410 automation is handled separately after sitemap generation.

## 関連ページ

- [Generation Report](docs-generation-report.md)
- [Reference](/reference/)
