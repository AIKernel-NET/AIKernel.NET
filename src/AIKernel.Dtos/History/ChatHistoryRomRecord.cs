namespace AIKernel.Dtos.History;

public sealed record ChatHistoryRomRecord(
    string Role,
    string Content,
    DateTimeOffset Timestamp);
