using AIKernel.Abstractions.DynamicSlm;
using AIKernel.Abstractions.Dsl;
using AIKernel.Abstractions.History;
using AIKernel.Abstractions.Time;
using AIKernel.Contracts;
using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Dsl;
using AIKernel.Dtos.History;
using AIKernel.Dtos.Time;
using AIKernel.Enums;

namespace AIKernel.Abstractions.Tests;

public sealed class ExtractedInterfaceContractTests
{
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
        Assert.Equal("dsl_rom_hash", DslRomMetadataKeys.RomHash);
    }

    [Fact]
    public void DynamicSlmContractsAreOwnedByAbstractions()
    {
        Assert.True(typeof(IDynamicSlmModelAbiProvider).IsInterface);
        Assert.True(typeof(IDynamicSlmModuleRegistry).IsInterface);
        Assert.True(typeof(IDynamicSlmCapabilityGraphResolver).IsInterface);
        Assert.True(typeof(IDynamicSlmCompatibilityVerifier).IsInterface);
        Assert.True(typeof(IDynamicSlmLineageVerifier).IsInterface);
        Assert.True(typeof(IDynamicSlmPayloadLoader).IsInterface);
        Assert.True(typeof(IDynamicSlmScheduler).IsInterface);
        Assert.True(typeof(IDynamicSlmCapabilityGapDetector).IsInterface);
        Assert.True(typeof(IDynamicSlmCapabilityGraphEvolutionPlanner).IsInterface);
        Assert.True(typeof(IDynamicSlmDistillationPlanner).IsInterface);
        Assert.True(typeof(IDynamicSlmArtifactPublisher).IsInterface);

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
            new Dictionary<string, string>());

        Assert.Equal("model-1", abi.ModelId);
        Assert.Equal("dynamicslm_model_abi_hash", DynamicSlmMetadataKeys.ModelAbiHash);
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
