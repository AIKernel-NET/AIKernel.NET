---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Pre-coding"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
lang: ja
title: "AIKernel 正典語彙辞書"
description: "AIKernel の Concept Elevation Refactoring で使う哲学由来の概念語彙と命名境界を定義します。"
---

# AIKernel 正典語彙辞書

この文書は、AIKernel の Concept Elevation Refactoring で使用する哲学由来の概念語彙を定義します。
開発者間で同じ責務を同じ名前で扱うためのユビキタス言語辞書です。

本辞書は CTG-ROM、GateInput、CouncilVoteValue、RejectReasonKind、その他の canonical governance contract を変更しません。
ここで定義するのは、概念層の命名規則と、使用してよい場所・使用してはいけない場所の境界です。

## 語彙の状態

`Core Concept` は、型やインターフェイスが意味論的責務を持つ場合に限って、安定した概念層の名前として使用できます。
`Reserved Vocabulary` は将来利用のために登録されていますが、設計レビュー、migration notes、architecture tests を通して慎重に導入します。

哲学語は装飾ではありません。DTO、Request、Result、Mapper、Adapter、Serializer、Converter、HttpClient、JSInterop、NativeBridge、Provider implementation などの機械的な carrier type には使いません。

## 正典語彙

| 層 | Term | カタカナ | Romaji | 哲学上の意味 | AIKernel での責務 | 旧技術名 | 許可例 | 禁止例 | 状態 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Governance | Ethos | エトス | etosu | 習慣、性格、道徳的気風 | 倫理・安全・規範 | Ethical policy / Safety council | `IEthosCouncil`, `EthosGovernanceSurface` | `EthosDto`, `EthosMapper`, `EthosJsonSerializer`, `EthosProviderImplementation` | Core Concept |
| Governance | Pathos | パトス | patosu | 感情、情念、受動的経験 | 危険・直感・異常検知 | Risk signal / Anomaly detector | `IPathosSignalSource`, `PathosAnomalySurface` | `PathosDto`, `PathosMapper`, `PathosHttpClient`, `PathosProviderManifest` | Core Concept |
| Governance | Logos | ロゴス | rogosu | 言葉、論理、理性、真理 | 論理・整合性・検証 | Logical validator / Consistency checker | `ILogosVerifier`, `LogosConsistencySurface` | `LogosDto`, `LogosJsonSerializer`, `LogosRequest`, `LogosAdapter` | Core Concept |
| CTG / Canon | Nomos | ノモス | nomosu | 法律、規則、慣習 | ROM・Canon・Rule | Rule set / Canon policy | `INomosCanonSource`, `NomosViewer` | `NomosRequest`, `NomosDto`, `NomosConverter`, `NomosProvider` | Core Concept |
| CTG / Canon | Dike | ディケー | dikee | 正義、秩序、裁判 | 正義・秩序・安全性 | Justice policy / Safety order | `IDikeOrderSurface`, `DikeSafetyBoundary` | `DikeResult`, `DikeMapper`, `DikeSerializer`, `DikeProviderImplementation` | Core Concept |
| Perception | Aisthesis | アイステーシス | aisuteeshisu | 感覚、知覚、生の感覚与件 | 生データ・Observation | Observation / Raw perception | `IAisthesisObservationSource`, `AisthesisSurface` | `AisthesisJsonConverter`, `AisthesisDto`, `AisthesisRequest`, `AisthesisProviderManifest` | Core Concept |
| Perception | Phantasia | ファンタシア | fantashia | 表象、想像力、心像 | Scene Graph・内的世界モデル | Scene graph / Inner model | `IPhantasiaSceneModel`, `PhantasiaViewer` | `PhantasiaProviderManifest`, `PhantasiaDto`, `PhantasiaMapper`, `PhantasiaHttpClient` | Core Concept |
| Perception | Chronos | クロノス | kuronosu | 連続的・客観的・物理的な時間 | Buffer・Window・Replay Timeline | Clock / Replay timeline | `IChronosReplayWindow`, `ChronosViewer` | `ChronosWebAudioInterop`, `ChronosDto`, `ChronosResult`, `ChronosNativeBridge` | Core Concept |
| Perception | Kairos | カイロス | kairosu | 主観的・質的な時間、好機 | Trigger・最適タイミング | Trigger / Timing policy | `IKairosTriggerSurface`, `KairosAutoPlayTrigger` | `KairosHttpClient`, `KairosDto`, `KairosAdapter`, `KairosSerializer` | Core Concept |
| Intent / Type | Telos | テロス | terosu | 目的、終局、究極の目標 | Goal・Intent・Objective | Goal / Intent / Objective | `ITelosObjectiveSurface`, `TelosPlannerContext` | `TelosDto`, `TelosRequest`, `TelosMapper`, `TelosJsonConverter` | Core Concept |
| Intent / Type | Eidos | エイドス | eidosu | 形相、本質、もののかたち | Concept・Graph・Type | Concept type / Type graph | `IEidosConceptGraph`, `EidosTypeSurface` | `EidosMapper`, `EidosDto`, `EidosResult`, `EidosProviderManifest` | Core Concept |
| Reserved | Kratos | クラトス | kuratosu | 権力、支配、実行力 | Action authority / executor | Executor authority | `KratosAuthoritySurface` | `KratosDto`, `KratosRequest`, `KratosMapper`, `KratosProviderImplementation` | Reserved Vocabulary |
| Reserved | Dynamis | デュナミス | dyunamisu | 潜勢力、可能態 | Embedding・Latent | Latent space / Potential vector | `DynamisLatentSurface` | `DynamisDto`, `DynamisVectorSerializer`, `DynamisMapper`, `DynamisHttpClient` | Reserved Vocabulary |
| Reserved | Energeia | エネルゲイア | enerugeia | 現実態、活動 | Action・Execution | Execution activity | `EnergeiaActionSurface` | `EnergeiaResult`, `EnergeiaRequest`, `EnergeiaAdapter`, `EnergeiaNativeBridge` | Reserved Vocabulary |
| Reserved | Nous | ヌース | nuusu | 知性、理性、宇宙の精神 | Supervisor・Planner | Supervisor / Planner | `NousPlanningSurface` | `NousDto`, `NousMapper`, `NousProviderImplementation`, `NousJsonSerializer` | Reserved Vocabulary |
| Reserved | Apatheia | アパテイア | apateia | 情念に支配されない状態 | Normalizer・安定化 | Normalizer / Stabilizer | `ApatheiaStabilitySurface` | `ApatheiaDto`, `ApatheiaConverter`, `ApatheiaRequest`, `ApatheiaProvider` | Reserved Vocabulary |
| Reserved | Ataraxia | アタラクシア | atarakushia | 魂の平静、乱されない心 | SafeMode・Fallback | Safe mode / Fallback | `AtaraxiaFallbackSurface` | `AtaraxiaResult`, `AtaraxiaMapper`, `AtaraxiaSerializer`, `AtaraxiaProviderManifest` | Reserved Vocabulary |

## 利用上の注意

- 哲学語は概念層に属し、機械的な carrier type には使いません。
- DTO、Request、Result、Mapper、Adapter、Serializer、Converter、HttpClient、JSInterop、NativeBridge、Provider implementation 名には哲学語 prefix を使いません。
- Ethos、Pathos、Logos は CTG council term として既に canonical です。本辞書は概念層での使い方を文書化するものであり、CTG contract を再定義しません。
- Reserved Vocabulary は、対象リポジトリに migration notes と architecture tests が用意されるまで実装コードに導入しません。
