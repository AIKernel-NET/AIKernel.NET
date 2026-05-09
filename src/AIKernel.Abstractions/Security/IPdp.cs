namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Policy Decision Point 判定契約を定義します。
/// 本契約の判定経路は決定論的コードで構成し、LLM 推論を直接・間接に介在させてはなりません。
/// </summary>
public interface IPolicyDecisionPoint
{
    /// <summary>
    /// アクセス決定を行います。
    /// </summary>
    /// <param name="request">アクセス決定リクエスト</param>
    /// <returns>アクセス決定結果</returns>
    Task<AccessDecision> EvaluateAsync(AccessRequest request);
}

/// <summary>
/// Policy registry を管理する契約です。
/// </summary>
public interface IPolicyRegistry
{
    /// <summary>
    /// ポリシーを追加します。
    /// </summary>
    /// <param name="policy">追加するポリシー</param>
    void AddPolicy(IPolicy policy);

    /// <summary>
    /// ポリシーを削除します。
    /// </summary>
    /// <param name="policyId">ポリシーID</param>
    bool RemovePolicy(string policyId);
}

/// <summary>
/// Policy source を公開する契約です。
/// </summary>
public interface IPolicySource
{
    /// <summary>
    /// ポリシー一覧を取得します。
    /// </summary>
    IReadOnlyList<IPolicy> GetPolicies();
}

/// <summary>
/// 統合コンテキストに対する policy evaluation 契約です。
/// </summary>
public interface IPolicyDecisionEvaluator
{
    /// <summary>
    /// 指定されたコンテキストに対するポリシー評価を実行します。
    /// </summary>
    /// <param name="contract">コンテキスト契約</param>
    /// <returns>ポリシー評価結果</returns>
    Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Policy Decision Point（PDP）互換合成契約を定義します。
/// </summary>
public interface IPdp :
    IPolicyDecisionPoint,
    IPolicyRegistry,
    IPolicySource,
    IPolicyDecisionEvaluator
{
}
