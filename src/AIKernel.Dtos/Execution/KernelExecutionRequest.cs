namespace AIKernel.Dtos.Execution;

public sealed record KernelExecutionRequest
{
    public required string ContextSnapshotId { get; init; }

    public required string ContextHash { get; init; }

    public required IReadOnlyList<ContextPromptBlock> ContextBlocks { get; init; }

    public required string UserInstruction { get; init; }

    public required PromptGenerationOptions PromptOptions { get; init; }

    public required ExecutionOptions ExecutionOptions { get; init; }

    public string? RequestedModelId { get; init; }
}
