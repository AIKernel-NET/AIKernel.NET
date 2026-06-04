namespace AIKernel.Dtos.Execution;

using AIKernel.Enums;

public sealed record PromptGenerationOptions
{
    public required PromptOverflowPolicy OverflowPolicy { get; init; }

    public required bool IncludeContextHash { get; init; }

    public required bool IncludeSourceMetadata { get; init; }
}
