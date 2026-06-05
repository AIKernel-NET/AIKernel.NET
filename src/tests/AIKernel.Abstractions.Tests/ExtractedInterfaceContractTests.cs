using AIKernel.Abstractions.DynamicSlm;
using AIKernel.Abstractions.Dsl;
using AIKernel.Abstractions.Hatl;
using AIKernel.Abstractions.History;
using AIKernel.Abstractions.Time;
using AIKernel.Contracts;
using AIKernel.Dtos.Context;
using AIKernel.Dtos.Core;
using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Dsl;
using AIKernel.Dtos.Governance;
using AIKernel.Dtos.Hatl;
using AIKernel.Dtos.History;
using AIKernel.Dtos.SemanticCompilation;
using AIKernel.Dtos.Time;
using AIKernel.Enums;

namespace AIKernel.Abstractions.Tests;

public sealed class ExtractedInterfaceContractTests
{
    [Fact]
    public void ContractDtosDoNotInjectRuntimeTimestamps()
    {
        var purpose = new Purpose
        {
            PurposeId = "purpose-1",
            Description = "demo"
        };

        var fragment = new ContextFragment();
        var expression = new ExpressionContextDto();
        var material = new MaterialContextDto
        {
            Source = "source",
            RawData = "raw"
        };
        var orchestration = new OrchestrationContextDto
        {
            Purpose = "purpose",
            Structure = "structure"
        };
        var unified = new UnifiedContextDto
        {
            Id = "context-1",
            Orchestration = orchestration
        };

        Assert.Equal(default, purpose.CreatedAt);
        Assert.Equal(default, fragment.CreatedAt);
        Assert.Equal(default, expression.CreatedAt);
        Assert.Equal(default, material.RetrievedAt);
        Assert.Equal(default, orchestration.CreatedAt);
        Assert.Equal(default, unified.CreatedAt);
    }

    [Fact]
    public void DslContractsAreOwnedByAbstractions()
    {
        Assert.True(typeof(IKernelPipeline).IsInterface);
        Assert.True(typeof(IDslPipelineCompiler).IsInterface);
        Assert.True(typeof(IDslCapabilityRegistry).IsInterface);
        Assert.True(typeof(IDslRomRegistry).IsInterface);
        Assert.True(typeof(IDslRomStore).IsInterface);

        Assert.Equal("Pipeline", new PipelineRootNode([]).Type);
        Assert.Equal("CallCapability", new CallCapabilityNode("demo", new Dictionary<string, string>()).Type);
        Assert.Equal("CallCapability", DslNodeTypes.CallCapability);
        Assert.Equal("CapabilityCall", DslNodeTypes.CapabilityCallAlias);
        Assert.Equal("Suspend", DslNodeTypes.Suspend);
        Assert.Equal("SuspendForApproval", DslNodeTypes.SuspendForApprovalAlias);
        Assert.Equal("dsl_rom_hash", DslRomMetadataKeys.RomHash);
    }

    [Fact]
    public void AdmissibilityAndSemanticIrVocabulariesAreSharedContracts()
    {
        var record = new AdmissibilityReplayRecord(
            "admission-1",
            "step-1",
            null,
            AdmissibilityGateKind.CapabilityAdmission,
            SemanticIrSlot.G,
            AdmissibilityDecisionKind.Admit,
            "capability admitted",
            "evidence-hash",
            "replay-hash",
            new Dictionary<string, string> { ["capability"] = "Observe" });

        Assert.Equal(SemanticIrSlot.G, record.Slot);
        Assert.Equal(AdmissibilityGateKind.CapabilityAdmission, record.GateKind);
        Assert.Equal(AdmissibilityDecisionKind.Admit, record.Decision);
        Assert.Equal(8, (int)AdmissibilityDecisionKind.Transform);
        Assert.Equal(9, (int)AdmissibilityDecisionKind.Decompose);
        Assert.True(typeof(SemanticIrSlot).IsEnum);
        Assert.True(typeof(AdmissibilityGateKind).IsEnum);
        Assert.True(typeof(AdmissibilityDecisionKind).IsEnum);
    }

