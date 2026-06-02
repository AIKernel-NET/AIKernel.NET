namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Providers;
using AIKernel.Dtos.Execution;

public interface IModelPromptCapabilityResolver
{
    ModelPromptCapability Resolve(
        IModelProvider provider,
        KernelExecutionRequest request);
}
