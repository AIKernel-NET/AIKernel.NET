namespace AIKernel.Dtos.History;

using AIKernel.Dtos.Rom;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.HistoryRomSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.HistoryRomSnapshot']" />
public sealed record HistoryRomSnapshot(
    HistoryRomMetadata Metadata,
    string Markdown,
    RomSnapshot Rom);
