namespace AIKernel.Dtos.Prompt;

/// <summary>
/// 署名済みプロンプトアーティファクト DTO。
/// SGS-006: Canonical Signing Payload - entity.id, version, policy, 本文を含む。
/// SGS-006 の署名対象となる成果物。
/// </summary>
public sealed record SignedPromptArtifactDto
{
    /// <summary>
    /// プロンプトのエンティティ ID。
    /// SGS-006: Canonical Signing Payload の必須要素。
    /// </summary>
    public string EntityId { get; init; }

    /// <summary>
    /// プロンプトのバージョン。
    /// SGS-006: Canonical Signing Payload の必須要素。
    /// </summary>
    public string Version { get; init; }

    /// <summary>
    /// プロンプトの型（"kernel.signed_prompt" など）。
    /// </summary>
    public string Type { get; init; }

    /// <summary>
    /// 実行ポリシー。
    /// SGS-004, SGS-006: Canonical Signing Payload の必須要素。
    /// SGS-007: 実行スコープの動的束縛に用いられる。
    /// </summary>
    public PromptPolicyDto Policy { get; init; }

    /// <summary>
    /// プロンプト本文（ROM フォーマット）。
    /// SGS-006: Canonical Signing Payload の必須要素。
    /// </summary>
    public string PromptBody { get; init; }

    /// <summary>
    /// ガバナンス情報（署名者、ハッシュ、署名）。
    /// </summary>
    public GovernanceMetadataDto Governance { get; init; }

    public SignedPromptArtifactDto() { }

    public SignedPromptArtifactDto(
        string entityId,
        string version,
        string type,
        PromptPolicyDto policy,
        string promptBody,
        GovernanceMetadataDto governance)
    {
        EntityId = entityId;
        Version = version;
        Type = type;
        Policy = policy;
        PromptBody = promptBody;
        Governance = governance;
    }
}
