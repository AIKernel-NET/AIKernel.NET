namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Providers;
using AIKernel.Dtos.Execution;

public interface IKernelExecutor
{
    Task<KernelRequestExecutionResult> ExecuteAsync(
        IModelProvider provider,
        KernelExecutionRequest request,
        CancellationToken cancellationToken = default);
}
