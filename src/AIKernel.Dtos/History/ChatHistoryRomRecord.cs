namespace AIKernel.Dtos.History;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.ChatHistoryRomRecord']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.ChatHistoryRomRecord']" />
public sealed record ChatHistoryRomRecord(
    string Role,
    string Content,
    DateTimeOffset Timestamp);
