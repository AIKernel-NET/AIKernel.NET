namespace AIKernel.Dtos.Execution;

using AIKernel.Enums;
using System.Collections.Immutable;

/// <summary>[EN] Documents this public package API member. [JA] ModelPromptCapability を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModelPromptCapability']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModelPromptCapability']" />
public sealed record ModelPromptCapability
{
    /// <summary>[EN] Documents this public package API member. [JA] ProviderId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ProviderId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ProviderId']" />
    public required string ProviderId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ModelId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ModelId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ModelId']" />
    public required string ModelId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] MessageFormat を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MessageFormat']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MessageFormat']" />
    public PromptMessageFormat MessageFormat { get; init; } = PromptMessageFormat.ChatMessages;

    /// <summary>[EN] Documents this public package API member. [JA] MaxInputTokens を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxInputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxInputTokens']" />
    public int MaxInputTokens { get; init; } = 8192;

    /// <summary>[EN] Documents this public package API member. [JA] MaxOutputTokens を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxOutputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxOutputTokens']" />
    public int MaxOutputTokens { get; init; } = 1024;

    /// <summary>[EN] Documents this public package API member. [JA] SupportsSystemMessages を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsSystemMessages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsSystemMessages']" />
    public bool SupportsSystemMessages { get; init; } = true;

    /// <summary>[EN] Documents this public package API member. [JA] SupportsDeveloperMessages を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsDeveloperMessages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsDeveloperMessages']" />
    public bool SupportsDeveloperMessages { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] RequiresAlternatingUserAssistantMessages を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.RequiresAlternatingUserAssistantMessages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.RequiresAlternatingUserAssistantMessages']" />
    public bool RequiresAlternatingUserAssistantMessages { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] SystemInstructionRole を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SystemInstructionRole']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SystemInstructionRole']" />
    public string SystemInstructionRole { get; init; } = "system";

    /// <summary>[EN] Documents this public package API member. [JA] SupportedRoles を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportedRoles']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportedRoles']" />
    public ImmutableArray<string> SupportedRoles { get; init; }
        =
        [
            "system",
            "user",
            "assistant"
        ];

    /// <summary>[EN] Documents this public package API member. [JA] Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
