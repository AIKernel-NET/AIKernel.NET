using AIKernel.Abstractions.Capabilities;
using AIKernel.Providers.LocalLlm;

namespace AIKernel.Integration.LocalLlm;

/// <summary>Owns the frozen provider and invoker for the lifetime of a host registration.</summary>
public sealed class LocalLlmRegistration : IAsyncDisposable
{
    /// <summary>The ID declared by the frozen provider manifest.</summary>
    public const string CapabilityId = "local-llm";

    private readonly LocalLlmProvider _provider;
    private readonly LocalLlmInvoker _invoker;
    private volatile bool _closing;

    private LocalLlmRegistration(LocalLlmSettings settings)
    {
        _provider = new LocalLlmProvider(settings with { ProviderId = CapabilityId });
        _invoker = _provider.CreateInvoker();
    }

    /// <summary>Initializes the provider and registers its shared descriptor under the manifest ID.</summary>
    public static Task<LocalLlmRegistration> RegisterAsync(
        LocalLlmSettings settings, ICapabilityModuleRegistry registry, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(settings);
        ArgumentNullException.ThrowIfNull(registry);
        cancellationToken.ThrowIfCancellationRequested();

        return new LocalLlmRegistration(settings).RegisterDescriptorAsync(registry, cancellationToken);
    }

    private async Task<LocalLlmRegistration> RegisterDescriptorAsync(
        ICapabilityModuleRegistry registry, CancellationToken cancellationToken)
    {
        try
        {
            await _provider.InitializeAsync().ConfigureAwait(false);
#if AIKERNEL_HISTORICAL_CONTRACTS
            var descriptor = _provider.ToCapabilityDescriptor();
#else
            AIKernel.Abstractions.Providers.IProviderCapabilitySource source = _provider;
            var descriptor = source.ToCapabilityDescriptor()
                ?? throw new InvalidOperationException("LocalLlm did not supply its registration descriptor.");
#endif
            await registry.RegisterAsync(descriptor, cancellationToken).ConfigureAwait(false);
            return this;
        }
        catch
        {
            await DisposeAsync().ConfigureAwait(false);
            throw;
        }
    }

    /// <summary>Returns the shared invoker for this ID while the registration is open.</summary>
    public ICapabilityModuleInvoker? ResolveInvoker(string capabilityId) =>
        !_closing && string.Equals(capabilityId, CapabilityId, StringComparison.Ordinal) ? _invoker : null;

    /// <summary>Stops resolving new calls and drains active generation before shutting down the provider.</summary>
    public async ValueTask DisposeAsync()
    {
        _closing = true;
        _invoker.Dispose();
        await _provider.ShutdownAsync().ConfigureAwait(false);
    }
}
