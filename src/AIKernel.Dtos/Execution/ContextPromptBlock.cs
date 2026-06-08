namespace AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ContextPromptBlock']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ContextPromptBlock']" />
public sealed record ContextPromptBlock(
    string Id,
    string Category,
    string Content,
    int Priority,
    IReadOnlyDictionary<string, string> Metadata);
