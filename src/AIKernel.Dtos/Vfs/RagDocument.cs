namespace AIKernel.Dtos.Vfs;

public sealed record RagDocument
{
    public required string DocumentId { get; init; }
    public string? Title { get; init; }
    public required string Content { get; init; }
    public string? Source { get; init; }
    public double RelevanceScore { get; init; }
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}
