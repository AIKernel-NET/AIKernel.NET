using AIKernel.Dtos.Cognition;

namespace AIKernel.Abstractions.Governance;

/// <summary>
/// EN: Produces a council vote snapshot without running the decision gate. JA: 決定ゲートを実行せず評議会投票スナップショットを生成します。
/// </summary>
public interface ICouncilVote
{
    /// <summary>
    /// EN: Produces a council vote. JA: 評議会投票を生成します。
    /// </summary>
    /// <param name="request">EN: The council vote request. JA: 評議会投票要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The council vote snapshot. JA: 評議会投票スナップショットを返します。</returns>
    ValueTask<CouncilVoteSnapshot> VoteAsync(CouncilVoteRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Describes a canonical CTG canon without embedding canon text. JA: 正典本文を埋め込まず正典 CTG canon を記述します。
/// </summary>
public interface ICtgCanon
{
    /// <summary>
    /// EN: Describes the canon snapshot. JA: 正典スナップショットを記述します。
    /// </summary>
    /// <param name="request">EN: The canon request. JA: 正典要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The canon snapshot. JA: 正典スナップショットを返します。</returns>
    ValueTask<CtgCanonSnapshot> DescribeAsync(CtgCanonRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Evaluates CTG ruleset carriers without adding new governance rules. JA: 新しい統治規則を追加せず CTG ルールセット carrier を評価します。
/// </summary>
public interface ICtgRuleset
{
    /// <summary>
    /// EN: Evaluates a ruleset carrier. JA: ルールセット carrier を評価します。
    /// </summary>
    /// <param name="request">EN: The ruleset evaluation request. JA: ルールセット評価要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The ruleset evaluation result. JA: ルールセット評価結果を返します。</returns>
    ValueTask<CtgRuleEvaluationResult> EvaluateAsync(CtgRuleEvaluationRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Evaluates a canonical CTG decision gate using extracted vote carriers. JA: 抽出済み投票 carrier を用いて正典 CTG 決定ゲートを評価します。
/// </summary>
public interface ICtgDecisionGate
{
    /// <summary>
    /// EN: Evaluates a CTG decision gate. JA: CTG 決定ゲートを評価します。
    /// </summary>
    /// <param name="request">EN: The gate request. JA: ゲート要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The gate result. JA: ゲート結果を返します。</returns>
    ValueTask<CtgDecisionGateResult> EvaluateAsync(CtgDecisionGateRequest request, CancellationToken cancellationToken);
}
