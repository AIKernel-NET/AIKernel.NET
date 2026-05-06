namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく IPromptRepository の契約を定義します。
/// </summary>
public interface IPromptRepository
{
    Task<SignedPromptArtifactDto?> GetSignedPromptArtifactAsync(string entityId, CancellationToken ct = default);
}




