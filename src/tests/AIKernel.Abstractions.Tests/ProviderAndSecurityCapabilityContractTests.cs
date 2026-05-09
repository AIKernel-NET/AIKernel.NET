using AIKernel.Abstractions.Models;
using AIKernel.Abstractions.Events;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Query;
using AIKernel.Abstractions.Security;
using AIKernel.Abstractions.Tooling;
using AIKernel.Dtos.Query;

namespace AIKernel.Abstractions.Tests;

public sealed class ProviderAndSecurityCapabilityContractTests
{
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
    public void ReadOnlyRagProviderDoesNotExposeIndexMutationCapabilities()
    {
        IRagSearchProvider provider = new SearchOnlyRagProvider();

        Assert.False(provider is IRagIndexWriter);
        Assert.False(provider is IRagIndexDeleter);
        Assert.False(provider is IRagIndexManager);
    }

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
    public void CompositeModelProviderExposesGranularModelCapabilities()
    {
        IModelProvider provider = new FullModelProvider();

        Assert.IsAssignableFrom<IProvider>(provider);
        Assert.IsAssignableFrom<ITextGenerationProvider>(provider);
        Assert.IsAssignableFrom<IStreamingGenerationProvider>(provider);
        Assert.IsAssignableFrom<IQuestionAnsweringProvider>(provider);
    }

    [Fact]
    public void TextOnlyModelProviderDoesNotExposeStreamingOrQuestionAnswering()
    {
        ITextGenerationProvider provider = new TextOnlyModelProvider();

        Assert.False(provider is IStreamingGenerationProvider);
        Assert.False(provider is IQuestionAnsweringProvider);
    }

    [Fact]
    public void CompositeEmbeddingProviderExposesGranularEmbeddingCapabilities()
    {
        IEmbeddingProvider provider = new FullEmbeddingProvider();

        Assert.IsAssignableFrom<IProvider>(provider);
        Assert.IsAssignableFrom<ITextEmbeddingProvider>(provider);
        Assert.IsAssignableFrom<IBatchEmbeddingProvider>(provider);
        Assert.IsAssignableFrom<IEmbeddingDimensionProvider>(provider);
    }

    [Fact]
    public void SingleEmbeddingProviderDoesNotExposeBatchCapability()
    {
        ITextEmbeddingProvider provider = new SingleEmbeddingProvider();

        Assert.False(provider is IBatchEmbeddingProvider);
        Assert.False(provider is IEmbeddingDimensionProvider);
    }

    [Fact]
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
    public void CompositeProviderRouterExposesGranularRoutingCapabilities()
    {
        IProviderRouter router = new FullProviderRouter();

        Assert.IsAssignableFrom<IProviderMaterialRetriever>(router);
        Assert.IsAssignableFrom<IMaterialCacheReader>(router);
        Assert.IsAssignableFrom<IMaterialCacheWriter>(router);
        Assert.IsAssignableFrom<IProviderRegistry>(router);
    }

    [Fact]
    public void CacheReadOnlyRouterDoesNotExposeCacheMutationOrRegistryCapabilities()
    {
        IMaterialCacheReader cacheReader = new CacheReadOnlyRouter();

        Assert.False(cacheReader is IMaterialCacheWriter);
        Assert.False(cacheReader is IProviderRegistry);
    }

    [Fact]
    public void CompositeEventBusExposesGranularEventCapabilities()
    {
        IEventBus eventBus = new FullEventBus();

        Assert.IsAssignableFrom<IProvider>(eventBus);
        Assert.IsAssignableFrom<IEventPublisher>(eventBus);
        Assert.IsAssignableFrom<IEventBroadcaster>(eventBus);
        Assert.IsAssignableFrom<IEventSubscriptionRegistry>(eventBus);
    }

    [Fact]
    public void SubscriptionOnlyEventRegistryDoesNotExposePublishCapabilities()
    {
        IEventSubscriptionRegistry registry = new SubscriptionOnlyEventRegistry();

        Assert.False(registry is IEventPublisher);
        Assert.False(registry is IEventBroadcaster);
    }

    private sealed class FullToolAccessValidator : IToolAccessValidator
    {
        public bool CanExecuteTool(IToolPermission permission, string toolName)
        {
            return true;
        }

        public bool CanReadFile(IToolPermission permission, string filePath)
        {
            return true;
        }

        public bool CanWriteFile(IToolPermission permission, string filePath)
        {
            return true;
        }

        public bool CanAccessNetwork(IToolPermission permission, string host)
        {
            return true;
        }

        public bool CanAccessEnvironment(IToolPermission permission, string variableName)
        {
            return true;
        }

        public bool CanExecuteSystemCommand(IToolPermission permission, string commandName)
        {
            return true;
        }

        public bool IsPermissionValid(IToolPermission permission)
        {
            return true;
        }

        public bool ValidateConstraints(IToolPermission permission, IReadOnlyDictionary<string, string> context)
        {
            return true;
        }
    }

    private sealed class SearchOnlyRagProvider : IRagSearchProvider
    {
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
        public string ProviderId => "full-rag";

        public string Name => "Full RAG";

        public string Version => "0.0.2";

        public IProviderCapabilities GetCapabilities()
        {
            return new EmptyProviderCapabilities();
        }

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }

