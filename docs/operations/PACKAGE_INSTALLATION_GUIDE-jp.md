---
title: "AIKernel パッケージ導入ガイド"
description: "公開済みのAIKernel 0.1.4をNuGetまたはPyPIから導入し、取得した版と用途に合うパッケージを確認します。"
updated: 2026-11-24
published: 2026-06-16
version: "0.1.4"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel パッケージ導入ガイド

ランタイムの導入例には公開済みの AIKernel SDK 0.1.4 を使います。Provider は用途ごとに下表の公開版を確認してください。 初めての方は、[最初のサンプルを動かす](../overview/quick-start-jp.md)で、実行するプロジェクトと期待する出力を確認できます。すでに0.1.3を使っている場合は、[0.1.4への移行ガイド](../overview/upgrade-0-1-4-jp.md)から始めてください。

## NuGet パッケージ

.NETプロジェクトがあるディレクトリで、.NET 10 SDKを確認してからランタイムを追加します。

```console
dotnet --list-sdks
dotnet add package AIKernel.Core --version 0.1.4
dotnet list package --include-transitive
```

一覧で `AIKernel.Core` の解決済みバージョンが0.1.4になっていることを確かめます。パッケージの版を一元管理している場合は、`Directory.Packages.props` の `PackageVersion` も確認します。復元できない場合は `dotnet nuget list source` を実行し、`AIKernel.*` を取得するフィードを確認してください。

