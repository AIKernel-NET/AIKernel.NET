namespace AIKernel.Dtos.Execution;

public sealed record ExecutionOptions
{
    public required double Temperature { get; init; }

    public required double TopP { get; init; }

    public required int? MaxOutputTokens { get; init; }

    public required IReadOnlyList<string> StopSequences { get; init; }
}
