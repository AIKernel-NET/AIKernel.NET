namespace AIKernel.Dtos.Vfs;

public sealed record LogEntry
{
    public required string Level { get; init; }
    public required string Message { get; init; }
    public required DateTime Timestamp { get; init; }
    public string? Source { get; init; }
    public IReadOnlyDictionary<string, string>? Context { get; init; }
}
