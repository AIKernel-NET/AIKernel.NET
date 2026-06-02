namespace AIKernel.Abstractions.Execution;

using AIKernel.Dtos.Execution;

public interface IPromptGenerator
{
    Task<GeneratedPrompt> GenerateAsync(
        PromptGenerationRequest request,
        CancellationToken cancellationToken = default);
}
