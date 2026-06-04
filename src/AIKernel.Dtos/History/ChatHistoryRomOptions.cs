namespace AIKernel.Dtos.History;

public sealed record ChatHistoryRomOptions(
    string RomId,
    DateTimeOffset GeneratedAtUtc,
    string EntityType = "conversation",
    string Version = "1",
    IReadOnlyList<string>? SecurityTags = null);
