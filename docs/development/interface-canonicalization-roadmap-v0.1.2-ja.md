# v0.1.2 Interface 正典化ロードマップ

このメモは、次回の正典 Interface 更新でレビューする実装 surface を整理するためのものです。契約ファイルではありません。現行の v0.1.1.1 パッケージでは、これらの surface を薄く保ち、CTG の意味論を変えずに昇格、改名、統合、削除できる状態にします。

## Release 前提

v0.1.2 正典シリーズは次の公式 release line です。v0.1.1.1 の local validation line と異なり、
v0.1.2 では NuGet と PyPI の package family が同期して公開される前提で準備します。
この roadmap の Interface 昇格判断では、.NET package consumer と Python wrapper consumer の
両方を考慮します。

## 候補ドメイン

- Perception: frame perception、auditory perception、spatial cognition、HUD signal extraction、overlay annotation DTO generation。
- Runtime model execution: descriptor-driven resident model execution、WebGPU buffer binding descriptor、zero-copy capability metadata。
- Control orchestration: perception-derived vote carrier、CTG policy delegation、dynamic pipeline selection carrier。
- Scenario mapping: scenario 固有 HUD、overlay、virtual input mapping。

## v0.1.1.1 での保持方針

- `AIKernel.Providers.Perception` は provider substrate contract のみを保持します。WebGPU、WebAudio、WASM runtime、scenario logic は所有しません。
- `AIKernel.Wasm.*` パッケージは browser/WASM execution surface を所有し、正典 contract が追加されるまで local DTO を公開できます。
- `AIKernel.Control.Core.Perception` は perception 由来の discrete vote candidate を既存 CTG Control pipeline に変換する adapter surface を所有します。
- scenario package は scenario 固有 mapping のみを所有します。

## v0.1.2 レビュー項目

- 最初の v0.1.2 正典 cognition pipeline surface を
  [正典 Interface Set v0.1.2](canonical-interface-set-v0.1.2-ja.md) として追加しました。
- Doom 固有の demo 例は `AIKernel.Abstractions.Scenarios` の scenario-neutral contract へ写像します。
- spatial / auditory の実装詳細は、DTO がさらに安定するまで実装 repository 側に保持します。
- resident model execution を `AIKernel.Abstractions.Models` に寄せるか、専用 execution domain にするかレビューする。
- HUD/overlay の request metadata key と diagnostic key を統一する。
- Control は Core CTG result を読むだけで Gate logic を実装しない、というルールを維持する。

## 境界ルール

- Providers は substrate、manifest、router、registry、descriptor、runtime-configurable provider surface に留まります。
- Wasm は browser/WASM runtime、WebGPU、WebAudio、framebuffer、virtual input、JS interop boundary を所有します。
- Control は orchestration と Core Gate invocation のみを所有します。
- scenario repository は scenario-specific semantics、mapping、benchmark のみを所有します。
- CTG GateInput は vote-only です。confidence、risk、score、diagnostics、explanation は GateInput に流しません。
