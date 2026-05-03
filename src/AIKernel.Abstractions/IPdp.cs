using AIKernel.Contracts;
using AIKernel.Enums;

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
    Task<PolicyEvaluationResult> EvaluatePoliciesAsync(IUnifiedContextContract contract);
}

/// <summary>
/// アクセス決定リクエストを表現します。
/// </summary>
public sealed class AccessRequest
{
    /// <summary>
    /// リクエスト主体を取得または設定します。
    /// </summary>
    public required IPrincipal Principal { get; init; }

    /// <summary>
    /// リクエストアクションを取得または設定します。
    /// </summary>
    public required string Action { get; init; }

    /// <summary>
    /// 対象リソースを取得または設定します。
    /// </summary>
    public required string Resource { get; init; }

    /// <summary>
    /// 環境属性を取得または設定します。
    /// </summary>
    public IReadOnlyDictionary<string, string>? Environment { get; init; }
}

/// <summary>
/// アクセス決定結果を表現します。
/// </summary>
public sealed class AccessDecision
{
    /// <summary>
    /// アクセスが許可されたかどうかを取得します。
    /// </summary>
    public bool Allowed { get; init; }

    /// <summary>
    /// 決定理由を取得します。
    /// </summary>
    public string? Reason { get; init; }

    /// <summary>
    /// 適用されたポリシーを取得します。
    /// </summary>
    public List<string> AppliedPolicies { get; init; } = new();

    /// <summary>
    /// 追加の制約条件を取得します。
    /// </summary>
    public IReadOnlyDictionary<string, string>? Constraints { get; init; }
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

/// <summary>
/// ポリシー評価結果を表現します。
/// </summary>
public sealed class PolicyEvaluationResult
{
    /// <summary>
    /// 全ポリシー評価が許可されたかどうかを取得します。
    /// </summary>
    public bool AllAllowed { get; init; }

    /// <summary>
    /// 個別の評価結果を取得します。
    /// </summary>
    public List<AccessDecision> Decisions { get; init; } = new();

    /// <summary>
    /// 失敗したポリシーを取得します。
    /// </summary>
    public List<string> FailedPolicies { get; init; } = new();

    /// <summary>
    /// 全体的なリスクレベルを取得します（Low / Medium / High）。
    /// </summary>
    public string RiskLevel { get; init; } = "Low";
}
