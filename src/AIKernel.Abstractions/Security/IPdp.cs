namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Policy Decision Point 判定契約を定義します。
/// EN: 本契約の判定経路は決定論的コードで構成し、LLM 推論を直接・間接に介在させてはなりません。
/// EN: Documentation for public API. JA: IPolicyDecisionPoint の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionPoint']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionPoint']" />
public interface IPolicyDecisionPoint
{
    /// <summary>
    /// EN: アクセス決定を行います。
    /// EN: Documentation for public API. JA: EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: Documentation for public API. JA: アクセス決定リクエスト request パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: アクセス決定結果 結果を返します。</returns>
    Task<AccessDecision> EvaluateAsync(AccessRequest request);
}

/// <summary>
/// EN: Policy registry を管理する契約です。
/// EN: Documentation for public API. JA: IPolicyRegistry の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyRegistry']" />
public interface IPolicyRegistry
{
    /// <summary>
    /// EN: ポリシーを追加します。
    /// EN: Documentation for public API. JA: AddPolicy 操作を実行します。
    /// </summary>
    /// <param name="policy">EN: Documentation for public API. JA: 追加するポリシー policy パラメーターです。</param>
    void AddPolicy(IPolicy policy);

    /// <summary>
    /// EN: ポリシーを削除します。
    /// EN: Documentation for public API. JA: RemovePolicy 操作を実行します。
    /// </summary>
    /// <param name="policyId">EN: Documentation for public API. JA: ポリシーID policyId パラメーターです。</param>
    bool RemovePolicy(string policyId);
}

/// <summary>
/// EN: Policy source を公開する契約です。
/// EN: Documentation for public API. JA: IPolicySource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicySource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicySource']" />
public interface IPolicySource
{
    /// <summary>
    /// EN: ポリシー一覧を取得します。
    /// EN: Documentation for public API. JA: GetPolicies 操作を実行します。
    /// </summary>
    IReadOnlyList<IPolicy> GetPolicies();
}

/// <summary>
/// EN: 統合コンテキストに対する policy evaluation 契約です。
/// EN: Documentation for public API. JA: IPolicyDecisionEvaluator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionEvaluator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionEvaluator']" />
public interface IPolicyDecisionEvaluator
{
    /// <summary>
    /// EN: 指定されたコンテキストに対するポリシー評価を実行します。
    /// EN: Documentation for public API. JA: EvaluatePoliciesAsync 操作を実行します。
    /// </summary>
    /// <param name="contract">EN: Documentation for public API. JA: コンテキスト契約 contract パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: ポリシー評価結果 結果を返します。</returns>
    Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract);
}

/// <summary>
/// EN: UC-21（マテリアル検疫とポリシー実行）に基づく Policy Decision Point（PDP）互換合成契約を定義します。
/// EN: Documentation for public API. JA: IPdp の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPdp']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPdp']" />
public interface IPdp :
    IPolicyDecisionPoint,
    IPolicyRegistry,
    IPolicySource,
    IPolicyDecisionEvaluator
{
}