    [Fact]
    public void SemanticCompilationDtosAreContractOnly()
    {
        var state = new SemanticStateSnapshot(
            "state-1",
            [0.1, 0.2],
            [0.01, 0.02],
            "embedding-model",
            "state-hash",
            new Dictionary<string, string>());

        var ir = new SemanticIrElement(
            "ir-1",
            "G:graph",
            "T:transition",
            "C:constraints",
            "B:invariants",
            state.StateId,
            new Dictionary<string, string>());

        var circuit = new GovernedCircuitDescriptor(
            "circuit-1",
            ir,
            "runtime-policy-1",
            ["capability.read"],
            ["fail_closed"],
            "prototype-space-1",
            new Dictionary<string, string>());

        var transition = new SemanticTransitionDescriptor(
            "transition-1",
            ir.IrId,
            "ir-2",
            state.StateId,
            "state-2",
            circuit.CircuitId,
            AdmissibilityDecisionKind.Admit,
            "replay-hash",
            new Dictionary<string, string>());

        var prototypeSpace = new PrototypeSpaceDescriptor(
            "prototype-space-1",
            [circuit],
            "v1",
            "prototype-space-hash",
            new Dictionary<string, string>());

        var distance = new SemanticDistanceReport(
            "distance-1",
            ir.IrId,
            circuit.CircuitId,
            0.1,
            0.2,
            0.3,
            0.4,
            0.5,
            1.5,
            "profile-1",
            new Dictionary<string, string>());

        var synthesis = new DeterministicSynthesisDescriptor(
            "synthesis-1",
            ir.IrId,
            circuit.CircuitId,
            ["artifact://policy/runtime-policy-1"],
            circuit.RuntimePolicyId,
            "replay-config-hash",
            new Dictionary<string, string>());

        Assert.Equal("ir-1", circuit.Ir.IrId);
        Assert.Equal("state-1", ir.AssociatedSemanticStateId);
        Assert.Equal(AdmissibilityDecisionKind.Admit, transition.AdmissionDecision);
        Assert.Equal(2, state.CenterVector.Count);
        Assert.Equal(circuit.CircuitId, prototypeSpace.Circuits[0].CircuitId);
        Assert.Equal(1.5, distance.CompositeScore);
        Assert.Equal(circuit.RuntimePolicyId, synthesis.RuntimePolicyId);
    }