| 作りたいもの | 追加するパッケージ |
| --- | --- |
| ランタイムを使うコンソールアプリ | [AIKernel.Core 0.1.4](https://www.nuget.org/packages/AIKernel.Core/0.1.4) |
| .NET Generic Hostから起動するアプリ | [AIKernel.Hosting 0.1.4](https://www.nuget.org/packages/AIKernel.Hosting/0.1.4) |
| 同じサービスをHTTPとMCPに公開するアプリ | Hostingと [AIKernel.Providers.Distributed 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.Distributed/0.1.4) |

## 用途別の Provider と公開版

モデルやネイティブランタイムが必要な Provider では、利用するホストで設定してください。下表の共有契約は通常、Provider の依存として取得されます。`Directory.Packages.props` などで直接指定する場合は、各 Provider の NuGet 依存関係を確認してください。

| 用途 | NuGet パッケージ | 用途別の共有契約 |
| --- | --- | --- |
| ローカルのチャット生成 | [AIKernel.Providers.LocalLlm 0.1.6](https://www.nuget.org/packages/AIKernel.Providers.LocalLlm/0.1.6) | — |
| テキスト埋め込み | [AIKernel.Providers.Embedding 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.Embedding/0.1.4) | [AIKernel.Contracts.Embedding 0.1.4](https://www.nuget.org/packages/AIKernel.Contracts.Embedding/0.1.4) |
| 検索結果の再順位付け | [AIKernel.Providers.Reranker 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.Reranker/0.1.4) | [AIKernel.Contracts.Reranking 0.1.4](https://www.nuget.org/packages/AIKernel.Contracts.Reranking/0.1.4) |
| WAVの文字起こし | [AIKernel.Providers.Stt 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.Stt/0.1.4) | [AIKernel.Contracts.SpeechRecognition 0.1.4](https://www.nuget.org/packages/AIKernel.Contracts.SpeechRecognition/0.1.4) |
| 音声合成 | [AIKernel.Providers.Tts 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.Tts/0.1.4) | — |
| 出典付きの文書検索 | [AIKernel.Providers.DocumentSearch 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.DocumentSearch/0.1.4) | — |
| 画像のイラスト化・背景除去 | [AIKernel.Providers.Image 0.3.0](https://www.nuget.org/packages/AIKernel.Providers.Image/0.3.0) | [AIKernel.Contracts.Images 0.3.0](https://www.nuget.org/packages/AIKernel.Contracts.Images/0.3.0) |
| FLUX.2 klein 4Bによる画像編集 | [AIKernel.Providers.Flux 0.1.5](https://www.nuget.org/packages/AIKernel.Providers.Flux/0.1.5) | [AIKernel.Contracts.Images 0.1.5](https://www.nuget.org/packages/AIKernel.Contracts.Images/0.1.5) |
| FLUX.2 klein 4BのCUDA実行 | [AIKernel.Providers.Flux.Cuda 0.1.5](https://www.nuget.org/packages/AIKernel.Providers.Flux.Cuda/0.1.5) | [AIKernel.Contracts.Images 0.1.5](https://www.nuget.org/packages/AIKernel.Contracts.Images/0.1.5) |
| Cosmosのランタイム接続 | [AIKernel.Providers.Cosmos 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.Cosmos/0.1.4) | — |
| Providerの配置先選択 | [AIKernel.Providers.ProviderPlacement 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.ProviderPlacement/0.1.4) | [AIKernel.Contracts.ProviderPlacement 0.1.4](https://www.nuget.org/packages/AIKernel.Contracts.ProviderPlacement/0.1.4) |

Provider の初回公開は SDK と同じ `0.1.4` です。モジュール単独の再リリースでは、第4要素を `0.1.4.1`、`0.1.4.2` のように進めます。LocalLlm、画像系、一部の WebGPU パッケージには過去に異なる版で公開されたものがあるため、表に実際の公開版を記載しています。

他のProviderや依存関係は、[パッケージの役割](../architecture/module-map-jp.md)と[NuGetの公開一覧](https://www.nuget.org/profiles/AIKernel-NET)をご覧ください。

## WebGPU を追加する

用途に合わせて Provider を選びます。どちらも .NET 10 と AIKernel SDK 0.1.4 に対応します。

| 実行環境 | パッケージ | 確認できること |
| --- | --- | --- |
| ネイティブ .NET ホスト | [AIKernel.Dawn.Provider 0.1.4](https://www.nuget.org/packages/AIKernel.Dawn.Provider/0.1.4) | D3D12 または Vulkan で `compute.vector_add` を実行する |
| ブラウザー内の WebAssembly | [AIKernel.Wasm.WebGpuComputeProvider 0.1.5](https://www.nuget.org/packages/AIKernel.Wasm.WebGpuComputeProvider/0.1.5) | OPFS に保存した重みをページ単位で WebGPU に転送する |

```bash
dotnet add package AIKernel.Dawn.Provider --version 0.1.4
dotnet add package AIKernel.Wasm.WebGpuComputeProvider --version 0.1.5
```

Dawn の Linux 動作は Ubuntu 24.04 と Vulkan ドライバーで検証しました。ブラウザー版はローカルホストまたは HTTPS で配信し、専用 Worker を使います。環境に応じた準備と計算結果の確認方法は[ブラウザー・WebGPU ガイド](../wasm/runtime-jp.md)を参照してください。

## CUDA を使う

Windows x64 と Linux x64 では、`AIKernel.Kernel` 0.1.4 同梱の CUDA Driver を使います。実行時に必要なネイティブ依存は NVIDIA ドライバのみです。

```bash
dotnet add package AIKernel.Kernel --version 0.1.4
```

`AIKernel.Cuda13.0` は 0.1.3 までの旧 LibTorch 参照実装で、保守は終了しました。

## PyPI パッケージ

仮想環境を有効にしてから、その環境のPythonで実行します。

```console
python -m pip install aikernel-net==0.1.4
python -m pip show aikernel-net
```

`Version: 0.1.4` が表示されることを確かめます。対応するPythonや配布ファイルは [PyPIのaikernel-net](https://pypi.org/project/aikernel-net/0.1.4/) に掲載されています。対応する配布物が見つからない場合は、使用中のPythonの版とpipのインデックス設定を確認してください。

## 履歴ライン

| 版 | 参照する場面 |
| --- | --- |
| 0.1.4 | 現行の導入手順。HTTP／MCPホスティングや標準CPU推論を使う場合。 |
| 0.1.3 | 以前の構成を確認する場合。[0.1.4 移行ガイド](../overview/upgrade-0-1-4-jp.md)を参照してください。 |
| 0.1.2以前 | 過去の構成を再現するために当時の資料を参照する場合。 |

更新時はアプリが直接参照するAIKernelパッケージをそろえ、依存として取得された版も確認します。ローカルビルドを検証する場合は、専用フィードと空のパッケージキャッシュを使うと、検証対象の配布物を特定できます。

## 0.1.4 のホスト設定

`KernelRequest` を使うホストは、認証済み主体、PDP、Guard を設定してください。`vfs.open` と `model.execute` のそれぞれで承認が必要です。VFS には `CredentialValidator` を設定し、書き込みが必要なローカル VFS だけ `AllowWrite` を有効にします。物理 VFS のルートと配下のディレクトリはホストが管理してください。Web VFS に独自の HTTP ハンドラーを渡す場合は自動リダイレクトを無効にします。標準の ROM 検証器には VFS パスとファイル全体の SHA-256 を、動的プロバイダーには DLL の SHA-256 を `TrustedAssemblyDigests` に登録します。

標準ネットワークプロバイダーの接続先は `services.AddAIKernelStandardProviders("https://api.example.org")` のように登録します。空の一覧では、このプロバイダーからの外向き通信を拒否します。標準以外のポートは明記し、TCP 接続には `tcp://ホスト名:ポート` を個別に登録します。
