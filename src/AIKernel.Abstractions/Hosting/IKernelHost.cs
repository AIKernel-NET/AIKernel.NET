namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IKernelHost の契約を定義します。
/// </summary>
public interface IKernelHost
{
    Task StartAsync(CancellationToken ct = default);
    Task StopAsync(CancellationToken ct = default);
    IKernel ResolveKernel();
}



