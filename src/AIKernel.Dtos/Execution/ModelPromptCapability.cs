namespace AIKernel.Dtos.Execution;

using AIKernel.Enums;
using System.Collections.Immutable;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModelPromptCapability']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModelPromptCapability']" />
public sealed record ModelPromptCapability
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ProviderId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ProviderId']" />
    public required string ProviderId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ModelId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.ModelId']" />
    public required string ModelId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MessageFormat']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MessageFormat']" />
    public PromptMessageFormat MessageFormat { get; init; } = PromptMessageFormat.ChatMessages;

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxInputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxInputTokens']" />
    public int MaxInputTokens { get; init; } = 8192;

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxOutputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.MaxOutputTokens']" />
    public int MaxOutputTokens { get; init; } = 1024;

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsSystemMessages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsSystemMessages']" />
    public bool SupportsSystemMessages { get; init; } = true;

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsDeveloperMessages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportsDeveloperMessages']" />
    public bool SupportsDeveloperMessages { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.RequiresAlternatingUserAssistantMessages']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.RequiresAlternatingUserAssistantMessages']" />
    public bool RequiresAlternatingUserAssistantMessages { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SystemInstructionRole']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SystemInstructionRole']" />
    public string SystemInstructionRole { get; init; } = "system";

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportedRoles']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.SupportedRoles']" />
    public ImmutableArray<string> SupportedRoles { get; init; }
        =
        [
            "system",
            "user",
            "assistant"
        ];

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModelPromptCapability.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
