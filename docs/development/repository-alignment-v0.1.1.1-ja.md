---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel リポジトリ整合方針 v0.1.1.1

この文書は、AIKernel 0.1.1.1 開発ラインにおけるリポジトリ横断の整合方針です。
各リポジトリの文書はローカルの build、package、implementation details を説明できますが、
共有の境界ルールはこの文書を正とします。

## 共通バージョン方針

- 公開済み baseline は 0.1.1 package family です。
- 現在の開発更新ラインは 0.1.1.1 です。
- ローカル開発 package は `0.1.1.1-dev{build-number}` を使います。
- 0.1.1.1 ラインは、Python/PyPI release が明示的に予定されない限り NuGet-only です。
- このラインにおける Python wrapper 文書は参照資料です。0.1.1.1 検証のために
  PyPI package を build / publish / require しません。

## ドキュメントの所有権

- AIKernel.NET は共通理論、contract policy、repository alignment、concept vocabulary、
  migration policy、cross-package documentation rules を所有します。
- 実装リポジトリは local setup、package usage、diagnostics、tests、
  implementation-specific developer notes を所有します。
- Demo / scenario repository は runnable examples と scenario mappings を所有し、
  共有 runtime semantics は所有しません。

## リポジトリ責務

| Repository | Role | Must not own |
| --- | --- | --- |
| `AIKernel.NET` | Contract、DTO、enum、canonical documentation、concept vocabulary。 | Runtime implementation、provider SDK wrapper、scenario logic。 |
| `AIKernel.Core` | Deterministic kernel runtime、monads、CTG evaluator、hosting、VFS/runtime primitive。 | Provider endpoint behavior、browser/WASM runtime、scenario mapping。 |
| `AIKernel.Providers` | Provider substrate、manifest、descriptor、deterministic router、runtime-configurable provider。 | Gate logic、WASM/JSInterop、固定 native SDK 依存、Doom semantics。 |
| `AIKernel.Cuda13.0` | 明示 opt-in の CUDA 13.0 + LibTorch 2.12 Windows backend package。 | Core runtime policy、generic provider routing、非 CUDA backend。 |
| `AIKernel.Control` | Orchestration、policy application、Core gate invocation、execution coordination。 | Gate truth table、provider semantics、browser runtime implementation。 |
| `AIKernel.Tools` | CLI、inspector、replay、instrumentation、canonical formatting。 | Kernel runtime ownership、provider execution、scenario runtime。 |
| `AIKernel.Wasm` | Browser/WebAssembly runtime、WebGPU/WebAudio/display/input execution surfaces。 | Doom-specific semantics、Providers substrate ownership、Gate/CTG decision。 |
| `AIKernel.Demo` | Package family を消費する runnable examples。 | Runtime contracts、package ownership、production scenario semantics。 |
| `AIKernel.Doom` | DOOM 向け scenario-specific demo mapping と browser sample。 | Shared contracts、generic WASM semantics、Core/Control gate logic。 |

## 判断境界

- Control は Core gate service を呼び出します。Decision Gate / Trajectory Gate logic を
  再実装しません。
- Providers は semantic material と diagnostics を返します。
  `GateDecisionKind`、`TrajectoryGateDecisionKind`、`RejectReasonKind`、`GateInput` を返しません。
- Wasm は browser-bound perception、spatial、HUD、WebGPU、WebAudio、framebuffer、
  input surface を実行します。Doom には依存しません。
- Doom は generic surface に対して scenario-specific な visual、audio、HUD、input semantics を
  map します。
- CUDA package は target runtime を知ることができますが、generic provider layer は
  descriptor-driven であり、compile-time CUDA runtime coupling を持ちません。

## 0.1.2 昇格に向けた Thin Surface Rule

perception、spatial、HUD、overlay、browser runtime surface の一部は、0.1.1.1 時点では
implementation / substrate の薄い surface です。0.1.2 の canonical contract update で
AIKernel.NET contracts へ昇格できるよう、additive かつ non-breaking に保ちます。

0.1.1.1 中に contract promotion plan が明示的に開かれない限り、これらを AIKernel.NET へ
移動しません。

## ローカル検証順序

最も共有度の高い surface から scenario-specific surface へ順に検証します。

1. `AIKernel.NET`
2. `AIKernel.Core`
3. `AIKernel.Providers`
4. `AIKernel.Cuda13.0`
5. `AIKernel.Control`
6. `AIKernel.Tools`
7. `AIKernel.Wasm`
8. `AIKernel.Demo`
9. `AIKernel.Doom`

ある repository が別 repository の current development work を消費する場合は、
同じ `0.1.1.1-dev{build}` family の local NuGet package version を使います。

