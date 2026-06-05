using AIKernel.Abstractions.Dsl;
using AIKernel.Abstractions.History;
using AIKernel.Abstractions.Time;
using AIKernel.Contracts;
using AIKernel.Dtos.Dsl;
using AIKernel.Dtos.History;
using AIKernel.Dtos.Time;

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
