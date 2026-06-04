namespace AIKernel.Dtos.History;

using AIKernel.Dtos.Rom;

public sealed record HistoryRomSnapshot(
    HistoryRomMetadata Metadata,
    string Markdown,
    RomSnapshot Rom);
