---
title: "Documentation Migration Report"
lang: en
description: "AIKernel.NET 0.1.2 公式ドキュメント刷新で既存 docs/reference をどう扱ったかを記録します。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---

# Documentation Migration Report

## Summary

### EN

This migration report records how existing documentation was handled during the 0.1.2 renewal.

### JA

この migration report は 0.1.2 renewal 中に既存 documentation をどう扱ったかを記録します。

## Why

### EN

Existing documents should not be deleted until their content is integrated and redirects or 410 rules are verified.

### JA

既存 document は、内容統合と redirect / 410 検証が終わるまで削除しません。

## Usage

### EN

Review this report before removing old pages or changing sitemap lifecycle rules.

### JA

古い page の削除や sitemap lifecycle rule を変更する前にこの report を確認します。

## Examples

### Migration actions

| Action | Result | Reason |
|---|---|---|
| Existing Markdown deletion | none | Archive candidates require manual source/content review. |
| New 0.1.2 guide structure | added | Required by the renewal prompt. |
| Generated Reference | rebuilt by site script | Keeps source paths and package metadata current. |
| Ad/meta/footer | inherited in build templates | Existing site AdSense and copyright areas are preserved. |


## Notes

- No existing Markdown source was deleted by this generator.
- Stale generated HTML can be cleaned by the site build only when a source page is no longer published.
- 410 automation is handled separately after sitemap generation.

## See Also

- [Generation Report](docs-generation-report.md)
- [Reference](/reference/)
