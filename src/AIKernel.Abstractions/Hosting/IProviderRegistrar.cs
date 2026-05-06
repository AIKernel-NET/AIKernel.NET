namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IProviderRegistrar の契約を定義します。
/// </summary>
public interface IProviderRegistrar
{
    void Register(string providerId, Func<IProvider> factory);
    bool TryResolve(string providerId, out IProvider? provider);
    IReadOnlyList<string> GetRegisteredIds();
}



