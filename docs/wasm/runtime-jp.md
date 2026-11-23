---
title: "ブラウザーで動かす前に"
lang: ja
description: "AIKernel.Wasmは、ブラウザーやWebAssemblyの実行、描画、入力などを扱うパッケージ群です。.NETのコンソールサンプルが動いても、ブラウザー側のGPU・アセット・権限まで確認できたことにはなりません。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-23"
---

# ブラウザーで動かす前に

AIKernel.Wasmは、ブラウザーやWebAssemblyの実行、描画、入力などを扱うパッケージ群です。.NETのコンソールサンプルが動いても、ブラウザー側のGPU・アセット・権限まで確認できたことにはなりません。

## まず動作を見たい場合

[Doomデモの案内](../doom/demo-overview-jp.md)から公開デモへ進みます。ゲームが動くこと、AIによる自動操作、HUDの状態表示はそれぞれ別に観察してください。画面が出ただけで、すべてのバックエンドが動作したとは判断できません。

## 自分のアプリへ組み込む場合

必要なのがプロセス実行、ファイル、描画、音声、入力のどれかを先に決めます。[AIKernel.WasmのREADME](https://github.com/AIKernel-NET/AIKernel.Wasm/blob/main/README-ja.md)と[ブラウザー用サンプル](https://github.com/AIKernel-NET/AIKernel.Demo/blob/main/src/AIKernel.Demo.Wasm/README.md)で、その機能に必要な準備を確認します。

ローカルのHTMLを直接開く方法では、Workerやアセット取得などがブラウザーの制約で動かないことがあります。サンプルに記載された開発サーバーの手順を使い、読み込み先のURLと失敗したネットワークリクエストを確認してください。

## GPUの結果を確かめる

WebGPUの利用可否はブラウザーと端末の組み合わせに依存します。CPUへの代替経路で動作した結果と、GPUで実行した結果は分けて記録します。HUDに表示されるバックエンドや診断情報を使って、実際にどちらが選ばれたかを確認します。

## ブラウザーで重みをページ単位で読む

[AIKernel.Wasm.WebGpuComputeProvider 0.1.5](https://www.nuget.org/packages/AIKernel.Wasm.WebGpuComputeProvider/0.1.5) の `BrowserWeightMemory` は、OPFS に置いた読み取り専用の重みを AIKernel の仮想メモリに接続します。AIKernel SDK への依存バージョンは 0.1.4 です。

```bash
dotnet add package AIKernel.Wasm.WebGpuComputeProvider --version 0.1.5
```

専用 Worker の .NET WebAssembly から、同梱の `runtime/browser/opfs-weight-memory.mjs` と、事前に検証して OPFS に保存した重みファイルを開きます。WebGPU デバイスと `COPY_DST` 用途のバッファは呼び出し側が用意します。

```csharp
using var weights = await BrowserWeightMemory.OpenAsync(moduleUrl, "weights.bin",
    pageSize: 1 << 20, ramPages: 8);
weights.UploadPage(pageIndex, device, uploadBuffer);
```

`ramPages` は常駐の上限です。転送用の作業領域も含めて予算を見積もり、`GetRamUsage()` で仮想メモリ層の確保量を、`GetStatistics().BackingReads` で OPFS の読み出し回数を確認します。試験では Edge の実 GPU で5回の計算が参照値に一致し、1ページの RAM キャッシュで OPFS 読み出しは4回でした。確認範囲はページ転送と GPU 計算までです。

[0.1.5 のブラウザー試験のソース](https://github.com/AIKernel-NET/AIKernel.Wasm/tree/webgpu-v0.1.5/tests/browser/WeightMemorySmoke)

## ネイティブホストで WebGPU を使う

[AIKernel.Dawn.Provider 0.1.4](https://www.nuget.org/packages/AIKernel.Dawn.Provider/0.1.4) は、.NET 10 のアプリから `compute.vector_add` を実行できます。Windows x64 の D3D12 と Linux x64 の Vulkan に対応します。Windows の Intel UHD P630 と Ubuntu 24.04 の RTX 3080 Ti で、WGSL の計算結果が CPU の参照値に一致しました。[導入ガイド](../operations/PACKAGE_INSTALLATION_GUIDE-jp.md) · [0.1.4 のソースと再現手順](https://github.com/AIKernel-NET/AIKernel.Dawn/tree/v0.1.4)

## 再現情報を残す

ブラウザーの名前と版、OS、選択したバックエンド、実行URL、デモの版、最初のエラーを残します。モデルやアセットの準備が必要な場合は、その準備が完了しているかも添えてください。

実行全体の切り分けは[トラブル対応](../runtime/index-jp.md)、パッケージ間の位置づけは[構成の説明](../architecture/module-map-jp.md)で確認できます。
