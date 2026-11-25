# LocalLlm 0.3.0への移行

0.3.0候補の `chat.local` は、ホストが登録したモデルでテキストを生成します。従来の2行の呼び出しを継続して使えます。

```csharp
using var invoker = new LocalLlmInvoker(settings);
var result = await invoker.InvokeAsync(request, cancellationToken);
```

## 埋め込みを利用する場合

Provider 0.1.4では、埋め込みモデルが未登録でも操作一覧に `embedding.local` が現れ、対応照会は `true` を返していました。0.3.0では一覧から外れ、対応照会は `false` になります。LocalLlmへ直接 `embedding.local` を送ると `provider.model_not_registered` が返ります。埋め込みを使うホストは専用のEmbedding Providerにモデルを登録し、`IEmbeddingRequestProvider.GenerateEmbeddingsAsync` を呼んでください。チャットモデルが未登録の場合の `chat.local` も同じエラーで失敗します。

## ホストへの組み込み

`LocalLlmRegistration.RegisterAsync(settings, registry, cancellationToken)` は、ホストの設定をコピーし、マニフェストのID `local-llm` でProviderとInvokerを結びます。記述子は初期化時に1回登録します。以後は共有の `ICapabilityModuleRegistry` にそのIDを渡して照会し、対応する要求を `ResolveInvoker(request.CapabilityId)` で得た `ICapabilityModuleInvoker` に渡します。IDが違う場合と終了処理に入った場合は `null` が返ります。モデルとシステムプロンプトはホスト設定で管理します。

ホストは登録をモデルの使用期間中保持し、受付終了後に `await registration.DisposeAsync()` で実行中の推論の終了を待って解放します。レジストリの記述子は能力の宣言です。共有契約に登録解除APIはないため、レジストリの寿命もホストに合わせてください。配置ABI v1への登録は保留中です。

## 互換試験の読み方

| 利用者コードの基準 | 凍結0.3.0の結果 |
|---|---|
| Provider 0.1.6／Kernel 0.1.4でコンパイルした利用者DLL | 無再コンパイルで11/11件合格 |
| Provider 0.1.4由来の契約試験（当時の版で5/5件合格） | 同一DLLで3/5件合格。差の2件は埋め込みの操作一覧と対応照会 |

[構成プロジェクトと検証手順](../../src/integrations/LocalLlm/README.md)
