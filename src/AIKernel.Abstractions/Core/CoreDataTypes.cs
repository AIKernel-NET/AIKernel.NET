namespace AIKernel.Abstractions.Core;

public enum FailureMode
{
    None = 0,
    AttentionPollution = 1,
    SurfaceModeDetected = 2,
    QuarantineFailed = 3
}

public enum ModelType
{
    Unknown = 0,
    Small = 1,
    Medium = 2,
    Large = 3
}

public sealed class OrchestrationContextDto
{
    public required string Purpose { get; init; }
    public IReadOnlyList<string> Constraints { get; init; } = Array.Empty<string>();
    public required string Structure { get; init; }
    public string? ReasoningPattern { get; init; }
    public IReadOnlyDictionary<string, string>? Parameters { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

public sealed class ExpressionContextDto
{
    public string? Style { get; init; }
    public IReadOnlyList<string> Examples { get; init; } = Array.Empty<string>();
    public string? DescriptionTemplate { get; init; }
    public IReadOnlyList<string> Analogies { get; init; } = Array.Empty<string>();
    public IReadOnlyDictionary<string, string>? FormatDirectives { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

public sealed class MaterialContextDto
{
    public required string Source { get; init; }
    public required string RawData { get; init; }
    public string? NormalizedData { get; init; }
    public IReadOnlyDictionary<string, string>? StructuredData { get; init; }
    public double RelevanceScore { get; init; } = 1.0;
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
    public DateTime RetrievedAt { get; init; } = DateTime.UtcNow;
}

public sealed class UnifiedContextDto
{
    public required string Id { get; init; }
    public required OrchestrationContextDto Orchestration { get; init; }
    public ExpressionContextDto? Expression { get; init; }
    public MaterialContextDto? Material { get; init; }
    public double SignalToNoiseRatio { get; init; } = 1.0;
    public IReadOnlyList<FailureMode> DetectedFailureModes { get; init; } = Array.Empty<FailureMode>();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

public sealed class Purpose
{
    public required string PurposeId { get; init; }
    public required string Description { get; init; }
    public int Priority { get; init; } = 5;
    public IReadOnlyList<string> Tags { get; init; } = Array.Empty<string>();
    public string? SuccessCriteria { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

public sealed record SignedPromptArtifactDto(
    string EntityId,
    string Version,
    string Type,
    PromptPolicyDto Policy,
    string PromptBody,
    GovernanceMetadataDto Governance);

public sealed record PromptPolicyDto(
    double TrustLevelRequired,
    IReadOnlyList<string> AllowedProviders,
    IReadOnlyList<string> AllowedScopes,
    IReadOnlyList<string> AllowedTools,
    int MaxTokenBudget,
    DateTime? ExpiresAt,
    DateTime CreatedAt);

public sealed record GovernanceMetadataDto(
    string Issuer,
    string SignerId,
    string HashAlgorithm,
    string Hash,
    string Signature,
    DateTime SignedAt);