    [Fact]
    public void DynamicSlmContractsAreOwnedByAbstractions()
    {
        Assert.True(typeof(IDynamicSlmModelAbiProvider).IsInterface);
        Assert.True(typeof(IDynamicSlmModuleRegistry).IsInterface);
        Assert.True(typeof(IDynamicSlmPipelineContextFactory).IsInterface);
        Assert.True(typeof(IDynamicSlmPipelineStep<,>).IsInterface);
        Assert.True(typeof(IDynamicSlmAsyncPipelineStep<,>).IsInterface);
        Assert.True(typeof(IDynamicSlmAsyncPipeline).IsInterface);
        Assert.True(typeof(IDynamicSlmPipelineBuilder).IsInterface);
        Assert.True(typeof(IDynamicSlmFailure).IsInterface);
        Assert.True(typeof(IDynamicSlmCapabilityGraphResolver).IsInterface);
        Assert.True(typeof(IDynamicSlmCompatibilityVerifier).IsInterface);
        Assert.True(typeof(IDynamicSlmLineageVerifier).IsInterface);
        Assert.True(typeof(IDynamicSlmPayloadLoader).IsInterface);
        Assert.True(typeof(IDynamicSlmScheduler).IsInterface);
        Assert.True(typeof(IDynamicSlmCapabilityGapDetector).IsInterface);
        Assert.True(typeof(IDynamicSlmCapabilityGraphEvolutionPlanner).IsInterface);
        Assert.True(typeof(IDynamicSlmDistillationPlanner).IsInterface);
        Assert.True(typeof(IDynamicSlmDistillationJobScheduler).IsInterface);
        Assert.True(typeof(IDynamicSlmBackgroundDistillationService).IsInterface);
        Assert.True(typeof(IDynamicSlmArtifactPublisher).IsInterface);
        Assert.True(typeof(ISeedSlmDisciplineVerifier).IsInterface);
        Assert.True(typeof(IDynamicSlmDelegationPlanner).IsInterface);
        Assert.True(typeof(IDynamicSlmThoughtArtifactSink).IsInterface);
        Assert.True(typeof(IDynamicSlmMemoryPlacementPlanner).IsInterface);

        var payload = new DynamicSlmPayloadDescriptor(
            "payload-1",
            DynamicSlmPayloadKind.LoRaDelta,
            "rom://model/demo/payload-1.bin",
            "sha256",
            1024,
            "int8",
            new Dictionary<string, string>());

        var graph = new DynamicSlmCapabilityGraph(
            [new DynamicSlmCapabilityNode("cap-1", "Plan", "profile-1", [payload.PayloadId], ["planning"])],
            []);

        var abi = new DynamicSlmModelAbi(
            "model-1",
            "0.0.1",
            new DynamicSlmSemanticProfile("profile-1", "planning", ["agent"], ["json"], "schema", ["replay-v1"]),
            graph,
            new DynamicSlmExecutionProfile(1024, 10, null, [DynamicSlmAcceleratorKind.Cpu], "int8", true, true),
            new DynamicSlmLineage("artifact-hash", null, "teacher-1", ["replay-hash"], "training-hash", "sig"),
            [payload],
            null,
            new Dictionary<string, string>());

        Assert.Equal("model-1", abi.ModelId);
        Assert.Equal("dynamicslm_model_abi_hash", DynamicSlmMetadataKeys.ModelAbiHash);
        Assert.Equal("dynamicslm_pipeline_id", DynamicSlmMetadataKeys.PipelineId);
        Assert.Equal(
            DynamicSlmCompatibilityStatus.Compatible,
            new DynamicSlmCompatibilityResult(
                DynamicSlmCompatibilityStatus.Compatible,
                abi.ModelId,
                ["cap-1"],
                null,
                new Dictionary<string, string>()).Status);
        Assert.Equal(
            DynamicSlmGraphUpdateKind.AddCapabilityNode,
            new DynamicSlmCapabilityGraphUpdate(
                DynamicSlmGraphUpdateKind.AddCapabilityNode,
                graph.Nodes[0],
                null,
                null,
                new Dictionary<string, string>()).Kind);

        var metadata = new DynamicSlmPipelineMetadata(
            "pipeline-1",
            "replay-hash",
            "abi-hash",
            "graph-hash",
            "lineage-hash",
            "placement-1",
            new DynamicSlmDistillationJobId("distill-job-1"),
            null,
            null,
            null,
            null,
            null,
            true,
            true,
            new Dictionary<string, string>());

        var distillationRequest = new DynamicSlmDistillationRequest(
            "distill-request-1",
            "cap-1",
            "teacher-1",
            ["replay-hash"],
            new Dictionary<string, string>(),
            new Dictionary<string, string> { [DynamicSlmMetadataKeys.TeacherFallbackUsed] = "true" });

        var distillationPlan = new DynamicSlmDistillationPlan(
            "distill-plan-1",
            distillationRequest,
            [payload],
            new Dictionary<string, string>(),
            new Dictionary<string, string> { [DynamicSlmMetadataKeys.GapDetected] = "true" });

        var distillationJob = new DynamicSlmDistillationJobDescriptor(
            new DynamicSlmDistillationJobId("distill-job-1"),
            distillationPlan,
            DynamicSlmDistillationJobStatus.Pending,
            ["replay-hash"],
            new Dictionary<string, string>());

        var offload = new DynamicSlmPipelineOffloadInfo(
            new DynamicSlmDistillationJobId("distill-job-1"),
            DynamicSlmDistillationJobStatus.Pending,
            "teacher-1",
            "replay-hash",
            new Dictionary<string, string>());

        var context = new DynamicSlmPipelineContext(
            abi,
            null,
            null,
            null,
            [],
            null,
            distillationPlan,
            distillationJob,
            new DynamicSlmFallbackStrategy(
                DynamicSlmFallbackKind.Teacher,
                null,
                "teacher-1",
                "gap_detected",
                new Dictionary<string, string>()),
            null,
            [],
            null,
            null,
            null,
            [],
            metadata,
            [new DynamicSlmPipelineTrace(DynamicSlmPipelineStage.CompatibilityVerification, "step-1", null, "replay-hash", new Dictionary<string, string>())]);

        var result = new DynamicSlmPipelineResult<DynamicSlmPipelineContext>(
            DynamicSlmPipelineStatus.OffloadPending,
            true,
            context,
            null,
            offload,
            context.Trace,
            metadata);

        Assert.True(result.IsSuccess);
        Assert.Equal(DynamicSlmPipelineStatus.OffloadPending, result.Status);
        Assert.Equal(DynamicSlmDistillationJobStatus.Pending, result.Offload?.Status);
        Assert.Equal(11, (int)DynamicSlmPipelineStage.DistillationOffload);
        Assert.Equal(12, (int)DynamicSlmPipelineStage.FallbackSelection);
        Assert.Null(abi.SeedProfile);
        Assert.Null(context.DelegationRequest);
        Assert.Empty(context.ThoughtArtifacts);
        Assert.Null(context.MemoryPlacement);
        Assert.Null(metadata.StrictOutputMode);
        Assert.Equal("true", context.DistillationPlan?.Metadata[DynamicSlmMetadataKeys.GapDetected]);
        Assert.Equal(DynamicSlmFallbackKind.Teacher, context.FallbackStrategy?.Kind);
        Assert.Equal(DynamicSlmPipelineStage.CompatibilityVerification, result.Trace[0].Stage);

        var legacyAbi = new DynamicSlmModelAbi(
            "legacy-model",
            "0.0.1",
            abi.SemanticProfile,
            abi.CapabilityGraph,
            abi.ExecutionProfile,
            abi.Lineage,
            abi.Payloads,
            new Dictionary<string, string>());

        var legacyMetadata = new DynamicSlmPipelineMetadata(
            "legacy-pipeline",
            null,
            null,
            null,
            null,
            null,
            null,
            false,
            false,
            new Dictionary<string, string>());

        var legacyContext = new DynamicSlmPipelineContext(
            legacyAbi,
            null,
            null,
            null,
            [],
            null,
            null,
            null,
            null,
            null,
            null,
            [],
            legacyMetadata,
            []);

        Assert.Null(legacyAbi.SeedProfile);
        Assert.Null(legacyMetadata.DelegationId);
        Assert.Null(legacyMetadata.StrictOutputMode);
        Assert.Null(legacyContext.DelegationRequest);
        Assert.Empty(legacyContext.ThoughtArtifacts);
        Assert.Null(legacyContext.MemoryPlacement);
    }

