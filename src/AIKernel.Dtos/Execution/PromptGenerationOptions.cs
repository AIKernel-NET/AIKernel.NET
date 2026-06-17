namespace AIKernel.Dtos.Execution;

using AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] PromptGenerationOptions を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PromptGenerationOptions']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PromptGenerationOptions']" />
public sealed record PromptGenerationOptions
{
    /// <summary>[EN] Documents this public package API member. [JA] OverflowPolicy を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PromptGenerationOptions.OverflowPolicy']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PromptGenerationOptions.OverflowPolicy']" />
    public required PromptOverflowPolicy OverflowPolicy { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] IncludeContextHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PromptGenerationOptions.IncludeContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PromptGenerationOptions.IncludeContextHash']" />
    public required bool IncludeContextHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] IncludeSourceMetadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PromptGenerationOptions.IncludeSourceMetadata']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PromptGenerationOptions.IncludeSourceMetadata']" />
    public required bool IncludeSourceMetadata { get; init; }
}
