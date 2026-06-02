namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;
using AIKernel.Vfs;

public interface IKernelVfsSessionFactory
{
    Task<IVfsSession> OpenSessionAsync(
        KernelRequest request,
        CancellationToken cancellationToken = default);
}