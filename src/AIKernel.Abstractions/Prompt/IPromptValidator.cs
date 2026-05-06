namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく IPromptValidator の契約を定義します。
/// </summary>
public interface IPromptValidator
{
    Task<PromptValidationResult> ValidateAsync(
        SignedPromptArtifactDto artifact,
        Models.IExecutionConstraints executionConstraints,
        CancellationToken ct = default);
}




