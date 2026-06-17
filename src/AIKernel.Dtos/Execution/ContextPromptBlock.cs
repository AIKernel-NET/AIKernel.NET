namespace AIKernel.Dtos.Execution;

/// <summary>[EN] Documents this public package API member. [JA] ContextPromptBlock を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ContextPromptBlock']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ContextPromptBlock']" />
public sealed record ContextPromptBlock(
    string Id,
    string Category,
    string Content,
    int Priority,
    IReadOnlyDictionary<string, string> Metadata);
