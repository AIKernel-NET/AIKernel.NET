namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IServiceRegistrar の契約を定義します。
/// </summary>
public interface IServiceRegistrar
{
    void AddSingleton<TService, TImplementation>() where TImplementation : class, TService where TService : class;
    void AddScoped<TService, TImplementation>() where TImplementation : class, TService where TService : class;
    void AddTransient<TService, TImplementation>() where TImplementation : class, TService where TService : class;
}



