namespace AIKernel.Dtos.Execution;

using AIKernel.Enums;
using System.Collections.Immutable;

public sealed record ModelPromptCapability
{
    public required string ProviderId { get; init; }

    public required string ModelId { get; init; }

    public PromptMessageFormat MessageFormat { get; init; } = PromptMessageFormat.ChatMessages;

    public int MaxInputTokens { get; init; } = 8192;

    public int MaxOutputTokens { get; init; } = 1024;

    public bool SupportsSystemMessages { get; init; } = true;

    public bool SupportsDeveloperMessages { get; init; }

    public bool RequiresAlternatingUserAssistantMessages { get; init; }

    public string SystemInstructionRole { get; init; } = "system";

    public ImmutableArray<string> SupportedRoles { get; init; }
        =
        [
            "system",
            "user",
            "assistant"
        ];

    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
