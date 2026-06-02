namespace AIKernel.Dtos.Execution;

public sealed record PromptGenerationOptions
{
    public static PromptGenerationOptions Default { get; } = new()
    {
        OverflowPolicy = PromptOverflowPolicy.FailClosed,
        IncludeContextHash = true,
        IncludeSourceMetadata = true
    };

    public required PromptOverflowPolicy OverflowPolicy { get; init; }

    public required bool IncludeContextHash { get; init; }

    public required bool IncludeSourceMetadata { get; init; }
}
