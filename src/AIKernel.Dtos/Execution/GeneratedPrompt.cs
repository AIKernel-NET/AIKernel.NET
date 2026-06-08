namespace AIKernel.Dtos.Execution;

using System.Collections.Immutable;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.GeneratedPrompt']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.GeneratedPrompt']" />
public sealed record GeneratedPrompt
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptId']" />
    public required string PromptId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.PromptHash']" />
    public required string PromptHash { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextSnapshotId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextSnapshotId']" />
    public required string ContextSnapshotId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.ContextHash']" />
    public required string ContextHash { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Capability']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Capability']" />
    public required ModelPromptCapability Capability { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Messages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.Messages']" />
    public required ImmutableArray<ModelMessage> Messages { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.EstimatedInputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.EstimatedInputTokens']" />
    public required int EstimatedInputTokens { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.GeneratedPrompt.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
