namespace AIKernel.Dtos.Execution;

public sealed record ReplayDump
{
    public required string DumpId { get; init; }
    public required ExecutionResult OriginalResult { get; init; }
    public required RawLogic StructureOutput { get; init; }
    public required string GenerationOutput { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required HashChain HashChain { get; init; }
}

