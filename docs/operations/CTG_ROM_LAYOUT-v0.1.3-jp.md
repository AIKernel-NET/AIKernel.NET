---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# CTG ROM Layout v0.1.3

[English](CTG_ROM_LAYOUT-v0.1.3.md)

この文書は、0.1.3 正典 package series における package-facing CTG-ROM layout rule を記録します。

## Scope

0.1.3 の作業では、CTG-ROM metadata を同期 package family に揃えます。
以前の CTG 文書から引き継ぐ CTG canon text、voting semantics、locale merge rule は書き換えません。

## Layout Rule

package sample は、既存の ROM structure を維持します。

```text
rom/
  governance/
    base/
    overlays/
  locales/
    default/
  metadata/
```

同期 package series を示す package-facing metadata には `0.1.3` を使います。
古い互換性境界を説明する historical filename と migration document は維持します。

## Developer Rule

- `aikernel-net` は Python wrapper validation 用の sample CTG-ROM asset を持ってよい。
- runtime package は hard-coded path ではなく canonical VFS / ROM interface 経由で CTG-ROM content を mount する。
- Demo と Doom は scenario evidence として CTG-ROM sample を読んでよいが、CTG canon rule を再定義してはいけない。
