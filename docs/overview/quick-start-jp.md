---
title: "最初のサンプルを動かす"
lang: ja
description: "小さなコンソールアプリを実行し、AIKernelが処理の行き先、利用できる機能、時刻、ファイルへの窓口をどのように分けているかを確認します。実行時のAPIキー、モデルのダウンロード、GPUは不要です。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.4"
documentation_target: "0.1.4"
updated: "2026-11-23"
---

# 最初のサンプルを動かす

小さなコンソールアプリを実行し、AIKernelが処理の行き先、利用できる機能、時刻、ファイルへの窓口をどのように分けているかを確認します。実行時のAPIキー、モデルのダウンロード、GPUは不要です。

## 始める前に

Gitと.NET 10 SDKを用意してください。SDKは `dotnet --version` で確認できます。初回のソース取得とNuGetパッケージの復元にはネットワーク接続が必要です。

この手順では、NuGetで公開中のAIKernel 0.1.4を使います。2026年11月23日にWindowsで下記の出力を確認しました。インストール前にモデルの応答を見たい場合は、[ブラウザーのモデル切り替えデモ](https://aikernel.net/demo/chat/)を試せます。

## 1. サンプルを取得する

新しい作業フォルダーで、次のコマンドを実行します。確認したソースに固定するため、コミットを指定しています。既存の作業中のコピーがある場合も、この手順では別のフォルダーを使ってください。

```powershell
git clone https://github.com/AIKernel-NET/AIKernel.Demo.git aikernel-first-run
cd aikernel-first-run
git checkout 800f92fc816bb792e91d2a31d5ec363a8c737278
dotnet --version
```

## 2. 一つのプロジェクトを実行する

現在のフォルダーが `aikernel-first-run` であることを確認してから実行します。ソリューション全体をビルドする必要はありません。

```powershell
dotnet restore src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj -p:StablePackageVersion=0.1.4 -p:UseLocalPackageVersion=false
dotnet run --project src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj -c Release --no-restore -p:StablePackageVersion=0.1.4 -p:UseLocalPackageVersion=false
```

## 3. 出力を確認する

ビルドのメッセージに続いて、次の行が表示されればサンプルは動いています。末尾には `contract.map=` で始まる型名の一覧も表示されます。

```text
AIKernel.Demo.CoreRuntime
router.route=local.default
registry=InMemoryCapabilityRegistry
clock.replaying=False
vfs.provider=MemoryFileProvider
```

`local.default` は入力に対して選ばれた行き先です。`False` は今回の時計がリプレイモードではないことを示します。ここでは構成要素を作って確認しており、LLMへの問い合わせや完全なKernel起動は行いません。これで、外部モデルの認証や通信を調べる前に、基本パッケージを使える環境か確かめられます。

## うまく動かないとき

| 表示・症状 | 確認すること |
| --- | --- |
| `dotnet` が見つからない | .NET 10 SDKのインストール後、ターミナルを開き直します。Runtimeだけではビルドできません。 |
| SDKが見つからない・対象フレームワークを扱えない | `dotnet --list-sdks` で.NET 10 SDKを確認します。作業フォルダーや親フォルダーに `global.json` がある場合は、そのSDK指定も確認します。 |
| `NU1301` など復元時のエラー | NuGetへの接続、プロキシ、`NuGet.config` を確認します。APIキーはこの復元エラーと無関係です。 |
| プロジェクトファイルが見つからない | `AIKernel.Demo.slnx` のあるフォルダーから実行しているか確認します。 |
| APIや型が見つからない | 指定コミットに切り替え、両方のコマンドに0.1.4を指定するオプションが入っていることを確認します。 |

動作確認では、指定した公開コミットから取得したプロジェクトと設定ファイルを使い、空のパッケージ保存先へNuGetから復元して実行しました。ネットワークやプロキシの条件が異なる場合は、上の表で切り分けてください。

## 次に、出力とコードを結びつける

[サンプルを一行ずつ読む](../tutorials/first-kernel-jp.md)では、今の出力を作ったコードを追い、一か所変更して結果を比べます。言葉が気になったら[最初に知っておく概念](../concepts/index-jp.md)を参照してください。

自分のCPU環境でモデルを実行する手順は、[0.1.4への移行ガイド](upgrade-0-1-4-jp.md)のローカル推論の節をご覧ください。
