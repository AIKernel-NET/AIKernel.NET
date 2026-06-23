---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# Package Release Alignment v0.1.3

[English](package-release-alignment-v0.1.3.md)

この文書は、AIKernel.NET 0.1.3 正典シリーズにおける package alignment の
開発者向け source です。package maintainer が「現行の手順」「履歴として残す手順」
「local validation で混在させてよい version」を迷わないようにします。

## 現行 Package Line

公開用の正典 package family は `0.1.3` を使います。

local validation では、次の development family を 1 系列だけ選んで使います。

| パッケージシステム | ローカル開発版 |
|---|---|
| NuGet | `0.1.3-dev<build-number>` |
| PyPI | `0.1.3.dev<build-number>` |

migration や fallback behavior を明示的に試験する場合を除き、安定版 `0.1.3`
package と別 build の local package を混在させないでください。

## Repository Order

build / verify は次の順序で行います。

1. `AIKernel.NET`
2. `AIKernel.Core`
3. `AIKernel.Control`
4. `AIKernel.Providers`
5. `AIKernel.Cuda13.0`
6. `AIKernel.Wasm`
7. `AIKernel.Tools`
8. `AIKernel.Demo`
9. `AIKernel.Doom`

最初の 7 repository は package surface を定義します。Demo と Doom は、それらの
package surface が実際に連携できることを検証するための repository です。

## Source Of Truth

- package installation UX は
  [Package Installation Guide](../operations/PACKAGE_INSTALLATION_GUIDE-jp.md) に置きます。
- demo execution UX は
  [Demo Programs Guide](../operations/DEMO_PROGRAMS_GUIDE-jp.md) に置きます。
- GPU migration context は
  [GPU Canonical Migration](../migration/v0.1.3-gpu-canonical-migration.md) に置きます。
- XML comment rule は
  [XML Documentation Policy](../operations/XML_DOCUMENTATION_POLICY-v0.1.3-jp.md) に置きます。

履歴文書は title や filename に古い version number を残してよいです。一方で、現行の
install command、package table、local validation example は 0.1.3 family を使います。

## Developer Checklist

- public example では NuGet と PyPI の package family を同期する。
- repository 固有の build note は、その build を所有する repository に置く。
- stable install command と local `dev` validation command を混ぜて書かない。
- Demo と Doom は package publication root ではなく validation/demo surface であることを明記する。
- public API documentation は .NET XML documentation tag または paired include file でバイリンガル化する。
