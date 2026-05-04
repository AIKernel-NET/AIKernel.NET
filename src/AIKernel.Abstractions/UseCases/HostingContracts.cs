namespace AIKernel.Abstractions.UseCases;

public interface IKernelContext
{
    string ContextId { get; }
    UnifiedContextDto? Contract { get; }
    DateTimeOffset CreatedAtUtc { get; }
    IReadOnlyDictionary<string, string> Attributes { get; }
}

public interface IServiceRegistrar
{
    void AddSingleton<TService, TImplementation>() where TImplementation : class, TService where TService : class;
    void AddScoped<TService, TImplementation>() where TImplementation : class, TService where TService : class;
    void AddTransient<TService, TImplementation>() where TImplementation : class, TService where TService : class;
}

public interface IProviderRegistrar
{
    void Register(string providerId, Func<IProvider> factory);
    bool TryResolve(string providerId, out IProvider? provider);
    IReadOnlyList<string> GetRegisteredIds();
}

public interface IKernelModule
{
    string ModuleName { get; }
    void ConfigureServices(IServiceRegistrar registrar);
    void ConfigureProviders(IProviderRegistrar registrar);
}

public interface IKernelHost
{
    Task StartAsync(CancellationToken ct = default);
    Task StopAsync(CancellationToken ct = default);
    IKernel ResolveKernel();
}
