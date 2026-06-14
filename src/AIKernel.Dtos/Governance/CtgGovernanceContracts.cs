using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Governance;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// EN: References a canon or ROM location without carrying rule text. JA: ルール本文を保持せず正典または ROM の位置を参照します。
/// </summary>
public sealed record CanonReference
{
    /// <summary>EN: Gets the canon identifier. JA: 正典識別子を取得します。</summary>
    public string CanonId { get; init; } = string.Empty;

    /// <summary>EN: Gets the canon path. JA: 正典パスを取得します。</summary>
    public string Path { get; init; } = string.Empty;

    /// <summary>EN: Gets the referenced section. JA: 参照セクションを取得します。</summary>
    public string Section { get; init; } = string.Empty;

    /// <summary>EN: Gets the optional anchor. JA: 任意のアンカーを取得します。</summary>
    public string? Anchor { get; init; }

    /// <summary>EN: Gets the optional content hash. JA: 任意のコンテンツハッシュを取得します。</summary>
    public string? ContentHash { get; init; }
}

/// <summary>
/// EN: Describes why a governance result was rejected. JA: 統治結果が拒否された理由を記述します。
/// </summary>
public sealed record RejectReasonInfo
{
    /// <summary>EN: Gets the reason identifier. JA: 理由識別子を取得します。</summary>
    public string ReasonId { get; init; } = string.Empty;

    /// <summary>EN: Gets the reason kind. JA: 理由種別を取得します。</summary>
    public RejectReasonKind Kind { get; init; } = RejectReasonKind.Unknown;

    /// <summary>EN: Gets the stable reason code. JA: 安定した理由コードを取得します。</summary>
    public string ReasonCode { get; init; } = string.Empty;

    /// <summary>EN: Gets the human-readable message. JA: 人間が読めるメッセージを取得します。</summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>EN: Gets canon references related to the rejection. JA: 拒否に関連する正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets when the reason was observed. JA: 理由が観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets reason metadata. JA: 理由メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a single council vote. JA: 単一評議会の投票を運びます。
/// </summary>
public sealed record CouncilVote
{
    /// <summary>EN: Gets the vote identifier. JA: 投票識別子を取得します。</summary>
    public string VoteId { get; init; } = string.Empty;

    /// <summary>EN: Gets the council kind. JA: 評議会種別を取得します。</summary>
    public CouncilKind CouncilKind { get; init; } = CouncilKind.Unknown;

    /// <summary>EN: Gets the vote value. JA: 投票値を取得します。</summary>
    public CouncilVoteValue VoteValue { get; init; } = CouncilVoteValue.Unknown;

    /// <summary>EN: Gets the optional observed confidence carrier. JA: 任意の観測 confidence carrier を取得します。</summary>
    public double? Confidence { get; init; }

    /// <summary>EN: Gets the optional observed risk score carrier. JA: 任意の観測 risk score carrier を取得します。</summary>
    public double? RiskScore { get; init; }

    /// <summary>EN: Gets the optional reason text. JA: 任意の理由テキストを取得します。</summary>
    public string? Reason { get; init; }

    /// <summary>EN: Gets canon references supporting the vote. JA: 投票を支える正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets when the vote was observed. JA: 投票が観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets vote metadata. JA: 投票メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries the aggregate council decision for a governance step. JA: 統治ステップの集約評議会決定を運びます。
/// </summary>
public sealed record CouncilDecision
{
    /// <summary>EN: Gets the decision identifier. JA: 決定識別子を取得します。</summary>
    public string DecisionId { get; init; } = string.Empty;

    /// <summary>EN: Gets the decision kind. JA: 決定種別を取得します。</summary>
    public CouncilDecisionKind DecisionKind { get; init; } = CouncilDecisionKind.Unknown;

    /// <summary>EN: Gets the council votes. JA: 評議会投票を取得します。</summary>
    public IReadOnlyList<CouncilVote> Votes { get; init; } = [];

    /// <summary>EN: Gets rejection reasons. JA: 拒否理由を取得します。</summary>
    public IReadOnlyList<RejectReasonInfo> RejectReasons { get; init; } = [];

