---
title: "サンプルを読み、入力を変えてみる"
lang: ja
description: "[最初のサンプル](../overview/quick-start-jp.md)が動いたら、出力を作るコードを読んでみましょう。今回は「入力文字列を変えると、処理の行き先も変わるか」を確かめます。"
category: tutorials
source: "maintained-guide"
generated: false
release: "0.1.4"
documentation_target: "0.1.4"
updated: "2026-11-23"
---

# サンプルを読み、入力を変えてみる

[最初のサンプル](../overview/quick-start-jp.md)が動いたら、出力を作るコードを読んでみましょう。今回は「入力文字列を変えると、処理の行き先も変わるか」を確かめます。

## 入口は二つのファイル

`AIKernel.Demo` の `src/AIKernel.Demo.CoreRuntime/Program.cs` は、`CoreRuntimeDemo.RunAsync()` の結果を一行ずつ表示します。実際の準備処理は、同じフォルダーの `CoreRuntimeDemo.cs` にあります。

```csharp
var router = new PassThroughSemanticRouter();
var route = await router.RouteAsync("demo core runtime").ConfigureAwait(false);
var registry = new InMemoryCapabilityRegistry();
var clock = KernelClock.System();
var memory = new MemoryFileProvider(new MemoryFileProviderOptions());
```

この抜粋は、Quick Startで指定したソースの処理です。単独の完成したプログラムではなく、既存ファイルの中で読むコードです。

## 出力から分かること

| 出力 | コードで行っていること | この段階では分からないこと |
| --- | --- | --- |
| `router.route=local.default` | ルーターに入力を渡し、返された行き先を表示 | LLMが内容を理解したかどうか |
| `registry=InMemoryCapabilityRegistry` | 機能を登録するための入れ物を作成 | 外部Providerの登録や呼び出しの成功 |
| `clock.replaying=False` | 通常の時計を作成 | 過去の処理を再生できたかどうか |
| `vfs.provider=MemoryFileProvider` | メモリ上のファイルを扱う実装を作成 | ローカルディスクやGitのマウント成功 |

型名が表示されたことと、その機能をすべて実行したことは区別します。特に `contract.map` はAPIの入口の一覧であり、各サービスの起動ログではありません。

## 入力を一か所だけ変える

`CoreRuntimeDemo.cs` の `"demo core runtime"` を `"hello AIKernel"` に変え、Quick Startと同じ `dotnet run` をもう一度実行します。

`PassThroughSemanticRouter` の既定の行き先は `local.default` なので、出力の行き先は同じままです。入力の文章を変えただけでは、別モデルへの振り分けは追加されません。入力に応じて分岐させたい場合は、ルーターの実装・設定を選ぶ作業が必要になります。

学習が終わったら、文字列を元に戻して保存してください。別の変更もあるファイル全体を巻き戻す必要はありません。

## 次に試すことを選ぶ

- 外部モデルやサービスにつなぐには[Providerの選び方](../providers/provider-model-jp.md)へ進みます。
- 各パッケージの役割を知りたい場合は[構成と依存関係](../architecture/module-map-jp.md)を読みます。
- 起動・設定で問題が起きた場合は[実行環境の確認とトラブル対応](../runtime/index-jp.md)を使います。

[確認したソース](https://github.com/AIKernel-NET/AIKernel.Demo/blob/800f92fc816bb792e91d2a31d5ec363a8c737278/src/AIKernel.Demo.CoreRuntime/CoreRuntimeDemo.cs)も参照できます。
