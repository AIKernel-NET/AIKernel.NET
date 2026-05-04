namespace AIKernel.Dtos.Prompt;

public sealed record PromptPolicyDto
{
    public double TrustLevelRequired { get; init; } = 0.0;
    public IReadOnlyList<string> AllowedProviders { get; init; } = new List<string>();
    public IReadOnlyList<string> AllowedScopes { get; init; } = new List<string>();
    public IReadOnlyList<string> AllowedTools { get; init; } = new List<string>();
    public int MaxTokenBudget { get; init; }
    public DateTime? ExpiresAt { get; init; }
    public DateTime CreatedAt { get; init; }

    public PromptPolicyDto() { }

    public PromptPolicyDto(
        double trustLevelRequired,
        IReadOnlyList<string> allowedProviders,
        IReadOnlyList<string> allowedScopes,
        IReadOnlyList<string> allowedTools,
        int maxTokenBudget,
        DateTime? expiresAt,
        DateTime createdAt)
    {
        TrustLevelRequired = trustLevelRequired;
        AllowedProviders = allowedProviders;
        AllowedScopes = allowedScopes;
        AllowedTools = allowedTools;
        MaxTokenBudget = maxTokenBudget;
        ExpiresAt = expiresAt;
        CreatedAt = createdAt;
    }
}