    [Fact]
    public void SeedSlmDisciplineContractsAreOwnedByAbstractions()
    {
        var constraints = new SeedSlmStructuralConstraints(
            true,
            true,
            true,
            true,
            DynamicSlmStrictOutputMode.ZeroSlop,
            DynamicSlmReasoningTraceFormat.HashLinkedJson,
            new Dictionary<string, string>());

        var policy = new SeedSlmOutputDisciplinePolicy(
            DynamicSlmStrictOutputMode.ZeroSlop,
            true,
            true,
            true,
            "schema-hash",
            new Dictionary<string, string>());

        var delegation = new DynamicSlmDelegationRequest(
            "delegation-1",
            DynamicSlmDelegationKind.Teacher,
            DynamicSlmDelegationReason.CapabilityGap,
            "cap-1",
            "teacher-1",
            "replay-hash",
            "thought-1",
            new Dictionary<string, string>());

        var thought = new DynamicSlmThoughtArtifact(
            "thought-1",
            DynamicSlmReasoningTraceFormat.HashLinkedJson,
            "delegate unsupported capability",
            ["gap detected"],
            ["delegate_to_teacher"],
            "output-hash",
            "replay-hash",
            new Dictionary<string, string>());

        var replayEntry = new DynamicSlmReplayLogEntry(
            "entry-1",
            null,
            DynamicSlmPipelineStage.ThoughtArtifactDump,
            thought.ArtifactId,
            "delta-hash",
            "replay-hash",
            new Dictionary<string, string>());

        var trajectory = new DynamicSlmTrajectoryMetadata(
            "trajectory-1",
            thought.ArtifactId,
            replayEntry.ReplayLogHash,
            true,
            new Dictionary<string, string>());

        var adapter = new DynamicSlmAdapterCompatibilityProfile(
            "seed-1",
            DynamicSlmBaseModelStateKind.Null,
            [DynamicSlmPayloadKind.LoRaDelta, DynamicSlmPayloadKind.CapabilityPage],
            ["lora"],
            "0.125",
            new Dictionary<string, string>());

        var neutrality = new DynamicSlmNeutralityMetadata(
            DynamicSlmBaseModelStateKind.Null,
            true,
            "1.0",
            new Dictionary<string, string>());

        var resident = new DynamicSlmResidentModelDescriptor(
            "seed-1",
            DynamicSlmBaseModelStateKind.Null,
            DynamicSlmAcceleratorKind.Gpu,
            "vram://seed/base",
            1024,
            new Dictionary<string, string>());

        var swap = new DynamicSlmCapabilitySwapDescriptor(
            "cap-1",
            "payload-1",
            DynamicSlmHotSwapPolicy.PageIn,
            "vmem://cap/payload-1",
            128,
            new Dictionary<string, string>());

        var memory = new DynamicSlmMemoryPlacementMetadata(
            resident,
            [swap],
            DynamicSlmHotSwapPolicy.HotSwap,
            new Dictionary<string, string>());

        var profile = new SeedSlmProfile(
            resident.ModelId,
            constraints,
            policy,
            adapter,
            neutrality,
            resident,
            new Dictionary<string, string>());

        var seedPayload = new DynamicSlmPayloadDescriptor(
            "seed-payload-1",
            DynamicSlmPayloadKind.SeedBase,
            "rom://model/demo/seed.bin",
            "sha256",
            1024,
            "int8",
            new Dictionary<string, string>());

        var seedGraph = new DynamicSlmCapabilityGraph(
            [new DynamicSlmCapabilityNode("cap-1", "Plan", "profile-1", [seedPayload.PayloadId], ["planning"])],
            []);

        var seedAbi = new DynamicSlmModelAbi(
            profile.SeedModelId,
            "0.0.1",
            new DynamicSlmSemanticProfile("profile-1", "planning", ["agent"], ["json"], "schema", ["replay-v1"]),
            seedGraph,
            new DynamicSlmExecutionProfile(1024, 10, null, [DynamicSlmAcceleratorKind.Gpu], "int8", true, true),
            new DynamicSlmLineage("artifact-hash", null, "teacher-1", ["replay-hash"], "training-hash", "sig"),
            [seedPayload],
            profile,
            new Dictionary<string, string>());

        var seedMetadata = new DynamicSlmPipelineMetadata(
            "pipeline-seed",
            "replay-hash",
            "abi-hash",
            "graph-hash",
            "lineage-hash",
            "placement-1",
            null,
            delegation.DelegationId,
            thought.ArtifactId,
            trajectory.TrajectoryId,
            "memory-placement-1",
            DynamicSlmStrictOutputMode.ZeroSlop,
            true,
            true,
            new Dictionary<string, string>());

        var seedContext = new DynamicSlmPipelineContext(
            seedAbi,
            null,
            null,
            null,
            [],
            null,
            null,
            null,
            null,
            delegation,
            [thought],
            memory,
            null,
            null,
            [],
            seedMetadata,
            [new DynamicSlmPipelineTrace(DynamicSlmPipelineStage.ThoughtArtifactDump, "step-seed", null, "replay-hash", new Dictionary<string, string>())]);

        Assert.Equal(DynamicSlmStrictOutputMode.ZeroSlop, profile.OutputDisciplinePolicy.Mode);
        Assert.Equal(DynamicSlmDelegationKind.Teacher, delegation.Kind);
        Assert.Equal(DynamicSlmDelegationReason.CapabilityGap, delegation.Reason);
        Assert.Equal(DynamicSlmPipelineStage.ThoughtArtifactDump, replayEntry.Stage);
        Assert.True(trajectory.DistillationEligible);
        Assert.Equal(DynamicSlmBaseModelStateKind.Null, profile.Neutrality.BaseModelState);
        Assert.Equal(DynamicSlmHotSwapPolicy.HotSwap, memory.HotSwapPolicy);
        Assert.Equal(profile.SeedModelId, seedAbi.SeedProfile?.SeedModelId);
        Assert.Equal(delegation.DelegationId, seedContext.DelegationRequest?.DelegationId);
        Assert.Equal(thought.ArtifactId, seedContext.ThoughtArtifacts[0].ArtifactId);
        Assert.Equal(memory.HotSwapPolicy, seedContext.MemoryPlacement?.HotSwapPolicy);
        Assert.Equal(DynamicSlmStrictOutputMode.ZeroSlop, seedMetadata.StrictOutputMode);
        Assert.Equal(trajectory.TrajectoryId, seedMetadata.TrajectoryId);
        Assert.Equal("dynamicslm_thought_artifact_id", DynamicSlmMetadataKeys.ThoughtArtifactId);
    }

