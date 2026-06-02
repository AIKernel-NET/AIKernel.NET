namespace AIKernel.Dtos.Execution;

public sealed record ExecutionOptions
{
    public static ExecutionOptions DeterministicDefault { get; } = new()
    {
        Temperature = 0.0,
        TopP = 1.0,
        MaxOutputTokens = null,
        StopSequences = Array.Empty<string>()
    };

    public required double Temperature { get; init; }

    public required double TopP { get; init; }

    public required int? MaxOutputTokens { get; init; }

    public required IReadOnlyList<string> StopSequences { get; init; }
}
