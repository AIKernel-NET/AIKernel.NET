---
title: "AIKernel パッケージ導入ガイド"
updated: 2026-06-16
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# AIKernel パッケージ導入ガイド

AIKernel 0.1.3 は、Semantic OS サーフェスの次期正典パッケージシリーズです。
NuGet パッケージと Python ラッパーパッケージを同じ public API catalog に揃えつつ、
実装ロジックは managed package 側に維持します。

安定版 `0.1.3` パッケージは、公開タスクが明示的に開始されるまで作成しません。
リポジトリ間の結合検証では、次のローカル開発版を使います。

| パッケージシステム | 開発版 |
|---|---|
| NuGet | `0.1.3-dev<build-number>` |
| PyPI | `0.1.3.dev<build-number>` |

共通の release / package alignment ルールは
[`../development/package-release-alignment-v0.1.3-ja.md`](../development/package-release-alignment-v0.1.3-ja.md)
にまとめています。RC5 monolith 由来の CTG-ROM は、本文・ルール・意味論を変更せず、
metadata のみを正典 `0.1.3` に揃えています。詳細は
[`CTG_ROM_LAYOUT-v0.1.3-jp.md`](CTG_ROM_LAYOUT-v0.1.3-jp.md)
を参照してください。

## Quick Start: 正典 0.1.3

安定版公開後は、同じ `0.1.3` ラインの package をレイヤーごとに導入します。

```bash
dotnet add package AIKernel.Core --version 0.1.3
dotnet add package AIKernel.Providers.Standard --version 0.1.3
dotnet tool install -g AIKernel.Tools.CLI --version 0.1.3
```

ローカル検証では、安定版 version を `0.1.3-dev<build-number>` に置き換え、
依存順に作成した local NuGet package source を参照します。

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
| 関数型プリミティブ | `AIKernel.Common` | Result、Option、Try、Async、識別子、hash、決定論的 helper。 |
| ランタイム | `AIKernel.Core` | Kernel runtime、VFS、ROM、DSL、process、compute、routing、CTG、OS 抽象。 |
| Hosting | `AIKernel.Hosting` | host composition と dependency-injection support。 |
| Kernel facade | `AIKernel.Kernel` | application entry point 向けの Kernel-facing facade package。 |
| Governance | `AIKernel.Control` | 決定論的な制御プレーン、policy、emulator、governance execution。 |
| 標準 Driver | `AIKernel.Providers.Standard` | CPU compute、file system、logging、event bus、network、profiler、scheduler provider。 |
| Provider 拡張 | `AIKernel.Providers.*` | runtime-configurable / descriptor-driven provider family。 |
| Tools | `AIKernel.Tools.*` | canonical formatting、inspection、replay、instrumentation、CLI。 |
| WASM | `AIKernel.Wasm.*` | WASM runtime、WebGPU、WebAudio、perception、HUD、overlay、sandbox surface。 |
| CUDA native | `AIKernel.Cuda13.0.Libtorch2.12.win-x64` | Windows 専用の LibTorch 2.12 / CUDA 13.0 package。 |

CUDA は意図的にプラットフォームを限定しています。Windows win-x64 かつ native runtime
要件を満たす環境でのみ利用してください。

## PyPI パッケージ

0.1.3 line では、Python package は managed package API catalog に対する薄い wrapper
として公開します。Python 側で CTG、provider routing、WASM execution、CUDA runtime、
Doom scenario logic を再実装してはいけません。

| パッケージ | import surface | 役割 |
|---|---|---|
| `aikernel-net` | `aikernel_net` | Core runtime wrapper、managed API catalog、assembly discovery、CTG-ROM sample asset。 |
| `aikernel-governance` | `aikernel_governance` | Control / governance wrapper。 |
| `aikernel-providers` | `aikernel_providers` | Provider descriptor、manifest、invoker wrapper。 |
| `aikernel-tools` | `aikernel_tools` | instrumentation、formatter、inspector、replay、CLI 隣接 wrapper。 |
| `aikernel-wasm` | `aikernel_wasm` | WASM runtime と WebGPU wrapper surface。 |
| `aikernel-cuda13-libtorch2-12-win-x64` | `aikernel_cuda13_libtorch2_12_win_x64` | Windows 専用 CUDA wrapper metadata と loader guidance。 |

安定版公開後は、必要なレイヤーごとに導入します。

```bash
pip install aikernel-net==0.1.3
pip install aikernel-providers==0.1.3
pip install aikernel-tools==0.1.3
```

governance、WASM、CUDA wrapper を使う場合は次を追加します。

```bash
pip install aikernel-governance==0.1.3
pip install aikernel-wasm==0.1.3
pip install aikernel-cuda13-libtorch2-12-win-x64==0.1.3
```

ローカル検証では `0.1.3.dev<build-number>` の local wheel を使い、Python wrapper の
API catalog が C# public surface を網羅していることを確認します。

## 依存順

package family は依存関係順に build / validate します。

1. `AIKernel.NET`
2. `AIKernel.Core`
3. `AIKernel.Control`
4. `AIKernel.Providers`
5. `AIKernel.Cuda13.0`
6. `AIKernel.Wasm`
7. `AIKernel.Tools`
8. Demo repository: `AIKernel.Demo`, `AIKernel.Doom`

Demo repository は検証対象であり、package publication 対象ではありません。

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

## 履歴ライン

| ライン | 意味 |
|---|---|
| `0.1.3` | 最初に同期された public Semantic OS package line。 |
| `0.1.3` | NuGet package と同期 Python wrapper を揃えた public canonical package line。 |
| `0.1.3` | 現在の正典シリーズターゲット。公開開始後は NuGet / PyPI package family を同期。 |

0.1.3 時点の CTG ドキュメントは migration context として維持します。

- [`../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1-jp.md`](../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1-jp.md)
- [`../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md`](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md)
- [`../design/CTG_CONTRACT_MODEL-v0.1.1.1-jp.md`](../design/CTG_CONTRACT_MODEL-v0.1.1.1-jp.md)
- [`CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md`](CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md)

## リポジトリ導線

- [AIKernel.NET](https://github.com/AIKernel-NET/AIKernel.NET) - contract boundary packages。
- [AIKernel.Core](https://github.com/AIKernel-NET/AIKernel.Core) - runtime と OS abstractions。
- [AIKernel.Providers](https://github.com/AIKernel-NET/AIKernel.Providers) - standard / extension provider drivers。
- [AIKernel.Control](https://github.com/AIKernel-NET/AIKernel.Control) - governance と control plane。
- [AIKernel.Tools](https://github.com/AIKernel-NET/AIKernel.Tools) - instrumentation と CLI。
- [AIKernel.Wasm](https://github.com/AIKernel-NET/AIKernel.Wasm) - sandboxed WASM runtime。
- [AIKernel.Cuda13.0](https://github.com/AIKernel-NET/AIKernel.Cuda13.0) - Windows CUDA package line。
- [AIKernel.Demo](https://github.com/AIKernel-NET/AIKernel.Demo) - 公式サンプル。

## リリースルール

正典 line では、同じ `0.1.3` package family だけを組み合わせてください。migration
behavior を明示的に試験する場合を除き、release validation environment で `0.1.3`、
`0.1.3`、`0.1.3` を混在させないでください。

安定版 package は公開タスクが開始されてから作成します。それまでは、すべての local package
validation で次を使います。

```text
NuGet: 0.1.3-dev<build-number>
PyPI:  0.1.3.dev<build-number>
```
