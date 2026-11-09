---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Pre-coding"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
lang: ja
title: "AIKernel Concept Elevation ガイドライン"
description: "哲学由来の概念名を AIKernel の責務境界へ安全に導入するためのガイドラインです。"
---

# AIKernel Concept Elevation ガイドライン

## 目的

Concept Elevation Refactoring は、単なるクラス名変更ではありません。
技術的責務を、意味論的に安定した概念層の名前へ昇格するための設計手順です。
AIKernel の思想、責務境界、型システム、実装構造を一致させることを目的とします。

## 非目的

このリファクタリングでは、次の canonical governance contract、ROM、gate logic を変更しません。

- CTG-ROM
- GateInput
- CouncilVoteValue
- GateDecisionKind
- TrajectoryGateDecisionKind
- RejectReasonKind
- CanonReference
- Decision Gate logic
- Trajectory Gate logic

## Concept Elevation は rename ではない

Concept Elevation は広範な rename 作業ではありません。
安定した責務が意味論的な重みを持つ場合に限り、概念層の名前へ昇格します。
互換性のある旧名称は、移行期間中も compatibility wrapper として残せます。

## 基本ルール

Rule 1: 哲学語は概念層にのみ使用します。

Rule 2: DTO / Request / Result 型には哲学語 prefix を使いません。

Rule 3: Mapper / Adapter / Serializer / Converter 型には哲学語 prefix を使いません。

Rule 4: Provider implementation 型には哲学語 prefix を使いません。

Rule 5: 概念名は意味論的な重みを持つ必要があります。

Rule 6: すべての哲学語は Canonical Language Dictionary に登録します。

Rule 7: 命名規則は architecture tests で検証します。

## 三形体モデル

現在の AIKernel の概念語彙は、次の三形体を基準に整理します。

| 形体 | 概念 | 責務 |
| --- | --- | --- |
| 感覚形体 | `Aisthesis` / `Phantasia` | 生の感覚入力、表象、世界モデル |
| 認知・統治形体 | `Nous` / `Telos` / `Ethos` / `Logos` / `Pathos` / `Kairos` | 認知、意図、統治、実行タイミング |
| 作動・行動形体 | `Kinesis` / `Praxis` / `Kratos` / `Energeia` / `Chronos` | 運動、相互作用、制御権限、実現された作用、再生履歴 |

三形体モデルでは、感覚と表象、認知と統治、行動と履歴を別の意味領域として扱います。
この分類は runtime metadata や UI label でも ASCII-safe な concept name として利用します。

Sensor OS mapping も同じモデルに従います。

| Sensor | Concept |
| --- | --- |
| `visual`, `audio`, `health` | `Aisthesis` |
| `motor` | `Kinesis` |
| `compass`, `spatial` | `Phantasia` |

`Hodos`、`Zoe`、`Topos` は中間的な sensor label でした。
新しいコードとドキュメントでは、legacy metadata を維持する場合を除き、上記の triadic mapping を使用します。

## 許可される層

- Governance
- Trajectory
- Perception
- Intent
- Latent
- Stability
- Canonical
- Concept facade
- Viewer / Inspector upper-level concept names

## 禁止される層

- DTO
- Request
- Result
- Mapper
- Adapter
- Serializer
- Converter
- HttpClient
- JSInterop
- NativeBridge
- Provider implementation
- low-level I/O

## Concept Weight Rule

哲学語を持つ型は、状態、振る舞い、意味論的責務のいずれかを持つ概念型でなければなりません。
単なる boolean flag、薄い DTO、機械的な wrapper に哲学語を使ってはいけません。

## CTG-ROM Safety Rule

Concept Elevation は、CTG-ROM、Monolith-ROM、council vote value、decision gate truth table、trajectory gate aggregation、rejection taxonomy、canon reference structure を変更しません。

## XML Documentation Rule

哲学語を使う public concept-layer member は、バイリンガルのドキュメントでその語を説明する必要があります。
ドキュメントには、concept layer、old technical name、forbidden usage boundary を明記します。

```csharp
/// <summary>
/// 【知覚層 - Aisthesis】
/// GUI / sensor / runtime surface からの raw observation を扱う概念層。
/// Old technical name: Observation.
/// DTO / Mapper / Provider implementation にはこの語を使用しない。
/// </summary>
public interface IAisthesisObservationSource
{
}
```

## Architecture Test Rule

DTO、Request、Result、Mapper、Adapter、Serializer、Converter、HttpClient、JSInterop、NativeBridge、provider implementation class に哲学語 prefix が現れた場合、architecture tests は失敗しなければなりません。

architecture tests は、コードに現れるすべての哲学語 prefix が Canonical Language Dictionary に登録されていることも検証します。

## リポジトリ適用範囲

共通語彙は canonical contract repository である AIKernel.NET に維持します。
リポジトリ固有の migration notes と architecture tests は、それぞれの実装リポジトリに置きます。

初期実装対象リポジトリは次の通りです。

- AIKernel.Core
- AIKernel.Control
- AIKernel.Providers
- AIKernel.Wasm
- AIKernel.Doom
- AIKernel.Tools

AIKernel.NET は Concept Elevation の breaking-change target ではありません。
Ethos、Pathos、Logos などの CTG canonical terms を参照できますが、既存 contract は安定したまま維持します。
