namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Policy Decision Point 判定契約を定義します。
/// 本契約の判定経路は決定論的コードで構成し、LLM 推論を直接・間接に介在させてはなりません。
/// JA: IPolicyDecisionPoint の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionPoint']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionPoint']" />
public interface IPolicyDecisionPoint
{
    /// <summary>
    /// アクセス決定を行います。
    /// JA: EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">アクセス決定リクエスト JA: request パラメーターです。</param>
    /// <returns>アクセス決定結果 JA: 結果を返します。</returns>
    Task<AccessDecision> EvaluateAsync(AccessRequest request);
}

/// <summary>
/// Policy registry を管理する契約です。
/// JA: IPolicyRegistry の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyRegistry']" />
public interface IPolicyRegistry
{
    /// <summary>
    /// ポリシーを追加します。
    /// JA: AddPolicy 操作を実行します。
    /// </summary>
    /// <param name="policy">追加するポリシー JA: policy パラメーターです。</param>
    void AddPolicy(IPolicy policy);

    /// <summary>
    /// ポリシーを削除します。
    /// JA: RemovePolicy 操作を実行します。
    /// </summary>
    /// <param name="policyId">ポリシーID JA: policyId パラメーターです。</param>
    bool RemovePolicy(string policyId);
}

/// <summary>
/// Policy source を公開する契約です。
/// JA: IPolicySource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicySource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicySource']" />
public interface IPolicySource
{
    /// <summary>
    /// ポリシー一覧を取得します。
    /// JA: GetPolicies 操作を実行します。
    /// </summary>
    IReadOnlyList<IPolicy> GetPolicies();
}

/// <summary>
/// 統合コンテキストに対する policy evaluation 契約です。
/// JA: IPolicyDecisionEvaluator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionEvaluator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicyDecisionEvaluator']" />
public interface IPolicyDecisionEvaluator
{
    /// <summary>
    /// 指定されたコンテキストに対するポリシー評価を実行します。
    /// JA: EvaluatePoliciesAsync 操作を実行します。
    /// </summary>
    /// <param name="contract">コンテキスト契約 JA: contract パラメーターです。</param>
    /// <returns>ポリシー評価結果 JA: 結果を返します。</returns>
    Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Policy Decision Point（PDP）互換合成契約を定義します。
/// JA: IPdp の公開契約を定義します。
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
