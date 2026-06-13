# Enum Handling Policy for v0.1.1.1

AIKernel.NET v0.1.1.1 domain enums are fail-closed contract surfaces for
unknown values.

---

## Base Rules

- Every new domain enum has `Unknown = 0`.
- Unknown enum values received from deserialization, external adapters,
  provider metadata, replay artifacts, or telemetry carriers must be handled
  safely.
- Unknown values must not be silently coerced into known values.
- Predictable failures are represented through result DTOs or descriptor /
  snapshot DTOs using `Succeeded = false`, `ErrorCode`, `ErrorMessage`, and
  diagnostics.
- Cancellation may still use `OperationCanceledException`.

---

## Meaning of Unknown

`Unknown = 0` means one of the following:

- The value is unset.
- The current contract package cannot interpret the value.
- An older consumer received a future enum value.
- A provider-specific value cannot be projected into the shared enum.

`Unknown` is not a success value. Runtime control, routing, replay, telemetry,
metrics, and evidence boundaries treat it as fail-closed unless the contract
explicitly defines a safe exception.

---

## Diagnostics

When an unknown enum value is detected, implementations should add a
`DiagnosticEntry`.

Recommended values:

- `Code`: `unknown_enum_value`
- `Severity`: `DiagnosticSeverity.Error`
- `Scope`: the relevant `DiagnosticScope`
- `Message`: a human-readable explanation

---

## Metadata

The raw enum value is preserved in `Metadata`.

Recommended keys:

```text
enum.type
enum.raw_value
enum.source
enum.contract_version
```

Example:

```text
Metadata["enum.type"] = "RuntimeState"
Metadata["enum.raw_value"] = "128"
Metadata["enum.source"] = "runtime.adapter"
Metadata["enum.contract_version"] = "0.1.1.1"
```

Vendor, runtime, and provider-specific information should remain in package
metadata instead of being forced into shared enums.

---

## Telemetry

When an unknown enum value causes a fail-closed outcome, telemetry should emit
an `unknown_enum_value` event where possible.

Recommended signal kinds:

- `TelemetrySignalKind.OperationStatus`
- `TelemetrySignalKind.Safety`
- `TelemetrySignalKind.RuntimeState` or the relevant state signal

The signal `Metadata` should include the same raw value information described
above.

---

## Target Domain Enums

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

---

## Implementer Decision Rules

When an unknown enum value is received:

1. Treat the DTO enum property as `Unknown`.
2. Set `Succeeded = false` when the DTO supports the failure envelope.
3. Set `ErrorCode = "unknown_enum_value"`.
4. Add a `DiagnosticEntry`.
5. Preserve the raw value in `Metadata`.
6. Record the event in telemetry, replay, or evidence when the boundary supports it.

This preserves the raw input while keeping execution boundaries fail-closed.
