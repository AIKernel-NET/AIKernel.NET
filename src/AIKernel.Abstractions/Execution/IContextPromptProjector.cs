namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Context;
using AIKernel.Dtos.Execution;

public interface IContextPromptProjector
{
    IReadOnlyList<ContextPromptBlock> Project(
        IContextSnapshot snapshot,
        PromptProjectionOptions options);
}
