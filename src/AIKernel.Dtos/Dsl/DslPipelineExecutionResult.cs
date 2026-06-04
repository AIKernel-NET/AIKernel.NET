namespace AIKernel.Dtos.Dsl;

using System.Collections.Immutable;
using AIKernel.Dtos.Execution;

public sealed record DslPipelineExecutionResult
{
    public required ExecutionStatus Status { get; init; }

    public required DslPipelineState State { get; init; }

    public required DslPipelineValue Output { get; init; }

    public required ExecutionError? Error { get; init; }

    public required int ReplayLogCount { get; init; }

    public required string ReplayLogHash { get; init; }

    public ImmutableDictionary<string, string> Metadata { get; init; } =
        ImmutableDictionary<string, string>.Empty;
}