        public Task<IReadOnlyList<MaterialContextDto>> SearchAsync(
            string query,
            int topK = 10,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<MaterialContextDto> results = [];
            return Task.FromResult(results);
        }

        public Task IndexAsync(
            string documentId,
            string content,
            IReadOnlyDictionary<string, string>? metadata = null,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string documentId, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task ClearAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }

    private sealed class TextOnlyModelProvider : ITextGenerationProvider
    {
        public Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(string.Empty);
        }
    }

    private sealed class FullModelProvider : FullProviderBase, IModelProvider
    {
        public Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(string.Empty);
        }

        public Task StreamGenerateAsync(
            IReadOnlyList<IModelMessage> messages,
            Func<string, Task> onChunk,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<string> AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(string.Empty);
        }
    }

    private sealed class SingleEmbeddingProvider : ITextEmbeddingProvider
    {
        public Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Array.Empty<float>());
        }
    }

    private sealed class FullEmbeddingProvider : FullProviderBase, IEmbeddingProvider
    {
        public Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Array.Empty<float>());
        }

        public Task<IReadOnlyList<float[]>> EmbedBatchAsync(
            IReadOnlyList<string> texts,
            CancellationToken cancellationToken = default)
        {
            IReadOnlyList<float[]> results = [];
            return Task.FromResult(results);
        }

        public int GetDimension()
        {
            return 0;
        }
    }

    private sealed class EmptyProviderCapabilities : IProviderCapabilities
    {
        public IReadOnlyList<string> SupportedOperations => [];

        public IReadOnlyList<string> SupportedDataTypes => [];

        public int MaxConcurrentConnections => 1;

        public RateLimitInfo? RateLimit => null;

        public ModelCapacityVector Vector => new();

        public IDictionary<string, float>? GetDynamicCapacities(IExecutionConstraints constraints)
        {
            return null;
        }

        public ICapabilityProfile? GetCapabilityProfile()
        {
            return null;
        }

        public bool SupportsOperation(string operation)
        {
            return false;
        }

        public bool SupportsDataType(string dataType)
        {
            return false;
        }

        public bool SupportsQuantization(string quantizationLevel)
        {
            return false;
        }

        public bool SupportsQueryAugmentation => false;

        public bool SupportsQueryDecomposition => false;

        public bool SupportsQueryRouting => false;

        public int MaxQueryParts => 0;

        public IReadOnlyList<string> SupportedQueryProcessingOperations => [];

        public bool SupportsQueryProcessingOperation(string operation)
        {
            return false;
        }

        public bool SupportsEmbedding => false;

        public int? EmbeddingDimensions => null;

        public IReadOnlyList<string> SupportedEmbeddingModels => [];
    }

    private sealed class StaticOperationCapabilities : IProviderOperationCapabilities
    {
        public IReadOnlyList<string> SupportedOperations => [];

        public IReadOnlyList<string> SupportedDataTypes => [];

        public bool SupportsOperation(string operation)
        {
            return false;
        }

        public bool SupportsDataType(string dataType)
        {
            return false;
        }
    }

    private sealed class CacheReadOnlyRouter : IMaterialCacheReader
    {
        public Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey)
        {
            return Task.FromResult<MaterialContextDto?>(null);
        }
    }

    private sealed class FullProviderRouter : IProviderRouter
    {
        public Task<MaterialContextDto> RetrieveAsync(string source, string query)
        {
            return Task.FromResult<MaterialContextDto>(null!);
        }

        public Task<IReadOnlyList<MaterialContextDto>> RetrieveMultipleAsync(IReadOnlyList<string> sources, string query)
        {
            IReadOnlyList<MaterialContextDto> results = [];
            return Task.FromResult(results);
        }

        public Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey)
        {
            return Task.FromResult<MaterialContextDto?>(null);
        }

        public Task CacheMaterialAsync(string cacheKey, MaterialContextDto data)
        {
            return Task.CompletedTask;
        }

        public void RegisterProvider(string name, IProvider provider)
        {
        }

        public bool UnregisterProvider(string name)
        {
            return true;
        }

        public IReadOnlyList<string> GetRegisteredProviders()
        {
            return [];
        }
    }

    private sealed class SubscriptionOnlyEventRegistry : IEventSubscriptionRegistry
    {
        public string Subscribe<T>(string eventName, Func<T, Task> handler)
        {
            return "subscription";
        }

        public bool Unsubscribe(string subscriptionId)
        {
            return true;
        }

        public int GetSubscriberCount(string eventName)
        {
            return 0;
        }
    }

    private sealed class FullEventBus : FullProviderBase, IEventBus
    {
        public Task PublishAsync(string eventName, object eventData, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task BroadcastAsync(string eventName, object eventData, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public string Subscribe<T>(string eventName, Func<T, Task> handler)
        {
            return "subscription";
        }

        public bool Unsubscribe(string subscriptionId)
        {
            return true;
        }

        public int GetSubscriberCount(string eventName)
        {
            return 0;
        }
    }

    private abstract class FullProviderBase : IProvider
    {
        public string ProviderId => "provider";

        public string Name => "Provider";

        public string Version => "0.0.2";

        public IProviderCapabilities GetCapabilities()
        {
            return new EmptyProviderCapabilities();
        }

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }
    }
}
