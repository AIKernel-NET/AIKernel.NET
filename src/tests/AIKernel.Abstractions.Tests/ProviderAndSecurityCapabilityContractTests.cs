using AIKernel.Abstractions.Models;
using AIKernel.Abstractions.Events;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Query;
using AIKernel.Abstractions.Security;
using AIKernel.Abstractions.Tooling;
using AIKernel.Dtos.Query;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// EN: Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class ProviderAndSecurityCapabilityContractTests
{
    /// <summary>
    /// EN: Executes CompositeToolAccessValidatorExposesGranularCapabilities.
    /// EN: Documentation for public API. JA: CompositeToolAccessValidatorExposesGranularCapabilities を実行します。
    /// </summary>
    [Fact]
    public void CompositeToolAccessValidatorExposesGranularCapabilities()
    {
        IToolAccessValidator validator = new FullToolAccessValidator();

        Assert.IsAssignableFrom<IToolExecutionAccessValidator>(validator);
        Assert.IsAssignableFrom<IFileReadAccessValidator>(validator);
        Assert.IsAssignableFrom<IFileWriteAccessValidator>(validator);
        Assert.IsAssignableFrom<INetworkAccessValidator>(validator);
        Assert.IsAssignableFrom<IEnvironmentAccessValidator>(validator);
        Assert.IsAssignableFrom<ISystemCommandAccessValidator>(validator);
        Assert.IsAssignableFrom<IPermissionLifecycleValidator>(validator);
        Assert.IsAssignableFrom<IPermissionConstraintValidator>(validator);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ReadOnlyRagProviderDoesNotExposeIndexMutationCapabilities()
    {
        IRagSearchProvider provider = new SearchOnlyRagProvider();

        Assert.False(provider is IRagIndexWriter);
        Assert.False(provider is IRagIndexDeleter);
        Assert.False(provider is IRagIndexManager);
    }
    /// <summary>
    /// EN: Executes CompositeRagProviderExposesSearchAndIndexCapabilities.
    /// EN: Documentation for public API. JA: CompositeRagProviderExposesSearchAndIndexCapabilities を実行します。
    /// </summary>

    [Fact]
    public void CompositeRagProviderExposesSearchAndIndexCapabilities()
    {
        IRagProvider provider = new FullRagProvider();

        Assert.IsAssignableFrom<IProvider>(provider);
        Assert.IsAssignableFrom<IRagSearchProvider>(provider);
        Assert.IsAssignableFrom<IRagIndexWriter>(provider);
        Assert.IsAssignableFrom<IRagIndexDeleter>(provider);
        Assert.IsAssignableFrom<IRagIndexManager>(provider);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void CompositeModelProviderExposesGranularModelCapabilities()
    {
        IModelProvider provider = new FullModelProvider();

        Assert.IsAssignableFrom<IProvider>(provider);
        Assert.IsAssignableFrom<ITextGenerationProvider>(provider);
        Assert.IsAssignableFrom<IStreamingGenerationProvider>(provider);
        Assert.IsAssignableFrom<IQuestionAnsweringProvider>(provider);
    }
    /// <summary>
    /// EN: Executes TextOnlyModelProviderDoesNotExposeStreamingOrQuestionAnswering.
    /// EN: Documentation for public API. JA: TextOnlyModelProviderDoesNotExposeStreamingOrQuestionAnswering を実行します。
    /// </summary>

    [Fact]
    public void TextOnlyModelProviderDoesNotExposeStreamingOrQuestionAnswering()
    {
        ITextGenerationProvider provider = new TextOnlyModelProvider();

        Assert.False(provider is IStreamingGenerationProvider);
        Assert.False(provider is IQuestionAnsweringProvider);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void CompositeEmbeddingProviderExposesGranularEmbeddingCapabilities()
    {
        IEmbeddingProvider provider = new FullEmbeddingProvider();

        Assert.IsAssignableFrom<IProvider>(provider);
        Assert.IsAssignableFrom<ITextEmbeddingProvider>(provider);
        Assert.IsAssignableFrom<IBatchEmbeddingProvider>(provider);
        Assert.IsAssignableFrom<IEmbeddingDimensionProvider>(provider);
    }
    /// <summary>
    /// EN: Executes SingleEmbeddingProviderDoesNotExposeBatchCapability.
    /// EN: Documentation for public API. JA: SingleEmbeddingProviderDoesNotExposeBatchCapability を実行します。
    /// </summary>

    [Fact]
    public void SingleEmbeddingProviderDoesNotExposeBatchCapability()
    {
        ITextEmbeddingProvider provider = new SingleEmbeddingProvider();

        Assert.False(provider is IBatchEmbeddingProvider);
        Assert.False(provider is IEmbeddingDimensionProvider);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ProviderCapabilitiesCanBeExposedAsSeparateCapabilitySources()
    {
        IProviderCapabilities capabilities = new EmptyProviderCapabilities();
        IProviderOperationCapabilities operationCapabilities = new StaticOperationCapabilities();

        Assert.IsAssignableFrom<IProviderOperationCapabilities>(capabilities);
        Assert.IsAssignableFrom<IProviderConnectionCapabilities>(capabilities);
        Assert.IsAssignableFrom<IProviderCapacityVectorSource>(capabilities);
        Assert.IsAssignableFrom<IDynamicProviderCapacitySource>(capabilities);
        Assert.IsAssignableFrom<IProviderProfileSource>(capabilities);
        Assert.IsAssignableFrom<IQuantizationSupport>(capabilities);
        Assert.IsAssignableFrom<IQueryProcessingCapabilities>(capabilities);
        Assert.IsAssignableFrom<IEmbeddingCapabilityMetadata>(capabilities);
        Assert.False(operationCapabilities is IDynamicProviderCapacitySource);
        Assert.False(operationCapabilities is IQuantizationSupport);
        Assert.False(operationCapabilities is IQueryProcessingCapabilities);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void QueryProcessingAbstractionsRequireKernelContext()
    {
        var augmentorMethod = typeof(IQueryAugmentor).GetMethod(nameof(IQueryAugmentor.AugmentAsync));
        var decomposerMethod = typeof(IQueryDecomposer).GetMethod(nameof(IQueryDecomposer.DecomposeAsync));
        var routerMethod = typeof(IQueryRouter).GetMethod(nameof(IQueryRouter.RouteAsync));

        Assert.Contains(augmentorMethod!.GetParameters(), parameter => parameter.ParameterType.Name == "IKernelContext");
        Assert.Contains(decomposerMethod!.GetParameters(), parameter => parameter.ParameterType.Name == "IKernelContext");
        Assert.Contains(routerMethod!.GetParameters(), parameter => parameter.ParameterType.Name == "IKernelContext");
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void QueryPartUsesImmutableMetadata()
    {
        var queryPart = new QueryPart
        {
            QueryPartId = "query-part-1",
            Text = "normalized query",
            Order = 0
        };

        Assert.Empty(queryPart.Metadata);
        Assert.Equal("query-part-1", queryPart.QueryPartId);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void CompositeProviderExposesGranularLifecycleCapabilities()
    {
        IProvider provider = new FullRagProvider();

        Assert.IsAssignableFrom<IProviderIdentity>(provider);
        Assert.IsAssignableFrom<IProviderCapabilitySource>(provider);
        Assert.IsAssignableFrom<IProviderAvailabilityProbe>(provider);
        Assert.IsAssignableFrom<IProviderLifecycle>(provider);
        Assert.IsAssignableFrom<IProviderHealthProbe>(provider);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void CompositeProviderRouterExposesGranularRoutingCapabilities()
    {
        IProviderRouter router = new FullProviderRouter();

        Assert.IsAssignableFrom<IProviderMaterialRetriever>(router);
        Assert.IsAssignableFrom<IMaterialCacheReader>(router);
        Assert.IsAssignableFrom<IMaterialCacheWriter>(router);
        Assert.IsAssignableFrom<IProviderRegistry>(router);
    }
    /// <summary>
    /// EN: Executes CacheReadOnlyRouterDoesNotExposeCacheMutationOrRegistryCapabilities.
    /// EN: Documentation for public API. JA: CacheReadOnlyRouterDoesNotExposeCacheMutationOrRegistryCapabilities を実行します。
    /// </summary>

    [Fact]
    public void CacheReadOnlyRouterDoesNotExposeCacheMutationOrRegistryCapabilities()
    {
        IMaterialCacheReader cacheReader = new CacheReadOnlyRouter();

        Assert.False(cacheReader is IMaterialCacheWriter);
        Assert.False(cacheReader is IProviderRegistry);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void CompositeEventBusExposesGranularEventCapabilities()
    {
        IEventBus eventBus = new FullEventBus();

        Assert.IsAssignableFrom<IProvider>(eventBus);
        Assert.IsAssignableFrom<IEventPublisher>(eventBus);
        Assert.IsAssignableFrom<IEventBroadcaster>(eventBus);
        Assert.IsAssignableFrom<IEventSubscriptionRegistry>(eventBus);
    }
    /// <summary>
    /// EN: Executes SubscriptionOnlyEventRegistryDoesNotExposePublishCapabilities.
    /// EN: Documentation for public API. JA: SubscriptionOnlyEventRegistryDoesNotExposePublishCapabilities を実行します。
    /// </summary>

    [Fact]
    public void SubscriptionOnlyEventRegistryDoesNotExposePublishCapabilities()
    {
        IEventSubscriptionRegistry registry = new SubscriptionOnlyEventRegistry();

        Assert.False(registry is IEventPublisher);
        Assert.False(registry is IEventBroadcaster);
    }

    private sealed class FullToolAccessValidator : IToolAccessValidator
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public bool CanExecuteTool(IToolPermission permission, string toolName)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes CanReadFile.
        /// EN: Documentation for public API. JA: CanReadFile を実行します。
        /// </summary>

        public bool CanReadFile(IToolPermission permission, string filePath)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes CanWriteFile.
        /// EN: Documentation for public API. JA: CanWriteFile を実行します。
        /// </summary>

        public bool CanWriteFile(IToolPermission permission, string filePath)
        {
            return true;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public bool CanAccessNetwork(IToolPermission permission, string host)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes CanAccessEnvironment.
        /// EN: Documentation for public API. JA: CanAccessEnvironment を実行します。
        /// </summary>

        public bool CanAccessEnvironment(IToolPermission permission, string variableName)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes CanExecuteSystemCommand.
        /// EN: Documentation for public API. JA: CanExecuteSystemCommand を実行します。
        /// </summary>

        public bool CanExecuteSystemCommand(IToolPermission permission, string commandName)
        {
            return true;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public bool IsPermissionValid(IToolPermission permission)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes ValidateConstraints.
        /// EN: Documentation for public API. JA: ValidateConstraints を実行します。
        /// </summary>

        public bool ValidateConstraints(IToolPermission permission, IReadOnlyDictionary<string, string> context)
        {
            return true;
        }
    }

    private sealed class SearchOnlyRagProvider : IRagSearchProvider
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadOnlyList<MaterialContextDto>> SearchAsync(
            string query,
            int topK = 10,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<MaterialContextDto> results = [];
            return Task.FromResult(results);
        }
    }

    private sealed class FullRagProvider : IRagProvider
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string ProviderId => "full-rag";
        /// <summary>
        /// EN: Gets Name.
        /// EN: Documentation for public API. JA: Name を取得します。
        /// </summary>

        public string Name => "Full RAG";
        /// <summary>
        /// EN: Gets Version.
        /// EN: Documentation for public API. JA: Version を取得します。
        /// </summary>

        public string Version => "0.0.2";
        /// <summary>
        /// EN: Executes GetCapabilities.
        /// EN: Documentation for public API. JA: GetCapabilities を実行します。
        /// </summary>

        public IProviderCapabilities GetCapabilities()
        {
            return new EmptyProviderCapabilities();
        }
        /// <summary>
        /// EN: Executes IsAvailableAsync.
        /// EN: Documentation for public API. JA: IsAvailableAsync を実行します。
        /// </summary>

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes ShutdownAsync.
        /// EN: Documentation for public API. JA: ShutdownAsync を実行します。
        /// </summary>

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes GetHealthAsync.
        /// EN: Documentation for public API. JA: GetHealthAsync を実行します。
        /// </summary>

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadOnlyList<MaterialContextDto>> SearchAsync(
            string query,
            int topK = 10,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<MaterialContextDto> results = [];
            return Task.FromResult(results);
        }
        /// <summary>
        /// EN: Gets IndexAsync.
        /// EN: Documentation for public API. JA: IndexAsync を取得します。
        /// </summary>

        public Task IndexAsync(
            string documentId,
            string content,
            IReadOnlyDictionary<string, string>? metadata = null,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task DeleteAsync(string documentId, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes ClearAsync.
        /// EN: Documentation for public API. JA: ClearAsync を実行します。
        /// </summary>

        public Task ClearAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }

    private sealed class TextOnlyModelProvider : ITextGenerationProvider
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(string.Empty);
        }
    }

    private sealed class FullModelProvider : FullProviderBase, IModelProvider
    {
        /// <summary>
        /// EN: Executes GenerateAsync.
        /// EN: Documentation for public API. JA: GenerateAsync を実行します。
        /// </summary>
        public Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(string.Empty);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task StreamGenerateAsync(
            IReadOnlyList<IModelMessage> messages,
            Func<string, Task> onChunk,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes AnswerAsync.
        /// EN: Documentation for public API. JA: AnswerAsync を実行します。
        /// </summary>

        public Task<string> AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(string.Empty);
        }
    }

    private sealed class SingleEmbeddingProvider : ITextEmbeddingProvider
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Array.Empty<float>());
        }
    }

    private sealed class FullEmbeddingProvider : FullProviderBase, IEmbeddingProvider
    {
        /// <summary>
        /// EN: Executes EmbedAsync.
        /// EN: Documentation for public API. JA: EmbedAsync を実行します。
        /// </summary>
        public Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Array.Empty<float>());
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadOnlyList<float[]>> EmbedBatchAsync(
            IReadOnlyList<string> texts,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<float[]> results = [];
            return Task.FromResult(results);
        }
        /// <summary>
        /// EN: Executes GetDimension.
        /// EN: Documentation for public API. JA: GetDimension を実行します。
        /// </summary>

        public int GetDimension()
        {
            return 0;
        }
    }

    private sealed class EmptyProviderCapabilities : IProviderCapabilities
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public IReadOnlyList<string> SupportedOperations => [];
        /// <summary>
        /// EN: Gets SupportedDataTypes.
        /// EN: Documentation for public API. JA: SupportedDataTypes を取得します。
        /// </summary>

        public IReadOnlyList<string> SupportedDataTypes => [];
        /// <summary>
        /// EN: Gets MaxConcurrentConnections.
        /// EN: Documentation for public API. JA: MaxConcurrentConnections を取得します。
        /// </summary>

        public int MaxConcurrentConnections => 1;
        /// <summary>
        /// EN: Gets RateLimit.
        /// EN: Documentation for public API. JA: RateLimit を取得します。
        /// </summary>

        public RateLimitInfo? RateLimit => null;
        /// <summary>
        /// EN: Executes Vector.
        /// EN: Documentation for public API. JA: Vector を実行します。
        /// </summary>

        public ModelCapacityVector Vector => new();
        /// <summary>
        /// EN: Executes GetDynamicCapacities.
        /// EN: Documentation for public API. JA: GetDynamicCapacities を実行します。
        /// </summary>

        public IDictionary<string, float>? GetDynamicCapacities(IExecutionConstraints constraints)
        {
            return null;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public ICapabilityProfile? GetCapabilityProfile()
        {
            return null;
        }
        /// <summary>
        /// EN: Executes SupportsOperation.
        /// EN: Documentation for public API. JA: SupportsOperation を実行します。
        /// </summary>

        public bool SupportsOperation(string operation)
        {
            return false;
        }
        /// <summary>
        /// EN: Executes SupportsDataType.
        /// EN: Documentation for public API. JA: SupportsDataType を実行します。
        /// </summary>

        public bool SupportsDataType(string dataType)
        {
            return false;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public bool SupportsQuantization(string quantizationLevel)
        {
            return false;
        }
        /// <summary>
        /// EN: Gets SupportsQueryAugmentation.
        /// EN: Documentation for public API. JA: SupportsQueryAugmentation を取得します。
        /// </summary>

        public bool SupportsQueryAugmentation => false;
        /// <summary>
        /// EN: Gets SupportsQueryDecomposition.
        /// EN: Documentation for public API. JA: SupportsQueryDecomposition を取得します。
        /// </summary>

        public bool SupportsQueryDecomposition => false;
        /// <summary>
        /// EN: Gets SupportsQueryRouting.
        /// EN: Documentation for public API. JA: SupportsQueryRouting を取得します。
        /// </summary>

        public bool SupportsQueryRouting => false;
        /// <summary>
        /// EN: Gets MaxQueryParts.
        /// EN: Documentation for public API. JA: MaxQueryParts を取得します。
        /// </summary>

        public int MaxQueryParts => 0;

        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public IReadOnlyList<string> SupportedQueryProcessingOperations => [];
        /// <summary>
        /// EN: Executes SupportsQueryProcessingOperation.
        /// EN: Documentation for public API. JA: SupportsQueryProcessingOperation を実行します。
        /// </summary>

        public bool SupportsQueryProcessingOperation(string operation)
        {
            return false;
        }
        /// <summary>
        /// EN: Gets SupportsEmbedding.
        /// EN: Documentation for public API. JA: SupportsEmbedding を取得します。
        /// </summary>

        public bool SupportsEmbedding => false;
        /// <summary>
        /// EN: Gets EmbeddingDimensions.
        /// EN: Documentation for public API. JA: EmbeddingDimensions を取得します。
        /// </summary>

        public int? EmbeddingDimensions => null;
        /// <summary>
        /// EN: Gets SupportedEmbeddingModels.
        /// EN: Documentation for public API. JA: SupportedEmbeddingModels を取得します。
        /// </summary>

        public IReadOnlyList<string> SupportedEmbeddingModels => [];
    }

    private sealed class StaticOperationCapabilities : IProviderOperationCapabilities
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public IReadOnlyList<string> SupportedOperations => [];
        /// <summary>
        /// EN: Gets SupportedDataTypes.
        /// EN: Documentation for public API. JA: SupportedDataTypes を取得します。
        /// </summary>

        public IReadOnlyList<string> SupportedDataTypes => [];
        /// <summary>
        /// EN: Executes SupportsOperation.
        /// EN: Documentation for public API. JA: SupportsOperation を実行します。
        /// </summary>

        public bool SupportsOperation(string operation)
        {
            return false;
        }
        /// <summary>
        /// EN: Executes SupportsDataType.
        /// EN: Documentation for public API. JA: SupportsDataType を実行します。
        /// </summary>

        public bool SupportsDataType(string dataType)
        {
            return false;
        }
    }

    private sealed class CacheReadOnlyRouter : IMaterialCacheReader
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey)
        {
            return Task.FromResult<MaterialContextDto?>(null);
        }
    }

    private sealed class FullProviderRouter : IProviderRouter
    {
        /// <summary>
        /// EN: Executes RetrieveAsync.
        /// EN: Documentation for public API. JA: RetrieveAsync を実行します。
        /// </summary>
        public Task<MaterialContextDto> RetrieveAsync(string source, string query)
        {
            return Task.FromResult<MaterialContextDto>(null!);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadOnlyList<MaterialContextDto>> RetrieveMultipleAsync(IReadOnlyList<string> sources, string query)
        {
            IReadOnlyList<MaterialContextDto> results = [];
            return Task.FromResult(results);
        }
        /// <summary>
        /// EN: Executes GetFromCacheAsync.
        /// EN: Documentation for public API. JA: GetFromCacheAsync を実行します。
        /// </summary>

        public Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey)
        {
            return Task.FromResult<MaterialContextDto?>(null);
        }
        /// <summary>
        /// EN: Executes CacheMaterialAsync.
        /// EN: Documentation for public API. JA: CacheMaterialAsync を実行します。
        /// </summary>

        public Task CacheMaterialAsync(string cacheKey, MaterialContextDto data)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public void RegisterProvider(string name, IProvider provider)
        {
        }
        /// <summary>
        /// EN: Executes UnregisterProvider.
        /// EN: Documentation for public API. JA: UnregisterProvider を実行します。
        /// </summary>

        public bool UnregisterProvider(string name)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes GetRegisteredProviders.
        /// EN: Documentation for public API. JA: GetRegisteredProviders を実行します。
        /// </summary>

        public IReadOnlyList<string> GetRegisteredProviders()
        {
            return [];
        }
    }

    private sealed class SubscriptionOnlyEventRegistry : IEventSubscriptionRegistry
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public string Subscribe<T>(string eventName, Func<T, Task> handler)
        {
            return "subscription";
        }
        /// <summary>
        /// EN: Executes Unsubscribe.
        /// EN: Documentation for public API. JA: Unsubscribe を実行します。
        /// </summary>

        public bool Unsubscribe(string subscriptionId)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes GetSubscriberCount.
        /// EN: Documentation for public API. JA: GetSubscriberCount を実行します。
        /// </summary>

        public int GetSubscriberCount(string eventName)
        {
            return 0;
        }
    }

    private sealed class FullEventBus : FullProviderBase, IEventBus
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task PublishAsync(string eventName, object eventData, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes BroadcastAsync.
        /// EN: Documentation for public API. JA: BroadcastAsync を実行します。
        /// </summary>

        public Task BroadcastAsync(string eventName, object eventData, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes Subscribe&lt;T&gt;.
        /// EN: Documentation for public API. JA: Subscribe&lt;T&gt; を実行します。
        /// </summary>

        public string Subscribe<T>(string eventName, Func<T, Task> handler)
        {
            return "subscription";
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public bool Unsubscribe(string subscriptionId)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes GetSubscriberCount.
        /// EN: Documentation for public API. JA: GetSubscriberCount を実行します。
        /// </summary>

        public int GetSubscriberCount(string eventName)
        {
            return 0;
        }
    }

    private abstract class FullProviderBase : IProvider
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string ProviderId => "provider";
        /// <summary>
        /// EN: Gets Name.
        /// EN: Documentation for public API. JA: Name を取得します。
        /// </summary>

        public string Name => "Provider";
        /// <summary>
        /// EN: Gets Version.
        /// EN: Documentation for public API. JA: Version を取得します。
        /// </summary>

        public string Version => "0.0.2";
        /// <summary>
        /// EN: Executes GetCapabilities.
        /// EN: Documentation for public API. JA: GetCapabilities を実行します。
        /// </summary>

        public IProviderCapabilities GetCapabilities()
        {
            return new EmptyProviderCapabilities();
        }
        /// <summary>
        /// EN: Executes IsAvailableAsync.
        /// EN: Documentation for public API. JA: IsAvailableAsync を実行します。
        /// </summary>

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes ShutdownAsync.
        /// EN: Documentation for public API. JA: ShutdownAsync を実行します。
        /// </summary>

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes GetHealthAsync.
        /// EN: Documentation for public API. JA: GetHealthAsync を実行します。
        /// </summary>

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }
    }
}
