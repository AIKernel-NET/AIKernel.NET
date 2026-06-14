# Enum Handling Policy for v0.1.1.1

AIKernel.NET v0.1.1.1 の domain enum は、未知値を安全側に倒すための
fail-closed contract surface として扱う。

## 基本方針

- すべての新規 domain enum は `Unknown = 0` を持つ。
- 逆シリアライズ、外部 adapter、provider metadata、replay artifact から未知 enum 値を受け取った場合、実装は安全側に倒して処理する。
- 未知値を silent fallback で既知値に丸めない。
- 予測可能な失敗は例外ではなく、Result DTO / Snapshot DTO の `Succeeded = false`、`ErrorCode`、`ErrorMessage`、`Diagnostics` で表現する。
- cancellation は `OperationCanceledException` を許容する。

## Unknown の意味

`Unknown = 0` は次の状態を表す。

- 値が未設定である。
- 値が現在の contract package では解釈できない。
- 将来の enum value を古い consumer が受け取った。
- provider 固有値が shared enum に投影できない。

`Unknown` は成功値ではない。control / routing / replay / telemetry / metrics / evidence の境界では、明示的に許可された例外を除き fail-closed として扱う。

## Diagnostics

未知 enum 値を検出した場合、実装は `DiagnosticEntry` を追加する。

推奨値:

- `Code`: `unknown_enum_value`
- `Severity`: `DiagnosticSeverity.Error`
- `Scope`: 対象境界に応じた `DiagnosticScope`
- `Message`: human-readable な説明

## Metadata

未知 enum 値の raw value は `Metadata` に記録する。

推奨 key:

```text
enum.type
enum.raw_value
enum.source
enum.contract_version
```

例:

```text
Metadata["enum.type"] = "RuntimeState"
Metadata["enum.raw_value"] = "128"
Metadata["enum.source"] = "runtime.adapter"
Metadata["enum.contract_version"] = "0.1.1.1"
```

vendor / runtime / provider 固有の情報は shared enum へ追加せず、provider package 側の metadata key に逃がす。

## Telemetry

未知 enum 値によって fail-closed した場合、telemetry 実装は可能な範囲で次を signal として出す。

- `TelemetrySignalKind.OperationStatus`
- `TelemetrySignalKind.Safety`
- `TelemetrySignalKind.RuntimeState` または該当する state signal

signal の `Metadata` には、上記 `enum.*` key と同等の raw value 情報を含める。

## 対象 domain enum

- `AdapterKind`
- `AdapterBindingState`
- `AdapterValidationSeverity`
- `RuntimeAttachmentMode`
- `RuntimeControlOperation`
- `RuntimeState`
- `RuntimeFailureKind`
- `ProcessControlOperation`
- `ProcessStateKind`
- `ProcessSignalKind`
- `ReplayEventKind`
- `ReplaySealState`
- `ReplayFrameKind`
- `EvidenceKind`
- `EvidenceCaptureMode`
- `DiagnosticSeverity`
- `DiagnosticScope`
- `OperatorMode`
- `OperatorDecisionKind`
- `ActionProposalKind`
- `ProfileKind`
- `ProfileFormat`
- `ProfileOptimizationGoal`
- `ProfileOptimizationDecision`
- `TelemetrySignalKind`
- `TelemetryLevel`
- `MetricKind`
- `MetricAggregationKind`
- `HudSignalKind`
- `SignalConfidenceKind`
- `OverlayShapeKind`
- `OverlayLayerKind`

## 実装者向け判断規則

未知 enum 値を受け取った場合:

1. DTO の enum property は `Unknown` として扱う。
2. `Succeeded = false` を返せる DTO では false にする。
3. `ErrorCode = "unknown_enum_value"` を設定する。
4. `DiagnosticEntry` を追加する。
5. `Metadata` に raw value を保存する。
6. telemetry / replay / evidence に記録できる場合は記録する。

これにより、Observability / Replay / Telemetry は未知値を失わず、かつ実行境界は fail-closed を維持する。
