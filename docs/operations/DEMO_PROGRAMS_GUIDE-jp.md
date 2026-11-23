---
title: "AIKernel 0.1.3 デモプログラムガイド"
updated: 2026-11-08
published: 2026-06-16
version: "0.1.3"
edition: "Release"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# AIKernel 0.1.3 デモプログラムガイド

AIKernel.Demo は、0.1.3 パッケージラインの公式サンプルリポジトリです。
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
| `AIKernel.Demo.Cuda` | `AIKernel.Kernel` 0.1.4 | 同梱 CUDA Driver による VRAM 転送。 |

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

Windows x64 と Linux x64 では、`AIKernel.Kernel` 0.1.4 同梱の CUDA Driver を使います。実行時に必要なネイティブ依存は NVIDIA ドライバのみです。

```bash
dotnet run --project src/AIKernel.Demo.Cuda/AIKernel.Demo.Cuda.csproj
```

対応外の環境、ドライバ未導入、または CUDA デバイスがない場合は `status=skipped`、転送成功時は `status=ok` が表示されます。

## Python デモサーフェス

AIKernel.Demo は Python 側にも対応するデモ導線を持ちます。PyPI パッケージ導入後、wrapper import、managed assembly discovery、dry-run package surface の確認に利用します。

次のコマンドは、対応する安定版 0.1.3 wheel の公開後に使います。公開前の
検証には同じ系列のローカル wheel を使い、
[リリース整合ガイド](../development/package-release-alignment-v0.1.3-ja.md) を参照してください。

```bash
pip install aikernel-net==0.1.3 aikernel-providers==0.1.3 aikernel-tools==0.1.3
```

`aikernel-governance` と `aikernel-wasm` は、そのレイヤーを利用する場合に追加します。

## Doom ブラウザーデモ

`AIKernel.Doom` は独立したソースデモで、インストールするパッケージではありません。
[公式サイトの埋め込みデモ](https://aikernel.net/#doom-demo) は引き続き利用できます。
版別ページの反映後は `/demo/doom/` が一覧、`/demo/doom/versions/v<version>/` が
個別の URL になります。用意した配置候補は `v0.1.2` のみで、`v0.1.3` はローカルプレビューです。

ライセンス表示を確認し、WAD とモデルのダウンロードには明示的に同意してください。
同意画面までの表示確認は、ゲームプレイや再起動を含む検証とは別です。

## 推奨される読み進め方

1. `AIKernel.Demo.CoreRuntime` を実行する。
2. パッケージ導入ガイドを読む。
3. `AIKernel.Demo.StandardProviders` を実行する。
4. `AIKernel.Demo.Providers` で拡張 Provider の形を確認する。
5. 評価対象のレイヤーに応じて Control、Tools、WASM、CUDA を追加する。

この順序にすると、kernel、driver、governance、observability の境界が順に見えるため、AIKernel を OS として理解しやすくなります。
