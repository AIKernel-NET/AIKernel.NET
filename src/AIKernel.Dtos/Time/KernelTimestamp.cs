namespace AIKernel.Dtos.Time;

/// <summary>
/// Represents an AIKernel logical timestamp without binding callers to a concrete clock implementation.
/// </summary>
public sealed record KernelTimestamp
{
    public required DateTimeOffset UtcDateTime { get; init; }

    public long? LogicalCounter { get; init; }

    public string? SourceId { get; init; }

    public string? Signature { get; init; }
}
