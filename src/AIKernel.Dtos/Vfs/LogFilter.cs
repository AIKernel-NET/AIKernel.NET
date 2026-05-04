namespace AIKernel.Dtos.Vfs;

public sealed record LogFilter
{
    public DateTime? StartTime { get; init; }
    public DateTime? EndTime { get; init; }
    public IReadOnlyList<string>? Levels { get; init; }
    public string? MessageContains { get; init; }
    public string? Source { get; init; }
    public int Limit { get; init; } = 1000;
}
