using AIKernel.Abstractions.Gpu;
using AIKernel.Dtos.Gpu;

namespace AIKernel.Abstractions.Tests;

public sealed class GpuCanonicalContractTests
{
    [Fact]
    public void GpuCanonicalLayouts_MatchCanonicalShapes()
    {
        Assert.Equal(8, GpuCanonicalLayouts.All.Count);
        Assert.Equal(81, GpuCanonicalLayouts.HudCells.MaxItems);
        Assert.Equal(12, GpuCanonicalLayouts.HudPanelRect.Stride);
        Assert.Equal(16, GpuCanonicalLayouts.HudPanelStateVector.Stride);
        Assert.Equal(81, GpuCanonicalLayouts.AisMatrix.Stride);
        Assert.Equal(4, GpuCanonicalLayouts.AisMatrix.MaxItems);

        var result = GpuCanonicalValidation.ValidateLayouts(GpuCanonicalLayouts.All);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void GpuPathRoles_ResolveCanonicalRolesFromPassIds()
    {
        Assert.True(GpuPathRoles.TryResolveFromPassId(GpuOperationNames.GpuAisthesisRawFrame, out var aisthesisRole));
        Assert.Equal(GpuPathRoles.Sensor, aisthesisRole);
        Assert.True(GpuPathRoles.TryResolveFromPassId(GpuOperationNames.GpuSpatialReasoning, out var spatialRole));
        Assert.Equal(GpuPathRoles.Sensor, spatialRole);
        Assert.True(GpuPathRoles.TryResolveFromPassId(GpuOperationNames.GpuHudComposite, out var hudRole));
        Assert.Equal(GpuPathRoles.Hud, hudRole);
        Assert.True(GpuPathRoles.TryResolveFromPassId("bonsai.model", out var bonsaiRole));
        Assert.Equal(GpuPathRoles.Bonsai, bonsaiRole);
        Assert.True(GpuPathRoles.TryResolveFromPassId("game.render", out var gameRole));
        Assert.Equal(GpuPathRoles.Game, gameRole);
        Assert.False(GpuPathRoles.TryResolveFromPassId("unknown", out _));
    }

    [Fact]
    public void ValidateAisthesisInput_RejectsHudCompositeCapture()
    {
        var input = new GpuAisthesisInput
        {
            Frame = new GpuFrameToken
            {
                FrameId = "frame-1",
                RawTarget = RawTarget("raw")
            },
            RawFramebuffer = new GpuFrameTarget
            {
                TargetId = "hud",
                Kind = GpuFrameTargetKind.HudCompositeOffscreen,
                Backend = GpuBackend.WebGpu,
                Width = 320,
                Height = 200,
                ZeroCopy = true
            }
        };

        var result = GpuCanonicalValidation.ValidateAisthesisInput(input);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, static issue => issue.Code == "GPU_AISTHESIS_RAW_TARGET_REQUIRED");
    }

