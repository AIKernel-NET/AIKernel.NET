namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// EN: UC-14 に基づく IKernelModule の契約を定義します。
/// EN: Documentation for public API. JA: IKernelModule の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelModule']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelModule']" />
public interface IKernelModule
{
    /// <summary>EN: Gets the ModuleName value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ModuleName 値を取得します。</summary>
    string ModuleName { get; }
    /// <summary>EN: Executes the ConfigureServices operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ConfigureServices 操作を実行します。</summary>
    void ConfigureServices(IServiceRegistrar registrar);
    /// <summary>EN: Executes the ConfigureProviders operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ConfigureProviders 操作を実行します。</summary>
    void ConfigureProviders(IProviderRegistrar registrar);
}



