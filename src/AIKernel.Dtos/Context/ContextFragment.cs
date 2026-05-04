namespace AIKernel.Dtos.Context;

using AIKernel.Enums;

public class ContextFragment
{
    public string FragmentId { get; init; } = string.Empty;
    public ContextCategory Category { get; init; }
    public string Content { get; init; } = string.Empty;
    public double Priority { get; init; } = 0.5;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}
