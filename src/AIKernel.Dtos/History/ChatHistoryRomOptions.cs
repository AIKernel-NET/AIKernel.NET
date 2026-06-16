namespace AIKernel.Dtos.History;

/// <summary>[EN] Documents this public package API member. [JA] ChatHistoryRomOptions を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.ChatHistoryRomOptions']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.ChatHistoryRomOptions']" />
public sealed record ChatHistoryRomOptions(
    string RomId,
    DateTimeOffset GeneratedAtUtc,
    string EntityType = "conversation",
    string Version = "1",
    IReadOnlyList<string>? SecurityTags = null);
