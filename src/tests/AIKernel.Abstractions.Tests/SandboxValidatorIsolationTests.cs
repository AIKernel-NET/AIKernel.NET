using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Conversation;
using AIKernel.Abstractions.Execution;
using AIKernel.Abstractions.Models;
using AIKernel.Abstractions.Rom;
using AIKernel.Abstractions.Tooling;
using AIKernel.Dtos.Rom;
using AIKernel.Dtos.Routing;
using AIKernel.Dtos.Sandbox;

namespace AIKernel.Abstractions.Tests;

public sealed class SandboxValidatorIsolationTests
{
    [Fact]
    public void CompositeToolSandboxExposesExecutionTransferCleanupAndObservationCapabilities()
    {
        IToolSandbox sandbox = new FullToolSandbox();

        Assert.IsAssignableFrom<IToolSandboxIdentity>(sandbox);
        Assert.IsAssignableFrom<IToolExecutor>(sandbox);
        Assert.IsAssignableFrom<IToolFileUploadSink>(sandbox);
        Assert.IsAssignableFrom<IToolFileDownloadSource>(sandbox);
        Assert.IsAssignableFrom<IToolSandboxCleanup>(sandbox);
        Assert.IsAssignableFrom<IToolResourceUsageSource>(sandbox);
    }

    [Fact]
    public void ToolExecutorDoesNotExposeFileTransferOrCleanup()
    {
        IToolExecutor executor = new ToolExecutionOnlySandbox();

        Assert.False(executor is IToolFileUploadSink);
        Assert.False(executor is IToolFileDownloadSource);
        Assert.False(executor is IToolSandboxCleanup);
    }

    [Fact]
    public void CompositeRomValidatorExposesGranularValidationCapabilities()
    {
        IRomValidator validator = new FullRomValidator();

        Assert.IsAssignableFrom<IRomSchemaValidator>(validator);
        Assert.IsAssignableFrom<IRomLinkageValidator>(validator);
        Assert.IsAssignableFrom<IRomTypeConsistencyValidator>(validator);
        Assert.IsAssignableFrom<IRomCircularReferenceValidator>(validator);
    }

    [Fact]
    public void RomSchemaValidatorDoesNotExposeGraphValidation()
    {
        IRomSchemaValidator validator = new SchemaOnlyRomValidator();

        Assert.False(validator is IRomLinkageValidator);
        Assert.False(validator is IRomCircularReferenceValidator);
    }

    [Fact]
    public void ConversationReaderDoesNotExposeMutationCapabilities()
    {
        IConversationSnapshotReader reader = new ReadOnlyConversationStore();

        Assert.False(reader is IConversationSnapshotWriter);
        Assert.False(reader is IConversationSnapshotDeleter);
    }

    [Fact]
    public void ContextFragmentCollectionDoesNotExposePhaseBuffers()
    {
        IContextFragmentCollection fragments = new FragmentOnlyContextCollection();

        Assert.False(fragments is IPhaseBufferCollection);
    }

    [Fact]
    public void CompositeComputeShapeAdvisorExposesGranularComputeCapabilities()
    {
        IComputeShapeAdvisor advisor = new FullComputeShapeAdvisor();

        Assert.IsAssignableFrom<IComputeCardinalityAdvisor>(advisor);
        Assert.IsAssignableFrom<IComputePaddingAdvisor>(advisor);
        Assert.IsAssignableFrom<IQuantizationAdvisor>(advisor);
        Assert.IsAssignableFrom<IComputeShapeOptimizer>(advisor);
    }

    private sealed class ToolExecutionOnlySandbox : IToolExecutor
    {
        public Task<SandboxExecutionResult> ExecuteToolAsync(
            string toolName,
            IReadOnlyDictionary<string, string> parameters,
            IToolPermission permissions)
        {
            return Task.FromResult<SandboxExecutionResult>(null!);
        }
    }

    private sealed class FullToolSandbox : IToolSandbox
    {
        public string SandboxId => "sandbox";

        public Task<SandboxExecutionResult> ExecuteToolAsync(
            string toolName,
            IReadOnlyDictionary<string, string> parameters,
            IToolPermission permissions)
        {
            return Task.FromResult<SandboxExecutionResult>(null!);
        }

        public Task<bool> UploadFileAsync(string fileName, byte[] content)
        {
            return Task.FromResult(true);
        }

        public Task<byte[]?> DownloadFileAsync(string fileName)
        {
            return Task.FromResult<byte[]?>(null);
        }

        public Task CleanupAsync()
        {
            return Task.CompletedTask;
        }

        public Task<SandboxResourceUsage> GetResourceUsageAsync()
        {
            return Task.FromResult<SandboxResourceUsage>(null!);
        }
    }

    private sealed class SchemaOnlyRomValidator : IRomSchemaValidator
    {
        public Task<RomSchemaValidationResult> ValidateSchemaAsync(
            IRomDocument document,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomSchemaValidationResult>(null!);
        }
    }

    private sealed class FullRomValidator : IRomValidator
    {
        public Task<RomSchemaValidationResult> ValidateSchemaAsync(
            IRomDocument document,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomSchemaValidationResult>(null!);
        }

        public Task<RomLinkageValidationResult> ValidateLinkageAsync(
            IRomDocument document,
            IRelationResolver relationResolver,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomLinkageValidationResult>(null!);
        }

        public Task<RomTypeConsistencyResult> ValidateTypeConsistencyAsync(
            IRomDocument document,
            EntityTypeSchema typeSchema,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomTypeConsistencyResult>(null!);
        }

        public Task<CircularReferenceDetectionResult> DetectCircularReferencesAsync(
            IRomDocument document,
            IRelationResolver relationResolver,
            int maxDepth = 10,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<CircularReferenceDetectionResult>(null!);
        }
    }

    private sealed class ReadOnlyConversationStore : IConversationSnapshotReader
    {
        public Task<IConversationSnapshot?> GetSnapshotAsync(string snapshotId, CancellationToken ct = default)
        {
            return Task.FromResult<IConversationSnapshot?>(null);
        }
    }

    private sealed class FragmentOnlyContextCollection : IContextFragmentCollection
    {
        public IEnumerable<ContextFragment> GetAll()
        {
            return [];
        }

        public IEnumerable<ContextFragment> GetByCategory(ContextCategory category)
        {
            return [];
        }
    }

    private sealed class FullComputeShapeAdvisor : IComputeShapeAdvisor
    {
        public int AdvisedPhysicalCardinality(int logicalLength, string deviceType)
        {
            return logicalLength;
        }

        public int SelectOptimalCardinality(IEnumerable<int> candidates, string deviceType)
        {
            return candidates.FirstOrDefault();
        }

        public int GetCardinalityAlignment(string deviceType)
        {
            return 1;
        }

        public PaddingStrategy GetPaddingStrategy(int logicalLength, string deviceType)
        {
            return null!;
        }

        public ComputeOverhead EstimatePaddingOverhead(int logicalLength, int physicalLength)
        {
            return null!;
        }

        public string AdvisedQuantizationLevel(int cardinality, string deviceType, float targetThroughputTflops)
        {
            return string.Empty;
        }

        public ComputeShape GetOptimalShape(IExecutionConstraints constraints)
        {
            return null!;
        }
    }
}
