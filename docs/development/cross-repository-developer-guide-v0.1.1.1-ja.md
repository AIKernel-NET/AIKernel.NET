---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# リポジトリ横断開発者ガイド v0.1.1.1

[English](cross-repository-developer-guide-v0.1.1.1.md)

このガイドは、複数の AIKernel リポジトリをまたぐ変更を始めるときの最初の
入口です。各リポジトリ固有の docs を置き換えるものではなく、責務の置き場所を
明確にし、誤った layer でロジックを再実装しないための地図です。

## 読む順番

1. このガイドで、責務を所有する repository を決めます。
2. versioning、package、release line の規則は
   [Repository Alignment v0.1.1.1](repository-alignment-v0.1.1.1-ja.md) を読みます。
3. local carrier を AIKernel.NET contract へ昇格する前に
   [Interface Canonicalization Roadmap v0.1.2](interface-canonicalization-roadmap-v0.1.2-ja.md)
   を読みます。
4. 哲学的 concept name を追加する前に
   [Concept Elevation Guidelines](../guidelines/concept-elevation-guidelines.md)
   を読みます。
5. build / test command は対象 repository の `docs/README*.md` を読みます。

## リポジトリ責務

| Repository | 所有するもの | 所有してはいけないもの |
| --- | --- | --- |
| `AIKernel.NET` | Contract、DTO、enum、正典 docs、ROM layout、CTG contract model | 実装 class、provider SDK wrapper、browser/runtime code |
| `AIKernel.Core` | 決定論的 CTG evaluator、Core runtime service、VFS 実装、hosting integration | provider endpoint behavior、Control orchestration、browser/WASM execution、scenario mapping |
| `AIKernel.Control` | orchestration、Apply Policy phase、Core Gate invocation、runtime control、pipeline selection | Decision Gate truth table、provider semantic evaluation、WebGPU/WebAudio 実装、scenario semantics |
| `AIKernel.Providers` | provider substrate、manifest、descriptor、deterministic router、provider-neutral perception/audio/compute substrate | WASM/JS/browser runtime、native SDK 実装、Gate decision、scenario logic |
| `AIKernel.Wasm` | browser/WASM execution、WebGPU/WebAudio、display/input、perception execution、spatial cognition、HUD signal generation | Providers substrate ownership、Doom semantics、CTG/Gate decision |
| `AIKernel.Cuda13.0` | opt-in CUDA native runtime package と CUDA-specific module boundary | generic compute contract、Core policy、non-CUDA provider routing |
| `AIKernel.Tools` | CLI、inspector、replay、diagnostics、canonical formatting、operator instrumentation | runtime implementation、provider execution、scenario runtime |
| `AIKernel.Demo` | package family を消費する runnable example | shared contract、production runtime behavior |
| `AIKernel.Doom` | Doom-specific scenario mapping、web demo glue、sample 用 HUD/input semantics | shared contract、generic WASM semantics、Core/Control Gate logic |

## Package / Release ルール

- v0.1.1.1 line は NuGet-only です。
- この local validation line では PyPI package を作成・公開しません。
- 次の公式 release は v0.1.2 正典シリーズです。v0.1.2 は NuGet + PyPI の
  同期 package line として扱います。
- local development package version は `0.1.1.1-dev{build-number}` を使います。
- 既存 public API は安定維持します。必要な場合は optional DTO property または
  side-by-side interface を追加します。
- `AIKernel.NET` が contract の source of truth です。implementation repository
  の local mirror は v0.1.2 抽出候補として扱います。

## CTG / Control 境界

Decision Gate と Trajectory Gate の logic は Core が所有します。

Control が行ってよいこと:

- provider output を council vote へ正規化する。
- Core CTG evaluator を呼び出す。
- diagnostics と retry intent を `GateInput` の外側へ付与する。
- 返却された decision envelope から execution pipeline を選ぶ。

Control が行ってはいけないこと:

- approval 数を数える。
- Ethos veto を派生する。
- Gate decision を生成する。
- Trajectory Gate の halt logic を複製する。
- confidence、score、risk などの continuous value を `GateInput` へ流す。

