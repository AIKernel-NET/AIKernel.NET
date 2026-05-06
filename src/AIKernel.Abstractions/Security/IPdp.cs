namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Policy Decision Point（PDP）契約を定義します。
/// </summary>
/// <remarks>
/// 本契約の判定経路は決定論的コードで構成し、LLM 推論を直接・間接に介在させてはなりません。
/// </remarks>
public interface IPdp
{
    /// <summary>
    /// アクセス決定を行います。
    /// </summary>
    /// <param name="request">アクセス決定リクエスト</param>
    /// <returns>アクセス決定結果</returns>
    /// <exception cref="ArgumentNullException">request が null の場合にスローされます。</exception>
    /// <exception cref="InvalidOperationException">判定経路に非決定論的要素が検出された場合にスローされます。</exception>
    Task<AccessDecision> EvaluateAsync(AccessRequest request);

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

    /// <summary>
    /// ポリシー一覧を取得します。
    /// </summary>
    IReadOnlyList<IPolicy> GetPolicies();

    /// <summary>
    /// 指定されたコンテキストに対するポリシー評価を実行します。
    /// </summary>
    /// <param name="contract">コンテキスト契約</param>
    /// <returns>ポリシー評価結果</returns>
    /// <exception cref="ArgumentNullException">contract が null の場合にスローされます。</exception>
    Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract);
}


