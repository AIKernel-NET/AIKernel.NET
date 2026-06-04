namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;
using AIKernel.Vfs;

public interface IHistoryRomStore
{
    Task<HistoryRomMetadata> SaveHistoryAsRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        IReadOnlyList<ChatHistoryRomRecord> records,
        DateTimeOffset generatedAtUtc,
        string entityType = "conversation",
        string version = "1",
        IReadOnlyList<string>? securityTags = null,
        CancellationToken cancellationToken = default);

    Task<HistoryRomMetadata> SaveMarkdownAsRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        string markdown,
        DateTimeOffset createdAtUtc,
        CancellationToken cancellationToken = default);

    Task<HistoryRomMetadata> LoadHistoryRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        DateTimeOffset createdAtUtc,
        string? expectedRomHash = null,
        CancellationToken cancellationToken = default);
}