    [Fact]
    public void HatlContractsAreOwnedByAbstractions()
    {
        Assert.True(typeof(IHatlLedgerStore).IsInterface);
        Assert.True(typeof(IHatlAnchorPublisher).IsInterface);
        Assert.True(typeof(IHatlAnchorVerifier).IsInterface);
        Assert.True(typeof(IHatlDigitalDeedResolver).IsInterface);
        Assert.True(typeof(IHatlCryptographicOperator).IsInterface);

        var macRequest = new HatlBlockMacRequest(
            "ledger-1",
            1,
            "prev-hash",
            "payload-hash",
            new Dictionary<string, string>());

        var macResult = new HatlBlockMacResult(
            "HMAC-SHA-512",
            "mac",
            "entry-hash",
            "leaf-hash",
            new Dictionary<string, string>());

        var entry = new HatlLedgerEntry(
            macRequest.LedgerId,
            macRequest.SequenceNumber,
            macRequest.PreviousEntryHash,
            macResult.EntryHash,
            macRequest.PayloadHash,
            macResult.MacAlgorithm,
            macResult.Mac,
            macResult.MerkleLeafHash,
            new Dictionary<string, string>());

        var anchor = new HatlAnchorDocument(
            "anchor-1",
            entry.LedgerId,
            HatlAnchorProfile.SlhDsa,
            1,
            1,
            "root-hash",
            null,
            "anchor-hash",
            "SLH-DSA",
            "signature",
            new Dictionary<string, string>());

        var deed = new HatlDigitalDeed(
            "deed-1",
            "subject-1",
            HatlDeedStatus.Active,
            "issuer-1",
            anchor.AnchorHash,
            DateTimeOffset.UnixEpoch,
            null,
            new Dictionary<string, string>());

        var verification = new HatlVerificationResult(
            HatlVerificationStatus.Valid,
            anchor.AnchorId,
            anchor.AnchorHash,
            null,
            new Dictionary<string, string>());

        var ratchet = new HatlRatchetStepResult(
            "HKDF-SHA-512",
            "next-key-commitment",
            new Dictionary<string, string>());

        Assert.Equal("hatl_anchor_id", HatlMetadataKeys.AnchorId);
        Assert.Equal(HatlAnchorProfile.SlhDsa, anchor.AnchorProfile);
        Assert.Equal(HatlDeedStatus.Active, deed.Status);
        Assert.Equal(HatlVerificationStatus.Valid, verification.Status);
        Assert.Equal("HKDF-SHA-512", ratchet.DerivationAlgorithm);
    }

