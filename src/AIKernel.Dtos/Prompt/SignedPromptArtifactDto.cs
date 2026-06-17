namespace AIKernel.Dtos.Prompt;

/// <summary>
/// 署名済みプロンプトアーティファクト DTO。
/// SGS-006: Canonical Signing Payload - entity.id, version, policy, 本文を含む。
/// EN: SGS-006 の署名対象となる成果物。
/// [EN] Documents this public package API member. [JA] SignedPromptArtifactDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.SignedPromptArtifactDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.SignedPromptArtifactDto']" />
public sealed record SignedPromptArtifactDto
{
    /// <summary>
    /// プロンプトのエンティティ ID。
    /// EN: SGS-006: Canonical Signing Payload の必須要素。
    /// [EN] Documents this public package API member. [JA] EntityId を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.EntityId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.EntityId']" />
    public required string EntityId { get; init; }

    /// <summary>
    /// プロンプトのバージョン。
    /// EN: SGS-006: Canonical Signing Payload の必須要素。
    /// [EN] Documents this public package API member. [JA] Version を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Version']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Version']" />
    public required string Version { get; init; }

    /// <summary>
    /// EN: プロンプトの型（"kernel.signed_prompt" など）。
    /// [EN] Documents this public package API member. [JA] Type を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Type']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Type']" />
    public required string Type { get; init; }

    /// <summary>
    /// 実行ポリシー。
    /// SGS-004, SGS-006: Canonical Signing Payload の必須要素。
    /// EN: SGS-007: 実行スコープの動的束縛に用いられる。
    /// [EN] Documents this public package API member. [JA] Policy を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Policy']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Policy']" />
    public required PromptPolicyDto Policy { get; init; }

    /// <summary>
    /// プロンプト本文（ROM フォーマット）。
    /// EN: SGS-006: Canonical Signing Payload の必須要素。
    /// [EN] Documents this public package API member. [JA] PromptBody を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.PromptBody']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.PromptBody']" />
    public required string PromptBody { get; init; }

    /// <summary>
    /// EN: ガバナンス情報（署名者、ハッシュ、署名）。
    /// [EN] Documents this public package API member. [JA] Governance を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Governance']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.SignedPromptArtifactDto.Governance']" />
    public required GovernanceMetadataDto Governance { get; init; }
}