    [Fact]
    public void ValidateSpatialReasoningInput_RejectsMissingCanonicalMatrix()
    {
        var input = new GpuSpatialReasoningInput
        {
            Frame = FrameToken(),
            AisMatrices =
            [
                FilledMatrix(),
                FilledMatrix(),
                FilledMatrix()
            ]
        };

        var result = GpuCanonicalValidation.ValidateSpatialReasoningInput(input);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, static issue => issue.Code == "GPU_SPATIAL_MATRIX_COUNT_MISMATCH");
    }

    [Fact]
    public void ValidateHudInput_RejectsPanelBufferStrideMismatch()
    {
        var input = new GpuHudInput
        {
            Frame = FrameToken(),
            HudPanelRects = [1.0f, 2.0f, 3.0f],
            HudPanelStateVectors = new float[16]
        };

        var result = GpuCanonicalValidation.ValidateHudInput(input);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, static issue => issue.Code == "GPU_FLAT_BUFFER_STRIDE_MISMATCH");
    }

    [Fact]
    public void ValidateCapabilities_ReportsMissingProviderCapabilities()
    {
        var required = GpuProviderCapabilities.SupportsCompute |
            GpuProviderCapabilities.SupportsHudComposite |
            GpuProviderCapabilities.SupportsZeroCopyRawTexture;

        var result = GpuCanonicalValidation.ValidateCapabilities(
            GpuProviderCapabilities.SupportsCompute,
            required);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, static issue => issue.Code == "GPU_CAPABILITY_MISSING");
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsZeroCopyFallbackReadbackConflict()
    {
        var diagnostics = new GpuFrameDiagnostics
        {
            SensorPath = new GpuDiagnosticsPathInfo
            {
                Backend = "webgpu",
                ZeroCopy = true,
                Readback = GpuReadbackPolicy.RequiredFallback,
                FrameId = "frame-1",
                PassId = "aisthesis"
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, static issue => issue.Code == "GPU_DIAGNOSTICS_ZERO_COPY_READBACK_CONFLICT");
    }

    [Fact]
    public void ValidateFrameDiagnostics_AllowsCanonicalPilotReadinessMetadata()
    {
        var diagnostics = new GpuFrameDiagnostics
        {
            SensorPath = new GpuDiagnosticsPathInfo
            {
                Backend = "webgpu",
                ZeroCopy = true,
                Readback = GpuReadbackPolicy.None,
                FrameId = "frame-1",
                PassId = "aisthesis",
                Metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
                {
                    [GpuDiagnosticsMetadataKeys.CanonicalAuthoritativeReady] = "false",
                    [GpuDiagnosticsMetadataKeys.CanonicalCandidateStreak] = "3",
                    [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticReady] = "true",
                    [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticStreak] = "3",
                    [GpuDiagnosticsMetadataKeys.CanonicalExecutionMode] = GpuExecutionModes.BrowserWebGpuCompute,
                    [GpuDiagnosticsMetadataKeys.CanonicalFeatureMaskStorageTexture] = "true",
                    [GpuDiagnosticsMetadataKeys.CanonicalFrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.CanonicalPassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
                    [GpuDiagnosticsMetadataKeys.CanonicalPassId] = GpuOperationNames.GpuAisthesisRawFrame,
                    [GpuDiagnosticsMetadataKeys.CanonicalPathRole] = "sensor",
                    [GpuDiagnosticsMetadataKeys.CanonicalPilotState] = GpuCanonicalPilotStates.Within,
                    [GpuDiagnosticsMetadataKeys.CanonicalPromotionGate] = GpuPromotionGates.TraceCandidate,
                    [GpuDiagnosticsMetadataKeys.CanonicalRequiredStreak] = "8",
                    [GpuDiagnosticsMetadataKeys.CanonicalSampleTicks] = "100"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.True(result.IsValid);
        Assert.Equal(
            GpuPromotionGates.TraceCandidate,
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.CanonicalPromotionGate]);
        Assert.Equal(
            "true",
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.CanonicalFeatureMaskStorageTexture]);
        Assert.Equal(
            GpuExecutionModes.BrowserWebGpuCompute,
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.CanonicalExecutionMode]);
        Assert.Equal(
            "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.CanonicalPassReadiness]);
    }

    [Fact]
    public void EvaluatePromotionReadiness_RequiresAuthoritativeReadyAndStableStreaks()
    {
        var metadata = ReadinessMetadata(
            authoritativeReady: true,
            diagnosticReady: true,
            candidateStreak: 8,
            diagnosticStreak: 8,
            requiredStreak: 8,
            gate: GpuPromotionGates.TraceCandidate);

        var readiness = GpuCanonicalValidation.EvaluatePromotionReadiness(metadata);

        Assert.True(readiness.IsAuthoritativeReady);
        Assert.True(readiness.IsDiagnosticReady);
        Assert.True(readiness.IsDiagnosticStable);
        Assert.True(readiness.IsPromotionCandidate);
        Assert.False(readiness.IsBlocked);
        Assert.True(readiness.HasStorageTextureFeature);
        Assert.Equal("authoritative-ready", readiness.Reason);
        Assert.Equal(8, readiness.RequiredStreak);
    }

    [Fact]
    public void EvaluatePromotionReadiness_KeepsPilotDiagnosticUntilStreaksAndAuthoritativeReady()
    {
        var metadata = ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: true,
            candidateStreak: 3,
            diagnosticStreak: 3,
            requiredStreak: 8,
            gate: GpuPromotionGates.TraceCandidate);

        var readiness = GpuCanonicalValidation.EvaluatePromotionReadiness(metadata);

        Assert.False(readiness.IsAuthoritativeReady);
        Assert.True(readiness.IsDiagnosticReady);
        Assert.False(readiness.IsDiagnosticStable);
        Assert.False(readiness.IsPromotionCandidate);
        Assert.False(readiness.IsBlocked);
        Assert.Equal("streak-not-ready", readiness.Reason);
        Assert.Equal(3, readiness.CandidateStreak);
        Assert.Equal(3, readiness.DiagnosticStreak);
    }

    [Theory]
    [InlineData(GpuPromotionGates.Fallback)]
    [InlineData(GpuPromotionGates.NativeBridgeRequired)]
    public void EvaluatePromotionReadiness_BlocksFallbackAndNativeBridgeGates(string gate)
    {
        var metadata = ReadinessMetadata(
            authoritativeReady: true,
            diagnosticReady: true,
            candidateStreak: 8,
            diagnosticStreak: 8,
            requiredStreak: 8,
            gate: gate);

        var readiness = GpuCanonicalValidation.EvaluatePromotionReadiness(metadata);

        Assert.False(readiness.IsAuthoritativeReady);
        Assert.False(readiness.IsPromotionCandidate);
        Assert.True(readiness.IsBlocked);
        Assert.Equal(gate, readiness.Reason);
    }

    [Fact]
    public void EvaluatePromotionReadiness_AllowsNotEvaluatedGateWithoutRequiredStreak()
    {
        var metadata = ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: false,
            candidateStreak: 0,
            diagnosticStreak: 0,
            requiredStreak: 0,
            gate: GpuPromotionGates.NotEvaluated);

        var readiness = GpuCanonicalValidation.EvaluatePromotionReadiness(metadata);

        Assert.False(readiness.IsAuthoritativeReady);
        Assert.False(readiness.IsPromotionCandidate);
        Assert.True(readiness.IsBlocked);
        Assert.Equal(GpuPromotionGates.NotEvaluated, readiness.Gate);
        Assert.Equal(GpuPromotionGates.NotEvaluated, readiness.Reason);
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsPartialCanonicalFrameTokenMetadata()
    {
        var diagnostics = new GpuFrameDiagnostics
        {
            SensorPath = new GpuDiagnosticsPathInfo
            {
                Backend = "webgpu",
                ZeroCopy = true,
                Readback = GpuReadbackPolicy.None,
                PassId = "aisthesis",
                Metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
                {
                    [GpuDiagnosticsMetadataKeys.CanonicalFrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.CanonicalPassId] = GpuOperationNames.GpuAisthesisRawFrame
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_METADATA_MISSING" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.CanonicalSampleTicks, StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsInvalidCanonicalPromotionGateMetadataShape()
    {
        var diagnostics = new GpuFrameDiagnostics
        {
            SensorPath = new GpuDiagnosticsPathInfo
            {
                Backend = "webgpu",
                ZeroCopy = true,
                Readback = GpuReadbackPolicy.None,
                PassId = "aisthesis",
                Metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
                {
                    [GpuDiagnosticsMetadataKeys.CanonicalAuthoritativeReady] = "maybe",
                    [GpuDiagnosticsMetadataKeys.CanonicalCandidateStreak] = "-1",
                    [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticReady] = "true",
                    [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticStreak] = "not-a-number",
                    [GpuDiagnosticsMetadataKeys.CanonicalExecutionMode] = GpuExecutionModes.BrowserWebGpuCompute,
                    [GpuDiagnosticsMetadataKeys.CanonicalFeatureMaskStorageTexture] = "false",
                    [GpuDiagnosticsMetadataKeys.CanonicalFrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.CanonicalPassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
                    [GpuDiagnosticsMetadataKeys.CanonicalPassId] = GpuOperationNames.GpuAisthesisRawFrame,
                    [GpuDiagnosticsMetadataKeys.CanonicalPathRole] = "sensor",
                    [GpuDiagnosticsMetadataKeys.CanonicalPilotState] = GpuCanonicalPilotStates.BrowserBuiltinCompute,
                    [GpuDiagnosticsMetadataKeys.CanonicalPromotionGate] = GpuPromotionGates.TraceCandidate,
                    [GpuDiagnosticsMetadataKeys.CanonicalRequiredStreak] = "8",
                    [GpuDiagnosticsMetadataKeys.CanonicalSampleTicks] = "100"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue => issue.Code == "GPU_DIAGNOSTICS_METADATA_BOOLEAN_INVALID");
        Assert.Contains(result.Errors, issue => issue.Code == "GPU_DIAGNOSTICS_METADATA_INTEGER_INVALID");
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsUnknownCanonicalDiagnosticsStateValues()
    {
        var diagnostics = new GpuFrameDiagnostics
        {
            SensorPath = new GpuDiagnosticsPathInfo
            {
                Backend = "webgpu",
                ZeroCopy = true,
                Readback = GpuReadbackPolicy.None,
                PassId = "aisthesis",
                Metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
                {
                    [GpuDiagnosticsMetadataKeys.CanonicalAuthoritativeReady] = "false",
                    [GpuDiagnosticsMetadataKeys.CanonicalCandidateStreak] = "1",
                    [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticReady] = "true",
                    [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticStreak] = "1",
                    [GpuDiagnosticsMetadataKeys.CanonicalExecutionMode] = "browser-webgpu-comptue",
                    [GpuDiagnosticsMetadataKeys.CanonicalFeatureMaskStorageTexture] = "false",
                    [GpuDiagnosticsMetadataKeys.CanonicalFrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.CanonicalPassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
                    [GpuDiagnosticsMetadataKeys.CanonicalPassId] = GpuOperationNames.GpuAisthesisRawFrame,
                    [GpuDiagnosticsMetadataKeys.CanonicalPathRole] = "senser",
                    [GpuDiagnosticsMetadataKeys.CanonicalPilotState] = "trace-readyish",
                    [GpuDiagnosticsMetadataKeys.CanonicalPromotionGate] = "trace-candidte",
                    [GpuDiagnosticsMetadataKeys.CanonicalRequiredStreak] = "3",
                    [GpuDiagnosticsMetadataKeys.CanonicalSampleTicks] = "100"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.CanonicalExecutionMode, StringComparison.Ordinal));
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.CanonicalPathRole, StringComparison.Ordinal));
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.CanonicalPilotState, StringComparison.Ordinal));
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.CanonicalPromotionGate, StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsIncompleteCanonicalPassReadinessMetadata()
    {
        var diagnostics = new GpuFrameDiagnostics
        {
            SensorPath = new GpuDiagnosticsPathInfo
            {
                Backend = "webgpu",
                ZeroCopy = true,
                Readback = GpuReadbackPolicy.None,
                PassId = "aisthesis",
                Metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
                {
                    [GpuDiagnosticsMetadataKeys.CanonicalPassReadiness] = "Passes.{Aisthesis,HudComposite}:ShaderBound,PipelineCached"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_PASS_READINESS_SHAPE_INVALID" &&
            issue.Message.Contains("ReadyForBuiltIn", StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateDiagnosticsMetadata_ValidatesSingleBridgeMetadataDictionary()
    {
        var metadata = ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: true,
            candidateStreak: 1,
            diagnosticStreak: 1,
            requiredStreak: 1,
            gate: GpuPromotionGates.TraceCandidate);

        var result = GpuCanonicalValidation.ValidateDiagnosticsMetadata(metadata, "envelope");

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateDiagnosticsMetadata_RejectsMalformedSingleBridgeMetadataDictionary()
    {
        var metadata = ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: true,
            candidateStreak: 1,
            diagnosticStreak: 1,
            requiredStreak: 1,
            gate: GpuPromotionGates.TraceCandidate);
        metadata[GpuDiagnosticsMetadataKeys.CanonicalPilotState] = "browser-comptue";
        metadata[GpuDiagnosticsMetadataKeys.CanonicalPassReadiness] = "Passes.{Aisthesis}:ShaderBound=true";

        var result = GpuCanonicalValidation.ValidateDiagnosticsMetadata(metadata, "envelope");

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_METADATA_VALUE_UNKNOWN" &&
            issue.Path == $"envelope.metadata.{GpuDiagnosticsMetadataKeys.CanonicalPilotState}");
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_PASS_READINESS_SHAPE_INVALID" &&
            issue.Path == $"envelope.metadata.{GpuDiagnosticsMetadataKeys.CanonicalPassReadiness}");
    }

    [Fact]
    public void GpuProviderMetadataKeys_ExposeCanonicalManifestAndEnvelopeBoundary()
    {
        Assert.Equal("adapter_profile", GpuProviderMetadataKeys.AdapterProfile);
        Assert.Equal("ais_matrix_order", GpuProviderMetadataKeys.AisMatrixOrder);
        Assert.Equal("backend", GpuProviderMetadataKeys.Backend);
        Assert.Equal("fallback", GpuProviderMetadataKeys.Fallback);
        Assert.Equal("gpu_backend", GpuProviderMetadataKeys.GpuBackend);
        Assert.Equal("gpu_capabilities", GpuProviderMetadataKeys.GpuCapabilities);
        Assert.Equal("gpu_bypass", GpuProviderMetadataKeys.GpuBypass);
        Assert.Equal("native_js_bridge", GpuProviderMetadataKeys.NativeJsBridge);
        Assert.Equal("aot_compiler_hooks", GpuProviderMetadataKeys.AotCompilerHooks);
        Assert.Equal("deterministic_frame_sampling", GpuProviderMetadataKeys.DeterministicFrameSampling);
        Assert.Equal("zero_copy_buffer_handling", GpuProviderMetadataKeys.ZeroCopyBufferHandling);
        Assert.Equal("pass_bridge", GpuProviderMetadataKeys.PassBridge);
        Assert.Equal("provider_family", GpuProviderMetadataKeys.ProviderFamily);
        Assert.Equal("provider_role", GpuProviderMetadataKeys.ProviderRole);
        Assert.Equal("raw_capture_source", GpuProviderMetadataKeys.RawCaptureSource);
        Assert.Equal("canonical", GpuProviderMetadataKeys.Canonical);
        Assert.Equal("version", GpuProviderMetadataKeys.Version);
        Assert.Equal("browser_pass_readiness", GpuProviderMetadataKeys.CanonicalBrowserPassReadiness);
        Assert.Equal("envelope_bridge", GpuProviderMetadataKeys.CanonicalEnvelopeBridge);
        Assert.Equal("envelope_bridge_executor_factory", GpuProviderMetadataKeys.CanonicalEnvelopeBridgeExecutorFactory);
        Assert.Equal("envelope_bridge_factory", GpuProviderMetadataKeys.CanonicalEnvelopeBridgeFactory);
        Assert.Equal("envelope_bridge_global", GpuProviderMetadataKeys.CanonicalEnvelopeBridgeGlobal);
        Assert.Equal("envelope_schema", GpuProviderMetadataKeys.CanonicalEnvelopeSchema);
    }

    [Fact]
    public void GpuDiagnosticsMetadataKeys_ExposeDeterministicFrameSamplingBoundary()
    {
        Assert.Equal("frame_index", GpuDiagnosticsMetadataKeys.CanonicalFrameIndex);
        Assert.Equal("sample_ticks", GpuDiagnosticsMetadataKeys.CanonicalSampleTicks);
    }

    [Fact]
    public void GpuControlMetadataKeys_ExposeControlPlaneArbitrationBoundary()
    {
        Assert.Equal("control.intent_id", GpuControlMetadataKeys.IntentId);
        Assert.Equal("control.objective_id", GpuControlMetadataKeys.ObjectiveId);
        Assert.Equal("control.action_id", GpuControlMetadataKeys.ActionId);
        Assert.Equal("control.gpu.reason", GpuControlMetadataKeys.Reason);
        Assert.Equal("control.gpu.required_capabilities", GpuControlMetadataKeys.RequiredCapabilities);
        Assert.Equal("control.gpu.available_capabilities", GpuControlMetadataKeys.AvailableCapabilities);
        Assert.Equal("control.gpu.missing_capabilities", GpuControlMetadataKeys.MissingCapabilities);
        Assert.Equal("control.gpu.input_target_kind", GpuControlMetadataKeys.InputTargetKind);
        Assert.Equal("control.gpu.readback_policy", GpuControlMetadataKeys.ReadbackPolicy);
        Assert.Equal("control.gpu.zero_copy_raw_texture_required", GpuControlMetadataKeys.ZeroCopyRawTextureRequired);
        Assert.Equal("control.gpu.native_pass_bridge_required", GpuControlMetadataKeys.NativePassBridgeRequired);
        Assert.Equal("control.gpu.native_pass_bridge_available", GpuControlMetadataKeys.NativePassBridgeAvailable);
        Assert.Equal("control.gpu.tags", GpuControlMetadataKeys.Tags);
    }

    [Fact]
    public void ValidateControlArbitrationMetadata_AllowsCanonicalControlMetadata()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuDiagnosticsMetadataKeys.CanonicalPassId] = GpuOperationNames.GpuHudComposite,
            [GpuDiagnosticsMetadataKeys.CanonicalExecutionMode] = "control-gpu-approved",
            [GpuProviderMetadataKeys.Backend] = GpuBackend.WebGpu.ToString(),
            [GpuProviderMetadataKeys.Fallback] = "none",
            [GpuControlMetadataKeys.IntentId] = "render",
            [GpuControlMetadataKeys.ObjectiveId] = "doom-hud",
            [GpuControlMetadataKeys.ActionId] = "compose",
            [GpuControlMetadataKeys.Reason] = "gpu-execution-approved",
            [GpuControlMetadataKeys.RequiredCapabilities] = "SupportsCompute, SupportsHudComposite",
            [GpuControlMetadataKeys.AvailableCapabilities] = "SupportsCompute, SupportsHudComposite",
            [GpuControlMetadataKeys.MissingCapabilities] = GpuProviderCapabilities.None.ToString(),
            [GpuControlMetadataKeys.InputTargetKind] = GpuFrameTargetKind.RawFramebuffer.ToString(),
            [GpuControlMetadataKeys.ReadbackPolicy] = GpuReadbackPolicy.None.ToString(),
            [GpuControlMetadataKeys.ZeroCopyRawTextureRequired] = "true",
            [GpuControlMetadataKeys.NativePassBridgeRequired] = "false",
            [GpuControlMetadataKeys.NativePassBridgeAvailable] = "true",
            [GpuControlMetadataKeys.Tags] = "gpu,approved,render,doom-hud,compose"
        };

        var result = GpuCanonicalValidation.ValidateControlArbitrationMetadata(metadata);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateControlArbitrationMetadata_RejectsMissingControlKey()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuDiagnosticsMetadataKeys.CanonicalPassId] = GpuOperationNames.GpuHudComposite,
            [GpuDiagnosticsMetadataKeys.CanonicalExecutionMode] = "control-gpu-approved",
            [GpuProviderMetadataKeys.Backend] = GpuBackend.WebGpu.ToString(),
            [GpuProviderMetadataKeys.Fallback] = "none",
            [GpuControlMetadataKeys.IntentId] = "render",
            [GpuControlMetadataKeys.ObjectiveId] = "doom-hud",
            [GpuControlMetadataKeys.ActionId] = "compose"
        };

        var result = GpuCanonicalValidation.ValidateControlArbitrationMetadata(metadata);

        Assert.False(result.IsValid);
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_CONTROL_ARBITRATION_METADATA_MISSING" &&
                issue.Path == $"controlArbitration.{GpuControlMetadataKeys.Reason}");
    }

    [Fact]
    public void ValidateBrowserBridgeMetadata_AllowsCanonicalWasmBridgeMetadata()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.CanonicalBrowserPassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound,PipelineCached,BuiltInExecutor,InjectedExecutor,ReadyForBuiltIn",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridge] = "runtime/browser/webgpu-envelope-bridge.js",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridgeExecutorFactory] = "createWebGpuBrowserExecutor",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridgeFactory] = "createWebGpuEnvelopeBridge",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridgeGlobal] = "AIKernelWebGpu",
            [GpuProviderMetadataKeys.CanonicalEnvelopeSchema] = "aikernel.gpu.dispatch"
        };

        var result = GpuCanonicalValidation.ValidateBrowserBridgeMetadata(metadata);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateBrowserBridgeMetadata_RejectsMissingPassReadinessToken()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.CanonicalBrowserPassReadiness] = "Passes.{Aisthesis,HudComposite}:ShaderBound,PipelineCached,BuiltInExecutor,InjectedExecutor",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridge] = "runtime/browser/webgpu-envelope-bridge.js",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridgeExecutorFactory] = "createWebGpuBrowserExecutor",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridgeFactory] = "createWebGpuEnvelopeBridge",
            [GpuProviderMetadataKeys.CanonicalEnvelopeBridgeGlobal] = "AIKernelWebGpu",
            [GpuProviderMetadataKeys.CanonicalEnvelopeSchema] = "aikernel.gpu.dispatch"
        };

        var result = GpuCanonicalValidation.ValidateBrowserBridgeMetadata(metadata);

        Assert.False(result.IsValid);
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_BROWSER_PASS_READINESS_SHAPE_INVALID" &&
                issue.Message.Contains("SpatialReasoning", StringComparison.Ordinal));
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_BROWSER_PASS_READINESS_SHAPE_INVALID" &&
                issue.Message.Contains("ReadyForBuiltIn", StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateExecutionLayerMetadata_AllowsCanonicalWebGpuExecutionMetadata()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.PassBridge] = "optional-native-or-js",
            [GpuProviderMetadataKeys.RawCaptureSource] = "raw-framebuffer",
            [GpuProviderMetadataKeys.GpuBypass] = "raw-texture-binding",
            [GpuProviderMetadataKeys.NativeJsBridge] = "canonical-envelope-bridge",
            [GpuProviderMetadataKeys.AotCompilerHooks] = "planned-gpu-native-execution",
            [GpuProviderMetadataKeys.DeterministicFrameSampling] = "frame-token-index-sample-ticks",
            [GpuProviderMetadataKeys.ZeroCopyBufferHandling] = "raw-framebuffer-texture"
        };

        var result = GpuCanonicalValidation.ValidateExecutionLayerMetadata(metadata);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateExecutionLayerMetadata_RejectsMissingZeroCopyBufferHandling()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.PassBridge] = "optional-native-or-js",
            [GpuProviderMetadataKeys.RawCaptureSource] = "raw-framebuffer",
            [GpuProviderMetadataKeys.GpuBypass] = "raw-texture-binding",
            [GpuProviderMetadataKeys.NativeJsBridge] = "canonical-envelope-bridge",
            [GpuProviderMetadataKeys.AotCompilerHooks] = "planned-gpu-native-execution",
            [GpuProviderMetadataKeys.DeterministicFrameSampling] = "frame-token-index-sample-ticks"
        };

        var result = GpuCanonicalValidation.ValidateExecutionLayerMetadata(metadata);

        Assert.False(result.IsValid);
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_EXECUTION_LAYER_METADATA_MISSING" &&
                issue.Path == $"canonicalExecutionLayer.{GpuProviderMetadataKeys.ZeroCopyBufferHandling}");
    }

    [Fact]
    public void GpuOperationAndPermissionNames_ExposeCanonicalWebGpuBoundary()
    {
        Assert.Equal("compute.dispatch", GpuOperationNames.ComputeDispatch);
        Assert.Equal("compute.vector_add", GpuOperationNames.ComputeVectorAdd);
        Assert.Equal("gpu.hud.composite", GpuOperationNames.GpuHudComposite);
        Assert.Equal("gpu.aisthesis.raw-frame", GpuOperationNames.GpuAisthesisRawFrame);
        Assert.Equal("gpu.spatial-reasoning", GpuOperationNames.GpuSpatialReasoning);
        Assert.Equal("gpu.zero-copy.raw-texture", GpuOperationNames.GpuZeroCopyRawTexture);
        Assert.Equal("webgpu_dispatch", GpuOperationNames.WebGpuDispatchEntryPoint);
        Assert.Equal(
            [
                GpuOperationNames.ComputeDispatch,
                GpuOperationNames.ComputeVectorAdd,
                GpuOperationNames.GpuHudComposite,
                GpuOperationNames.GpuAisthesisRawFrame,
                GpuOperationNames.GpuSpatialReasoning,
                GpuOperationNames.GpuZeroCopyRawTexture
            ],
            GpuOperationNames.WebGpuComputeProviderOperations);

        Assert.Equal("compute.execute", GpuPermissionNames.ComputeExecute);
        Assert.Equal("buffer.read", GpuPermissionNames.BufferRead);
        Assert.Equal("buffer.write", GpuPermissionNames.BufferWrite);
        Assert.Equal("texture.bind", GpuPermissionNames.TextureBind);
        Assert.Equal("texture.write", GpuPermissionNames.TextureWrite);
        Assert.Equal(
            [
                GpuPermissionNames.ComputeExecute,
                GpuPermissionNames.BufferRead,
                GpuPermissionNames.BufferWrite,
                GpuPermissionNames.TextureBind,
                GpuPermissionNames.TextureWrite
            ],
            GpuPermissionNames.WebGpuComputeRequiredPermissions);
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsBlankMetadataKey()
    {
        var diagnostics = new GpuFrameDiagnostics
        {
            SensorPath = new GpuDiagnosticsPathInfo
            {
                Backend = "webgpu",
                ZeroCopy = true,
                Readback = GpuReadbackPolicy.None,
                Metadata = new Dictionary<string, string>(StringComparer.Ordinal)
                {
                    [" "] = "invalid"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, static issue => issue.Code == "GPU_DIAGNOSTICS_METADATA_KEY_EMPTY");
    }

    [Fact]
    public void GpuProviderOptions_ExposeNativeValidationSwitch()
    {
        var defaults = new GpuProviderOptions();
        var enabled = defaults with { EnableNativeValidation = true };

        Assert.False(defaults.EnableNativeValidation);
        Assert.True(enabled.EnableNativeValidation);
    }

    [Fact]
    public void GpuDiagnosticsBoundary_CapturesFrameDiagnostics()
    {
        var method = typeof(IGpuDiagnostics).GetMethod(nameof(IGpuDiagnostics.CaptureFrameDiagnosticsAsync));

        Assert.NotNull(method);
        Assert.Equal(typeof(ValueTask<GpuFrameDiagnostics>), method.ReturnType);
    }

    [Fact]
    public void GpuHudLabel_CarriesLightweightTextPlacementMetadata()
    {
        var label = new GpuHudLabel
        {
            Id = "priority",
            Text = "PRIORITY",
            X = 0.12f,
            Y = 0.34f,
            AnchorRect = [0.1f, 0.2f, 0.3f, 0.4f],
            Layer = 2,
            Tone = "logos",
            Source = "gpu-hud",
            Key = "kairos.priority"
        };

        Assert.Equal(1U, label.Version);
        Assert.Equal([0.1f, 0.2f, 0.3f, 0.4f], label.AnchorRect);
        Assert.Equal(2, label.Layer);
        Assert.Equal("logos", label.Tone);
        Assert.Equal("gpu-hud", label.Source);
        Assert.Equal("kairos.priority", label.Key);
    }

    [Fact]
    public void GpuNativeAbiMetadataKeys_ExposeProviderProbeBoundary()
    {
        Assert.Equal("dawn.native.abi.available", GpuNativeAbiMetadataKeys.DawnNativeAbiAvailable);
        Assert.Equal("dawn.native.abi.reason", GpuNativeAbiMetadataKeys.DawnNativeAbiReason);
        Assert.Equal("dawn.native.abi.source", GpuNativeAbiMetadataKeys.DawnNativeAbiSource);
        Assert.Equal("dawn.native.entry_point", GpuNativeAbiMetadataKeys.DawnNativeEntryPoint);
        Assert.Equal("dawn.native.init_entry_point", GpuNativeAbiMetadataKeys.DawnNativeInitializationEntryPoint);
        Assert.Equal("dawn.native.dispatch_entry_point", GpuNativeAbiMetadataKeys.DawnNativeDispatchEntryPoint);
        Assert.Equal("dawn.native.env", GpuNativeAbiMetadataKeys.DawnNativeEnvironmentVariable);
        Assert.Equal("dawn.native.validation", GpuNativeAbiMetadataKeys.DawnNativeValidation);
        Assert.Equal("dawn.native.path.configured", GpuNativeAbiMetadataKeys.DawnNativePathConfigured);
        Assert.Equal("cuda.native.abi.available", GpuNativeAbiMetadataKeys.CudaNativeAbiAvailable);
        Assert.Equal("cuda.native.abi.reason", GpuNativeAbiMetadataKeys.CudaNativeAbiReason);
        Assert.Equal("cuda.native.bridge.available", GpuNativeAbiMetadataKeys.CudaNativeBridgeAvailable);
        Assert.Equal("cuda.native.bridge.library", GpuNativeAbiMetadataKeys.CudaNativeBridgeLibrary);
        Assert.Equal("cuda.native.bridge.path", GpuNativeAbiMetadataKeys.CudaNativeBridgePath);
        Assert.Equal("cuda.native.loader.configured", GpuNativeAbiMetadataKeys.CudaNativeLoaderConfigured);
        Assert.Equal("cuda.native.loader.env", GpuNativeAbiMetadataKeys.CudaNativeLoaderEnvironmentVariable);
        Assert.Equal("cuda.native.loader.path", GpuNativeAbiMetadataKeys.CudaNativeLoaderPath);
        Assert.Equal("cuda.native.validation", GpuNativeAbiMetadataKeys.CudaNativeValidation);
        Assert.Equal("cuda.libtorch.path.configured", GpuNativeAbiMetadataKeys.CudaLibTorchPathConfigured);
        Assert.Equal("cuda.libtorch.path.available", GpuNativeAbiMetadataKeys.CudaLibTorchPathAvailable);
        Assert.Equal("cuda.libtorch.path.env", GpuNativeAbiMetadataKeys.CudaLibTorchPathEnvironmentVariable);
        Assert.Equal("cuda.libtorch.path", GpuNativeAbiMetadataKeys.CudaLibTorchPath);
    }

    [Fact]
    public void ValidateNativeAbiProbeMetadata_AllowsCanonicalDawnProbeMetadata()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuNativeAbiMetadataKeys.DawnNativeAbiAvailable] = "false",
            [GpuNativeAbiMetadataKeys.DawnNativeAbiReason] = "path-not-configured",
            [GpuNativeAbiMetadataKeys.DawnNativeEnvironmentVariable] = "AIKERNEL_DAWNCORE_PATH",
            [GpuNativeAbiMetadataKeys.DawnNativeEntryPoint] = "aikernel_dawn_dispatch",
            [GpuNativeAbiMetadataKeys.DawnNativeInitializationEntryPoint] = "InitializeDawnNative",
            [GpuNativeAbiMetadataKeys.DawnNativeDispatchEntryPoint] = "aikernel_dawn_dispatch",
            [GpuNativeAbiMetadataKeys.DawnNativeValidation] = "default",
            [GpuNativeAbiMetadataKeys.DawnNativePathConfigured] = "false"
        };

        var result = GpuCanonicalValidation.ValidateNativeAbiProbeMetadata(GpuBackend.Dawn, metadata);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateNativeAbiProbeMetadata_RejectsMissingCudaRequiredProbeKey()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuNativeAbiMetadataKeys.CudaNativeAbiAvailable] = "false",
            [GpuNativeAbiMetadataKeys.CudaNativeAbiReason] = "native-bridge-not-configured",
            [GpuNativeAbiMetadataKeys.CudaNativeBridgeAvailable] = "false",
            [GpuNativeAbiMetadataKeys.CudaLibTorchPathAvailable] = "false"
        };

        var result = GpuCanonicalValidation.ValidateNativeAbiProbeMetadata(GpuBackend.Cuda, metadata);

        Assert.False(result.IsValid);
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_NATIVE_ABI_METADATA_MISSING" &&
                issue.Path == $"nativeAbi.{GpuBackend.Cuda}.{GpuNativeAbiMetadataKeys.CudaNativeValidation}");
    }

    [Fact]
    public void ValidateNativeAbiProbeMetadata_RejectsInvalidBooleanProbeValue()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuNativeAbiMetadataKeys.DawnNativeAbiAvailable] = "maybe",
            [GpuNativeAbiMetadataKeys.DawnNativeAbiReason] = "path-not-configured",
            [GpuNativeAbiMetadataKeys.DawnNativeEnvironmentVariable] = "AIKERNEL_DAWNCORE_PATH",
            [GpuNativeAbiMetadataKeys.DawnNativeEntryPoint] = "aikernel_dawn_dispatch",
            [GpuNativeAbiMetadataKeys.DawnNativeInitializationEntryPoint] = "InitializeDawnNative",
            [GpuNativeAbiMetadataKeys.DawnNativeDispatchEntryPoint] = "aikernel_dawn_dispatch",
            [GpuNativeAbiMetadataKeys.DawnNativeValidation] = "default"
        };

        var result = GpuCanonicalValidation.ValidateNativeAbiProbeMetadata(GpuBackend.Dawn, metadata);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, static issue => issue.Code == "GPU_NATIVE_ABI_METADATA_BOOLEAN_INVALID");
    }

    private static GpuFrameToken FrameToken()
        => new()
        {
            FrameId = "frame-1",
            RawTarget = RawTarget("raw")
        };

    private static GpuFrameTarget RawTarget(string id)
        => new()
        {
            TargetId = id,
            Kind = GpuFrameTargetKind.RawFramebuffer,
            Backend = GpuBackend.WebGpu,
            Width = 320,
            Height = 200,
            ZeroCopy = true
        };

    private static SortedDictionary<string, string> ReadinessMetadata(
        bool authoritativeReady,
        bool diagnosticReady,
        int candidateStreak,
        int diagnosticStreak,
        int requiredStreak,
        string gate)
        => new(StringComparer.Ordinal)
        {
            [GpuDiagnosticsMetadataKeys.CanonicalAuthoritativeReady] = authoritativeReady.ToString().ToLowerInvariant(),
            [GpuDiagnosticsMetadataKeys.CanonicalCandidateStreak] = candidateStreak.ToString(),
            [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticReady] = diagnosticReady.ToString().ToLowerInvariant(),
            [GpuDiagnosticsMetadataKeys.CanonicalDiagnosticStreak] = diagnosticStreak.ToString(),
            [GpuDiagnosticsMetadataKeys.CanonicalExecutionMode] = GpuExecutionModes.BrowserWebGpuCompute,
            [GpuDiagnosticsMetadataKeys.CanonicalFeatureMaskStorageTexture] = "true",
            [GpuDiagnosticsMetadataKeys.CanonicalFrameIndex] = "1",
            [GpuDiagnosticsMetadataKeys.CanonicalPassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
            [GpuDiagnosticsMetadataKeys.CanonicalPassId] = GpuOperationNames.GpuAisthesisRawFrame,
            [GpuDiagnosticsMetadataKeys.CanonicalPathRole] = "sensor",
            [GpuDiagnosticsMetadataKeys.CanonicalPilotState] = GpuCanonicalPilotStates.Within,
            [GpuDiagnosticsMetadataKeys.CanonicalPromotionGate] = gate,
            [GpuDiagnosticsMetadataKeys.CanonicalRequiredStreak] = requiredStreak.ToString(),
            [GpuDiagnosticsMetadataKeys.CanonicalSampleTicks] = "100"
        };

    private static IReadOnlyList<float> FilledMatrix()
        => Enumerable.Repeat(0.0f, GpuCanonicalLayouts.AisMatrix.Stride).ToArray();
}
