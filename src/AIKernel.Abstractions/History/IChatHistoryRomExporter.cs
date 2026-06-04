namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;

public interface IChatHistoryRomExporter
{
    Task<string> ToRomMarkdownAsync(
        IReadOnlyList<ChatHistoryRomRecord> records,
        ChatHistoryRomOptions options,
        CancellationToken cancellationToken = default);
}