Providers、Wasm、Doom、Tools は sensor / perception output として
`GateDecisionKind`、`TrajectoryGateDecisionKind`、`RejectReasonKind` を出力しません。

## Sensor OS と三形体 concept

Sensor OS carrier は固定配列ではなく map です。

```text
sensorInputs: { [sensorName: string]: SensorState }
```

v0.1.1.1 では、これらの carrier は AIKernel.NET contract の外側に置き、
v0.1.2 正典更新で統合できるように準備します。

| Sensor Name | Concept Name | 現在の所有場所 | 意味 |
| --- | --- | --- | --- |
| `visual` | `Aisthesis` | Providers/Wasm/Doom local carrier | 直接的な視覚感覚証跡 |
| `audio` | `Aisthesis` | Providers/Wasm/Doom local carrier | 直接的な stereo auditory evidence |
| `health` | `Aisthesis` | Providers/Wasm/Doom local carrier | HUD / face-like quantization から得る直接的な生命・死亡証跡 |
| `motor` | `Kinesis` | Providers/Wasm/Doom local carrier | movement intent / motion vector input |
| `movement` | `Kinesis` | Providers/Wasm/Doom local carrier | visual / audio / motor を融合した derived relative movement vector |
| `compass` | `Phantasia` | Providers/Wasm/Doom local carrier | 相対 heading representation |
| `spatial` | `Phantasia` | Providers/Wasm/Doom local carrier | fused spatial representation / world model |

`Hodos`、`Zoe`、`Topos` は中間的な sensor label でした。互換 metadata を保持する場合を
除き、新規 code / docs では上表の三形体 model を使います。

Canonical concept flow:

```text
Aisthesis -> Phantasia -> Nous -> Telos -> Ethos/Logos/Pathos
  -> Kairos -> Kinesis/Praxis/Kratos -> Energeia -> Chronos
```

## AIKernel.NET v0.1.2 への昇格準備

local implementation surface を AIKernel.NET へ抽出する前に、次を確認します。

- provider-neutral / scenario-neutral である。
- Gate decision / reject reason を carrier に含めていない。
- DTO は immutable で、collection は null にしない。
- public member には bilingual XML documentation がある。
- breaking change を提案する場合は migration document を作る。

現在の抽出候補:

- sensor input map carrier
- spatial fusion vector carrier
- retry intent carrier
- sensor normalizer abstraction
- spatial sensor fusion abstraction
- retry intent resolver abstraction

## 検証 matrix

まず最小の関連 command を実行します。

```powershell
dotnet test AIKernel.Core\AIKernel.Core.slnx -c Release --no-restore
dotnet test AIKernel.Control\tests\AIKernel.Control.Tests\AIKernel.Control.Tests.csproj -c Release --no-restore
dotnet test AIKernel.Providers\tests\Perception\AIKernel.Providers.Perception.Tests\AIKernel.Providers.Perception.Tests.csproj -c Release --no-restore
dotnet test AIKernel.Wasm\AIKernel.Wasm.slnx -c Release --no-restore
dotnet test AIKernel.Doom\AIKernel.Doom.slnx -c Release --no-restore
```

browser-facing change では JS syntax check と development site sync も実行します。

```powershell
node --check AIKernel.Doom\src\DoomWeb\wwwroot\js\doom.js
WebSite\script\sync_dev_wwwroot.ps1
```

browser automation を使った後は、Node.js debug process が残っていないことを確認します。

## よくあるミス

- shared contract を implementation repository に置く。
- Control が Core Gate logic を複製する。
- Providers が capability adapter ではなく SDK wrapper になる。
- Wasm が Providers perception substrate に直接依存する。
- Doom-specific event name が Wasm / Providers に漏れる。
- DTO、Mapper、Adapter、Serializer、Provider 実装 class に哲学語を使う。
- PyPI packaging を v0.1.2 正典 release line ではなく v0.1.1.1 validation line に戻す。