    [Fact]
    public void HistoryRomContractsAreOwnedByAbstractions()
    {
        Assert.True(typeof(IHistoryRomRegistry).IsInterface);
        Assert.True(typeof(IHistoryRomStore).IsInterface);
        Assert.True(typeof(IChatHistoryRomExporter).IsInterface);

        var record = new ChatHistoryRomRecord(
            "user",
            "hello",
            DateTimeOffset.UnixEpoch);

        Assert.Equal("user", record.Role);
        Assert.Equal("history_rom_hash", HistoryRomMetadataKeys.RomHash);
    }

    [Fact]
    public void KernelClockContractUsesDtoTimestamp()
    {
        Assert.True(typeof(IKernelClock).IsInterface);

        var timestamp = new KernelTimestamp
        {
            UtcDateTime = DateTimeOffset.UnixEpoch,
            LogicalCounter = 1,
            SourceId = "test",
            Signature = "sig"
        };

        Assert.Equal(DateTimeOffset.UnixEpoch, timestamp.UtcDateTime);
        Assert.Equal(1, timestamp.LogicalCounter);
    }

    [Fact]
    public void ExtractedContractsDoNotIntroduceReverseDependencies()
    {
        var abstractionReferences = typeof(IKernelPipeline)
            .Assembly
            .GetReferencedAssemblies()
            .Select(name => name.Name)
            .ToArray();

        Assert.DoesNotContain("AIKernel.Core", abstractionReferences);
        Assert.DoesNotContain("AIKernel.Common", abstractionReferences);
        Assert.DoesNotContain("AIKernel.Vfs", abstractionReferences);

        var dtoReferences = typeof(DslDocument)
            .Assembly
            .GetReferencedAssemblies()
            .Select(name => name.Name)
            .ToArray();

        Assert.DoesNotContain("AIKernel.Abstractions", dtoReferences);
        Assert.DoesNotContain("AIKernel.Contracts", dtoReferences);
        Assert.DoesNotContain("AIKernel.Core", dtoReferences);
        Assert.DoesNotContain("AIKernel.Common", dtoReferences);

        var contractReferences = typeof(IUnifiedContextContract)
            .Assembly
            .GetReferencedAssemblies()
            .Select(name => name.Name)
            .ToArray();

        Assert.DoesNotContain("AIKernel.Abstractions", contractReferences);
        Assert.DoesNotContain("AIKernel.Core", contractReferences);
        Assert.DoesNotContain("AIKernel.Common", contractReferences);
        Assert.DoesNotContain("AIKernel.Vfs", contractReferences);

        var enumReferences = typeof(AIKernel.Enums.FailureMode)
            .Assembly
            .GetReferencedAssemblies()
            .Select(name => name.Name)
            .Where(name => name is not "System.Runtime")
            .ToArray();

        Assert.Empty(enumReferences);
    }

