---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Pre-coding"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel Canonical Language Dictionary

This document defines the canonical philosophical vocabulary used by AIKernel's Concept Elevation Refactoring.
It is a ubiquitous language dictionary for developers.

This dictionary does not change CTG-ROM, GateInput, CouncilVoteValue, RejectReasonKind, or any canonical governance contract.
It only defines concept-layer naming rules.

本ドキュメントは、AIKernel の Concept Elevation Refactoring で使用する哲学由来の概念語彙を定義する。
開発チーム内のユビキタス言語として使用する。

本辞書は CTG-ROM、GateInput、CouncilVoteValue、RejectReasonKind、その他 canonical governance contract を変更しない。
概念層の命名規則を定義するためのものである。

## Vocabulary Status

`Core Concept` terms may be used for stable concept-layer names when the type carries meaningful semantic responsibility.
`Reserved Vocabulary` terms are registered for future use but must be introduced carefully through design review, migration notes, and architecture tests.

`Core Concept` は、型が意味論的責務を持つ場合に限り、安定した概念層の名前として使用できる。
`Reserved Vocabulary` は将来利用のために登録するが、設計レビュー、migration notes、architecture tests を通して慎重に導入する。

## Canonical Terms

| Layer | Term | Japanese Reading | Pronunciation Hint | Philosophical Meaning | AIKernel Responsibility | Old Technical Name | Allowed Examples | Forbidden Examples | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Governance | Ethos | エトス | EH-thos | 習慣、性格、道徳的気風 | 倫理・安全・規範 | Ethical policy / Safety council | `IEthosCouncil`, `EthosGovernanceSurface` | `EthosDto`, `EthosMapper`, `EthosJsonSerializer`, `EthosProviderImplementation` | Core Concept |
| Governance | Pathos | パトス | PA-thos | 感情、情念、受動的経験 | 危険・直感・異常検知 | Risk signal / Anomaly detector | `IPathosSignalSource`, `PathosAnomalySurface` | `PathosDto`, `PathosMapper`, `PathosHttpClient`, `PathosProviderManifest` | Core Concept |
| Governance | Logos | ロゴス | LO-gos | 言葉、論理、理性、真理 | 論理・整合性・検証 | Logical validator / Consistency checker | `ILogosVerifier`, `LogosConsistencySurface` | `LogosDto`, `LogosJsonSerializer`, `LogosRequest`, `LogosAdapter` | Core Concept |
| CTG / Canon | Nomos | ノモス | NO-mos | 法律、規則、慣習 | ROM・Canon・Rule | Rule set / Canon policy | `INomosCanonSource`, `NomosViewer` | `NomosRequest`, `NomosDto`, `NomosConverter`, `NomosProvider` | Core Concept |
| CTG / Canon | Dike | ディケー | DEE-kay | 正義、秩序、裁判 | 正義・秩序・安全性 | Justice policy / Safety order | `IDikeOrderSurface`, `DikeSafetyBoundary` | `DikeResult`, `DikeMapper`, `DikeSerializer`, `DikeProviderImplementation` | Core Concept |
| Perception | Aisthesis | アイステーシス | Ice-THAY-sis | 感覚、知覚、生の感覚与件 | 生データ・Observation | Observation / Raw perception | `IAisthesisObservationSource`, `AisthesisSurface` | `AisthesisJsonConverter`, `AisthesisDto`, `AisthesisRequest`, `AisthesisProviderManifest` | Core Concept |
| Perception | Phantasia | ファンタシア | Fan-TA-see-a | 表象、想像力、心像 | Scene Graph・内的世界モデル | Scene graph / Inner model | `IPhantasiaSceneModel`, `PhantasiaViewer` | `PhantasiaProviderManifest`, `PhantasiaDto`, `PhantasiaMapper`, `PhantasiaHttpClient` | Core Concept |
| Perception | Chronos | クロノス | KRO-nos | 連続的・客観的・物理的な時間 | Buffer・Window・Replay Timeline | Clock / Replay timeline | `IChronosReplayWindow`, `ChronosViewer` | `ChronosWebAudioInterop`, `ChronosDto`, `ChronosResult`, `ChronosNativeBridge` | Core Concept |
| Perception | Kairos | カイロス | KAI-ros | 主観的・質的な時間、好機 | Trigger・最適タイミング | Trigger / Timing policy | `IKairosTriggerSurface`, `KairosAutoPlayTrigger` | `KairosHttpClient`, `KairosDto`, `KairosAdapter`, `KairosSerializer` | Core Concept |
| Intent / Type | Telos | テロス | TE-los | 目的、終局、究極の目標 | Goal・Intent・Objective | Goal / Intent / Objective | `ITelosObjectiveSurface`, `TelosPlannerContext` | `TelosDto`, `TelosRequest`, `TelosMapper`, `TelosJsonConverter` | Core Concept |
| Intent / Type | Eidos | エイドス | EYE-dos | 形相、本質、もののかたち | Concept・Graph・Type | Concept type / Type graph | `IEidosConceptGraph`, `EidosTypeSurface` | `EidosMapper`, `EidosDto`, `EidosResult`, `EidosProviderManifest` | Core Concept |
| Reserved | Kratos | クラトス | KRA-tos | 権力、支配、実行力 | Action authority / executor | Executor authority | `KratosAuthoritySurface` | `KratosDto`, `KratosRequest`, `KratosMapper`, `KratosProviderImplementation` | Reserved Vocabulary |
| Reserved | Dynamis | デュナミス | DY-na-mis | 潜勢力、可能態 | Embedding・Latent | Latent space / Potential vector | `DynamisLatentSurface` | `DynamisDto`, `DynamisVectorSerializer`, `DynamisMapper`, `DynamisHttpClient` | Reserved Vocabulary |
| Reserved | Energeia | エネルゲイア | En-er-GAY-a | 現実態、活動 | Action・Execution | Execution activity | `EnergeiaActionSurface` | `EnergeiaResult`, `EnergeiaRequest`, `EnergeiaAdapter`, `EnergeiaNativeBridge` | Reserved Vocabulary |
| Reserved | Nous | ヌース | NOOS | 知性、理性、宇宙の精神 | Supervisor・Planner | Supervisor / Planner | `NousPlanningSurface` | `NousDto`, `NousMapper`, `NousProviderImplementation`, `NousJsonSerializer` | Reserved Vocabulary |
| Reserved | Apatheia | アパテイア | A-pa-THEI-a | 情念に支配されない状態 | Normalizer・安定化 | Normalizer / Stabilizer | `ApatheiaStabilitySurface` | `ApatheiaDto`, `ApatheiaConverter`, `ApatheiaRequest`, `ApatheiaProvider` | Reserved Vocabulary |
| Reserved | Ataraxia | アタラクシア | A-ta-RAX-ia | 魂の平静、乱されない心 | SafeMode・Fallback | Safe mode / Fallback | `AtaraxiaFallbackSurface` | `AtaraxiaResult`, `AtaraxiaMapper`, `AtaraxiaSerializer`, `AtaraxiaProviderManifest` | Reserved Vocabulary |

## Usage Notes

- Philosophical terms belong to concept layers, not mechanical carrier types.
- DTO, Request, Result, Mapper, Adapter, Serializer, Converter, HttpClient, JSInterop, NativeBridge, and provider implementation names must not use philosophical prefixes.
- Ethos, Pathos, and Logos are already canonical CTG council terms. This dictionary documents their concept-layer use; it does not redefine the CTG contract.
- Reserved Vocabulary must not be introduced into implementation code until the owning repository has migration notes and architecture tests.

## 運用メモ

- 哲学語は概念層に属し、機械的な carrier type には使わない。
- DTO、Request、Result、Mapper、Adapter、Serializer、Converter、HttpClient、JSInterop、NativeBridge、Provider implementation 名には哲学語 prefix を使わない。
- Ethos / Pathos / Logos は既に CTG council term として canonical である。本辞書は概念層での使い方を文書化するだけで、CTG contract を再定義しない。
- Reserved Vocabulary は、対象 repository に migration notes と architecture tests が用意されるまで実装コードに導入しない。
