namespace AIKernel.Dtos.Prompt;

/// <summary>
/// PromptPolicyDto の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.PromptPolicyDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.PromptPolicyDto']" />
public sealed record PromptPolicyDto
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.TrustLevelRequired']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.TrustLevelRequired']" />
    public double TrustLevelRequired { get; init; } = 0.0;
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Prompt.PromptPolicyDto.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Prompt.PromptPolicyDto.List&lt;string&gt;']" />
    public IReadOnlyList<string> AllowedProviders { get; init; } = new List<string>();
    /// <summary>Gets the AllowedScopes value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AllowedScopes 値を取得します。</summary>
    public IReadOnlyList<string> AllowedScopes { get; init; } = new List<string>();
    /// <summary>Gets the AllowedTools value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AllowedTools 値を取得します。</summary>
    public IReadOnlyList<string> AllowedTools { get; init; } = new List<string>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.MaxTokenBudget']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.MaxTokenBudget']" />
    public int MaxTokenBudget { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.ExpiresAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.ExpiresAt']" />
    public DateTime? ExpiresAt { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.PromptPolicyDto.CreatedAt']" />
    public DateTime CreatedAt { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Prompt.PromptPolicyDto.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Prompt.PromptPolicyDto.#ctor']" />
    public PromptPolicyDto() { }

    /// <summary>Initializes a new instance for the PromptPolicyDto AIKernel contract surface. JA: PromptPolicyDto AIKernel 契約サーフェスの新しいインスタンスを初期化します。</summary>
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



