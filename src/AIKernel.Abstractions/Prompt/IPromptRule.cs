namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく IPromptRule の契約を定義します。
/// </summary>
public interface IPromptRule
{
    string RuleId { get; }
    string Name { get; }
    string Description { get; }
    string Content { get; }
    RuleScope Scope { get; }
    string Version { get; }
    string Signature { get; }
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
    bool IsActive { get; }
    string CreatedBy { get; }
    string? UpdatedBy { get; }
    IReadOnlyList<string> Tags { get; }
    int Priority { get; }
    DateTime? ExpiresAt { get; }
    IReadOnlyDictionary<string, string>? Metadata { get; }
}




