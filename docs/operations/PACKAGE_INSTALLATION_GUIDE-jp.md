---
title: "AIKernel 0.1.1 / 0.1.1.1 パッケージ導入ガイド"
updated: 2026-06-14
published: 2026-06-10
version: "0.1.1.1"
edition: "Release"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# AIKernel 0.1.1 / 0.1.1.1 パッケージ導入ガイド

AIKernel 0.1.1 は、公開された Semantic OS サーフェスを同期した最初のパッケージラインです。  
.NET パッケージは NuGet、Python ラッパーは PyPI、公式デモは AIKernel.Demo リポジトリで提供されます。

AIKernel 0.1.1.1 は、一部の public package に対する additive interface-extension
update です。GitHub release workflow は不要で、v0.1.1 consumer との互換性を維持します。
[`../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1-jp.md`](../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1-jp.md)
に記載された新しい semantic contract surface が必要な場合のみ、`0.1.1.1`
package version を利用してください。CTG については
[`../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md`](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md)、
[`../design/CTG_CONTRACT_MODEL-v0.1.1.1-jp.md`](../design/CTG_CONTRACT_MODEL-v0.1.1.1-jp.md)、
[`CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md`](CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md)
を参照してください。公開済み論文参照は
[`../papers/12-canonical-trajectory-governance/README.md`](../papers/12-canonical-trajectory-governance/README.md)
です。

## Quick Start: OS サーフェスを起動する

標準 Provider と運用ツールを含むローカル AIKernel ランタイムを最短で試す場合は、次の 3 つから始めます。

```bash
dotnet add package AIKernel.Core --version 0.1.1
dotnet add package AIKernel.Providers.Standard --version 0.1.1
dotnet tool install -g AIKernel.Tools.CLI --version 0.1.1
```

CLI サーフェスは次のコマンドで確認します。

```bash
aik runtime ping
aik system info
aik system vfs --vfs-root .
aik capabilities invoke aikernel.vfs vfs.exists path=README.md
```

## NuGet パッケージ

| レイヤー | パッケージ | 役割 |
|---|---|---|
| 契約境界 | `AIKernel.Abstractions` | Interface と OS 境界の契約。 |
| 契約 DTO | `AIKernel.Contracts` | request / response / policy の契約形状。 |
| 契約 DTO | `AIKernel.Dtos` | ランタイム横断で使う公開 DTO。 |
| 契約 enum | `AIKernel.Enums` | Semantic OS の安定した enum 語彙。 |
| 関数型プリミティブ | `AIKernel.Common` | Result、Option、Try、Async、識別子、hash、共有の決定論的 helper。 |
| ランタイム | `AIKernel.Core` | Kernel runtime、VFS、ROM、DSL、process、compute、routing、OS 抽象。 |
| Hosting | `AIKernel.Hosting` | host composition と dependency-injection support。 |
| Kernel facade | `AIKernel.Kernel` | application entry point 向けの Kernel-facing facade package。 |
| Governance | `AIKernel.Control` | 決定論的な制御プレーン、policy、emulator、governance execution。 |
| 標準 Driver | `AIKernel.Providers.Standard` | CPU compute、file system、logging、event bus、network、profiler、scheduler provider。 |
| Provider 拡張 | `AIKernel.Providers.ChatHistory` | 軽量な chat history provider。 |
| Provider 拡張 | `AIKernel.Providers.ChatOpenAI` | OpenAI chat provider の manifest / invoker surface。 |
| Provider 拡張 | `AIKernel.Providers.MicrosoftAI` | Microsoft AI provider surface。 |
| Provider 拡張 | `AIKernel.Providers.LocalLlm` | Local LLM provider surface。 |
| Provider 拡張 | `AIKernel.Providers.DynamicPipelineCompiler` | Dynamic pipeline compiler provider。 |
| Provider 拡張 | `AIKernel.Providers.CudaCompute` | CUDA compute provider の抽象 surface。 |
| Tools | `AIKernel.Tools.Instrumentation` | canonical formatting、inspection、replay、instrumentation。 |
| Tools inspector | `AIKernel.Tools.Inspectors.Vfs` | VFS inspection helper。 |
| Tools inspector | `AIKernel.Tools.Inspectors.ChatHistoryScraper` | chat history scraping / inspection helper。 |
| Tools capability | `AIKernel.Tools.Capability.RomStorage` | ROM storage capability bridge。 |
| CLI | `AIKernel.Tools.CLI` | `aik` コマンドラインツール。 |
| WASM | `AIKernel.Wasm.Runtime` | WASM runtime、process、memory、FS、event、audio、screenshot、save-state、time surface。 |
| WASM Compute | `AIKernel.Wasm.WebGpuComputeProvider` | CPU fallback 統合を持つ WebGPU compute provider surface。 |
| CUDA native | `AIKernel.Cuda13.0.Libtorch2.12.win-x64` | Windows 専用の LibTorch 2.12 / CUDA 13.0 パッケージ。 |

