namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// EN: UC-14 に基づく IKernelHost の契約を定義します。
/// EN: Documentation for public API. JA: IKernelHost の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelHost']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelHost']" />
public interface IKernelHost
{
    /// <summary>EN: Executes the StartAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで StartAsync 操作を実行します。</summary>
    Task StartAsync(CancellationToken ct = default);
    /// <summary>EN: Executes the StopAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで StopAsync 操作を実行します。</summary>
    Task StopAsync(CancellationToken ct = default);
    /// <summary>EN: Executes the ResolveKernel operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveKernel 操作を実行します。</summary>
    IKernel ResolveKernel();
}



