namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IKernelModule の契約を定義します。
/// </summary>
public interface IKernelModule
{
    string ModuleName { get; }
    void ConfigureServices(IServiceRegistrar registrar);
    void ConfigureProviders(IProviderRegistrar registrar);
}



