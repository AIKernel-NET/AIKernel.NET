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

[日本語](package-release-alignment-v0.1.2-ja.md)

This document is the shared package and release alignment note for the
AIKernel.NET v0.1.2 canonical series. Repository-specific package instructions
may add local details, but they must not contradict this page.

## Scope

The v0.1.2 line aligns the C# NuGet package families with the Python package
wrappers that mirror their public managed surfaces.

| Repository | NuGet role | PyPI distribution | Python import name |
| --- | --- | --- | --- |
| AIKernel.NET | Contract packages | Included through `aikernel-net` managed catalog | `aikernel_net` |
| AIKernel.Core | Core runtime packages | `aikernel-net` | `aikernel_net` |
| AIKernel.Control | Governance/control packages | `aikernel-governance` | `aikernel_governance` |
| AIKernel.Providers | Provider substrate packages | `aikernel-providers` | `aikernel_providers` |
| AIKernel.Cuda13.0 | CUDA capability package | `aikernel-cuda13-libtorch2-12-win-x64` | `aikernel_cuda13_libtorch2_12_win_x64` |
| AIKernel.Wasm | Browser/WASM runtime packages | `aikernel-wasm` | `aikernel_wasm` |
| AIKernel.Tools | CLI/tooling packages | `aikernel-tools` | `aikernel_tools` |

AIKernel.Demo and AIKernel.Doom are demo/application repositories. They consume
the package family for validation, but they are not published as package
artifacts in this line.

## Versioning

Stable package creation is deferred until the maintainer explicitly opens the
v0.1.2 publication step. During integration and cross-repository verification,
use development package versions only:

- NuGet local development packages: `0.1.2-dev{buildNumber}`
- Python development packages: `0.1.2.dev{buildNumber}`

Do not create or cache stable `0.1.2` packages during development validation.
Stable artifacts must be created only in dependency order and only when the
release task explicitly asks for stable packaging.

## Dependency Order

When creating development or stable packages, follow this order:

1. AIKernel.NET contract packages
2. AIKernel.Core
3. AIKernel.Control
4. AIKernel.Providers
5. AIKernel.Cuda13.0
6. AIKernel.Wasm
7. AIKernel.Tools
8. AIKernel.Demo and AIKernel.Doom validation

This ordering prevents later repositories from resolving stale package cache
entries or partially updated managed assemblies.

## Python Wrapper Boundary

Python packages are thin wrappers over the managed C# assemblies. They may
provide loading helpers, package metadata, sample assets, and managed API
catalogs, but they must not reimplement:

- CTG / Gate / trajectory decisions
- Provider routing decisions
- WebGPU, WebAudio, or browser runtime behavior outside the Wasm package
- Scenario-specific behavior from AIKernel.Doom

The Python surface should make the managed API discoverable and importable
without changing responsibility boundaries.

## Managed API Catalog

Each Python wrapper exposes a generated managed API catalog:

- `managed_api_catalog()`
- `managed_api_summary()`
- `managed_type_names()`
- `find_managed_type(full_name)`

The catalog is generated from the public managed source surface and is used by
tests and examples to confirm that Python package users can discover the C#
contracts, DTOs, enums, and implementation surfaces that belong to that package.

## CTG-ROM Sample Asset

`aikernel-net` includes a sample CTG-ROM resource tree for Core and Python
experiments:

- `ctg_rom_sample_path()`
- `ctg_rom_sample_files()`

The sample is a carrier asset for development and education. The canonical ROM
content itself remains governed by the AIKernel.NET ROM documents. The v0.1.2
package line promotes the rc5 Monolith CTG-ROM content by metadata alignment
only; semantic rules and canonical text remain unchanged. See
[CTG ROM Layout v0.1.2](../operations/CTG_ROM_LAYOUT-v0.1.2.md).

## PyPI Trusted Publishing

Stable PyPI publication uses GitHub Actions Trusted Publishing:

- publish jobs use the GitHub Environment named `pypi`
- publish jobs request `id-token: write`
- publish jobs use `pypa/gh-action-pypi-publish@release/v1`
- workflows must not contain PyPI API tokens, `TWINE_USERNAME`, or
  `TWINE_PASSWORD`
- build and publish steps remain separated so release artifacts can be
  inspected before upload

CUDA may use a split workflow where a self-hosted runner builds artifacts and a
stable publish job uploads the Python wrapper with Trusted Publishing.

## Documentation Expectations

Repository-specific documentation must link back to this document when it
discusses cross-repository release order, PyPI publishing, or development
package versioning. Historical v0.1.1.1 documents may remain as migration
records, but current package guides must describe the v0.1.2 workflow.
