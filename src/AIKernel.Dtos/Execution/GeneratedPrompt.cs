namespace AIKernel.Dtos.Execution;

using System.Collections.Immutable;

/// <summary>[EN] Documents this public package API member. [JA] GeneratedPrompt を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.GeneratedPrompt']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.GeneratedPrompt']" />
public sealed record GeneratedPrompt
{
    /// <summary>[EN] Documents this public package API member. [JA] PromptId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptId']" />
    public required string PromptId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] PromptHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptHash']" />
    public required string PromptHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ContextSnapshotId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextSnapshotId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextSnapshotId']" />
    public required string ContextSnapshotId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ContextHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextHash']" />
    public required string ContextHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Capability を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Capability']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Capability']" />
    public required ModelPromptCapability Capability { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Messages を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Messages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Messages']" />
    public required ImmutableArray<ModelMessage> Messages { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] EstimatedInputTokens を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.EstimatedInputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.EstimatedInputTokens']" />
    public required int EstimatedInputTokens { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