    [Fact]
    public void PublicInterfacesHaveUniqueSimpleNamesInsideAbstractions()
    {
        var duplicates = typeof(IKernelPipeline)
            .Assembly
            .GetExportedTypes()
            .Where(type => type.IsInterface)
            .GroupBy(type => type.Name, StringComparer.Ordinal)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToArray();

        Assert.Empty(duplicates);
    }

    [Fact]
    public void AbstractionsAndContractsExportInterfacesOnly()
    {
        var abstractionNonInterfaces = typeof(IKernelPipeline)
            .Assembly
            .GetExportedTypes()
            .Where(type => !type.IsInterface)
            .Select(type => type.FullName)
            .ToArray();

        var contractNonInterfaces = typeof(IUnifiedContextContract)
            .Assembly
            .GetExportedTypes()
            .Where(type => !type.IsInterface)
            .Select(type => type.FullName)
            .ToArray();

        Assert.Empty(abstractionNonInterfaces);
        Assert.Empty(contractNonInterfaces);
    }

    [Fact]
    public void DtosDoNotOwnSharedEnums()
    {
        var dtoEnums = typeof(DslDocument)
            .Assembly
            .GetExportedTypes()
            .Where(type => type.IsEnum)
            .Select(type => type.FullName)
            .ToArray();

        Assert.Empty(dtoEnums);
        Assert.True(typeof(AIKernel.Enums.ExecutionStatus).IsEnum);
        Assert.True(typeof(AIKernel.Enums.PromptMessageFormat).IsEnum);
        Assert.True(typeof(AIKernel.Enums.PromptOverflowPolicy).IsEnum);
        Assert.True(typeof(DynamicSlmPayloadKind).IsEnum);
        Assert.True(typeof(DynamicSlmAcceleratorKind).IsEnum);
        Assert.True(typeof(DynamicSlmCompatibilityStatus).IsEnum);
        Assert.True(typeof(DynamicSlmGraphUpdateKind).IsEnum);
        Assert.True(typeof(DynamicSlmPipelineStage).IsEnum);
        Assert.True(typeof(DynamicSlmFailureKind).IsEnum);
        Assert.True(typeof(DynamicSlmDistillationJobStatus).IsEnum);
        Assert.True(typeof(DynamicSlmFallbackKind).IsEnum);
        Assert.True(typeof(DynamicSlmPipelineStatus).IsEnum);
        Assert.True(typeof(DynamicSlmStrictOutputMode).IsEnum);
        Assert.True(typeof(DynamicSlmDelegationKind).IsEnum);
        Assert.True(typeof(DynamicSlmDelegationReason).IsEnum);
        Assert.True(typeof(DynamicSlmReasoningTraceFormat).IsEnum);
        Assert.True(typeof(DynamicSlmBaseModelStateKind).IsEnum);
        Assert.True(typeof(DynamicSlmHotSwapPolicy).IsEnum);
        Assert.True(typeof(SemanticIrSlot).IsEnum);
        Assert.True(typeof(AdmissibilityGateKind).IsEnum);
        Assert.True(typeof(AdmissibilityDecisionKind).IsEnum);
        Assert.True(typeof(HatlAnchorProfile).IsEnum);
        Assert.True(typeof(HatlDeedStatus).IsEnum);
        Assert.True(typeof(HatlVerificationStatus).IsEnum);
    }

