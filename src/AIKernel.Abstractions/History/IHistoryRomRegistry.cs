namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;

public interface IHistoryRomRegistry
{
    Task<HistoryRomMetadata> RegisterAsync(
        HistoryRomSnapshot snapshot,
        CancellationToken cancellationToken = default);

    bool Contains(string romId);

    Task<HistoryRomSnapshot> ResolveAsync(
        string romId,
        CancellationToken cancellationToken = default);
}
