---
title: "CLIと実行記録を使って調べる"
lang: ja
description: "AIKernel.Toolsは、CLIや実行記録の検査を担当します。アプリの実装を変える前に、どの機能やファイル領域が見えているかを確認するために使います。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# CLIと実行記録を使って調べる

AIKernel.Toolsは、CLIや実行記録の検査を担当します。アプリの実装を変える前に、どの機能やファイル領域が見えているかを確認するために使います。

## CLIを導入する

CLIは.NETのツールとしてインストールします。アプリのプロジェクトへ通常のライブラリとして追加するものとは導入方法が異なります。以下は0.1.3のDemo READMEに記載されたコマンドです。

```powershell
dotnet tool install -g AIKernel.Tools.CLI --version 0.1.3
aik runtime ping
aik system info
aik capabilities list
```

インストールには.NET SDKとパッケージ配布元への接続が必要です。すでに別版が入っている場合は、まず `dotnet tool list -g` で版を確認します。このページのCLI例はソースの記載を確認したもので、Quick Startのコンソールデモとは別の手順です。

## 結果をどう使うか

`runtime ping` で基本の応答を調べ、`system info` で見えている構成を確認し、`capabilities list` で公開されている処理を調べます。表示される機能は使うホストや登録状態に依存するため、固定の一覧を成功条件にしません。

ファイル領域を確認するときは、対象フォルダーを明示します。

```powershell
aik system vfs --vfs-root .
```

この `.` はコマンドを実行しているフォルダーです。調査対象でない秘密情報のあるフォルダーを選ばないようにしてください。

## Replayの記録を読むとき

処理の入力、Providerの選択、適用したルール、パッケージ版を比較します。文章の差だけでなく、実行条件が変わっていないかを見ることが大切です。利用可能な検査機能は[ToolsのREADME](https://github.com/AIKernel-NET/AIKernel.Tools/blob/main/README-ja.md)、利用例は[DemoのREADME](https://github.com/AIKernel-NET/AIKernel.Demo/blob/8c960f57bdf6f431663a1ca33de7584f5e882140/README-ja.md)で確認できます。

記録に問題があるときは[トラブル対応](../runtime/index-jp.md)、そもそもReplayが何を意味するかは[概念説明](../concepts/index-jp.md)へ進んでください。
