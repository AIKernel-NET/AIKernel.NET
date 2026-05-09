using AIKernel.Abstractions.Models;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Security;
using AIKernel.Abstractions.Tooling;

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
}
