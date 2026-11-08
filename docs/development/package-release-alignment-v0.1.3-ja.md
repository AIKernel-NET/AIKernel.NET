---
updated: 2026-11-08
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# Package Release Alignment v0.1.3

[English](package-release-alignment-v0.1.3.md)

この文書は、AIKernel.NET 0.1.3 正典シリーズにおける package alignment の
開発者向け source です。package maintainer が「現行の手順」「履歴として残す手順」
「local validation で混在させてよい version」を迷わないようにします。

## 現行 Package Line

安定版の公開対象は `0.1.3` です。ローカルの開発版の検証結果は、安定版の公開や
安定版 PyPI wheel の検証完了を意味しません。

local validation では、次の development family を 1 系列だけ選んで使います。

| パッケージシステム | ローカル開発版 |
|---|---|
| NuGet | `0.1.3-dev<build-number>` |
| PyPI | `0.1.3.dev<build-number>` |

migration や fallback behavior を明示的に試験する場合を除き、安定版 `0.1.3`
package と別 build の local package を混在させないでください。

## Repository Order

build / verify は次の順序で行います。

1. `AIKernel.NET`
2. `AIKernel.Core`
3. `AIKernel.Control`
4. `AIKernel.Providers`
5. `AIKernel.Cuda13.0`
6. `AIKernel.Wasm`
7. `AIKernel.Tools`
8. `AIKernel.Demo`
9. `AIKernel.Doom`

最初の 7 リポジトリはパッケージを定義します。Demo と Doom は連携を検証する
ソースデモで、NuGet／PyPI の公開対象ではありません。Dawn のネイティブ検証は
別枠です。

## ローカル検証の記録：`0.1.3-dev3`

2026-11-08 時点のローカル検証。共通フィードはワークスペースの
`artifacts/local-nuget/v0.1.3-dev3/`、ログは
`artifacts/contract-validation/v0.1.3-dev3/` にあります。Release テストの件数は
成功した実行のみを数え、再試行や別枠のスモークテストは含めません。

| リポジトリ | Release 合格 | NuGet | 補足 |
|---|---:|---:|---|
| AIKernel.NET | 173 | 4 | `GpuCanonicalContractTests` の37ケースを含む |
| AIKernel.Core | 439 | 5 | dev3 の契約パッケージで復元・検証 |
| AIKernel.Control | 42 | 6 | Python 同梱 DLL と依存マニフェストの再生成・読み込みを確認 |
| AIKernel.Providers | 120 | 12 | Compute を含む Python 同梱 DLL の再生成・読み込み・登録を確認 |
| AIKernel.Cuda13.0 | 21 | 1 | Windows x64 のネイティブ ABI と隔離した Python 同梱物の読み込みを確認。モデル推論の検証ではない |
| AIKernel.Wasm | 64 | 9 | 実ブラウザーで WebGPU 3パスが動作。隔離環境の dev3 wheel で同梱 DLL と3つの `.create()` を確認 |
| AIKernel.Tools | 34 | 6 | CLI と、隔離環境の dev3 wheel に同梱した DLL の読み込み・Python テスト8件を確認 |

NuGet は計43件です。Demo はこの記録の検証対象に含まれません。Doom は別枠で
Release 566件、JavaScript 42件、版別ページの起動・描画4件、Edge の GPU／CPU
起動を確認しました。これらはブラウザー内の完全なライフサイクル試験とは別です。

## 安定版へ進む前の確認

1. 変更をリポジトリ単位でレビューし、公開対象のコミットを固定します。変更された
   成果物を既存の dev3 として上書きせず、新しい開発版番号とフィードで再検証します。
2. Demo と、公開範囲に含める任意のネイティブ Capability を、確定した依存関係で確認します。
3. PyPI の対象ごとに、同じ系列から同梱物を再生成し、クリーンな環境に wheel を
   インストールしてテストします。Wasm は安定版 DLL で
   `WasmRuntime`、`WasmRuntimeContext`、`WebGpuWasmBackend` の `.create()` を再確認します。
   開発版同梱物を安定版 wheel に入れないよう、公開ワークフローの入力も照合します。
4. 公開承認後、安定版 `0.1.3` を依存順に新規ビルドし、依存バージョン・内容・
   ハッシュ・クリーンな消費側での復元を確認します。NET は既定でローカル版を
   生成するため、安定版生成時は `UseLocalPackageVersion=false` を明示します。
5. 公開後に公式フィードから再取得して確認し、その結果に合わせてサイトの導入案内を
   切り替えます。Doom の新版は、完全なライフサイクル試験と対応ソース・ライセンスの
   公開条件を満たしたあと、既存版を上書きせず別 URL に配置します。

## Source Of Truth

- package installation UX は
  [Package Installation Guide](../operations/PACKAGE_INSTALLATION_GUIDE-jp.md) に置きます。
- demo execution UX は
  [Demo Programs Guide](../operations/DEMO_PROGRAMS_GUIDE-jp.md) に置きます。
- GPU migration context は
  [GPU Canonical Migration](../migration/v0.1.3-gpu-canonical-migration-jp.md) に置きます。
- XML comment rule は
  [XML Documentation Policy](../operations/XML_DOCUMENTATION_POLICY-v0.1.3-jp.md) に置きます。

履歴文書は title や filename に古い version number を残してよいです。一方で、現行の
install command、package table、local validation example は 0.1.3 family を使います。

## Developer Checklist

- public example では NuGet と PyPI の package family を同期する。
- repository 固有の build note は、その build を所有する repository に置く。
- stable install command と local `dev` validation command を混ぜて書かない。
- Demo と Doom は package publication root ではなく validation/demo surface であることを明記する。
- public API documentation は .NET XML documentation tag または paired include file でバイリンガル化する。
