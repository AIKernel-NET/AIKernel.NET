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
    public required string EntityId { get; init; }

    /// <summary>
    /// プロンプトのバージョン。
    /// SGS-006: Canonical Signing Payload の必須要素。
    /// </summary>
    public required string Version { get; init; }

    /// <summary>
    /// プロンプトの型（"kernel.signed_prompt" など）。
    /// </summary>
    public required string Type { get; init; }

    /// <summary>
    /// 実行ポリシー。
    /// SGS-004, SGS-006: Canonical Signing Payload の必須要素。
    /// SGS-007: 実行スコープの動的束縛に用いられる。
    /// </summary>
    public required PromptPolicyDto Policy { get; init; }

    /// <summary>
    /// プロンプト本文（ROM フォーマット）。
    /// SGS-006: Canonical Signing Payload の必須要素。
    /// </summary>
    public required string PromptBody { get; init; }

    /// <summary>
    /// ガバナンス情報（署名者、ハッシュ、署名）。
    /// </summary>
    public required GovernanceMetadataDto Governance { get; init; }
}

/// <summary>
/// プロンプトの実行ポリシー DTO。
/// SGS-004, SGS-007 に対応。
/// </summary>
public sealed record PromptPolicyDto
{
    /// <summary>
    /// 要求される信頼レベル（0.0-1.0）。
    /// SGS-003: ISignatureTrustStore から取得した TrustScore がこの値以上であることが必須。
    /// </summary>
    public double TrustLevelRequired { get; init; } = 0.0;

    /// <summary>
    /// 許可される実行プロバイダ ID リスト。
    /// SGS-007: 実行直前コンテキストの権限内にあることが必須。
    /// </summary>
    public IReadOnlyList<string> AllowedProviders { get; init; } = new List<string>();

    /// <summary>
    /// 許可される実行スコープ（例: "read:financial_data"）。
    /// SGS-007: 実行直前コンテキストのスコープ内にあることが必須。
    /// </summary>
    public IReadOnlyList<string> AllowedScopes { get; init; } = new List<string>();

    /// <summary>
    /// 許可されるツール ID リスト。
    /// SGS-007: 実行予算内にあることが必須。
    /// </summary>
    public IReadOnlyList<string> AllowedTools { get; init; } = new List<string>();

    /// <summary>
    /// 最大トークン予算。
    /// SGS-007: 実行直前の予算内にあることが必須。
    /// </summary>
    public int MaxTokenBudget { get; init; }

    /// <summary>
    /// 有効期限（UTC）。
    /// SGS-F004: expires_at 超過時は即時ロード拒否する。
    /// </summary>
    public DateTime? ExpiresAt { get; init; }

    /// <summary>
    /// 作成時刻（UTC）。
    /// SGS-F004: created_at が未来時刻の場合はロード拒否する。
    /// </summary>
    public DateTime CreatedAt { get; init; }
}

/// <summary>
/// ガバナンス・署名メタデータ DTO。
/// SGS-006: Canonical Signing Payload の署名部分。
/// </summary>
public sealed record GovernanceMetadataDto
{
    /// <summary>
    /// 発行者（Issuer）。
    /// SGS-006: Canonical Signing Payload に含まれる。
    /// </summary>
    public required string Issuer { get; init; }

    /// <summary>
    /// 署名者 ID。
    /// SGS-003: ISignatureTrustStore で信頼判定される。
    /// </summary>
    public required string SignerId { get; init; }

    /// <summary>
    /// ハッシュアルゴリズム（"SHA256", "SHA512" など）。
    /// </summary>
    public required string HashAlgorithm { get; init; } = "SHA256";

    /// <summary>
    /// 正規化されたペイロードのハッシュ。
    /// SGS-002: IPromptVerifier がハッシュ整合性を検証する。
    /// SGS-006: entity.id, version, policy, 本文から算出されるハッシュ。
    /// </summary>
    public required string Hash { get; init; }

    /// <summary>
    /// デジタル署名（ECDSA/RSA 等）。
    /// SGS-002: IPromptVerifier が署名検証する。
    /// </summary>
    public required string Signature { get; init; }

    /// <summary>
    /// 署名生成タイムスタンプ。
    /// </summary>
    public required DateTime SignedAt { get; init; }
}