    /// <summary>EN: Gets canon references related to the decision. JA: 決定に関連する正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets the optional observed confidence carrier. JA: 任意の観測 confidence carrier を取得します。</summary>
    public double? Confidence { get; init; }

    /// <summary>EN: Gets the optional observed risk score carrier. JA: 任意の観測 risk score carrier を取得します。</summary>
    public double? RiskScore { get; init; }

    /// <summary>EN: Gets when the decision was observed. JA: 決定が観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets decision metadata. JA: 決定メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a council evaluation request. JA: 評議会評価要求を運びます。
/// </summary>
public sealed record CouncilEvaluationRequest
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets the step identifier. JA: ステップ識別子を取得します。</summary>
    public string StepId { get; init; } = string.Empty;

    /// <summary>EN: Gets required councils. JA: 必須評議会を取得します。</summary>
    public IReadOnlyList<CouncilKind> RequiredCouncils { get; init; } = [];

    /// <summary>EN: Gets canon references for the request. JA: 要求の正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets input facts. JA: 入力事実を取得します。</summary>
    public IReadOnlyDictionary<string, string> InputFacts { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a council evaluation result. JA: 評議会評価結果を運びます。
/// </summary>
public sealed record CouncilEvaluationResult
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether evaluation succeeded. JA: 評価が成功したかどうかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the council decision. JA: 評議会決定を取得します。</summary>
    public CouncilDecision Decision { get; init; } = new();

    /// <summary>EN: Gets a stable error code. JA: 安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: 人間が読めるエラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets rejection reasons. JA: 拒否理由を取得します。</summary>
    public IReadOnlyList<RejectReasonInfo> RejectReasons { get; init; } = [];

    /// <summary>EN: Gets canon references related to the result. JA: 結果に関連する正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets evaluation diagnostics. JA: 評価診断を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the result was observed. JA: 結果が観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries the pure triadic council vote input for a decision gate. JA: 決定ゲート用の純粋な三項 council vote 入力を運びます。
/// </summary>
public sealed record GateInput
{
    /// <summary>EN: Gets the Logos council vote value. JA: Logos council vote value を取得します。</summary>
    public CouncilVoteValue Logos { get; init; } = CouncilVoteValue.Unknown;

    /// <summary>EN: Gets the Ethos council vote value. JA: Ethos council vote value を取得します。</summary>
    public CouncilVoteValue Ethos { get; init; } = CouncilVoteValue.Unknown;

    /// <summary>EN: Gets the Pathos council vote value. JA: Pathos council vote value を取得します。</summary>
    public CouncilVoteValue Pathos { get; init; } = CouncilVoteValue.Unknown;
}

/// <summary>
/// EN: Carries a single-step decision gate request. JA: 単一ステップ決定ゲート要求を運びます。
/// </summary>
public sealed record DecisionGateRequest
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets the step identifier. JA: ステップ識別子を取得します。</summary>
    public string StepId { get; init; } = string.Empty;

    /// <summary>EN: Gets the council decision. JA: 評議会決定を取得します。</summary>
    public CouncilDecision CouncilDecision { get; init; } = new();

    /// <summary>EN: Gets the logos gate input. JA: Logos ゲート入力を取得します。</summary>
    public GateInput L { get; init; } = new();

    /// <summary>EN: Gets the ethos gate input. JA: Ethos ゲート入力を取得します。</summary>
    public GateInput E { get; init; } = new();

    /// <summary>EN: Gets the pathos gate input. JA: Pathos ゲート入力を取得します。</summary>
    public GateInput P { get; init; } = new();

    /// <summary>EN: Gets canon references for the request. JA: 要求の正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a single-step decision gate result. JA: 単一ステップ決定ゲート結果を運びます。
/// </summary>
public sealed record DecisionGateResult
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether evaluation succeeded. JA: 評価が成功したかどうかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the gate decision kind. JA: ゲート決定種別を取得します。</summary>
    public GateDecisionKind DecisionKind { get; init; } = GateDecisionKind.Unknown;

    /// <summary>EN: Gets whether the gate accepted the step. JA: ゲートがステップを受理したかどうかを取得します。</summary>
    public bool Accepted { get; init; }

    /// <summary>EN: Gets rejection reasons. JA: 拒否理由を取得します。</summary>
    public IReadOnlyList<RejectReasonInfo> RejectReasons { get; init; } = [];

    /// <summary>EN: Gets canon references related to the result. JA: 結果に関連する正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: 安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: 人間が読めるエラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets gate diagnostics. JA: ゲート診断を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the result was observed. JA: 結果が観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries trajectory-level input metrics as opaque values. JA: 軌道レベル入力指標を不透明な値として運びます。
/// </summary>
public sealed record TrajectoryGateInput
{
    /// <summary>EN: Gets the optional convergence score. JA: 任意の収束スコアを取得します。</summary>
    public double? ConvergenceScore { get; init; }

    /// <summary>EN: Gets the optional anomaly score. JA: 任意の異常スコアを取得します。</summary>
    public double? AnomalyScore { get; init; }

    /// <summary>EN: Gets the optional risk score. JA: 任意のリスクスコアを取得します。</summary>
    public double? RiskScore { get; init; }

    /// <summary>EN: Gets the optional repetition score. JA: 任意の反復スコアを取得します。</summary>
    public double? RepetitionScore { get; init; }

    /// <summary>EN: Gets the optional goal divergence value. JA: 任意の目標乖離値を取得します。</summary>
    public double? GoalDivergence { get; init; }

    /// <summary>EN: Gets the optional root-goal drift value. JA: 任意の根本目標ドリフト値を取得します。</summary>
    public double? RootGoalDrift { get; init; }

    /// <summary>EN: Gets the optional raw directional drift value. JA: 任意の生方向ドリフト値を取得します。</summary>
    public double? RawDirectionalDrift { get; init; }

    /// <summary>EN: Gets input metadata. JA: 入力メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a trajectory gate request. JA: 軌道ゲート要求を運びます。
/// </summary>
public sealed record TrajectoryGateRequest
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets step governance traces. JA: ステップ統治トレースを取得します。</summary>
    public IReadOnlyList<StepGovernanceTrace> Steps { get; init; } = [];

    /// <summary>EN: Gets trajectory input. JA: 軌道入力を取得します。</summary>
    public TrajectoryGateInput Trajectory { get; init; } = new();

    /// <summary>EN: Gets canon references for the request. JA: 要求の正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a trajectory gate result. JA: 軌道ゲート結果を運びます。
/// </summary>
public sealed record TrajectoryGateResult
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether evaluation succeeded. JA: 評価が成功したかどうかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the trajectory gate decision kind. JA: 軌道ゲート決定種別を取得します。</summary>
    public TrajectoryGateDecisionKind DecisionKind { get; init; } = TrajectoryGateDecisionKind.Unknown;

    /// <summary>EN: Gets whether the trajectory was accepted. JA: 軌道が受理されたかどうかを取得します。</summary>
    public bool Accepted { get; init; }

    /// <summary>EN: Gets rejection reasons. JA: 拒否理由を取得します。</summary>
    public IReadOnlyList<RejectReasonInfo> RejectReasons { get; init; } = [];

    /// <summary>EN: Gets the governance trace. JA: 統治トレースを取得します。</summary>
    public GovernanceTrace Trace { get; init; } = new();

    /// <summary>EN: Gets a stable error code. JA: 安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: 人間が読めるエラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets trajectory diagnostics. JA: 軌道診断を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the result was observed. JA: 結果が観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries deterministic governance trace data for a single step. JA: 単一ステップの決定論的統治トレースデータを運びます。
/// </summary>
public sealed record StepGovernanceTrace
{
    /// <summary>EN: Gets the trace identifier. JA: トレース識別子を取得します。</summary>
    public string TraceId { get; init; } = string.Empty;

    /// <summary>EN: Gets the step identifier. JA: ステップ識別子を取得します。</summary>
    public string StepId { get; init; } = string.Empty;

    /// <summary>EN: Gets the council evaluation result. JA: 評議会評価結果を取得します。</summary>
    public CouncilEvaluationResult CouncilEvaluation { get; init; } = new();

    /// <summary>EN: Gets the decision gate result. JA: 決定ゲート結果を取得します。</summary>
    public DecisionGateResult DecisionGate { get; init; } = new();

    /// <summary>EN: Gets canon references related to the step. JA: ステップに関連する正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets rejection reasons. JA: 拒否理由を取得します。</summary>
    public IReadOnlyList<RejectReasonInfo> RejectReasons { get; init; } = [];

    /// <summary>EN: Gets when the trace was observed. JA: トレースが観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets trace metadata. JA: トレースメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries deterministic governance trace data for a trajectory. JA: 軌道の決定論的統治トレースデータを運びます。
/// </summary>
public sealed record GovernanceTrace
{
    /// <summary>EN: Gets the trace identifier. JA: トレース識別子を取得します。</summary>
    public string TraceId { get; init; } = string.Empty;

    /// <summary>EN: Gets step traces. JA: ステップトレースを取得します。</summary>
    public IReadOnlyList<StepGovernanceTrace> Steps { get; init; } = [];

    /// <summary>EN: Gets the trajectory input. JA: 軌道入力を取得します。</summary>
    public TrajectoryGateInput TrajectoryInput { get; init; } = new();

    /// <summary>EN: Gets the trajectory decision kind. JA: 軌道決定種別を取得します。</summary>
    public TrajectoryGateDecisionKind DecisionKind { get; init; } = TrajectoryGateDecisionKind.Unknown;

    /// <summary>EN: Gets whether the trajectory was accepted. JA: 軌道が受理されたかどうかを取得します。</summary>
    public bool Accepted { get; init; }

    /// <summary>EN: Gets rejection reasons. JA: 拒否理由を取得します。</summary>
    public IReadOnlyList<RejectReasonInfo> RejectReasons { get; init; } = [];

    /// <summary>EN: Gets canon references related to the trace. JA: トレースに関連する正典参照を取得します。</summary>
    public IReadOnlyList<CanonReference> CanonReferences { get; init; } = [];

    /// <summary>EN: Gets when the trace was created. JA: トレースが作成された日時を取得します。</summary>
    public DateTimeOffset CreatedAt { get; init; }

    /// <summary>EN: Gets when the trace was completed. JA: トレースが完了した日時を取得します。</summary>
    public DateTimeOffset? CompletedAt { get; init; }

    /// <summary>EN: Gets the optional replay timeline identifier. JA: 任意のリプレイタイムライン識別子を取得します。</summary>
    public string? ReplayTimelineId { get; init; }

    /// <summary>EN: Gets trace metadata. JA: トレースメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a ROM governance evaluation request. JA: ROM 統治評価要求を運びます。
/// </summary>
public sealed record RomGovernanceEvaluationRequest
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets the step identifier. JA: ステップ識別子を取得します。</summary>
    public string StepId { get; init; } = string.Empty;

    /// <summary>EN: Gets the canon path. JA: 正典パスを取得します。</summary>
    public string CanonPath { get; init; } = "rom/governance/ctg.canon.md";

    /// <summary>EN: Gets input facts. JA: 入力事実を取得します。</summary>
    public IReadOnlyDictionary<string, string> InputFacts { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a ROM governance evaluation result. JA: ROM 統治評価結果を運びます。
/// </summary>
public sealed record RomGovernanceEvaluationResult
{
    /// <summary>EN: Gets the operation identifier. JA: 操作識別子を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether evaluation succeeded. JA: 評価が成功したかどうかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the council evaluation result. JA: 評議会評価結果を取得します。</summary>
    public CouncilEvaluationResult CouncilEvaluation { get; init; } = new();

    /// <summary>EN: Gets the decision gate result. JA: 決定ゲート結果を取得します。</summary>
    public DecisionGateResult DecisionGate { get; init; } = new();

    /// <summary>EN: Gets the step governance trace. JA: ステップ統治トレースを取得します。</summary>
    public StepGovernanceTrace StepTrace { get; init; } = new();

    /// <summary>EN: Gets a stable error code. JA: 安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: 人間が読めるエラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets evaluation diagnostics. JA: 評価診断を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the result was observed. JA: 結果が観測された日時を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the optional correlation identifier. JA: 任意の相関識別子を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the optional trace identifier. JA: 任意のトレース識別子を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}
