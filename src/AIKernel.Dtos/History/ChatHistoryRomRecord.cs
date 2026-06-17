namespace AIKernel.Dtos.History;

/// <summary>[EN] Documents this public package API member. [JA] ChatHistoryRomRecord を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.ChatHistoryRomRecord']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.ChatHistoryRomRecord']" />
public sealed record ChatHistoryRomRecord(
    string Role,
    string Content,
    DateTimeOffset Timestamp);
