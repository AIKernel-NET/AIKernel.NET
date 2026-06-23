using AIKernel.Abstractions.Gpu;
using AIKernel.Dtos.Gpu;

namespace AIKernel.Abstractions.Tests;

public sealed class GpuCanonicalContractTests
{
    [Fact]
    public void GpuCanonicalLayouts_MatchRev3Shapes()
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
    public void GpuRev3PathRoles_ResolveCanonicalRolesFromPassIds()
    {
        Assert.True(GpuRev3PathRoles.TryResolveFromPassId(GpuOperationNames.GpuAisthesisRawFrame, out var aisthesisRole));
        Assert.Equal(GpuRev3PathRoles.Sensor, aisthesisRole);
        Assert.True(GpuRev3PathRoles.TryResolveFromPassId(GpuOperationNames.GpuSpatialReasoning, out var spatialRole));
        Assert.Equal(GpuRev3PathRoles.Sensor, spatialRole);
        Assert.True(GpuRev3PathRoles.TryResolveFromPassId(GpuOperationNames.GpuHudComposite, out var hudRole));
        Assert.Equal(GpuRev3PathRoles.Hud, hudRole);
        Assert.True(GpuRev3PathRoles.TryResolveFromPassId("bonsai.model", out var bonsaiRole));
        Assert.Equal(GpuRev3PathRoles.Bonsai, bonsaiRole);
        Assert.True(GpuRev3PathRoles.TryResolveFromPassId("game.render", out var gameRole));
        Assert.Equal(GpuRev3PathRoles.Game, gameRole);
        Assert.False(GpuRev3PathRoles.TryResolveFromPassId("unknown", out _));
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
    public void ValidateFrameDiagnostics_AllowsRev3PilotReadinessMetadata()
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
                    [GpuDiagnosticsMetadataKeys.Rev3AuthoritativeReady] = "false",
                    [GpuDiagnosticsMetadataKeys.Rev3CandidateStreak] = "3",
                    [GpuDiagnosticsMetadataKeys.Rev3DiagnosticReady] = "true",
                    [GpuDiagnosticsMetadataKeys.Rev3DiagnosticStreak] = "3",
                    [GpuDiagnosticsMetadataKeys.Rev3ExecutionMode] = GpuRev3ExecutionModes.BrowserWebGpuCompute,
                    [GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture] = "true",
                    [GpuDiagnosticsMetadataKeys.Rev3FrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.Rev3PassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
                    [GpuDiagnosticsMetadataKeys.Rev3PassId] = GpuOperationNames.GpuAisthesisRawFrame,
                    [GpuDiagnosticsMetadataKeys.Rev3PathRole] = "sensor",
                    [GpuDiagnosticsMetadataKeys.Rev3PilotState] = GpuRev3PilotStates.Within,
                    [GpuDiagnosticsMetadataKeys.Rev3PromotionGate] = GpuRev3PromotionGates.TraceCandidate,
                    [GpuDiagnosticsMetadataKeys.Rev3RequiredStreak] = "8",
                    [GpuDiagnosticsMetadataKeys.Rev3SampleTicks] = "100"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.True(result.IsValid);
        Assert.Equal(
            GpuRev3PromotionGates.TraceCandidate,
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.Rev3PromotionGate]);
        Assert.Equal(
            "true",
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture]);
        Assert.Equal(
            GpuRev3ExecutionModes.BrowserWebGpuCompute,
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.Rev3ExecutionMode]);
        Assert.Equal(
            "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
            diagnostics.SensorPath.Metadata[GpuDiagnosticsMetadataKeys.Rev3PassReadiness]);
    }

    [Fact]
    public void EvaluateRev3PromotionReadiness_RequiresAuthoritativeReadyAndStableStreaks()
    {
        var metadata = Rev3ReadinessMetadata(
            authoritativeReady: true,
            diagnosticReady: true,
            candidateStreak: 8,
            diagnosticStreak: 8,
            requiredStreak: 8,
            gate: GpuRev3PromotionGates.TraceCandidate);

        var readiness = GpuCanonicalValidation.EvaluateRev3PromotionReadiness(metadata);

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
    public void EvaluateRev3PromotionReadiness_KeepsPilotDiagnosticUntilStreaksAndAuthoritativeReady()
    {
        var metadata = Rev3ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: true,
            candidateStreak: 3,
            diagnosticStreak: 3,
            requiredStreak: 8,
            gate: GpuRev3PromotionGates.TraceCandidate);

        var readiness = GpuCanonicalValidation.EvaluateRev3PromotionReadiness(metadata);

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
    [InlineData(GpuRev3PromotionGates.Fallback)]
    [InlineData(GpuRev3PromotionGates.NativeBridgeRequired)]
    public void EvaluateRev3PromotionReadiness_BlocksFallbackAndNativeBridgeGates(string gate)
    {
        var metadata = Rev3ReadinessMetadata(
            authoritativeReady: true,
            diagnosticReady: true,
            candidateStreak: 8,
            diagnosticStreak: 8,
            requiredStreak: 8,
            gate: gate);

        var readiness = GpuCanonicalValidation.EvaluateRev3PromotionReadiness(metadata);

        Assert.False(readiness.IsAuthoritativeReady);
        Assert.False(readiness.IsPromotionCandidate);
        Assert.True(readiness.IsBlocked);
        Assert.Equal(gate, readiness.Reason);
    }

    [Fact]
    public void EvaluateRev3PromotionReadiness_AllowsNotEvaluatedGateWithoutRequiredStreak()
    {
        var metadata = Rev3ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: false,
            candidateStreak: 0,
            diagnosticStreak: 0,
            requiredStreak: 0,
            gate: GpuRev3PromotionGates.NotEvaluated);

        var readiness = GpuCanonicalValidation.EvaluateRev3PromotionReadiness(metadata);

        Assert.False(readiness.IsAuthoritativeReady);
        Assert.False(readiness.IsPromotionCandidate);
        Assert.True(readiness.IsBlocked);
        Assert.Equal(GpuRev3PromotionGates.NotEvaluated, readiness.Gate);
        Assert.Equal(GpuRev3PromotionGates.NotEvaluated, readiness.Reason);
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsPartialRev3FrameTokenMetadata()
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
                    [GpuDiagnosticsMetadataKeys.Rev3FrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.Rev3PassId] = GpuOperationNames.GpuAisthesisRawFrame
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_MISSING" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.Rev3SampleTicks, StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsInvalidRev3PromotionGateMetadataShape()
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
                    [GpuDiagnosticsMetadataKeys.Rev3AuthoritativeReady] = "maybe",
                    [GpuDiagnosticsMetadataKeys.Rev3CandidateStreak] = "-1",
                    [GpuDiagnosticsMetadataKeys.Rev3DiagnosticReady] = "true",
                    [GpuDiagnosticsMetadataKeys.Rev3DiagnosticStreak] = "not-a-number",
                    [GpuDiagnosticsMetadataKeys.Rev3ExecutionMode] = GpuRev3ExecutionModes.BrowserWebGpuCompute,
                    [GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture] = "false",
                    [GpuDiagnosticsMetadataKeys.Rev3FrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.Rev3PassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
                    [GpuDiagnosticsMetadataKeys.Rev3PassId] = GpuOperationNames.GpuAisthesisRawFrame,
                    [GpuDiagnosticsMetadataKeys.Rev3PathRole] = "sensor",
                    [GpuDiagnosticsMetadataKeys.Rev3PilotState] = GpuRev3PilotStates.BrowserBuiltinCompute,
                    [GpuDiagnosticsMetadataKeys.Rev3PromotionGate] = GpuRev3PromotionGates.TraceCandidate,
                    [GpuDiagnosticsMetadataKeys.Rev3RequiredStreak] = "8",
                    [GpuDiagnosticsMetadataKeys.Rev3SampleTicks] = "100"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue => issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_BOOLEAN_INVALID");
        Assert.Contains(result.Errors, issue => issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_INTEGER_INVALID");
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsUnknownRev3DiagnosticsStateValues()
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
                    [GpuDiagnosticsMetadataKeys.Rev3AuthoritativeReady] = "false",
                    [GpuDiagnosticsMetadataKeys.Rev3CandidateStreak] = "1",
                    [GpuDiagnosticsMetadataKeys.Rev3DiagnosticReady] = "true",
                    [GpuDiagnosticsMetadataKeys.Rev3DiagnosticStreak] = "1",
                    [GpuDiagnosticsMetadataKeys.Rev3ExecutionMode] = "browser-webgpu-comptue",
                    [GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture] = "false",
                    [GpuDiagnosticsMetadataKeys.Rev3FrameIndex] = "1",
                    [GpuDiagnosticsMetadataKeys.Rev3PassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
                    [GpuDiagnosticsMetadataKeys.Rev3PassId] = GpuOperationNames.GpuAisthesisRawFrame,
                    [GpuDiagnosticsMetadataKeys.Rev3PathRole] = "senser",
                    [GpuDiagnosticsMetadataKeys.Rev3PilotState] = "trace-readyish",
                    [GpuDiagnosticsMetadataKeys.Rev3PromotionGate] = "trace-candidte",
                    [GpuDiagnosticsMetadataKeys.Rev3RequiredStreak] = "3",
                    [GpuDiagnosticsMetadataKeys.Rev3SampleTicks] = "100"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.Rev3ExecutionMode, StringComparison.Ordinal));
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.Rev3PathRole, StringComparison.Ordinal));
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.Rev3PilotState, StringComparison.Ordinal));
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_VALUE_UNKNOWN" &&
            issue.Path is not null &&
            issue.Path.EndsWith(GpuDiagnosticsMetadataKeys.Rev3PromotionGate, StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateFrameDiagnostics_RejectsIncompleteRev3PassReadinessMetadata()
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
                    [GpuDiagnosticsMetadataKeys.Rev3PassReadiness] = "Passes.{Aisthesis,HudComposite}:ShaderBound,PipelineCached"
                }
            }
        };

        var result = GpuCanonicalValidation.ValidateFrameDiagnostics(diagnostics);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_PASS_READINESS_SHAPE_INVALID" &&
            issue.Message.Contains("ReadyForBuiltIn", StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateRev3DiagnosticsMetadata_ValidatesSingleBridgeMetadataDictionary()
    {
        var metadata = Rev3ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: true,
            candidateStreak: 1,
            diagnosticStreak: 1,
            requiredStreak: 1,
            gate: GpuRev3PromotionGates.TraceCandidate);

        var result = GpuCanonicalValidation.ValidateRev3DiagnosticsMetadata(metadata, "envelope");

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateRev3DiagnosticsMetadata_RejectsMalformedSingleBridgeMetadataDictionary()
    {
        var metadata = Rev3ReadinessMetadata(
            authoritativeReady: false,
            diagnosticReady: true,
            candidateStreak: 1,
            diagnosticStreak: 1,
            requiredStreak: 1,
            gate: GpuRev3PromotionGates.TraceCandidate);
        metadata[GpuDiagnosticsMetadataKeys.Rev3PilotState] = "browser-comptue";
        metadata[GpuDiagnosticsMetadataKeys.Rev3PassReadiness] = "Passes.{Aisthesis}:ShaderBound=true";

        var result = GpuCanonicalValidation.ValidateRev3DiagnosticsMetadata(metadata, "envelope");

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_METADATA_VALUE_UNKNOWN" &&
            issue.Path == $"envelope.metadata.{GpuDiagnosticsMetadataKeys.Rev3PilotState}");
        Assert.Contains(result.Errors, issue =>
            issue.Code == "GPU_DIAGNOSTICS_REV3_PASS_READINESS_SHAPE_INVALID" &&
            issue.Path == $"envelope.metadata.{GpuDiagnosticsMetadataKeys.Rev3PassReadiness}");
    }

    [Fact]
    public void GpuProviderMetadataKeys_ExposeRev3ManifestAndEnvelopeBoundary()
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
        Assert.Equal("rev3", GpuProviderMetadataKeys.Rev3);
        Assert.Equal("version", GpuProviderMetadataKeys.Version);
        Assert.Equal("rev3_browser_pass_readiness", GpuProviderMetadataKeys.Rev3BrowserPassReadiness);
        Assert.Equal("rev3_envelope_bridge", GpuProviderMetadataKeys.Rev3EnvelopeBridge);
        Assert.Equal("rev3_envelope_bridge_executor_factory", GpuProviderMetadataKeys.Rev3EnvelopeBridgeExecutorFactory);
        Assert.Equal("rev3_envelope_bridge_factory", GpuProviderMetadataKeys.Rev3EnvelopeBridgeFactory);
        Assert.Equal("rev3_envelope_bridge_global", GpuProviderMetadataKeys.Rev3EnvelopeBridgeGlobal);
        Assert.Equal("rev3_envelope_schema", GpuProviderMetadataKeys.Rev3EnvelopeSchema);
    }

    [Fact]
    public void GpuDiagnosticsMetadataKeys_ExposeDeterministicFrameSamplingBoundary()
    {
        Assert.Equal("rev3_frame_index", GpuDiagnosticsMetadataKeys.Rev3FrameIndex);
        Assert.Equal("rev3_sample_ticks", GpuDiagnosticsMetadataKeys.Rev3SampleTicks);
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
            [GpuDiagnosticsMetadataKeys.Rev3PassId] = GpuOperationNames.GpuHudComposite,
            [GpuDiagnosticsMetadataKeys.Rev3ExecutionMode] = "control-gpu-approved",
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
            [GpuDiagnosticsMetadataKeys.Rev3PassId] = GpuOperationNames.GpuHudComposite,
            [GpuDiagnosticsMetadataKeys.Rev3ExecutionMode] = "control-gpu-approved",
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
    public void ValidateRev3BrowserBridgeMetadata_AllowsCanonicalWasmBridgeMetadata()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.Rev3BrowserPassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound,PipelineCached,BuiltInExecutor,InjectedExecutor,ReadyForBuiltIn",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridge] = "runtime/browser/webgpu-rev3-envelope-bridge.js",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridgeExecutorFactory] = "createWebGpuRev3BrowserExecutor",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridgeFactory] = "createWebGpuRev3EnvelopeBridge",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridgeGlobal] = "AIKernelWebGpuRev3",
            [GpuProviderMetadataKeys.Rev3EnvelopeSchema] = "aikernel.gpu.rev3.dispatch"
        };

        var result = GpuCanonicalValidation.ValidateRev3BrowserBridgeMetadata(metadata);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateRev3BrowserBridgeMetadata_RejectsMissingPassReadinessToken()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.Rev3BrowserPassReadiness] = "Passes.{Aisthesis,HudComposite}:ShaderBound,PipelineCached,BuiltInExecutor,InjectedExecutor",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridge] = "runtime/browser/webgpu-rev3-envelope-bridge.js",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridgeExecutorFactory] = "createWebGpuRev3BrowserExecutor",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridgeFactory] = "createWebGpuRev3EnvelopeBridge",
            [GpuProviderMetadataKeys.Rev3EnvelopeBridgeGlobal] = "AIKernelWebGpuRev3",
            [GpuProviderMetadataKeys.Rev3EnvelopeSchema] = "aikernel.gpu.rev3.dispatch"
        };

        var result = GpuCanonicalValidation.ValidateRev3BrowserBridgeMetadata(metadata);

        Assert.False(result.IsValid);
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_REV3_BROWSER_PASS_READINESS_SHAPE_INVALID" &&
                issue.Message.Contains("SpatialReasoning", StringComparison.Ordinal));
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_REV3_BROWSER_PASS_READINESS_SHAPE_INVALID" &&
                issue.Message.Contains("ReadyForBuiltIn", StringComparison.Ordinal));
    }

    [Fact]
    public void ValidateRev3ExecutionLayerMetadata_AllowsCanonicalWebGpuExecutionMetadata()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.PassBridge] = "optional-native-or-js",
            [GpuProviderMetadataKeys.RawCaptureSource] = "raw-framebuffer",
            [GpuProviderMetadataKeys.GpuBypass] = "raw-texture-binding",
            [GpuProviderMetadataKeys.NativeJsBridge] = "rev3-envelope-bridge",
            [GpuProviderMetadataKeys.AotCompilerHooks] = "planned-gpu-native-execution",
            [GpuProviderMetadataKeys.DeterministicFrameSampling] = "frame-token-index-sample-ticks",
            [GpuProviderMetadataKeys.ZeroCopyBufferHandling] = "raw-framebuffer-texture"
        };

        var result = GpuCanonicalValidation.ValidateRev3ExecutionLayerMetadata(metadata);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateRev3ExecutionLayerMetadata_RejectsMissingZeroCopyBufferHandling()
    {
        var metadata = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            [GpuProviderMetadataKeys.PassBridge] = "optional-native-or-js",
            [GpuProviderMetadataKeys.RawCaptureSource] = "raw-framebuffer",
            [GpuProviderMetadataKeys.GpuBypass] = "raw-texture-binding",
            [GpuProviderMetadataKeys.NativeJsBridge] = "rev3-envelope-bridge",
            [GpuProviderMetadataKeys.AotCompilerHooks] = "planned-gpu-native-execution",
            [GpuProviderMetadataKeys.DeterministicFrameSampling] = "frame-token-index-sample-ticks"
        };

        var result = GpuCanonicalValidation.ValidateRev3ExecutionLayerMetadata(metadata);

        Assert.False(result.IsValid);
        Assert.Contains(
            result.Errors,
            static issue =>
                issue.Code == "GPU_REV3_EXECUTION_LAYER_METADATA_MISSING" &&
                issue.Path == $"rev3ExecutionLayer.{GpuProviderMetadataKeys.ZeroCopyBufferHandling}");
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

    private static SortedDictionary<string, string> Rev3ReadinessMetadata(
        bool authoritativeReady,
        bool diagnosticReady,
        int candidateStreak,
        int diagnosticStreak,
        int requiredStreak,
        string gate)
        => new(StringComparer.Ordinal)
        {
            [GpuDiagnosticsMetadataKeys.Rev3AuthoritativeReady] = authoritativeReady.ToString().ToLowerInvariant(),
            [GpuDiagnosticsMetadataKeys.Rev3CandidateStreak] = candidateStreak.ToString(),
            [GpuDiagnosticsMetadataKeys.Rev3DiagnosticReady] = diagnosticReady.ToString().ToLowerInvariant(),
            [GpuDiagnosticsMetadataKeys.Rev3DiagnosticStreak] = diagnosticStreak.ToString(),
            [GpuDiagnosticsMetadataKeys.Rev3ExecutionMode] = GpuRev3ExecutionModes.BrowserWebGpuCompute,
            [GpuDiagnosticsMetadataKeys.Rev3FeatureMaskStorageTexture] = "true",
            [GpuDiagnosticsMetadataKeys.Rev3FrameIndex] = "1",
            [GpuDiagnosticsMetadataKeys.Rev3PassReadiness] = "Passes.{Aisthesis,SpatialReasoning,HudComposite}:ShaderBound=true,PipelineCached=true,BuiltInExecutor=true,InjectedExecutor=false,ReadyForBuiltIn=true",
            [GpuDiagnosticsMetadataKeys.Rev3PassId] = GpuOperationNames.GpuAisthesisRawFrame,
            [GpuDiagnosticsMetadataKeys.Rev3PathRole] = "sensor",
            [GpuDiagnosticsMetadataKeys.Rev3PilotState] = GpuRev3PilotStates.Within,
            [GpuDiagnosticsMetadataKeys.Rev3PromotionGate] = gate,
            [GpuDiagnosticsMetadataKeys.Rev3RequiredStreak] = requiredStreak.ToString(),
            [GpuDiagnosticsMetadataKeys.Rev3SampleTicks] = "100"
        };

    private static IReadOnlyList<float> FilledMatrix()
        => Enumerable.Repeat(0.0f, GpuCanonicalLayouts.AisMatrix.Stride).ToArray();
}
