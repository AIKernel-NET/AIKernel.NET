using AIKernel.Enums;

namespace AIKernel.Dtos.Gpu;

/// <summary>
/// [EN] Compact two-dimensional vector used by GPU DTOs without binding callers to a math package.
/// [JA] math package に依存せず GPU DTO で使用する compact 2D vector です。
/// </summary>
public readonly record struct GpuVector2(float X, float Y);

/// <summary>
/// [EN] Describes a flat GPU buffer layout with a fixed stride and maximum item count.
/// [JA] 固定 stride と最大 item 数を持つ flat GPU buffer layout です。
/// </summary>
public sealed record GpuFlatBufferLayout
{
    /// <summary>[EN] Logical layout name. [JA] 論理 layout 名です。</summary>
    public required string Name { get; init; }

    /// <summary>[EN] Number of floats per item. [JA] item ごとの float 数です。</summary>
    public int Stride { get; init; }

    /// <summary>[EN] Maximum number of items. [JA] 最大 item 数です。</summary>
    public int MaxItems { get; init; }

    /// <summary>[EN] Optional semantic channel names. [JA] 任意の semantic channel 名です。</summary>
    public IReadOnlyList<string> Channels { get; init; } = [];
}

/// <summary>
/// [EN] Canonical v0.1.3 GPU buffer layout registry.
/// [JA] canonical v0.1.3 GPU buffer layout registry です。
/// </summary>
public static class GpuCanonicalLayouts
{
    /// <summary>[EN] HUD 9x9 heat cells. [JA] HUD 9x9 heat cell です。</summary>
    public static GpuFlatBufferLayout HudCells { get; } = new()
    {
        Name = "HudCells",
        Stride = 1,
        MaxItems = 81,
        Channels = ["heat"]
    };

    /// <summary>[EN] Generic HUD rectangle entries. [JA] 汎用 HUD rectangle entry です。</summary>
    public static GpuFlatBufferLayout HudRect { get; } = new()
    {
        Name = "HudRect",
        Stride = 8,
        MaxItems = 256,
        Channels = ["x", "y", "w", "h", "r", "g", "b", "a"]
    };

    /// <summary>[EN] Styled HUD panel rectangles. [JA] style を含む HUD panel rectangle です。</summary>
    public static GpuFlatBufferLayout HudPanelRect { get; } = new()
    {
        Name = "HudPanelRect",
        Stride = 12,
        MaxItems = 64,
        Channels = ["x", "y", "w", "h", "r", "g", "b", "a", "border", "radius", "z", "flags"]
    };

    /// <summary>[EN] Semantic HUD panel state vectors. [JA] semantic HUD panel state vector です。</summary>
    public static GpuFlatBufferLayout HudPanelStateVector { get; } = new()
    {
        Name = "HudPanelStateVector",
        Stride = 16,
        MaxItems = 64,
        Channels = ["kind", "state", "confidence", "risk", "v0", "v1", "v2", "v3"]
    };

    /// <summary>[EN] Runtime state vector. [JA] runtime state vector です。</summary>
    public static GpuFlatBufferLayout StateVector { get; } = new()
    {
        Name = "StateVector",
        Stride = 16,
        MaxItems = 1
    };

    /// <summary>[EN] Spatial reasoning matrices: Topos, Route, Threat, Zoe. [JA] Topos, Route, Threat, Zoe 用 spatial reasoning matrix です。</summary>
    public static GpuFlatBufferLayout AisMatrix { get; } = new()
    {
        Name = "AisMatrix",
        Stride = 81,
        MaxItems = 4,
        Channels = ["topos", "route", "threat", "zoe"]
    };

    /// <summary>[EN] Feature vector output. [JA] feature vector 出力です。</summary>
    public static GpuFlatBufferLayout FeatureVector { get; } = new()
    {
        Name = "FeatureVector",
        Stride = 32,
        MaxItems = 1
    };

    /// <summary>[EN] Spatial vector output. [JA] spatial vector 出力です。</summary>
    public static GpuFlatBufferLayout SpatialVector { get; } = new()
    {
        Name = "SpatialVector",
        Stride = 32,
        MaxItems = 1
    };

    /// <summary>[EN] All canonical layouts. [JA] すべての canonical layout です。</summary>
    public static IReadOnlyList<GpuFlatBufferLayout> All { get; } =
    [
        HudCells,
        HudRect,
        HudPanelRect,
        HudPanelStateVector,
        StateVector,
        AisMatrix,
        FeatureVector,
        SpatialVector
    ];
}

/// <summary>
/// [EN] One canonical GPU validation issue.
/// [JA] canonical GPU validation issue です。
/// </summary>
public sealed record GpuValidationIssue
{
    /// <summary>[EN] Stable issue code. [JA] 安定した issue code です。</summary>
    public required string Code { get; init; }

    /// <summary>[EN] Human-readable message. [JA] 人が読める message です。</summary>
    public required string Message { get; init; }

    /// <summary>[EN] Optional DTO or layout path. [JA] 任意の DTO または layout path です。</summary>
    public string? Path { get; init; }

    /// <summary>[EN] Validation severity. [JA] validation severity です。</summary>
    public GpuValidationSeverity Severity { get; init; } = GpuValidationSeverity.Error;
}

/// <summary>
/// [EN] Result of a canonical GPU validation pass.
/// [JA] canonical GPU validation pass の結果です。
/// </summary>
public sealed record GpuValidationResult
{
    /// <summary>[EN] Validation issues. [JA] validation issue です。</summary>
    public IReadOnlyList<GpuValidationIssue> Issues { get; init; } = [];

    /// <summary>[EN] True when no error issue exists. [JA] error issue がない場合 true です。</summary>
    public bool IsValid => Issues.All(static issue => issue.Severity != GpuValidationSeverity.Error);

    /// <summary>[EN] Error issues. [JA] error issue です。</summary>
    public IReadOnlyList<GpuValidationIssue> Errors =>
        Issues.Where(static issue => issue.Severity == GpuValidationSeverity.Error).ToArray();

    /// <summary>[EN] Warning issues. [JA] warning issue です。</summary>
    public IReadOnlyList<GpuValidationIssue> Warnings =>
        Issues.Where(static issue => issue.Severity == GpuValidationSeverity.Warning).ToArray();

    /// <summary>[EN] Empty successful result. [JA] 空の成功 result です。</summary>
    public static GpuValidationResult Success { get; } = new();

    /// <summary>[EN] Creates a result from issues. [JA] issue から result を作成します。</summary>
    public static GpuValidationResult FromIssues(IEnumerable<GpuValidationIssue> issues)
        => new() { Issues = issues.ToArray() };

    /// <summary>[EN] Merges this result with another result. [JA] 別 result と merge します。</summary>
    public GpuValidationResult Merge(GpuValidationResult other)
        => FromIssues(Issues.Concat(other.Issues));
}

/// <summary>
/// [EN] Canonical rev3 promotion readiness interpreted from diagnostics metadata.
/// [JA] diagnostics metadata から解釈した canonical rev3 promotion readiness です。
/// </summary>
public sealed record GpuRev3PromotionReadiness
{
    /// <summary>[EN] Final authoritative promotion decision. [JA] authoritative promotion の最終判定です。</summary>
    public bool IsAuthoritativeReady { get; init; }

    /// <summary>[EN] Diagnostic path reports readiness. [JA] diagnostic path が ready と報告しているかです。</summary>
    public bool IsDiagnosticReady { get; init; }

    /// <summary>[EN] Diagnostic readiness has held for the required streak. [JA] diagnostic readiness が required streak 継続したかです。</summary>
    public bool IsDiagnosticStable { get; init; }

    /// <summary>[EN] Trace can be treated as a promotion candidate. [JA] trace を promotion candidate として扱えるかです。</summary>
    public bool IsPromotionCandidate { get; init; }

    /// <summary>[EN] Promotion is blocked by a gate or invalid metadata. [JA] gate または invalid metadata により promotion が block されたかです。</summary>
    public bool IsBlocked { get; init; }

    /// <summary>[EN] Storage texture feature mask is present. [JA] storage texture feature mask が有効かです。</summary>
    public bool HasStorageTextureFeature { get; init; }

    /// <summary>[EN] Promotion gate value. [JA] promotion gate 値です。</summary>
    public string Gate { get; init; } = GpuRev3PromotionGates.NotEvaluated;

    /// <summary>[EN] Stable machine-readable readiness reason. [JA] 機械判定向けの安定 reason です。</summary>
    public string Reason { get; init; } = "not-evaluated";

    /// <summary>[EN] Candidate streak reported by diagnostics. [JA] diagnostics が報告した candidate streak です。</summary>
    public int CandidateStreak { get; init; }

    /// <summary>[EN] Diagnostic streak reported by diagnostics. [JA] diagnostics が報告した diagnostic streak です。</summary>
    public int DiagnosticStreak { get; init; }

    /// <summary>[EN] Required stable streak before promotion. [JA] promotion 前に必要な stable streak です。</summary>
    public int RequiredStreak { get; init; }
}

/// <summary>
/// [EN] Canonical GPU contract validator shared by providers, tools, and demos.
/// [JA] provider、tools、demo で共有する canonical GPU contract validator です。
/// </summary>
public static class GpuCanonicalValidation
{
    private static readonly IReadOnlyDictionary<string, GpuFlatBufferLayout> RequiredLayouts =
        GpuCanonicalLayouts.All.ToDictionary(static layout => layout.Name, StringComparer.Ordinal);

