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

/// <summary>
/// EN: Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class SandboxValidatorIsolationTests
{
    /// <summary>
    /// EN: Executes CompositeToolSandboxExposesExecutionTransferCleanupAndObservationCapabilities.
    /// EN: Documentation for public API. JA: CompositeToolSandboxExposesExecutionTransferCleanupAndObservationCapabilities を実行します。
    /// </summary>
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
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ToolExecutorDoesNotExposeFileTransferOrCleanup()
    {
        IToolExecutor executor = new ToolExecutionOnlySandbox();

        Assert.False(executor is IToolFileUploadSink);
        Assert.False(executor is IToolFileDownloadSource);
        Assert.False(executor is IToolSandboxCleanup);
    }
    /// <summary>
    /// EN: Executes CompositeRomValidatorExposesGranularValidationCapabilities.
    /// EN: Documentation for public API. JA: CompositeRomValidatorExposesGranularValidationCapabilities を実行します。
    /// </summary>

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
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void RomSchemaValidatorDoesNotExposeGraphValidation()
    {
        IRomSchemaValidator validator = new SchemaOnlyRomValidator();

        Assert.False(validator is IRomLinkageValidator);
        Assert.False(validator is IRomCircularReferenceValidator);
    }
    /// <summary>
    /// EN: Executes ConversationReaderDoesNotExposeMutationCapabilities.
    /// EN: Documentation for public API. JA: ConversationReaderDoesNotExposeMutationCapabilities を実行します。
    /// </summary>

    [Fact]
    public void ConversationReaderDoesNotExposeMutationCapabilities()
    {
        IConversationSnapshotReader reader = new ReadOnlyConversationStore();

        Assert.False(reader is IConversationSnapshotWriter);
        Assert.False(reader is IConversationSnapshotDeleter);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ContextFragmentCollectionDoesNotExposePhaseBuffers()
    {
        IContextFragmentCollection fragments = new FragmentOnlyContextCollection();

        Assert.False(fragments is IPhaseBufferCollection);
    }
    /// <summary>
    /// EN: Executes CompositeComputeShapeAdvisorExposesGranularComputeCapabilities.
    /// EN: Documentation for public API. JA: CompositeComputeShapeAdvisorExposesGranularComputeCapabilities を実行します。
    /// </summary>

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
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
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
        /// <summary>
        /// EN: Gets SandboxId.
        /// EN: Documentation for public API. JA: SandboxId を取得します。
        /// </summary>
        public string SandboxId => "sandbox";

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<SandboxExecutionResult> ExecuteToolAsync(
            string toolName,
            IReadOnlyDictionary<string, string> parameters,
            IToolPermission permissions)
        {
            return Task.FromResult<SandboxExecutionResult>(null!);
        }
        /// <summary>
        /// EN: Executes UploadFileAsync.
        /// EN: Documentation for public API. JA: UploadFileAsync を実行します。
        /// </summary>

        public Task<bool> UploadFileAsync(string fileName, byte[] content)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<byte[]?> DownloadFileAsync(string fileName)
        {
            return Task.FromResult<byte[]?>(null);
        }
        /// <summary>
        /// EN: Executes CleanupAsync.
        /// EN: Documentation for public API. JA: CleanupAsync を実行します。
        /// </summary>

        public Task CleanupAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes GetResourceUsageAsync.
        /// EN: Documentation for public API. JA: GetResourceUsageAsync を実行します。
        /// </summary>

        public Task<SandboxResourceUsage> GetResourceUsageAsync()
        {
            return Task.FromResult<SandboxResourceUsage>(null!);
        }
    }

    private sealed class SchemaOnlyRomValidator : IRomSchemaValidator
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<RomSchemaValidationResult> ValidateSchemaAsync(
            IRomDocument document,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomSchemaValidationResult>(null!);
        }
    }

    private sealed class FullRomValidator : IRomValidator
    {
        /// <summary>
        /// EN: Gets ValidateSchemaAsync.
        /// EN: Documentation for public API. JA: ValidateSchemaAsync を取得します。
        /// </summary>
        public Task<RomSchemaValidationResult> ValidateSchemaAsync(
            IRomDocument document,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomSchemaValidationResult>(null!);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<RomLinkageValidationResult> ValidateLinkageAsync(
            IRomDocument document,
            IRelationResolver relationResolver,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomLinkageValidationResult>(null!);
        }
        /// <summary>
        /// EN: Gets ValidateTypeConsistencyAsync.
        /// EN: Documentation for public API. JA: ValidateTypeConsistencyAsync を取得します。
        /// </summary>

        public Task<RomTypeConsistencyResult> ValidateTypeConsistencyAsync(
            IRomDocument document,
            EntityTypeSchema typeSchema,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RomTypeConsistencyResult>(null!);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
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
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IConversationSnapshot?> GetSnapshotAsync(string snapshotId, CancellationToken ct = default)
        {
            return Task.FromResult<IConversationSnapshot?>(null);
        }
    }

    private sealed class FragmentOnlyContextCollection : IContextFragmentCollection
    {
        /// <summary>
        /// EN: Executes GetAll.
        /// EN: Documentation for public API. JA: GetAll を実行します。
        /// </summary>
        public IEnumerable<ContextFragment> GetAll()
        {
            return [];
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public IEnumerable<ContextFragment> GetByCategory(ContextCategory category)
        {
            return [];
        }
    }

    private sealed class FullComputeShapeAdvisor : IComputeShapeAdvisor
    {
        /// <summary>
        /// EN: Executes AdvisedPhysicalCardinality.
        /// EN: Documentation for public API. JA: AdvisedPhysicalCardinality を実行します。
        /// </summary>
        public int AdvisedPhysicalCardinality(int logicalLength, string deviceType)
        {
            return logicalLength;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public int SelectOptimalCardinality(IEnumerable<int> candidates, string deviceType)
        {
            return candidates.FirstOrDefault();
        }
        /// <summary>
        /// EN: Executes GetCardinalityAlignment.
        /// EN: Documentation for public API. JA: GetCardinalityAlignment を実行します。
        /// </summary>

        public int GetCardinalityAlignment(string deviceType)
        {
            return 1;
        }
        /// <summary>
        /// EN: Executes GetPaddingStrategy.
        /// EN: Documentation for public API. JA: GetPaddingStrategy を実行します。
        /// </summary>

        public PaddingStrategy GetPaddingStrategy(int logicalLength, string deviceType)
        {
            return null!;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public ComputeOverhead EstimatePaddingOverhead(int logicalLength, int physicalLength)
        {
            return null!;
        }
        /// <summary>
        /// EN: Executes AdvisedQuantizationLevel.
        /// EN: Documentation for public API. JA: AdvisedQuantizationLevel を実行します。
        /// </summary>

        public string AdvisedQuantizationLevel(int cardinality, string deviceType, float targetThroughputTflops)
        {
            return string.Empty;
        }
        /// <summary>
        /// EN: Executes GetOptimalShape.
        /// EN: Documentation for public API. JA: GetOptimalShape を実行します。
        /// </summary>

        public ComputeShape GetOptimalShape(IExecutionConstraints constraints)
        {
            return null!;
        }
    }
}