    [Fact]
    public void RemovedImplementationTypesAreNotExportedFromContractAssemblies()
    {
        var abstractionTypes = typeof(IKernelPipeline)
            .Assembly
            .GetExportedTypes()
            .Select(type => type.FullName)
            .ToHashSet(StringComparer.Ordinal);

        var dtoTypes = typeof(DslDocument)
            .Assembly
            .GetExportedTypes()
            .Select(type => type.FullName)
            .ToHashSet(StringComparer.Ordinal);

        Assert.DoesNotContain("AIKernel.Abstractions.Context.ContextAssemblyRequest", abstractionTypes);
        Assert.DoesNotContain("AIKernel.Abstractions.Context.ContextAssemblyScope", abstractionTypes);
        Assert.DoesNotContain("AIKernel.Abstractions.Context.ContextAssemblyDecision", abstractionTypes);
        Assert.DoesNotContain("AIKernel.Abstractions.Execution.PromptGenerationException", abstractionTypes);
        Assert.DoesNotContain("AIKernel.Abstractions.Execution.PromptTokenBudgetExceededException", abstractionTypes);
        Assert.DoesNotContain("AIKernel.Abstractions.Execution.UnsupportedPromptCapabilityException", abstractionTypes);
        Assert.DoesNotContain("AIKernel.Abstractions.Vfs.VfsAuthenticationFailedException", abstractionTypes);

        Assert.DoesNotContain("AIKernel.Dtos.Execution.ExecutionStatus", dtoTypes);
        Assert.DoesNotContain("AIKernel.Dtos.Execution.PromptMessageFormat", dtoTypes);
        Assert.DoesNotContain("AIKernel.Dtos.Execution.PromptOverflowPolicy", dtoTypes);
    }

    [Fact]
    public void SharedInterfaceSurfaceDoesNotUseAmbiguousGenericNames()
    {
        var interfaces = typeof(IKernelPipeline)
            .Assembly
            .GetExportedTypes()
            .Where(type => type.IsInterface)
            .ToArray();

        var names = interfaces
            .Select(type => type.FullName)
            .ToArray();

        Assert.DoesNotContain("AIKernel.Abstractions.Scheduling.IExecutionResult", names);
        Assert.DoesNotContain("AIKernel.Abstractions.Governance.ChatChain.IResult", names);
        Assert.Contains("AIKernel.Abstractions.Scheduling.IScheduledExecutionResult", names);

        var semanticHashers = interfaces
            .Where(type => type.Name == "ISemanticHasher")
            .Select(type => type.FullName!)
            .ToArray();

        Assert.Equal(["AIKernel.Abstractions.Rom.ISemanticHasher"], semanticHashers);
    }
}
