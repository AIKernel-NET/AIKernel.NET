---
updated: 2026-06-16
published: 2026-06-16
version: "0.1.2"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Package Release Alignment v0.1.2

[English](package-release-alignment-v0.1.2.md)

この文書は、AIKernel.NET v0.1.2 正典シリーズにおける package / release
alignment の共有ルールです。各 repository 固有の package 手順はこの文書に
local detail を追加できますが、この文書と矛盾してはいけません。

## Scope

v0.1.2 line では、C# NuGet package family と、それぞれの public managed
surface を反映する Python wrapper package を同期します。

| Repository | NuGet role | PyPI distribution | Python import name |
| --- | --- | --- | --- |
| AIKernel.NET | Contract packages | `aikernel-net` の managed catalog に含めて公開 | `aikernel_net` |
| AIKernel.Core | Core runtime packages | `aikernel-net` | `aikernel_net` |
| AIKernel.Control | Governance/control packages | `aikernel-governance` | `aikernel_governance` |
| AIKernel.Providers | Provider substrate packages | `aikernel-providers` | `aikernel_providers` |
| AIKernel.Cuda13.0 | CUDA capability package | `aikernel-cuda13-libtorch2-12-win-x64` | `aikernel_cuda13_libtorch2_12_win_x64` |
| AIKernel.Wasm | Browser/WASM runtime packages | `aikernel-wasm` | `aikernel_wasm` |
| AIKernel.Tools | CLI/tooling packages | `aikernel-tools` | `aikernel_tools` |

AIKernel.Demo と AIKernel.Doom は demo / application repository です。
検証では package family を利用しますが、この line では package artifact として
公開しません。

## Versioning

安定版 package の作成は、maintainer が v0.1.2 公開手順を明示するまで行いません。
統合検証と repository 横断検証では、development package version のみを使います。

- NuGet local development package: `0.1.2-dev{buildNumber}`
- Python development package: `0.1.2.dev{buildNumber}`

開発検証中に stable `0.1.2` package を作成・cache してはいけません。stable artifact
は依存関係順に、かつ release task が明示的に stable packaging を求めた場合だけ
作成します。

## Dependency Order

development package と stable package のどちらを作成する場合でも、次の順序を守ります。

1. AIKernel.NET contract packages
2. AIKernel.Core
3. AIKernel.Control
4. AIKernel.Providers
5. AIKernel.Cuda13.0
6. AIKernel.Wasm
7. AIKernel.Tools
8. AIKernel.Demo / AIKernel.Doom validation

この順序により、後続 repository が stale package cache や部分更新された managed
assembly を解決する事故を避けます。

## Python Wrapper Boundary

Python package は managed C# assemblies の薄い wrapper です。loading helper、
package metadata、sample asset、managed API catalog は提供できますが、次を
Python 側で再実装してはいけません。

- CTG / Gate / trajectory decision
- Provider routing decision
- Wasm package の外側にある WebGPU / WebAudio / browser runtime behavior
- AIKernel.Doom の scenario-specific behavior

Python surface は managed API を発見・import しやすくするためのものであり、
責務境界を変更してはいけません。

## Managed API Catalog

各 Python wrapper は generated managed API catalog を公開します。

- `managed_api_catalog()`
- `managed_api_summary()`
- `managed_type_names()`
- `find_managed_type(full_name)`

この catalog は public managed source surface から生成されます。tests と example は、
Python package user が C# contracts、DTO、enum、implementation surface を発見できる
ことを確認します。

## CTG-ROM Sample Asset

`aikernel-net` は Core / Python 実験向けの CTG-ROM sample resource tree を同梱します。

- `ctg_rom_sample_path()`
- `ctg_rom_sample_files()`

この sample は development / education 向けの carrier asset です。canonical ROM
content 自体は AIKernel.NET の ROM documents に従います。v0.1.2 package line では、
rc5 の Monolith CTG-ROM content を metadata alignment のみで昇格します。semantic
rule と canonical text は変更しません。詳細は
[CTG ROM Layout v0.1.2](../operations/CTG_ROM_LAYOUT-v0.1.2-jp.md) を参照してください。

## PyPI Trusted Publishing

stable PyPI publication は GitHub Actions Trusted Publishing で行います。

- publish job は `pypi` GitHub Environment を使う
- publish job は `id-token: write` を要求する
- publish job は `pypa/gh-action-pypi-publish@release/v1` を使う
- workflow に PyPI API token、`TWINE_USERNAME`、`TWINE_PASSWORD` を含めない
- build と publish は分離し、upload 前に release artifact を検査できるようにする

CUDA は self-hosted runner で artifact を build し、stable publish job で Trusted
Publishing により Python wrapper を upload する split workflow を取ることがあります。

## Documentation Expectations

repository 固有のドキュメントが cross-repository release order、PyPI publishing、
development package versioning に触れる場合は、この文書へ link します。v0.1.1.1 の
historical document は migration record として残せますが、現在の package guide は
v0.1.2 workflow を説明する必要があります。
