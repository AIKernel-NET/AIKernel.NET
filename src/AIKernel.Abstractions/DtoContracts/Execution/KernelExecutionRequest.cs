namespace AIKernel.Dtos.Execution;

using AIKernel.Abstractions.Context;

public sealed record KernelExecutionRequest
{
    public required IContextSnapshot ContextSnapshot { get; init; }

    public required string UserInstruction { get; init; }

    public required PromptGenerationOptions PromptOptions { get; init; }

    public required ExecutionOptions ExecutionOptions { get; init; }

    public string? RequestedModelId { get; init; }
}
