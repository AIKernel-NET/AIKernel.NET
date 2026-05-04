namespace AIKernel.Abstractions;

/// <summary>
/// ポリシー決定ポイント（Policy Decision Point）を定義します。
/// アクセス制御とセキュリティポリシーの決定を行います。
/// </summary>
public interface IPdp
{
    /// <summary>
    /// アクセス決定を行います。
    /// </summary>
    /// <param name="request">アクセス決定リクエスト</param>
    /// <returns>アクセス決定結果</returns>
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
    Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract);
}

/// <summary>
/// セキュリティポリシーを定義します。
/// </summary>
public interface IPolicy
{
    /// <summary>
    /// ポリシーの一意識別子を取得します。
    /// </summary>
    string GetId();

    /// <summary>
    /// ポリシーの名前を取得します。
    /// </summary>
    string GetName();

    /// <summary>
    /// ポリシーが適用可能であるかを確認します。
    /// </summary>
    /// <param name="request">アクセスリクエスト</param>
    /// <returns>適用可能な場合 true</returns>
    bool IsApplicable(AccessRequest request);

    /// <summary>
    /// ポリシーを評価します。
    /// </summary>
    /// <param name="request">アクセスリクエスト</param>
    /// <returns>ポリシー評価結果</returns>
    AccessDecision Evaluate(AccessRequest request);
}
