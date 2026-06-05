namespace AIKernel.Abstractions.Capabilities;

using AIKernel.Dtos.Capabilities;

public interface ICapabilityModuleInvoker
{
    ValueTask<CapabilityInvocationResult> InvokeAsync(
        CapabilityInvocationRequest request,
        CancellationToken cancellationToken = default);
}