    /// <summary>
    /// [EN] Validates that supplied layouts match the canonical rev3 registry.
    /// [JA] 指定 layout が canonical rev3 registry と一致することを検証します。
    /// </summary>
    public static GpuValidationResult ValidateLayouts(IEnumerable<GpuFlatBufferLayout> layouts)
    {
        var supplied = layouts.ToArray();
        var issues = new List<GpuValidationIssue>();
        foreach (var group in supplied.GroupBy(static layout => layout.Name, StringComparer.Ordinal))
        {
            if (group.Count() > 1)
            {
                issues.Add(Error(
                    "GPU_LAYOUT_DUPLICATE",
                    $"GPU layout '{group.Key}' is duplicated.",
                    $"layouts.{group.Key}"));
            }
        }

        foreach (var layout in supplied)
        {
            if (layout.Stride <= 0)
            {
                issues.Add(Error(
                    "GPU_LAYOUT_INVALID_STRIDE",
                    $"GPU layout '{layout.Name}' has an invalid stride: {layout.Stride}.",
                    $"layouts.{layout.Name}.stride"));
            }

            if (layout.MaxItems <= 0)
            {
                issues.Add(Error(
                    "GPU_LAYOUT_INVALID_MAX_ITEMS",
                    $"GPU layout '{layout.Name}' has an invalid max item count: {layout.MaxItems}.",
                    $"layouts.{layout.Name}.maxItems"));
            }
        }

        var byName = supplied
            .GroupBy(static layout => layout.Name, StringComparer.Ordinal)
            .ToDictionary(static group => group.Key, static group => group.First(), StringComparer.Ordinal);
        foreach (var required in RequiredLayouts.Values)
        {
            if (!byName.TryGetValue(required.Name, out var actual))
            {
                issues.Add(Error(
                    "GPU_LAYOUT_MISSING",
                    $"Canonical GPU layout '{required.Name}' is missing.",
                    $"layouts.{required.Name}"));
                continue;
            }

            if (actual.Stride != required.Stride)
            {
                issues.Add(Error(
                    "GPU_LAYOUT_STRIDE_MISMATCH",
                    $"GPU layout '{required.Name}' stride must be {required.Stride}, but was {actual.Stride}.",
                    $"layouts.{required.Name}.stride"));
            }

            if (actual.MaxItems != required.MaxItems)
            {
                issues.Add(Error(
                    "GPU_LAYOUT_MAX_ITEMS_MISMATCH",
                    $"GPU layout '{required.Name}' maxItems must be {required.MaxItems}, but was {actual.MaxItems}.",
                    $"layouts.{required.Name}.maxItems"));
            }
        }

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates that a provider has the required canonical capabilities.
    /// [JA] provider が必要な canonical capability を持つことを検証します。
    /// </summary>
    public static GpuValidationResult ValidateCapabilities(
        GpuProviderCapabilities available,
        GpuProviderCapabilities required)
    {
        var missing = required & ~available;
        if (missing == GpuProviderCapabilities.None)
        {
            return GpuValidationResult.Success;
        }

        return GpuValidationResult.FromIssues(
        [
            Error(
                "GPU_CAPABILITY_MISSING",
                $"GPU provider is missing required capabilities: {missing}.",
                "provider.capabilities")
        ]);
    }

    /// <summary>
    /// [EN] Validates provider native ABI probe metadata for canonical rev3 native GPU backends.
    /// [JA] canonical rev3 native GPU backend 用 provider native ABI probe metadata を検証します。
    /// </summary>
    public static GpuValidationResult ValidateNativeAbiProbeMetadata(
        GpuBackend backend,
        IReadOnlyDictionary<string, string> metadata)
    {
        ArgumentNullException.ThrowIfNull(metadata);

        var requiredKeys = GetRequiredNativeAbiProbeKeys(backend);
        if (requiredKeys.Count == 0)
        {
            return GpuValidationResult.Success;
        }

        var issues = new List<GpuValidationIssue>();
        foreach (var key in requiredKeys)
        {
            if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            {
                issues.Add(Error(
                    "GPU_NATIVE_ABI_METADATA_MISSING",
                    $"GPU provider native ABI probe metadata is missing required key '{key}'.",
                    $"nativeAbi.{backend}.{key}"));
            }
        }

        ValidateBooleanMetadata(
            metadata,
            GetNativeAbiProbeBooleanKeys(backend),
            $"nativeAbi.{backend}",
            issues);

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates Control-plane GPU arbitration diagnostics metadata.
    /// [JA] Control-plane GPU arbitration diagnostics metadata を検証します。
    /// </summary>
    public static GpuValidationResult ValidateControlArbitrationMetadata(
        IReadOnlyDictionary<string, string> metadata)
    {
        ArgumentNullException.ThrowIfNull(metadata);

        var issues = new List<GpuValidationIssue>();
        foreach (var key in RequiredControlArbitrationMetadataKeys)
        {
            if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            {
                issues.Add(Error(
                    "GPU_CONTROL_ARBITRATION_METADATA_MISSING",
                    $"Control GPU arbitration metadata is missing required key '{key}'.",
                    $"controlArbitration.{key}"));
            }
        }

        foreach (var key in ControlArbitrationBooleanMetadataKeys)
        {
            if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            {
                continue;
            }

            if (!string.Equals(value, "true", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(value, "false", StringComparison.OrdinalIgnoreCase))
            {
                issues.Add(Error(
                    "GPU_CONTROL_ARBITRATION_METADATA_BOOLEAN_INVALID",
                    $"Control GPU arbitration metadata key '{key}' must be 'true' or 'false', but was '{value}'.",
                    $"controlArbitration.{key}"));
            }
        }

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates browser WebGPU rev3 bridge metadata exposed by WASM providers and Doom hosts.
    /// [JA] WASM provider と Doom host が公開する browser WebGPU rev3 bridge metadata を検証します。
    /// </summary>
    public static GpuValidationResult ValidateRev3BrowserBridgeMetadata(
        IReadOnlyDictionary<string, string> metadata)
    {
        ArgumentNullException.ThrowIfNull(metadata);

        var issues = new List<GpuValidationIssue>();
        foreach (var key in RequiredRev3BrowserBridgeMetadataKeys)
        {
            if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            {
                issues.Add(Error(
                    "GPU_REV3_BROWSER_BRIDGE_METADATA_MISSING",
                    $"Rev3 browser bridge metadata is missing required key '{key}'.",
                    $"rev3BrowserBridge.{key}"));
            }
        }

        if (metadata.TryGetValue(GpuProviderMetadataKeys.Rev3EnvelopeSchema, out var schema) &&
            !string.Equals(schema, "aikernel.gpu.rev3.dispatch", StringComparison.Ordinal))
        {
            issues.Add(Error(
                "GPU_REV3_BROWSER_BRIDGE_SCHEMA_INVALID",
                $"Rev3 browser bridge schema must be 'aikernel.gpu.rev3.dispatch', but was '{schema}'.",
                $"rev3BrowserBridge.{GpuProviderMetadataKeys.Rev3EnvelopeSchema}"));
        }

        if (metadata.TryGetValue(GpuProviderMetadataKeys.Rev3EnvelopeBridge, out var bridgePath) &&
            !bridgePath.EndsWith("webgpu-rev3-envelope-bridge.js", StringComparison.Ordinal))
        {
            issues.Add(Error(
                "GPU_REV3_BROWSER_BRIDGE_PATH_INVALID",
                "Rev3 browser bridge runtime path must end with 'webgpu-rev3-envelope-bridge.js'.",
                $"rev3BrowserBridge.{GpuProviderMetadataKeys.Rev3EnvelopeBridge}"));
        }

        if (metadata.TryGetValue(GpuProviderMetadataKeys.Rev3BrowserPassReadiness, out var readiness))
        {
            foreach (var token in RequiredRev3BrowserReadinessTokens)
            {
                if (!readiness.Contains(token, StringComparison.Ordinal))
                {
                    issues.Add(Error(
                        "GPU_REV3_BROWSER_PASS_READINESS_SHAPE_INVALID",
                        $"Rev3 browser pass readiness metadata must include '{token}'.",
                        $"rev3BrowserBridge.{GpuProviderMetadataKeys.Rev3BrowserPassReadiness}"));
                }
            }
        }

        ValidateNoWhitespaceMetadataValue(
            metadata,
            GpuProviderMetadataKeys.Rev3EnvelopeBridgeFactory,
            "rev3BrowserBridge",
            issues);
        ValidateNoWhitespaceMetadataValue(
            metadata,
            GpuProviderMetadataKeys.Rev3EnvelopeBridgeExecutorFactory,
            "rev3BrowserBridge",
            issues);
        ValidateNoWhitespaceMetadataValue(
            metadata,
            GpuProviderMetadataKeys.Rev3EnvelopeBridgeGlobal,
            "rev3BrowserBridge",
            issues);

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates rev3 execution-layer metadata shared by browser WebGPU, Dawn, and CUDA sibling providers.
    /// [JA] browser WebGPU、Dawn、CUDA sibling provider で共有する rev3 execution-layer metadata を検証します。
    /// </summary>
    public static GpuValidationResult ValidateRev3ExecutionLayerMetadata(
        IReadOnlyDictionary<string, string> metadata)
    {
        ArgumentNullException.ThrowIfNull(metadata);

        var issues = new List<GpuValidationIssue>();
        foreach (var key in RequiredRev3ExecutionLayerMetadataKeys)
        {
            if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            {
                issues.Add(Error(
                    "GPU_REV3_EXECUTION_LAYER_METADATA_MISSING",
                    $"Rev3 execution-layer metadata is missing required key '{key}'.",
                    $"rev3ExecutionLayer.{key}"));
            }
        }

        ValidateNoWhitespaceExecutionLayerMetadataValue(
            metadata,
            GpuProviderMetadataKeys.GpuBypass,
            "rev3ExecutionLayer",
            issues);
        ValidateNoWhitespaceExecutionLayerMetadataValue(
            metadata,
            GpuProviderMetadataKeys.NativeJsBridge,
            "rev3ExecutionLayer",
            issues);
        ValidateNoWhitespaceExecutionLayerMetadataValue(
            metadata,
            GpuProviderMetadataKeys.AotCompilerHooks,
            "rev3ExecutionLayer",
            issues);
        ValidateNoWhitespaceExecutionLayerMetadataValue(
            metadata,
            GpuProviderMetadataKeys.DeterministicFrameSampling,
            "rev3ExecutionLayer",
            issues);
        ValidateNoWhitespaceExecutionLayerMetadataValue(
            metadata,
            GpuProviderMetadataKeys.ZeroCopyBufferHandling,
            "rev3ExecutionLayer",
            issues);

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates that GPU Aisthesis receives a raw framebuffer and not a HUD-composited target.
    /// [JA] GPU Aisthesis が HUD 合成済み target ではなく raw framebuffer を受け取ることを検証します。
    /// </summary>
    public static GpuValidationResult ValidateAisthesisInput(GpuAisthesisInput input)
    {
        var issues = new List<GpuValidationIssue>();
        if (input.RawFramebuffer.Kind != GpuFrameTargetKind.RawFramebuffer)
        {
            issues.Add(Error(
                "GPU_AISTHESIS_RAW_TARGET_REQUIRED",
                $"GPU Aisthesis must bind RawFramebuffer, but received {input.RawFramebuffer.Kind}.",
                "aisthesis.rawFramebuffer.kind"));
        }

        if (input.RawFramebuffer.Width <= 0 || input.RawFramebuffer.Height <= 0)
        {
            issues.Add(Error(
                "GPU_AISTHESIS_INVALID_FRAME_SIZE",
                $"GPU Aisthesis raw target size must be positive, but was {input.RawFramebuffer.Width}x{input.RawFramebuffer.Height}.",
                "aisthesis.rawFramebuffer.size"));
        }

        if (!string.IsNullOrWhiteSpace(input.Frame.RawTarget.TargetId) &&
            !string.Equals(input.Frame.RawTarget.TargetId, input.RawFramebuffer.TargetId, StringComparison.Ordinal))
        {
            issues.Add(Error(
                "GPU_AISTHESIS_FRAME_TARGET_MISMATCH",
                $"GPU Aisthesis frame target '{input.Frame.RawTarget.TargetId}' does not match raw target '{input.RawFramebuffer.TargetId}'.",
                "aisthesis.frame.rawTarget"));
        }

        if (!input.RawFramebuffer.ZeroCopy)
        {
            issues.Add(Warning(
                "GPU_AISTHESIS_ZERO_COPY_DISABLED",
                "GPU Aisthesis raw target is not zero-copy; provider must expose a fallback reason.",
                "aisthesis.rawFramebuffer.zeroCopy"));
        }

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates canonical spatial reasoning matrix and state-vector shapes.
    /// [JA] canonical spatial reasoning matrix と state-vector の shape を検証します。
    /// </summary>
    public static GpuValidationResult ValidateSpatialReasoningInput(GpuSpatialReasoningInput input)
    {
        var issues = new List<GpuValidationIssue>();
        if (input.AisMatrices.Count != GpuCanonicalLayouts.AisMatrix.MaxItems)
        {
            issues.Add(Error(
                "GPU_SPATIAL_MATRIX_COUNT_MISMATCH",
                $"GPU spatial reasoning requires {GpuCanonicalLayouts.AisMatrix.MaxItems} matrices in Topos, Route, Threat, Zoe order, but received {input.AisMatrices.Count}.",
                "spatial.aisMatrices"));
        }

        for (var index = 0; index < input.AisMatrices.Count; index++)
        {
            if (input.AisMatrices[index].Count != GpuCanonicalLayouts.AisMatrix.Stride)
            {
                issues.Add(Error(
                    "GPU_SPATIAL_MATRIX_STRIDE_MISMATCH",
                    $"GPU spatial matrix {index} must contain {GpuCanonicalLayouts.AisMatrix.Stride} floats, but contained {input.AisMatrices[index].Count}.",
                    $"spatial.aisMatrices[{index}]"));
            }
        }

        if (input.StateVector.Count > GpuCanonicalLayouts.StateVector.Stride)
        {
            issues.Add(Error(
                "GPU_SPATIAL_STATE_VECTOR_TOO_LONG",
                $"GPU spatial state vector can contain at most {GpuCanonicalLayouts.StateVector.Stride} floats, but contained {input.StateVector.Count}.",
                "spatial.stateVector"));
        }

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates canonical GPU HUD flat buffer counts.
    /// [JA] canonical GPU HUD flat buffer count を検証します。
    /// </summary>
    public static GpuValidationResult ValidateHudInput(GpuHudInput input)
    {
        var issues = new List<GpuValidationIssue>();
        ValidateFlatBufferCount(
            input.HudPanelRects.Count,
            GpuCanonicalLayouts.HudPanelRect,
            "hud.panelRects",
            issues);
        ValidateFlatBufferCount(
            input.HudPanelStateVectors.Count,
            GpuCanonicalLayouts.HudPanelStateVector,
            "hud.panelStateVectors",
            issues);

        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates the canonical game/Bonsai/HUD/sensor diagnostics table.
    /// [JA] canonical game/Bonsai/HUD/sensor diagnostics table を検証します。
    /// </summary>
    public static GpuValidationResult ValidateFrameDiagnostics(GpuFrameDiagnostics diagnostics)
    {
        var issues = new List<GpuValidationIssue>();
        ValidateDiagnosticsPath(diagnostics.GamePath, "diagnostics.gamePath", issues);
        ValidateDiagnosticsPath(diagnostics.BonsaiPath, "diagnostics.bonsaiPath", issues);
        ValidateDiagnosticsPath(diagnostics.HudPath, "diagnostics.hudPath", issues);
        ValidateDiagnosticsPath(diagnostics.SensorPath, "diagnostics.sensorPath", issues);
        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Validates one canonical rev3 diagnostics metadata dictionary before provider or bridge handoff.
    /// [JA] provider または bridge handoff 前に canonical rev3 diagnostics metadata 辞書単体を検証します。
    /// </summary>
    public static GpuValidationResult ValidateRev3DiagnosticsMetadata(
        IReadOnlyDictionary<string, string> metadata,
        string pathName = "diagnostics")
    {
        ArgumentNullException.ThrowIfNull(metadata);

        var issues = new List<GpuValidationIssue>();
        ValidateDiagnosticsMetadata(metadata, pathName, issues);
        return GpuValidationResult.FromIssues(issues);
    }

    /// <summary>
    /// [EN] Evaluates canonical rev3 promotion readiness from validated diagnostics metadata.
    /// [JA] 検証済み diagnostics metadata から canonical rev3 promotion readiness を評価します。
    /// </summary>
    public static GpuRev3PromotionReadiness EvaluateRev3PromotionReadiness(
        IReadOnlyDictionary<string, string> metadata)
    {
        ArgumentNullException.ThrowIfNull(metadata);

        if (!TryReadRequiredString(metadata, GpuDiagnosticsMetadataKeys.Rev3PromotionGate, out var gate) ||
            !TryReadRequiredBoolean(metadata, GpuDiagnosticsMetadataKeys.Rev3AuthoritativeReady, out var authoritativeReady) ||
            !TryReadRequiredBoolean(metadata, GpuDiagnosticsMetadataKeys.Rev3DiagnosticReady, out var diagnosticReady) ||
            !TryReadRequiredBoolean(metadata, GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture, out var storageTextureReady) ||
            !TryReadRequiredInt(metadata, GpuDiagnosticsMetadataKeys.Rev3CandidateStreak, out var candidateStreak) ||
            !TryReadRequiredInt(metadata, GpuDiagnosticsMetadataKeys.Rev3DiagnosticStreak, out var diagnosticStreak) ||
            !TryReadRequiredInt(metadata, GpuDiagnosticsMetadataKeys.Rev3RequiredStreak, out var requiredStreak))
        {
            return new GpuRev3PromotionReadiness
            {
                IsBlocked = true,
                Reason = "metadata-missing"
            };
        }

        if (!GpuRev3PromotionGates.All.Contains(gate))
        {
            return new GpuRev3PromotionReadiness
            {
                IsBlocked = true,
                Gate = gate,
                Reason = "unknown-gate",
                CandidateStreak = candidateStreak,
                DiagnosticStreak = diagnosticStreak,
                RequiredStreak = requiredStreak,
                HasStorageTextureFeature = storageTextureReady,
                IsDiagnosticReady = diagnosticReady
            };
        }

        if (candidateStreak < 0 || diagnosticStreak < 0)
        {
            return new GpuRev3PromotionReadiness
            {
                IsBlocked = true,
                Gate = gate,
                Reason = "metadata-invalid",
                CandidateStreak = candidateStreak,
                DiagnosticStreak = diagnosticStreak,
                RequiredStreak = requiredStreak,
                HasStorageTextureFeature = storageTextureReady,
                IsDiagnosticReady = diagnosticReady
            };
        }

        if (gate == GpuRev3PromotionGates.NotApplicable)
        {
            return new GpuRev3PromotionReadiness
            {
                Gate = gate,
                Reason = "not-applicable",
                CandidateStreak = candidateStreak,
                DiagnosticStreak = diagnosticStreak,
                RequiredStreak = requiredStreak,
                HasStorageTextureFeature = storageTextureReady,
                IsDiagnosticReady = diagnosticReady
            };
        }

        if (gate != GpuRev3PromotionGates.TraceCandidate)
        {
            return new GpuRev3PromotionReadiness
            {
                IsBlocked = true,
                Gate = gate,
                Reason = gate,
                CandidateStreak = candidateStreak,
                DiagnosticStreak = diagnosticStreak,
                RequiredStreak = requiredStreak,
                HasStorageTextureFeature = storageTextureReady,
                IsDiagnosticReady = diagnosticReady
            };
        }

        if (requiredStreak <= 0)
        {
            return new GpuRev3PromotionReadiness
            {
                IsBlocked = true,
                Gate = gate,
                Reason = "metadata-invalid",
                CandidateStreak = candidateStreak,
                DiagnosticStreak = diagnosticStreak,
                RequiredStreak = requiredStreak,
                HasStorageTextureFeature = storageTextureReady,
                IsDiagnosticReady = diagnosticReady
            };
        }

        var diagnosticStable = diagnosticReady && diagnosticStreak >= requiredStreak;
        var candidateStable = candidateStreak >= requiredStreak;
        var promotionCandidate = storageTextureReady && diagnosticStable && candidateStable;
        var finalReady = promotionCandidate && authoritativeReady;

        return new GpuRev3PromotionReadiness
        {
            IsAuthoritativeReady = finalReady,
            IsDiagnosticReady = diagnosticReady,
            IsDiagnosticStable = diagnosticStable,
            IsPromotionCandidate = promotionCandidate,
            IsBlocked = !storageTextureReady,
            HasStorageTextureFeature = storageTextureReady,
            Gate = gate,
            Reason = ResolveRev3PromotionReason(
                finalReady,
                storageTextureReady,
                diagnosticReady,
                diagnosticStable,
                candidateStable,
                authoritativeReady),
            CandidateStreak = candidateStreak,
            DiagnosticStreak = diagnosticStreak,
            RequiredStreak = requiredStreak
        };
    }

    private static void ValidateFlatBufferCount(
        int count,
        GpuFlatBufferLayout layout,
        string path,
        ICollection<GpuValidationIssue> issues)
    {
        if (count % layout.Stride != 0)
        {
            issues.Add(Error(
                "GPU_FLAT_BUFFER_STRIDE_MISMATCH",
                $"{layout.Name} flat buffer count {count} is not divisible by stride {layout.Stride}.",
                path));
            return;
        }

        var itemCount = count / layout.Stride;
        if (itemCount > layout.MaxItems)
        {
            issues.Add(Error(
                "GPU_FLAT_BUFFER_TOO_LONG",
                $"{layout.Name} flat buffer contains {itemCount} items; maximum is {layout.MaxItems}.",
                path));
        }
    }

    private static string ResolveRev3PromotionReason(
        bool finalReady,
        bool storageTextureReady,
        bool diagnosticReady,
        bool diagnosticStable,
        bool candidateStable,
        bool authoritativeReady)
    {
        if (finalReady)
        {
            return "authoritative-ready";
        }

        if (!storageTextureReady)
        {
            return "storage-texture-not-ready";
        }

        if (!diagnosticReady)
        {
            return "diagnostic-not-ready";
        }

        if (!diagnosticStable || !candidateStable)
        {
            return "streak-not-ready";
        }

        return authoritativeReady ? "not-evaluated" : "authoritative-not-ready";
    }

    private static bool TryReadRequiredString(
        IReadOnlyDictionary<string, string> metadata,
        string key,
        out string value)
    {
        if (metadata.TryGetValue(key, out value!) && !string.IsNullOrWhiteSpace(value))
        {
            return true;
        }

        value = string.Empty;
        return false;
    }

    private static bool TryReadRequiredBoolean(
        IReadOnlyDictionary<string, string> metadata,
        string key,
        out bool value)
    {
        value = false;
        return metadata.TryGetValue(key, out var raw) &&
            bool.TryParse(raw, out value);
    }

    private static bool TryReadRequiredInt(
        IReadOnlyDictionary<string, string> metadata,
        string key,
        out int value)
    {
        value = 0;
        return metadata.TryGetValue(key, out var raw) &&
            int.TryParse(raw, out value);
    }

    private static IReadOnlyList<string> GetRequiredNativeAbiProbeKeys(GpuBackend backend)
        => backend switch
        {
            GpuBackend.Dawn =>
            [
                GpuNativeAbiMetadataKeys.DawnNativeAbiAvailable,
                GpuNativeAbiMetadataKeys.DawnNativeAbiReason,
                GpuNativeAbiMetadataKeys.DawnNativeEnvironmentVariable,
                GpuNativeAbiMetadataKeys.DawnNativeEntryPoint,
                GpuNativeAbiMetadataKeys.DawnNativeInitializationEntryPoint,
                GpuNativeAbiMetadataKeys.DawnNativeDispatchEntryPoint,
                GpuNativeAbiMetadataKeys.DawnNativeValidation
            ],
            GpuBackend.Cuda =>
            [
                GpuNativeAbiMetadataKeys.CudaNativeAbiAvailable,
                GpuNativeAbiMetadataKeys.CudaNativeAbiReason,
                GpuNativeAbiMetadataKeys.CudaNativeBridgeAvailable,
                GpuNativeAbiMetadataKeys.CudaLibTorchPathAvailable,
                GpuNativeAbiMetadataKeys.CudaNativeValidation
            ],
            _ => []
        };

    private static IReadOnlyList<string> GetNativeAbiProbeBooleanKeys(GpuBackend backend)
        => backend switch
        {
            GpuBackend.Dawn =>
            [
                GpuNativeAbiMetadataKeys.DawnNativeAbiAvailable,
                GpuNativeAbiMetadataKeys.DawnNativePathConfigured
            ],
            GpuBackend.Cuda =>
            [
                GpuNativeAbiMetadataKeys.CudaNativeAbiAvailable,
                GpuNativeAbiMetadataKeys.CudaNativeBridgeAvailable,
                GpuNativeAbiMetadataKeys.CudaNativeLoaderConfigured,
                GpuNativeAbiMetadataKeys.CudaLibTorchPathConfigured,
                GpuNativeAbiMetadataKeys.CudaLibTorchPathAvailable
            ],
            _ => []
        };

    private static IReadOnlyList<string> RequiredControlArbitrationMetadataKeys { get; } =
    [
        GpuDiagnosticsMetadataKeys.Rev3PassId,
        GpuDiagnosticsMetadataKeys.Rev3ExecutionMode,
        GpuProviderMetadataKeys.Backend,
        GpuProviderMetadataKeys.Fallback,
        GpuControlMetadataKeys.IntentId,
        GpuControlMetadataKeys.ObjectiveId,
        GpuControlMetadataKeys.ActionId,
        GpuControlMetadataKeys.Reason,
        GpuControlMetadataKeys.RequiredCapabilities,
        GpuControlMetadataKeys.AvailableCapabilities,
        GpuControlMetadataKeys.MissingCapabilities,
        GpuControlMetadataKeys.InputTargetKind,
        GpuControlMetadataKeys.ReadbackPolicy,
        GpuControlMetadataKeys.ZeroCopyRawTextureRequired,
        GpuControlMetadataKeys.NativePassBridgeRequired,
        GpuControlMetadataKeys.NativePassBridgeAvailable,
        GpuControlMetadataKeys.Tags
    ];

    private static IReadOnlyList<string> ControlArbitrationBooleanMetadataKeys { get; } =
    [
        GpuControlMetadataKeys.ZeroCopyRawTextureRequired,
        GpuControlMetadataKeys.NativePassBridgeRequired,
        GpuControlMetadataKeys.NativePassBridgeAvailable
    ];

    private static IReadOnlyList<string> RequiredRev3BrowserBridgeMetadataKeys { get; } =
    [
        GpuProviderMetadataKeys.Rev3BrowserPassReadiness,
        GpuProviderMetadataKeys.Rev3EnvelopeBridge,
        GpuProviderMetadataKeys.Rev3EnvelopeBridgeExecutorFactory,
        GpuProviderMetadataKeys.Rev3EnvelopeBridgeFactory,
        GpuProviderMetadataKeys.Rev3EnvelopeBridgeGlobal,
        GpuProviderMetadataKeys.Rev3EnvelopeSchema
    ];

    private static IReadOnlyList<string> RequiredRev3BrowserReadinessTokens { get; } =
    [
        "Passes.",
        "Aisthesis",
        "SpatialReasoning",
        "HudComposite",
        "ShaderBound",
        "PipelineCached",
        "BuiltInExecutor",
        "InjectedExecutor",
        "ReadyForBuiltIn"
    ];

    private static IReadOnlyList<string> RequiredRev3ExecutionLayerMetadataKeys { get; } =
    [
        GpuProviderMetadataKeys.PassBridge,
        GpuProviderMetadataKeys.RawCaptureSource,
        GpuProviderMetadataKeys.GpuBypass,
        GpuProviderMetadataKeys.NativeJsBridge,
        GpuProviderMetadataKeys.AotCompilerHooks,
        GpuProviderMetadataKeys.DeterministicFrameSampling,
        GpuProviderMetadataKeys.ZeroCopyBufferHandling
    ];

    private static IReadOnlyList<string> RequiredRev3FrameDiagnosticsMetadataKeys { get; } =
    [
        GpuDiagnosticsMetadataKeys.Rev3FrameIndex,
        GpuDiagnosticsMetadataKeys.Rev3SampleTicks
    ];

    private static IReadOnlyList<string> RequiredRev3DiagnosticsMetadataKeys { get; } =
    [
        GpuDiagnosticsMetadataKeys.Rev3AuthoritativeReady,
        GpuDiagnosticsMetadataKeys.Rev3CandidateStreak,
        GpuDiagnosticsMetadataKeys.Rev3DiagnosticReady,
        GpuDiagnosticsMetadataKeys.Rev3DiagnosticStreak,
        GpuDiagnosticsMetadataKeys.Rev3ExecutionMode,
        GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture,
        GpuDiagnosticsMetadataKeys.Rev3PassId,
        GpuDiagnosticsMetadataKeys.Rev3PassReadiness,
        GpuDiagnosticsMetadataKeys.Rev3PathRole,
        GpuDiagnosticsMetadataKeys.Rev3PilotState,
        GpuDiagnosticsMetadataKeys.Rev3PromotionGate,
        GpuDiagnosticsMetadataKeys.Rev3RequiredStreak,
        .. RequiredRev3FrameDiagnosticsMetadataKeys
    ];

    private static IReadOnlyList<string> Rev3DiagnosticsBooleanMetadataKeys { get; } =
    [
        GpuDiagnosticsMetadataKeys.Rev3AuthoritativeReady,
        GpuDiagnosticsMetadataKeys.Rev3DiagnosticReady,
        GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture,
        GpuDiagnosticsMetadataKeys.Rev3PromotionBlocked,
        GpuDiagnosticsMetadataKeys.Rev3PromotionCandidateReady,
        GpuDiagnosticsMetadataKeys.Rev3PromotionDiagnosticStable
    ];

    private static IReadOnlyList<string> Rev3DiagnosticsIntegerMetadataKeys { get; } =
    [
        GpuDiagnosticsMetadataKeys.Rev3CandidateStreak,
        GpuDiagnosticsMetadataKeys.Rev3DiagnosticStreak,
        GpuDiagnosticsMetadataKeys.Rev3RequiredStreak,
        GpuDiagnosticsMetadataKeys.Rev3FrameIndex,
        GpuDiagnosticsMetadataKeys.Rev3SampleTicks
    ];

    private static IReadOnlyDictionary<string, IReadOnlySet<string>> Rev3DiagnosticsKnownValueMetadataKeys { get; } =
        new Dictionary<string, IReadOnlySet<string>>(StringComparer.Ordinal)
        {
            [GpuDiagnosticsMetadataKeys.Rev3ExecutionMode] = GpuRev3ExecutionModes.All,
            [GpuDiagnosticsMetadataKeys.Rev3PathRole] = GpuRev3PathRoles.All,
            [GpuDiagnosticsMetadataKeys.Rev3PilotState] = GpuRev3PilotStates.All,
            [GpuDiagnosticsMetadataKeys.Rev3PromotionGate] = GpuRev3PromotionGates.All
        };

    private static void ValidateBooleanMetadata(
        IReadOnlyDictionary<string, string> metadata,
        IEnumerable<string> keys,
        string pathPrefix,
        ICollection<GpuValidationIssue> issues)
    {
        foreach (var key in keys)
        {
            if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            {
                continue;
            }

            if (!string.Equals(value, "true", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(value, "false", StringComparison.OrdinalIgnoreCase))
            {
                issues.Add(Error(
                    "GPU_NATIVE_ABI_METADATA_BOOLEAN_INVALID",
                    $"GPU provider native ABI probe metadata key '{key}' must be 'true' or 'false', but was '{value}'.",
                    $"{pathPrefix}.{key}"));
            }
        }
    }

    private static void ValidateNoWhitespaceMetadataValue(
        IReadOnlyDictionary<string, string> metadata,
        string key,
        string pathPrefix,
        ICollection<GpuValidationIssue> issues)
    {
        if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        if (value.Any(char.IsWhiteSpace))
        {
            issues.Add(Error(
                "GPU_REV3_BROWSER_BRIDGE_IDENTIFIER_INVALID",
                $"Rev3 browser bridge metadata key '{key}' must be a compact identifier with no whitespace.",
                $"{pathPrefix}.{key}"));
        }
    }

    private static void ValidateNoWhitespaceExecutionLayerMetadataValue(
        IReadOnlyDictionary<string, string> metadata,
        string key,
        string pathPrefix,
        ICollection<GpuValidationIssue> issues)
    {
        if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        if (value.Any(char.IsWhiteSpace))
        {
            issues.Add(Error(
                "GPU_REV3_EXECUTION_LAYER_IDENTIFIER_INVALID",
                $"Rev3 execution-layer metadata key '{key}' must be a compact identifier with no whitespace.",
                $"{pathPrefix}.{key}"));
        }
    }

    private static void ValidateDiagnosticsPath(
        GpuDiagnosticsPathInfo path,
        string pathName,
        ICollection<GpuValidationIssue> issues)
    {
        if (path.MemoryEstimate < 0)
        {
            issues.Add(Error(
                "GPU_DIAGNOSTICS_NEGATIVE_MEMORY",
                "GPU diagnostics memory estimate must not be negative.",
                $"{pathName}.memoryEstimate"));
        }

        if (path.ZeroCopy && path.Readback == GpuReadbackPolicy.RequiredFallback)
        {
            issues.Add(Error(
                "GPU_DIAGNOSTICS_ZERO_COPY_READBACK_CONFLICT",
                "GPU diagnostics path cannot be zero-copy while requiring fallback readback.",
                $"{pathName}.readback"));
        }

        if (!path.ZeroCopy &&
            path.Readback == GpuReadbackPolicy.None &&
            string.IsNullOrWhiteSpace(path.FallbackReason))
        {
            issues.Add(Warning(
                "GPU_DIAGNOSTICS_FALLBACK_REASON_MISSING",
                "GPU diagnostics path is not zero-copy and has no fallback reason.",
                $"{pathName}.fallbackReason"));
        }

        ValidateDiagnosticsMetadata(path.Metadata, pathName, issues);
    }

    private static void ValidateDiagnosticsMetadata(
        IReadOnlyDictionary<string, string>? metadata,
        string pathName,
        ICollection<GpuValidationIssue> issues)
    {
        if (metadata is null)
        {
            return;
        }

        foreach (var pair in metadata)
        {
            if (string.IsNullOrWhiteSpace(pair.Key))
            {
                issues.Add(Error(
                    "GPU_DIAGNOSTICS_METADATA_KEY_EMPTY",
                    "GPU diagnostics metadata keys must be non-empty.",
                    $"{pathName}.metadata"));
            }

            if (pair.Value is null)
            {
                issues.Add(Error(
                    "GPU_DIAGNOSTICS_METADATA_VALUE_NULL",
                    "GPU diagnostics metadata values must be non-null strings.",
                    $"{pathName}.metadata.{pair.Key}"));
            }
        }

        if (metadata.Keys.Any(static key => key.StartsWith("rev3_", StringComparison.Ordinal)))
        {
            foreach (var key in RequiredRev3DiagnosticsMetadataKeys)
            {
                if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
                {
                    issues.Add(Error(
                        "GPU_DIAGNOSTICS_REV3_METADATA_MISSING",
                        $"GPU diagnostics rev3 metadata must include key '{key}'.",
                        $"{pathName}.metadata.{key}"));
                }
            }

            foreach (var key in Rev3DiagnosticsBooleanMetadataKeys)
            {
                if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                if (!string.Equals(value, "true", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(value, "false", StringComparison.OrdinalIgnoreCase))
                {
                    issues.Add(Error(
                        "GPU_DIAGNOSTICS_REV3_METADATA_BOOLEAN_INVALID",
                        $"GPU diagnostics rev3 metadata key '{key}' must be 'true' or 'false', but was '{value}'.",
                        $"{pathName}.metadata.{key}"));
                }
            }

            foreach (var key in Rev3DiagnosticsIntegerMetadataKeys)
            {
                if (!metadata.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                if (!long.TryParse(value, out var parsed) || parsed < 0)
                {
                    issues.Add(Error(
                        "GPU_DIAGNOSTICS_REV3_METADATA_INTEGER_INVALID",
                        $"GPU diagnostics rev3 metadata key '{key}' must be a non-negative integer, but was '{value}'.",
                        $"{pathName}.metadata.{key}"));
                }
            }

            foreach (var pair in Rev3DiagnosticsKnownValueMetadataKeys)
            {
                if (!metadata.TryGetValue(pair.Key, out var value) || string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                if (!pair.Value.Contains(value))
                {
                    issues.Add(Error(
                        "GPU_DIAGNOSTICS_REV3_METADATA_VALUE_UNKNOWN",
                        $"GPU diagnostics rev3 metadata key '{pair.Key}' has unknown canonical value '{value}'.",
                        $"{pathName}.metadata.{pair.Key}"));
                }
            }
        }

        if (metadata.TryGetValue(GpuDiagnosticsMetadataKeys.Rev3PassReadiness, out var readiness))
        {
            foreach (var token in RequiredRev3BrowserReadinessTokens)
            {
                if (!readiness.Contains(token, StringComparison.Ordinal))
                {
                    issues.Add(Error(
                        "GPU_DIAGNOSTICS_REV3_PASS_READINESS_SHAPE_INVALID",
                        $"GPU diagnostics rev3 pass readiness metadata must include '{token}'.",
                        $"{pathName}.metadata.{GpuDiagnosticsMetadataKeys.Rev3PassReadiness}"));
                }
            }
        }
    }

    private static GpuValidationIssue Error(string code, string message, string path)
        => new()
        {
            Code = code,
            Message = message,
            Path = path,
            Severity = GpuValidationSeverity.Error
        };

    private static GpuValidationIssue Warning(string code, string message, string path)
        => new()
        {
            Code = code,
            Message = message,
            Path = path,
            Severity = GpuValidationSeverity.Warning
        };
}

/// <summary>
/// [EN] Identifies a GPU texture target used by capture, analysis, HUD, or presentation.
/// [JA] capture、analysis、HUD、presentation で使用する GPU texture target を識別します。
/// </summary>
public sealed record GpuFrameTarget
{
    /// <summary>[EN] Target identifier. [JA] target 識別子です。</summary>
    public required string TargetId { get; init; }

    /// <summary>[EN] Target kind. [JA] target kind です。</summary>
    public GpuFrameTargetKind Kind { get; init; } = GpuFrameTargetKind.Unknown;

    /// <summary>[EN] Backend that owns the target. [JA] target を所有する backend です。</summary>
    public GpuBackend Backend { get; init; } = GpuBackend.Unknown;

    /// <summary>[EN] Width in pixels. [JA] pixel 幅です。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Height in pixels. [JA] pixel 高です。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Pixel format. [JA] pixel format です。</summary>
    public FramePixelFormat PixelFormat { get; init; } = FramePixelFormat.Unknown;

    /// <summary>[EN] True when the target can be consumed without CPU readback. [JA] CPU readback なしで消費できる場合 true です。</summary>
    public bool ZeroCopy { get; init; }
}

/// <summary>
/// [EN] Frame token that lets GPU passes share a deterministic sample boundary.
/// [JA] GPU pass 間で deterministic sample boundary を共有する frame token です。
/// </summary>
public sealed record GpuFrameToken
{
    /// <summary>[EN] Frame identifier. [JA] frame 識別子です。</summary>
    public required string FrameId { get; init; }

    /// <summary>[EN] Monotonic frame index. [JA] monotonic frame index です。</summary>
    public long FrameIndex { get; init; }

    /// <summary>[EN] Deterministic sample timestamp in ticks. [JA] deterministic sample timestamp tick です。</summary>
    public long SampleTicks { get; init; }

    /// <summary>[EN] Raw frame target. [JA] raw frame target です。</summary>
    public GpuFrameTarget RawTarget { get; init; } = new() { TargetId = "raw" };

    /// <summary>[EN] Optional HUD composite target. [JA] 任意の HUD composite target です。</summary>
    public GpuFrameTarget? HudTarget { get; init; }
}

/// <summary>
/// [EN] Diagnostics for one GPU path in the canonical frame table.
/// [JA] canonical frame table 内の 1 つの GPU path 用 diagnostics です。
/// </summary>
public sealed record GpuDiagnosticsPathInfo
{
    /// <summary>[EN] Backend label. [JA] backend label です。</summary>
    public string Backend { get; init; } = "unknown";

    /// <summary>[EN] True when zero-copy is active. [JA] zero-copy が有効な場合 true です。</summary>
    public bool ZeroCopy { get; init; }

    /// <summary>[EN] Readback policy. [JA] readback policy です。</summary>
    public GpuReadbackPolicy Readback { get; init; } = GpuReadbackPolicy.None;

    /// <summary>[EN] Fallback reason, if any. [JA] fallback 理由です。</summary>
    public string? FallbackReason { get; init; }

    /// <summary>[EN] Frame id for this path. [JA] この path の frame id です。</summary>
    public string? FrameId { get; init; }

    /// <summary>[EN] GPU pass id for this path. [JA] この path の GPU pass id です。</summary>
    public string? PassId { get; init; }

    /// <summary>[EN] Estimated memory use in bytes. [JA] 推定 memory 使用量(byte)です。</summary>
    public long? MemoryEstimate { get; init; }

    /// <summary>[EN] Deterministic provider/pilot diagnostics metadata. [JA] deterministic provider/pilot diagnostics metadata です。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// [EN] Canonical v0.1.3 metadata keys for GPU diagnostics paths.
/// [JA] GPU diagnostics path 用 canonical v0.1.3 metadata key です。
/// </summary>
public static class GpuDiagnosticsMetadataKeys
{
    /// <summary>[EN] Canonical pass identifier. [JA] canonical pass identifier です。</summary>
    public const string Rev3PassId = "rev3_pass_id";

    /// <summary>[EN] Deterministic frame index copied from GpuFrameToken. [JA] GpuFrameToken 由来の deterministic frame index です。</summary>
    public const string Rev3FrameIndex = "rev3_frame_index";

    /// <summary>[EN] Deterministic sample ticks copied from GpuFrameToken. [JA] GpuFrameToken 由来の deterministic sample ticks です。</summary>
    public const string Rev3SampleTicks = "rev3_sample_ticks";

    /// <summary>[EN] Path role such as game, bonsai, hud, or sensor. [JA] game、bonsai、hud、sensor などの path role です。</summary>
    public const string Rev3PathRole = "rev3_path_role";

    /// <summary>[EN] Pilot comparison state. [JA] pilot 比較状態です。</summary>
    public const string Rev3PilotState = "rev3_pilot_state";

    /// <summary>[EN] Promotion gate state. [JA] promotion gate 状態です。</summary>
    public const string Rev3PromotionGate = "rev3_promotion_gate";

    /// <summary>[EN] Consecutive candidate frame count. [JA] 連続 candidate frame 数です。</summary>
    public const string Rev3CandidateStreak = "rev3_candidate_streak";

    /// <summary>[EN] Consecutive diagnostic-ready frame count. [JA] 連続 diagnostic-ready frame 数です。</summary>
    public const string Rev3DiagnosticStreak = "rev3_diagnostic_streak";

    /// <summary>[EN] Required streak count for readiness. [JA] readiness に必要な streak 数です。</summary>
    public const string Rev3RequiredStreak = "rev3_required_streak";

    /// <summary>[EN] True when the path may become authoritative. [JA] path が authoritative になり得る場合 true です。</summary>
    public const string Rev3AuthoritativeReady = "rev3_authoritative_ready";

    /// <summary>[EN] True when the path is diagnostically stable. [JA] path が diagnostics 上 stable な場合 true です。</summary>
    public const string Rev3DiagnosticReady = "rev3_diagnostic_ready";

    /// <summary>[EN] Execution mode such as browser WebGPU compute or deterministic fallback. [JA] browser WebGPU compute や deterministic fallback などの execution mode です。</summary>
    public const string Rev3ExecutionMode = "rev3_execution_mode";

    /// <summary>[EN] True when Aisthesis owns a canonical FeatureMask GPU storage texture. [JA] Aisthesis が canonical FeatureMask GPU storage texture を所有する場合 true です。</summary>
    public const string Rev3FeatureMaskStorageTexture = "rev3_feature_mask_storage_texture";

    /// <summary>[EN] Compact pass-readiness summary for browser HUD rows. [JA] browser HUD row 用の compact pass-readiness summary です。</summary>
    public const string Rev3PassReadiness = "rev3_pass_readiness";

    /// <summary>[EN] True when promotion readiness is blocked. [JA] promotion readiness が block されている場合 true です。</summary>
    public const string Rev3PromotionBlocked = "rev3_promotion_blocked";

    /// <summary>[EN] True when the path is a stable promotion candidate. [JA] path が stable promotion candidate の場合 true です。</summary>
    public const string Rev3PromotionCandidateReady = "rev3_promotion_candidate_ready";

    /// <summary>[EN] True when diagnostic readiness has reached the required stable streak. [JA] diagnostic readiness が required stable streak に到達した場合 true です。</summary>
    public const string Rev3PromotionDiagnosticStable = "rev3_promotion_diagnostic_stable";

    /// <summary>[EN] Machine-readable reason produced by the rev3 promotion evaluator. [JA] rev3 promotion evaluator が生成する機械判定用 reason です。</summary>
    public const string Rev3PromotionReason = "rev3_promotion_reason";
}

/// <summary>
/// [EN] Canonical v0.1.3 rev3 diagnostics execution mode values.
/// [JA] canonical v0.1.3 rev3 diagnostics execution mode 値です。
/// </summary>
public static class GpuRev3ExecutionModes
{
    /// <summary>[EN] Browser WebGPU compute execution. [JA] browser WebGPU compute execution です。</summary>
    public const string BrowserWebGpuCompute = "browser-webgpu-compute";

    /// <summary>[EN] Browser deterministic fallback execution. [JA] browser deterministic fallback execution です。</summary>
    public const string DeterministicFallback = "deterministic-fallback";

    /// <summary>[EN] Managed deterministic C# execution. [JA] managed deterministic C# execution です。</summary>
    public const string CSharpDeterministic = "csharp-deterministic";

    /// <summary>[EN] Native Dawn descriptor/probe execution. [JA] native Dawn descriptor/probe execution です。</summary>
    public const string NativeDawnDescriptor = "native-dawn-descriptor";

    /// <summary>[EN] Native Dawn compute execution. [JA] native Dawn compute execution です。</summary>
    public const string NativeDawnCompute = "native-dawn-compute";

    /// <summary>[EN] Native CUDA descriptor execution. [JA] native CUDA descriptor execution です。</summary>
    public const string NativeCudaDescriptor = "native-cuda-descriptor";

    /// <summary>[EN] Native CUDA descriptor execution before binding. [JA] native CUDA descriptor execution の未 bind 状態です。</summary>
    public const string NativeCudaDescriptorUnbound = "native-cuda-descriptor-unbound";

    /// <summary>[EN] Native CUDA ABI execution. [JA] native CUDA ABI execution です。</summary>
    public const string NativeCudaAbi = "native-cuda-abi";

    /// <summary>[EN] Native CUDA ABI probe execution. [JA] native CUDA ABI probe execution です。</summary>
    public const string NativeCudaAbiProbe = "native-cuda-abi-probe";

    /// <summary>[EN] Control-plane approved GPU execution. [JA] Control-plane approved GPU execution です。</summary>
    public const string ControlGpuApproved = "control-gpu-approved";

    /// <summary>[EN] Control-plane CPU fallback execution. [JA] Control-plane CPU fallback execution です。</summary>
    public const string ControlCpuFallback = "control-cpu-fallback";

    /// <summary>[EN] Stable known execution mode values. [JA] 安定した既知 execution mode 値です。</summary>
    public static IReadOnlySet<string> All { get; } = new HashSet<string>(StringComparer.Ordinal)
    {
        BrowserWebGpuCompute,
        DeterministicFallback,
        CSharpDeterministic,
        NativeDawnDescriptor,
        NativeDawnCompute,
        NativeCudaDescriptor,
        NativeCudaDescriptorUnbound,
        NativeCudaAbi,
        NativeCudaAbiProbe,
        ControlGpuApproved,
        ControlCpuFallback
    };
}

/// <summary>
/// [EN] Canonical v0.1.3 rev3 diagnostics path roles.
/// [JA] canonical v0.1.3 rev3 diagnostics path role 値です。
/// </summary>
public static class GpuRev3PathRoles
{
    /// <summary>[EN] Game rendering path. [JA] game rendering path です。</summary>
    public const string Game = "game";

    /// <summary>[EN] Bonsai/model path. [JA] Bonsai/model path です。</summary>
    public const string Bonsai = "bonsai";

    /// <summary>[EN] HUD composition path. [JA] HUD composition path です。</summary>
    public const string Hud = "hud";

    /// <summary>[EN] Sensor/Aisthesis/Spatial path. [JA] sensor/Aisthesis/Spatial path です。</summary>
    public const string Sensor = "sensor";

    /// <summary>[EN] Stable known path role values. [JA] 安定した既知 path role 値です。</summary>
    public static IReadOnlySet<string> All { get; } = new HashSet<string>(StringComparer.Ordinal)
    {
        Game,
        Bonsai,
        Hud,
        Sensor
    };

    /// <summary>
    /// [EN] Resolves a canonical diagnostics path role from a pass identifier.
    /// [JA] pass 識別子から canonical diagnostics path role を解決します。
    /// </summary>
    /// <param name="passId">EN: Pass identifier. JA: pass 識別子です。</param>
    /// <param name="role">EN: Resolved path role when successful. JA: 解決できた path role です。</param>
    /// <returns>EN: True when a canonical role was resolved. JA: canonical role を解決できた場合 true です。</returns>
    public static bool TryResolveFromPassId(string? passId, out string role)
    {
        if (passId is not null &&
            (passId.Contains("aisthesis", StringComparison.OrdinalIgnoreCase) ||
            passId.Contains("spatial", StringComparison.OrdinalIgnoreCase) ||
            passId.Contains("sensor", StringComparison.OrdinalIgnoreCase)))
        {
            role = Sensor;
            return true;
        }

        if (passId is not null &&
            passId.Contains("hud", StringComparison.OrdinalIgnoreCase))
        {
            role = Hud;
            return true;
        }

        if (passId is not null &&
            passId.Contains("bonsai", StringComparison.OrdinalIgnoreCase))
        {
            role = Bonsai;
            return true;
        }

        if (passId is not null &&
            passId.Contains("game", StringComparison.OrdinalIgnoreCase))
        {
            role = Game;
            return true;
        }

        role = string.Empty;
        return false;
    }
}

/// <summary>
/// [EN] Canonical v0.1.3 rev3 pilot state values used by diagnostics rows.
/// [JA] diagnostics row で使う canonical v0.1.3 rev3 pilot state 値です。
/// </summary>
public static class GpuRev3PilotStates
{
    /// <summary>[EN] Pilot state has not been evaluated. [JA] pilot state は未評価です。</summary>
    public const string NotEvaluated = "not-evaluated";

    /// <summary>[EN] Diagnostic path is present but not authoritative. [JA] diagnostic path は存在するが authoritative ではありません。</summary>
    public const string Diagnostic = "diagnostic";

    /// <summary>[EN] Live parity is within threshold. [JA] live parity が threshold 内です。</summary>
    public const string Within = "within";

    /// <summary>[EN] Browser built-in compute pilot. [JA] browser built-in compute pilot です。</summary>
    public const string BrowserBuiltinCompute = "browser-builtin-compute";

    /// <summary>[EN] Browser deterministic fallback pilot. [JA] browser deterministic fallback pilot です。</summary>
    public const string BrowserDeterministicFallback = "browser-deterministic-fallback";

    /// <summary>[EN] Native descriptor candidate. [JA] native descriptor candidate です。</summary>
    public const string DescriptorNativeCandidate = "descriptor-native-candidate";

    /// <summary>[EN] Native descriptor is ready. [JA] native descriptor は ready です。</summary>
    public const string DescriptorReady = "descriptor-ready";

    /// <summary>[EN] Native ABI probe candidate. [JA] native ABI probe candidate です。</summary>
    public const string ProbeNativeCandidate = "probe-native-candidate";

    /// <summary>[EN] Native ABI probe is ready. [JA] native ABI probe は ready です。</summary>
    public const string ProbeReady = "probe-ready";

    /// <summary>[EN] Provider has not been initialized. [JA] provider は未初期化です。</summary>
    public const string NotInitialized = "not-initialized";

    /// <summary>[EN] DTO-projected browser diagnostics row. [JA] DTO 投影済み browser diagnostics row です。</summary>
    public const string DtoProjected = "dto-projected";

    /// <summary>[EN] Runtime-observed browser diagnostics row. [JA] runtime 観測済み browser diagnostics row です。</summary>
    public const string RuntimeObserved = "runtime-observed";

    /// <summary>[EN] Aisthesis pilot is pending. [JA] Aisthesis pilot は pending です。</summary>
    public const string AisthesisPending = "aisthesis-pending";

    /// <summary>[EN] Spatial pilot is pending. [JA] Spatial pilot は pending です。</summary>
    public const string SpatialPending = "spatial-pending";

    /// <summary>[EN] Pilot source is unavailable. [JA] pilot source は unavailable です。</summary>
    public const string Unavailable = "unavailable";

    /// <summary>[EN] Stable known pilot state values. [JA] 安定した既知 pilot state 値です。</summary>
    public static IReadOnlySet<string> All { get; } = new HashSet<string>(StringComparer.Ordinal)
    {
        NotEvaluated,
        Diagnostic,
        Within,
        BrowserBuiltinCompute,
        BrowserDeterministicFallback,
        DescriptorNativeCandidate,
        DescriptorReady,
        ProbeNativeCandidate,
        ProbeReady,
        NotInitialized,
        DtoProjected,
        RuntimeObserved,
        AisthesisPending,
        SpatialPending,
        Unavailable
    };
}

/// <summary>
/// [EN] Canonical v0.1.3 rev3 promotion gate values used by diagnostics rows.
/// [JA] diagnostics row で使う canonical v0.1.3 rev3 promotion gate 値です。
/// </summary>
public static class GpuRev3PromotionGates
{
    /// <summary>[EN] Promotion gate has not been evaluated. [JA] promotion gate は未評価です。</summary>
    public const string NotEvaluated = "not-evaluated";

    /// <summary>[EN] Trace can be considered a candidate. [JA] trace を candidate として扱えます。</summary>
    public const string TraceCandidate = "trace-candidate";

    /// <summary>[EN] Deterministic fallback is active. [JA] deterministic fallback が有効です。</summary>
    public const string Fallback = "fallback";

    /// <summary>[EN] Native bridge is required before promotion. [JA] promotion 前に native bridge が必要です。</summary>
    public const string NativeBridgeRequired = "native-bridge-required";

    /// <summary>[EN] Runtime stamp is required before promotion. [JA] promotion 前に runtime stamp が必要です。</summary>
    public const string RuntimeStampRequired = "runtime-stamp-required";

    /// <summary>[EN] Promotion gate does not apply to this row. [JA] この row には promotion gate は適用されません。</summary>
    public const string NotApplicable = "not-applicable";

    /// <summary>[EN] Promotion source is unavailable. [JA] promotion source は unavailable です。</summary>
    public const string Unavailable = "unavailable";

    /// <summary>[EN] Stable known promotion gate values. [JA] 安定した既知 promotion gate 値です。</summary>
    public static IReadOnlySet<string> All { get; } = new HashSet<string>(StringComparer.Ordinal)
    {
        NotEvaluated,
        TraceCandidate,
        Fallback,
        NativeBridgeRequired,
        RuntimeStampRequired,
        NotApplicable,
        Unavailable
    };
}

/// <summary>
/// [EN] Canonical v0.1.3 metadata keys shared by GPU provider manifests, capability descriptors, and rev3 dispatch envelopes.
/// [JA] GPU provider manifest、capability descriptor、rev3 dispatch envelope で共有する canonical v0.1.3 metadata key です。
/// </summary>
public static class GpuProviderMetadataKeys
{
    /// <summary>[EN] Adapter profile selected by the provider. [JA] Provider が選択した adapter profile です。</summary>
    public const string AdapterProfile = "adapter_profile";

    /// <summary>[EN] Canonical AIS matrix order. [JA] canonical AIS matrix order です。</summary>
    public const string AisMatrixOrder = "ais_matrix_order";

    /// <summary>[EN] Backend name. [JA] backend 名です。</summary>
    public const string Backend = "backend";

    /// <summary>[EN] Fallback mode. [JA] fallback mode です。</summary>
    public const string Fallback = "fallback";

    /// <summary>[EN] Canonical GPU backend enum projection. [JA] canonical GPU backend enum projection です。</summary>
    public const string GpuBackend = "gpu_backend";

    /// <summary>[EN] Canonical GPU provider capabilities projection. [JA] canonical GPU provider capability projection です。</summary>
    public const string GpuCapabilities = "gpu_capabilities";

    /// <summary>[EN] GPU bypass strategy for avoiding CPU round-trips. [JA] CPU 往復を避ける GPU bypass 戦略です。</summary>
    public const string GpuBypass = "gpu_bypass";

    /// <summary>[EN] Native JavaScript bridge strategy for browser GPU execution. [JA] browser GPU execution 用 native JavaScript bridge 戦略です。</summary>
    public const string NativeJsBridge = "native_js_bridge";

    /// <summary>[EN] AOT compiler hook status for GPU-native execution. [JA] GPU-native execution 用 AOT compiler hook 状態です。</summary>
    public const string AotCompilerHooks = "aot_compiler_hooks";

    /// <summary>[EN] Deterministic frame sampling strategy. [JA] 決定論的 frame sampling 戦略です。</summary>
    public const string DeterministicFrameSampling = "deterministic_frame_sampling";

    /// <summary>[EN] Zero-copy buffer handling strategy. [JA] zero-copy buffer handling 戦略です。</summary>
    public const string ZeroCopyBufferHandling = "zero_copy_buffer_handling";

    /// <summary>[EN] Native/JS pass bridge mode. [JA] native/JS pass bridge mode です。</summary>
    public const string PassBridge = "pass_bridge";

    /// <summary>[EN] Provider family shared by sibling GPU providers. [JA] sibling GPU provider が共有する provider family です。</summary>
    public const string ProviderFamily = "provider_family";

    /// <summary>[EN] Provider role inside the shared GPU family. [JA] 共有 GPU family 内での provider role です。</summary>
    public const string ProviderRole = "provider_role";

    /// <summary>[EN] Raw capture source. [JA] raw capture source です。</summary>
    public const string RawCaptureSource = "raw_capture_source";

    /// <summary>[EN] Canonical rev3 enablement marker. [JA] canonical rev3 有効化 marker です。</summary>
    public const string Rev3 = "rev3";

    /// <summary>[EN] Provider or schema version. [JA] provider または schema version です。</summary>
    public const string Version = "version";

    /// <summary>[EN] Browser executor per-pass readiness diagnostics shape. [JA] browser executor の pass 別 readiness diagnostics 形状です。</summary>
    public const string Rev3BrowserPassReadiness = "rev3_browser_pass_readiness";

    /// <summary>[EN] Packaged browser rev3 bridge runtime path. [JA] packaged browser rev3 bridge runtime path です。</summary>
    public const string Rev3EnvelopeBridge = "rev3_envelope_bridge";

    /// <summary>[EN] Browser WebGPU executor factory. [JA] browser WebGPU executor factory です。</summary>
    public const string Rev3EnvelopeBridgeExecutorFactory = "rev3_envelope_bridge_executor_factory";

    /// <summary>[EN] Rev3 envelope bridge factory. [JA] rev3 envelope bridge factory です。</summary>
    public const string Rev3EnvelopeBridgeFactory = "rev3_envelope_bridge_factory";

    /// <summary>[EN] Rev3 browser bridge global object. [JA] rev3 browser bridge global object です。</summary>
    public const string Rev3EnvelopeBridgeGlobal = "rev3_envelope_bridge_global";

    /// <summary>[EN] Rev3 dispatch envelope schema. [JA] rev3 dispatch envelope schema です。</summary>
    public const string Rev3EnvelopeSchema = "rev3_envelope_schema";
}

/// <summary>
/// [EN] Canonical v0.1.3 metadata keys emitted by Control-plane GPU arbitration.
/// [JA] Control-plane GPU arbitration が出力する canonical v0.1.3 metadata key です。
/// </summary>
public static class GpuControlMetadataKeys
{
    /// <summary>[EN] Intent identifier. [JA] intent 識別子です。</summary>
    public const string IntentId = "control.intent_id";

    /// <summary>[EN] Objective identifier. [JA] objective 識別子です。</summary>
    public const string ObjectiveId = "control.objective_id";

    /// <summary>[EN] Action identifier. [JA] action 識別子です。</summary>
    public const string ActionId = "control.action_id";

    /// <summary>[EN] Arbitration reason. [JA] arbitration 理由です。</summary>
    public const string Reason = "control.gpu.reason";

    /// <summary>[EN] Required GPU capabilities. [JA] 必要な GPU capability です。</summary>
    public const string RequiredCapabilities = "control.gpu.required_capabilities";

    /// <summary>[EN] Available GPU capabilities. [JA] 利用可能な GPU capability です。</summary>
    public const string AvailableCapabilities = "control.gpu.available_capabilities";

    /// <summary>[EN] Missing GPU capabilities. [JA] 不足している GPU capability です。</summary>
    public const string MissingCapabilities = "control.gpu.missing_capabilities";

    /// <summary>[EN] Input target kind. [JA] input target kind です。</summary>
    public const string InputTargetKind = "control.gpu.input_target_kind";

    /// <summary>[EN] Readback policy. [JA] readback policy です。</summary>
    public const string ReadbackPolicy = "control.gpu.readback_policy";

    /// <summary>[EN] Zero-copy raw texture requirement. [JA] zero-copy raw texture 要求です。</summary>
    public const string ZeroCopyRawTextureRequired = "control.gpu.zero_copy_raw_texture_required";

    /// <summary>[EN] Native/browser pass bridge requirement. [JA] native/browser pass bridge 要求です。</summary>
    public const string NativePassBridgeRequired = "control.gpu.native_pass_bridge_required";

    /// <summary>[EN] Native/browser pass bridge availability. [JA] native/browser pass bridge 利用可能状態です。</summary>
    public const string NativePassBridgeAvailable = "control.gpu.native_pass_bridge_available";

    /// <summary>[EN] Compact arbitration tags. [JA] compact arbitration tag です。</summary>
    public const string Tags = "control.gpu.tags";
}

/// <summary>
/// [EN] Canonical v0.1.3 metadata keys for native GPU ABI probes.
/// [JA] native GPU ABI probe 用 canonical v0.1.3 metadata key です。
/// </summary>
public static class GpuNativeAbiMetadataKeys
{
    /// <summary>[EN] Dawn native ABI availability. [JA] Dawn native ABI の利用可能状態です。</summary>
    public const string DawnNativeAbiAvailable = "dawn.native.abi.available";

    /// <summary>[EN] Dawn native ABI status reason. [JA] Dawn native ABI の status reason です。</summary>
    public const string DawnNativeAbiReason = "dawn.native.abi.reason";

    /// <summary>[EN] Dawn native ABI path source. [JA] Dawn native ABI path source です。</summary>
    public const string DawnNativeAbiSource = "dawn.native.abi.source";

    /// <summary>[EN] Dawn native ABI entry point. [JA] Dawn native ABI entry point です。</summary>
    public const string DawnNativeEntryPoint = "dawn.native.entry_point";

    /// <summary>[EN] Dawn native initialization ABI entry point. [JA] Dawn native 初期化 ABI entry point です。</summary>
    public const string DawnNativeInitializationEntryPoint = "dawn.native.init_entry_point";

    /// <summary>[EN] Dawn native dispatch ABI entry point. [JA] Dawn native dispatch ABI entry point です。</summary>
    public const string DawnNativeDispatchEntryPoint = "dawn.native.dispatch_entry_point";

    /// <summary>[EN] Dawn native ABI environment variable. [JA] Dawn native ABI 環境変数です。</summary>
    public const string DawnNativeEnvironmentVariable = "dawn.native.env";

    /// <summary>[EN] Dawn native validation request state. [JA] Dawn native validation request 状態です。</summary>
    public const string DawnNativeValidation = "dawn.native.validation";

    /// <summary>[EN] Dawn native path configuration state. [JA] Dawn native path 設定状態です。</summary>
    public const string DawnNativePathConfigured = "dawn.native.path.configured";

    /// <summary>[EN] CUDA native ABI availability. [JA] CUDA native ABI の利用可能状態です。</summary>
    public const string CudaNativeAbiAvailable = "cuda.native.abi.available";

    /// <summary>[EN] CUDA native ABI status reason. [JA] CUDA native ABI の status reason です。</summary>
    public const string CudaNativeAbiReason = "cuda.native.abi.reason";

    /// <summary>[EN] CUDA native bridge availability. [JA] CUDA native bridge の利用可能状態です。</summary>
    public const string CudaNativeBridgeAvailable = "cuda.native.bridge.available";

    /// <summary>[EN] CUDA native bridge library name. [JA] CUDA native bridge library 名です。</summary>
    public const string CudaNativeBridgeLibrary = "cuda.native.bridge.library";

    /// <summary>[EN] CUDA native bridge path. [JA] CUDA native bridge path です。</summary>
    public const string CudaNativeBridgePath = "cuda.native.bridge.path";

    /// <summary>[EN] CUDA native loader configuration state. [JA] CUDA native loader 設定状態です。</summary>
    public const string CudaNativeLoaderConfigured = "cuda.native.loader.configured";

    /// <summary>[EN] CUDA native loader environment variable. [JA] CUDA native loader 環境変数です。</summary>
    public const string CudaNativeLoaderEnvironmentVariable = "cuda.native.loader.env";

    /// <summary>[EN] CUDA native loader path. [JA] CUDA native loader path です。</summary>
    public const string CudaNativeLoaderPath = "cuda.native.loader.path";

    /// <summary>[EN] CUDA native validation request state. [JA] CUDA native validation request 状態です。</summary>
    public const string CudaNativeValidation = "cuda.native.validation";

    /// <summary>[EN] LibTorch runtime path configuration state. [JA] LibTorch runtime path 設定状態です。</summary>
    public const string CudaLibTorchPathConfigured = "cuda.libtorch.path.configured";

    /// <summary>[EN] LibTorch runtime path availability. [JA] LibTorch runtime path 利用可能状態です。</summary>
    public const string CudaLibTorchPathAvailable = "cuda.libtorch.path.available";

    /// <summary>[EN] LibTorch runtime path environment variable. [JA] LibTorch runtime path 環境変数です。</summary>
    public const string CudaLibTorchPathEnvironmentVariable = "cuda.libtorch.path.env";

    /// <summary>[EN] LibTorch runtime path. [JA] LibTorch runtime path です。</summary>
    public const string CudaLibTorchPath = "cuda.libtorch.path";
}

/// <summary>
/// [EN] Canonical v0.1.3 GPU operation and pass identifiers shared by providers and tools.
/// [JA] provider と tools で共有する canonical v0.1.3 GPU operation / pass identifier です。
/// </summary>
public static class GpuOperationNames
{
    /// <summary>[EN] Generic compute dispatch operation. [JA] 汎用 compute dispatch operation です。</summary>
    public const string ComputeDispatch = "compute.dispatch";

    /// <summary>[EN] Vector-add compute sample operation. [JA] vector-add compute sample operation です。</summary>
    public const string ComputeVectorAdd = "compute.vector_add";

    /// <summary>[EN] Canonical GPU HUD composite pass operation. [JA] canonical GPU HUD composite pass operation です。</summary>
    public const string GpuHudComposite = "gpu.hud.composite";

    /// <summary>[EN] Canonical raw-frame GPU Aisthesis pass operation. [JA] canonical raw-frame GPU Aisthesis pass operation です。</summary>
    public const string GpuAisthesisRawFrame = "gpu.aisthesis.raw-frame";

    /// <summary>[EN] Canonical GPU spatial reasoning pass operation. [JA] canonical GPU spatial reasoning pass operation です。</summary>
    public const string GpuSpatialReasoning = "gpu.spatial-reasoning";

    /// <summary>[EN] Canonical zero-copy raw texture capability operation. [JA] canonical zero-copy raw texture capability operation です。</summary>
    public const string GpuZeroCopyRawTexture = "gpu.zero-copy.raw-texture";

    /// <summary>[EN] Capability module entry point for WebGPU dispatch. [JA] WebGPU dispatch 用 capability module entry point です。</summary>
    public const string WebGpuDispatchEntryPoint = "webgpu_dispatch";

    /// <summary>[EN] Canonical operation list for the WebGPU compute provider. [JA] WebGPU compute provider 用 canonical operation list です。</summary>
    public static IReadOnlyList<string> WebGpuComputeProviderOperations { get; } =
    [
        ComputeDispatch,
        ComputeVectorAdd,
        GpuHudComposite,
        GpuAisthesisRawFrame,
        GpuSpatialReasoning,
        GpuZeroCopyRawTexture
    ];
}

/// <summary>
/// [EN] Canonical v0.1.3 permission names required by GPU providers.
/// [JA] GPU provider が要求する canonical v0.1.3 permission 名です。
/// </summary>
public static class GpuPermissionNames
{
    /// <summary>[EN] Permission to execute compute work. [JA] compute work を実行する permission です。</summary>
    public const string ComputeExecute = "compute.execute";

    /// <summary>[EN] Permission to read buffers. [JA] buffer を read する permission です。</summary>
    public const string BufferRead = "buffer.read";

    /// <summary>[EN] Permission to write buffers. [JA] buffer に write する permission です。</summary>
    public const string BufferWrite = "buffer.write";

    /// <summary>[EN] Permission to bind textures. [JA] texture を bind する permission です。</summary>
    public const string TextureBind = "texture.bind";

    /// <summary>[EN] Permission to write textures. [JA] texture に write する permission です。</summary>
    public const string TextureWrite = "texture.write";

    /// <summary>[EN] Canonical required permissions for WebGPU compute providers. [JA] WebGPU compute provider 用 canonical required permission です。</summary>
    public static IReadOnlyList<string> WebGpuComputeRequiredPermissions { get; } =
    [
        ComputeExecute,
        BufferRead,
        BufferWrite,
        TextureBind,
        TextureWrite
    ];
}

/// <summary>
/// [EN] Canonical v0.1.3 frame diagnostics split by game, Bonsai, HUD, and sensor paths.
/// [JA] game、Bonsai、HUD、sensor path ごとに分割した canonical v0.1.3 frame diagnostics です。
/// </summary>
public sealed record GpuFrameDiagnostics
{
    /// <summary>[EN] Game rendering path diagnostics. [JA] game rendering path diagnostics です。</summary>
    public GpuDiagnosticsPathInfo GamePath { get; init; } = new();

    /// <summary>[EN] Bonsai/model execution path diagnostics. [JA] Bonsai/model execution path diagnostics です。</summary>
    public GpuDiagnosticsPathInfo BonsaiPath { get; init; } = new();

    /// <summary>[EN] HUD composition path diagnostics. [JA] HUD composition path diagnostics です。</summary>
    public GpuDiagnosticsPathInfo HudPath { get; init; } = new();

    /// <summary>[EN] Sensor/Aisthesis path diagnostics. [JA] sensor/Aisthesis path diagnostics です。</summary>
    public GpuDiagnosticsPathInfo SensorPath { get; init; } = new();
}

/// <summary>
/// [EN] Final smoothed ego-radar state consumed by the GPU HUD shader.
/// [JA] GPU HUD shader がそのまま消費する最終 smoothing 済み ego-radar state です。
/// </summary>
public sealed record GpuHudEgoRadarInput
{
    /// <summary>[EN] North heading relative to the agent front, in degrees. [JA] agent 正面基準の北方位(deg)です。</summary>
    public float CompassHeadingDegrees { get; init; }

    /// <summary>[EN] Heading confidence. [JA] heading confidence です。</summary>
    public float CompassConfidence { get; init; }

    /// <summary>[EN] True when heading can be used by control logic. [JA] heading を control logic が利用できる場合 true です。</summary>
    public bool CompassUsable { get; init; }

    /// <summary>[EN] Current kinesis vector, X=turn and Y=forward. [JA] 現在の kinesis vector です。X=turn、Y=forward です。</summary>
    public GpuVector2 Kinesis { get; init; }

    /// <summary>[EN] Visual enemy yaw relative to front. [JA] 正面基準の visual enemy yaw です。</summary>
    public float? VisualEnemyYawDegrees { get; init; }

    /// <summary>[EN] Visual enemy confidence. [JA] visual enemy confidence です。</summary>
    public float VisualEnemyConfidence { get; init; }

    /// <summary>[EN] Audio enemy yaw relative to front. [JA] 正面基準の audio enemy yaw です。</summary>
    public float? AudioEnemyYawDegrees { get; init; }

    /// <summary>[EN] Audio enemy confidence. [JA] audio enemy confidence です。</summary>
    public float AudioEnemyConfidence { get; init; }

    /// <summary>[EN] Fused enemy yaw relative to front. [JA] 正面基準の fused enemy yaw です。</summary>
    public float? FusedEnemyYawDegrees { get; init; }

    /// <summary>[EN] Fused enemy confidence. [JA] fused enemy confidence です。</summary>
    public float FusedEnemyConfidence { get; init; }

    /// <summary>[EN] True when the shader should draw the visual/audio fusion link. [JA] shader が visual/audio fusion link を描画する場合 true です。</summary>
    public bool SdfLink { get; init; }

    /// <summary>[EN] Radar display mode. [JA] radar display mode です。</summary>
    public GpuEgoRadarMode RadarMode { get; init; } = GpuEgoRadarMode.Normal;

    /// <summary>[EN] Flicker amount already resolved by the runtime. [JA] runtime 側で解決済みの flicker 量です。</summary>
    public float Flicker { get; init; }

    /// <summary>[EN] Hold strength already resolved by the runtime. [JA] runtime 側で解決済みの hold 強度です。</summary>
    public float Hold { get; init; }

    /// <summary>[EN] Decay strength already resolved by the runtime. [JA] runtime 側で解決済みの decay 強度です。</summary>
    public float Decay { get; init; }

    /// <summary>[EN] Compact human-readable summary for lightweight text overlays. [JA] 軽量 text overlay 用の compact summary です。</summary>
    public string? Summary { get; init; }
}

/// <summary>
/// [EN] HUD label text intentionally left to the light DOM/text layer.
/// [JA] lightweight DOM/text layer に残す HUD label text です。
/// </summary>
public sealed record GpuHudLabel
{
    /// <summary>[EN] DTO version. [JA] DTO version です。</summary>
    public uint Version { get; init; } = 1;

    /// <summary>[EN] Label identifier. [JA] label 識別子です。</summary>
    public required string Id { get; init; }

    /// <summary>[EN] Display text. [JA] display text です。</summary>
    public required string Text { get; init; }

    /// <summary>[EN] Normalized X coordinate. [JA] normalized X 座標です。</summary>
    public float X { get; init; }

    /// <summary>[EN] Normalized Y coordinate. [JA] normalized Y 座標です。</summary>
    public float Y { get; init; }

    /// <summary>[EN] Optional anchor rectangle as x, y, width, height normalized values. [JA] x, y, width, height の normalized 値で表す任意の anchor rectangle です。</summary>
    public IReadOnlyList<float> AnchorRect { get; init; } = [];

    /// <summary>[EN] Drawing layer, where lower numbers are closer to the viewer. [JA] 小さい値ほど手前に描画される drawing layer です。</summary>
    public int Layer { get; init; }

    /// <summary>[EN] Style tone token such as normal, warning, danger, ethos, logos, or pathos. [JA] normal、warning、danger、ethos、logos、pathos などの style tone token です。</summary>
    public string Tone { get; init; } = "normal";

    /// <summary>[EN] Source category for lightweight text placement. [JA] lightweight text 配置用の source category です。</summary>
    public string? Source { get; init; }

    /// <summary>[EN] Optional semantic key. [JA] 任意の semantic key です。</summary>
    public string? Key { get; init; }
}

/// <summary>
/// [EN] Input contract for canonical GPU HUD composition.
/// [JA] canonical GPU HUD composition 用 input contract です。
/// </summary>
public sealed record GpuHudInput
{
    /// <summary>[EN] DTO version. [JA] DTO version です。</summary>
    public uint Version { get; init; } = 1;

    /// <summary>[EN] Deterministic frame token. [JA] deterministic frame token です。</summary>
    public required GpuFrameToken Frame { get; init; }

    /// <summary>[EN] HUD feature enable flags by canonical name. [JA] canonical 名ごとの HUD feature enable flag です。</summary>
    public IReadOnlyDictionary<string, bool> Features { get; init; } = new Dictionary<string, bool>();

    /// <summary>[EN] Panel rectangle buffer data. [JA] panel rectangle buffer data です。</summary>
    public IReadOnlyList<float> HudPanelRects { get; init; } = [];

    /// <summary>[EN] Panel semantic state buffer data. [JA] panel semantic state buffer data です。</summary>
    public IReadOnlyList<float> HudPanelStateVectors { get; init; } = [];

    /// <summary>[EN] Ego-radar input. [JA] ego-radar input です。</summary>
    public GpuHudEgoRadarInput EgoRadar { get; init; } = new();

    /// <summary>[EN] Text labels rendered outside GPU shader effects. [JA] GPU shader effect 外で描画する text label です。</summary>
    public IReadOnlyList<GpuHudLabel> Labels { get; init; } = [];
}

/// <summary>
/// [EN] Input contract for GPU Aisthesis feature extraction.
/// [JA] GPU Aisthesis feature extraction 用 input contract です。
/// </summary>
public sealed record GpuAisthesisInput
{
    /// <summary>[EN] Deterministic frame token. [JA] deterministic frame token です。</summary>
    public required GpuFrameToken Frame { get; init; }

    /// <summary>[EN] Raw capture target; analysis must not use HUD-composited frames. [JA] raw capture target です。analysis は HUD 合成済み frame を使用してはいけません。</summary>
    public required GpuFrameTarget RawFramebuffer { get; init; }

    /// <summary>[EN] Feature enable flags by canonical name. [JA] canonical 名ごとの feature enable flag です。</summary>
    public IReadOnlyDictionary<string, bool> Features { get; init; } = new Dictionary<string, bool>();
}

/// <summary>
/// [EN] Output contract for GPU Aisthesis feature extraction.
/// [JA] GPU Aisthesis feature extraction の output contract です。
/// </summary>
public sealed record GpuAisthesisOutput
{
    /// <summary>[EN] Deterministic frame token. [JA] deterministic frame token です。</summary>
    public required GpuFrameToken Frame { get; init; }

    /// <summary>[EN] Feature vector; canonical default length is 32 floats. [JA] feature vector です。canonical default は 32 float です。</summary>
    public IReadOnlyList<float> FeatureVector { get; init; } = [];

    /// <summary>[EN] Optional mask texture target; minimum format is RGBA8. [JA] 任意の mask texture target です。最小 format は RGBA8 です。</summary>
    public GpuFrameTarget? MaskTexture { get; init; }

    /// <summary>[EN] Diagnostics for the sensor path. [JA] sensor path diagnostics です。</summary>
    public GpuDiagnosticsPathInfo Diagnostics { get; init; } = new();
}

/// <summary>
/// [EN] Input contract for GPU spatial reasoning.
/// [JA] GPU spatial reasoning 用 input contract です。
/// </summary>
public sealed record GpuSpatialReasoningInput
{
    /// <summary>[EN] Deterministic frame token. [JA] deterministic frame token です。</summary>
    public required GpuFrameToken Frame { get; init; }

    /// <summary>[EN] Four canonical 9x9 matrices in order: Topos, Route, Threat, Zoe. [JA] Topos, Route, Threat, Zoe の順の 4 つの canonical 9x9 matrix です。</summary>
    public IReadOnlyList<IReadOnlyList<float>> AisMatrices { get; init; } = [];

    /// <summary>[EN] CTG and other non-spatial state vector values. [JA] CTG などの non-spatial state vector 値です。</summary>
    public IReadOnlyList<float> StateVector { get; init; } = [];
}

/// <summary>
/// [EN] Output contract for GPU spatial reasoning.
/// [JA] GPU spatial reasoning の output contract です。
/// </summary>
public sealed record GpuSpatialReasoningOutput
{
    /// <summary>[EN] Deterministic frame token. [JA] deterministic frame token です。</summary>
    public required GpuFrameToken Frame { get; init; }

    /// <summary>[EN] Spatial vector; canonical default length is 32 floats. [JA] spatial vector です。canonical default は 32 float です。</summary>
    public IReadOnlyList<float> SpatialVector { get; init; } = [];

    /// <summary>[EN] Diagnostics for the spatial path. [JA] spatial path diagnostics です。</summary>
    public GpuDiagnosticsPathInfo Diagnostics { get; init; } = new();
}