CUDA は意図的にプラットフォームを限定しています。Windows win-x64 かつ native runtime 要件を満たす環境でのみ利用してください。

## PyPI パッケージ

| パッケージ | import surface | 役割 |
|---|---|---|
| `aikernel-net` | `aikernel_net` | Core runtime と managed assembly discovery wrapper。 |
| `aikernel-governance` | `aikernel_governance` | Control / governance wrapper。 |
| `aikernel-providers` | `aikernel_providers` | Provider descriptor、manifest、invoker wrapper。 |
| `aikernel-tools` | `aikernel_tools` | instrumentation、formatter、inspector、replay、CLI 隣接 wrapper。 |
| `aikernel-wasm` | `aikernel_wasm` | WASM runtime と WebGPU provider wrapper surface。 |
| `aikernel-cuda13-libtorch2-12-win-x64` | `aikernel_cuda13_libtorch2_12_win_x64` | Windows 専用 CUDA wrapper metadata と loader guidance。 |

Python 側は必要なレイヤーごとに導入します。

```bash
pip install aikernel-net==0.1.1
pip install aikernel-providers==0.1.1
pip install aikernel-tools==0.1.1
```

governance や WASM を使う場合は、次を追加します。

```bash
pip install aikernel-governance==0.1.1
pip install aikernel-wasm==0.1.1
```

## Provider の選び方

必要な runtime boundary に応じて Provider を選びます。

| シナリオ | パッケージ |
|---|---|
| ローカル OS サービス、file system、logging、scheduler、profiler | `AIKernel.Providers.Standard` |
| hosted API なしの Local LLM 実験 | `AIKernel.Providers.LocalLlm` |
| OpenAI chat integration | `AIKernel.Providers.ChatOpenAI` |
| Microsoft AI integration | `AIKernel.Providers.MicrosoftAI` |
| 履歴ベースの軽量 inference surface | `AIKernel.Providers.ChatHistory` |
| Dynamic DSL pipeline compilation | `AIKernel.Providers.DynamicPipelineCompiler` |
| CUDA compute capability bridge | `AIKernel.Providers.CudaCompute` と必要に応じた CUDA runtime package |

## リポジトリ導線

- [AIKernel.NET](https://github.com/AIKernel-NET/AIKernel.NET) — contract boundary packages。
- [AIKernel.Core](https://github.com/AIKernel-NET/AIKernel.Core) — runtime と OS abstractions。
- [AIKernel.Providers](https://github.com/AIKernel-NET/AIKernel.Providers) — standard / extension provider drivers。
- [AIKernel.Control](https://github.com/AIKernel-NET/AIKernel.Control) — governance と control plane。
- [AIKernel.Tools](https://github.com/AIKernel-NET/AIKernel.Tools) — instrumentation と CLI。
- [AIKernel.Wasm](https://github.com/AIKernel-NET/AIKernel.Wasm) — sandboxed WASM runtime。
- [AIKernel.Cuda13.0](https://github.com/AIKernel-NET/AIKernel.Cuda13.0) — Windows CUDA package line。
- [AIKernel.Demo](https://github.com/AIKernel-NET/AIKernel.Demo) — 公式サンプル。

## リリースルール

同期された 0.1.1 ラインでは、`0.1.1` パッケージ同士を組み合わせてください。`0.1.0` と `0.1.1` を混在させると、古い contract、provider manifest、Python wrapper surface が残る可能性があります。

additive interface-extension line では、更新対象の public package を
`0.1.1.1` で揃えてください。local development package は次を使います。

```text
0.1.1-dev<build-number>
```
