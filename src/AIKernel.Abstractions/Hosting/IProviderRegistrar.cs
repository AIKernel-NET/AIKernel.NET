namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IProviderRegistrar の契約を定義します。
/// JA: IProviderRegistrar の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IProviderRegistrar']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IProviderRegistrar']" />
public interface IProviderRegistrar
{
    /// <summary>Executes the Register operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Register 操作を実行します。</summary>
    void Register(string providerId, Func<IProvider> factory);
    /// <summary>Executes the TryResolve operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで TryResolve 操作を実行します。</summary>
    bool TryResolve(string providerId, out IProvider? provider);
    /// <summary>Executes the GetRegisteredIds operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetRegisteredIds 操作を実行します。</summary>
    IReadOnlyList<string> GetRegisteredIds();
}



