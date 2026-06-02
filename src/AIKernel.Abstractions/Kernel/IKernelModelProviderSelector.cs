namespace AIKernel.Abstractions.Kernel;

using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Providers;
using AIKernel.Dtos.Kernel;

public interface IKernelModelProviderSelector
{
    Task<IModelProvider> SelectAsync(
        KernelRequest request,
        IContextSnapshot contextSnapshot,
        CancellationToken cancellationToken = default);
}