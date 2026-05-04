namespace AIKernel.Abstractions.Execution;

public sealed record ModificationContext
{
    public required string Reason { get; init; }
    public required string TargetPhase { get; init; }
    public required string ModificationData { get; init; }
    public required string ModifiedBy { get; init; }
}
