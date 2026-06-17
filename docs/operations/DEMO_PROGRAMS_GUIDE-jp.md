---
title: "AIKernel 0.1.1 デモプログラムガイド"
updated: 2026-06-10
published: 2026-06-10
version: "0.1.1"
edition: "Release"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# AIKernel 0.1.1 デモプログラムガイド

AIKernel.Demo は、0.1.1 パッケージラインの公式サンプルリポジトリです。  
各デモは OS レイヤーごとに最小のゴールデンパスを示すため、パッケージ導入後に最初に触る場所として適しています。

## 最初に動かすデモ

まずは `AIKernel.Demo.CoreRuntime` から始めます。

```bash
dotnet run --project src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj
```

このデモは、semantic router、capability registry、kernel clock、VFS、ROM、time、security surface を含む最小の runtime 形状を示します。

## デモ一覧

| Demo Project | 主なパッケージ | 学べること |
|---|---|---|
| `AIKernel.Demo.CoreRuntime` | `AIKernel.Core` | Kernel runtime、hosting、VFS、ROM、time、security baseline。 |
| `AIKernel.Demo.Contracts` | `AIKernel.Abstractions`, `AIKernel.Contracts`, `AIKernel.Dtos`, `AIKernel.Enums` | Contract DTO、policy result、unified context、hash-chain DTO。 |
| `AIKernel.Demo.Control` | `AIKernel.Control` | Governance policy、deterministic scheduler、emulator、control execution。 |
| `AIKernel.Demo.Providers` | `AIKernel.Providers.*` | Provider descriptor、manifest、invoker、dry-run provider selection。 |
| `AIKernel.Demo.StandardProviders` | `AIKernel.Providers.Standard` | File system、logging、network、EventBus、profiler、scheduler。 |
| `AIKernel.Demo.Tools` | `AIKernel.Tools.Instrumentation` | Canonical formatting、inspection、replay、ROM tooling。 |
| `AIKernel.Demo.Wasm` | `AIKernel.Wasm.Runtime`, `AIKernel.Wasm.WebGpuComputeProvider` | WASM runtime、memory、FS、event、audio、screenshot、save-state、time、WebGPU surface。 |
| `AIKernel.Demo.Cuda` | `AIKernel.Cuda13.0.Libtorch2.12.win-x64` | Windows 専用 CUDA descriptor と guarded native capability surface。 |

## 全デモの実行

デモは外部通信を行わず、dry-run のゴールデンパスとして実行できるように設計されています。

```bash
dotnet build -c Release
dotnet run --project src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj
dotnet run --project src/AIKernel.Demo.Contracts/AIKernel.Demo.Contracts.csproj
dotnet run --project src/AIKernel.Demo.Control/AIKernel.Demo.Control.csproj
dotnet run --project src/AIKernel.Demo.Providers/AIKernel.Demo.Providers.csproj
dotnet run --project src/AIKernel.Demo.StandardProviders/AIKernel.Demo.StandardProviders.csproj
dotnet run --project src/AIKernel.Demo.Tools/AIKernel.Demo.Tools.csproj
dotnet run --project src/AIKernel.Demo.Wasm/AIKernel.Demo.Wasm.csproj
```

CUDA デモは、必要な CUDA native runtime が存在する Windows 環境でのみ実行します。

```bash
dotnet run --project src/AIKernel.Demo.Cuda/AIKernel.Demo.Cuda.csproj
```

Windows 以外では、CUDA デモは失敗ではなく guarded skip を報告する想定です。

## Python デモサーフェス

AIKernel.Demo は Python 側にも対応するデモ導線を持ちます。PyPI パッケージ導入後、wrapper import、managed assembly discovery、dry-run package surface の確認に利用します。

この Python デモ確認は、同期済み 0.1.1 パッケージライン向けです。0.1.1.1 の
contract update では、新しい PyPI package や追加の Python demo validation はありません。
次の公式 v0.1.2 正典シリーズでは PyPI package family を更新する前提のため、
0.1.2 package 公開後にこの demo command も更新します。

```bash
pip install aikernel-net==0.1.1 aikernel-providers==0.1.1 aikernel-tools==0.1.1
```

`aikernel-governance`、`aikernel-wasm`、Windows 専用 CUDA wrapper は、そのレイヤーを利用するシナリオで追加します。

## 推奨される読み進め方

1. `AIKernel.Demo.CoreRuntime` を実行する。
2. パッケージ導入ガイドを読む。
3. `AIKernel.Demo.StandardProviders` を実行する。
4. `AIKernel.Demo.Providers` で拡張 Provider の形を確認する。
5. 評価対象のレイヤーに応じて Control、Tools、WASM、CUDA を追加する。

この順序にすると、kernel、driver、governance、observability の境界が順に見えるため、AIKernel を OS として理解しやすくなります。
