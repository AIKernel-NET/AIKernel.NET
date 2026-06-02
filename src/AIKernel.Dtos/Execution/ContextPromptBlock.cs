namespace AIKernel.Dtos.Execution;

public sealed record ContextPromptBlock(
    string Id,
    string Category,
    string Content,
    int Priority,
    IReadOnlyDictionary<string, string> Metadata);
