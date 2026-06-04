using AIKernel.Abstractions.Dsl;
using AIKernel.Abstractions.History;
using AIKernel.Abstractions.Time;
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

        Assert.Equal("Pipeline", new PipelineRootNode([]).Type);
        Assert.Equal("CallCapability", new CallCapabilityNode("demo", new Dictionary<string, string>()).Type);
        Assert.Equal("dsl_rom_hash", DslRomMetadataKeys.RomHash);
    }

    [Fact]
    public void HistoryRomContractsAreOwnedByAbstractions()
    {
        Assert.True(typeof(IHistoryRomRegistry).IsInterface);
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
        Assert.DoesNotContain("AIKernel.Core", dtoReferences);
        Assert.DoesNotContain("AIKernel.Common", dtoReferences);
    }
}
