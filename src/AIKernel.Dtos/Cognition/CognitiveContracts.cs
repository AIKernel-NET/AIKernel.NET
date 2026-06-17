using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Cognition;
using AIKernel.Enums.Governance;

namespace AIKernel.Dtos.Cognition;

/// <summary>
/// EN: Carries a bounded numeric vector used by Topos and related carriers. JA: Topos と関連 carrier が使用する境界付き数値ベクトルを保持します。
/// </summary>
public sealed record IntentionVector
{
    /// <summary>EN: Gets the vector identifier. JA: ベクトル識別子を取得します。</summary>
    public string VectorId { get; init; } = string.Empty;

    /// <summary>EN: Gets the vector kind. JA: ベクトル種別を取得します。</summary>
    public TriadicVectorKind Kind { get; init; } = TriadicVectorKind.Unknown;

    /// <summary>EN: Gets the normalized X component. JA: 正規化 X 成分を取得します。</summary>
    public double X { get; init; }

    /// <summary>EN: Gets the normalized Y component. JA: 正規化 Y 成分を取得します。</summary>
    public double Y { get; init; }

    /// <summary>EN: Gets the normalized Z component when available. JA: 利用可能な場合の正規化 Z 成分を取得します。</summary>
    public double? Z { get; init; }

    /// <summary>EN: Gets the vector magnitude. JA: ベクトル強度を取得します。</summary>
    public double Magnitude { get; init; }

    /// <summary>EN: Gets the vector confidence. JA: ベクトル信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets vector metadata. JA: ベクトルメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a normalized sensor state. JA: 正規化済みセンサー状態を保持します。
/// </summary>
public sealed record SensorState
{
    /// <summary>EN: Gets the stable sensor name. JA: 安定したセンサー名を取得します。</summary>
    public string SensorName { get; init; } = string.Empty;

    /// <summary>EN: Gets the sensor signal kind. JA: センサー信号種別を取得します。</summary>
    public AisthesisSignalKind Kind { get; init; } = AisthesisSignalKind.Unknown;

    /// <summary>EN: Gets whether the sensor is enabled. JA: センサーが有効かどうかを取得します。</summary>
    public bool Enabled { get; init; } = true;

    /// <summary>EN: Gets the normalized scalar value. JA: 正規化済みスカラー値を取得します。</summary>
    public double Value { get; init; }

    /// <summary>EN: Gets the sensor confidence. JA: センサー信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets sensor metadata. JA: センサーメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a canonical sensory request. JA: 正典的な感覚要求を保持します。
/// </summary>
public sealed record AisthesisRequest
{
    /// <summary>EN: Gets the observation identifier. JA: 観測識別子を取得します。</summary>
    public string ObservationId { get; init; } = string.Empty;

    /// <summary>EN: Gets requested sensor names. JA: 要求されたセンサー名を取得します。</summary>
    public IReadOnlyList<string> SensorNames { get; init; } = [];

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries raw or normalized sensory observations. JA: 生または正規化済みの感覚観測を保持します。
/// </summary>
public sealed record AisthesisSnapshot
{
    /// <summary>EN: Gets the observation identifier. JA: 観測識別子を取得します。</summary>
    public string ObservationId { get; init; } = string.Empty;

    /// <summary>EN: Gets when the observation was captured. JA: 観測が取得された時刻を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets sensor inputs keyed by stable sensor name. JA: 安定したセンサー名でキー付けされたセンサー入力を取得します。</summary>
    public IReadOnlyDictionary<string, SensorState> SensorInputs { get; init; } = new Dictionary<string, SensorState>(StringComparer.Ordinal);

    /// <summary>EN: Gets whether capture succeeded when this snapshot is used as a result. JA: このスナップショットが結果として使われる場合の成功状態を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when capture failed. JA: 取得に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when capture failed. JA: 取得に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: スナップショットメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a representation request. JA: 表象要求を保持します。
/// </summary>
public sealed record PhantasiaRequest
{
    /// <summary>EN: Gets the source sensory snapshot. JA: 入力感覚スナップショットを取得します。</summary>
    public AisthesisSnapshot Aisthesis { get; init; } = new();

    /// <summary>EN: Gets requested representation granularity. JA: 要求された表象粒度を取得します。</summary>
    public RepresentationGranularity Granularity { get; init; } = RepresentationGranularity.Unknown;

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a symbolic feature extracted from sensory input. JA: 感覚入力から抽出された記号的特徴を保持します。
/// </summary>
public sealed record SemanticFeature
{
    /// <summary>EN: Gets the feature identifier. JA: 特徴識別子を取得します。</summary>
    public string FeatureId { get; init; } = string.Empty;

    /// <summary>EN: Gets the feature kind. JA: 特徴種別を取得します。</summary>
    public string Kind { get; init; } = string.Empty;

    /// <summary>EN: Gets the feature score. JA: 特徴スコアを取得します。</summary>
    public double Score { get; init; }

    /// <summary>EN: Gets the feature confidence. JA: 特徴信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets feature metadata. JA: 特徴メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a symbolic representation snapshot. JA: 記号的表象スナップショットを保持します。
/// </summary>
public sealed record PhantasiaSnapshot
{
    /// <summary>EN: Gets the representation identifier. JA: 表象識別子を取得します。</summary>
    public string RepresentationId { get; init; } = string.Empty;

    /// <summary>EN: Gets the source observation identifier. JA: 入力観測識別子を取得します。</summary>
    public string SourceObservationId { get; init; } = string.Empty;

    /// <summary>EN: Gets representation granularity. JA: 表象粒度を取得します。</summary>
    public RepresentationGranularity Granularity { get; init; } = RepresentationGranularity.Unknown;

    /// <summary>EN: Gets semantic features. JA: 意味特徴を取得します。</summary>
    public IReadOnlyList<SemanticFeature> Features { get; init; } = [];

    /// <summary>EN: Gets whether representation succeeded when used as a result. JA: 結果として使われる場合の表象成功状態を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when representation failed. JA: 表象に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when representation failed. JA: 表象に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: スナップショットメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a cognition request. JA: 認知要求を保持します。
/// </summary>
public sealed record NousRequest
{
    /// <summary>EN: Gets the source representation. JA: 入力表象を取得します。</summary>
    public PhantasiaSnapshot Phantasia { get; init; } = new();

    /// <summary>EN: Gets optional memory context. JA: 任意の記憶文脈を取得します。</summary>
    public SemanticMemorySnapshot? Memory { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an interpreted situation label. JA: 解釈された状況ラベルを保持します。
/// </summary>
public sealed record SituationLabel
{
    /// <summary>EN: Gets the label identifier. JA: ラベル識別子を取得します。</summary>
    public string LabelId { get; init; } = string.Empty;

    /// <summary>EN: Gets the label kind. JA: ラベル種別を取得します。</summary>
    public string Kind { get; init; } = string.Empty;

    /// <summary>EN: Gets the label confidence. JA: ラベル信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets label metadata. JA: ラベルメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries cognition labels and lightweight hints without selecting actions. JA: 行動選択を行わず、認知ラベルと軽量ヒントを保持します。
/// </summary>
public sealed record NousSnapshot
{
    /// <summary>EN: Gets the cognition identifier. JA: 認知識別子を取得します。</summary>
    public string CognitionId { get; init; } = string.Empty;

    /// <summary>EN: Gets situation labels. JA: 状況ラベルを取得します。</summary>
    public IReadOnlyList<SituationLabel> SituationLabels { get; init; } = [];

    /// <summary>EN: Gets cognition hints. JA: 認知ヒントを取得します。</summary>
    public IReadOnlyDictionary<string, string> CognitionHints { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);

    /// <summary>EN: Gets whether cognition succeeded when used as a result. JA: 結果として使われる場合の認知成功状態を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when cognition failed. JA: 認知に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when cognition failed. JA: 認知に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: スナップショットメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a telos proposal request. JA: TELOS 提案要求を保持します。
/// </summary>
public sealed record TelosRequest
{
    /// <summary>EN: Gets the cognition snapshot. JA: 認知スナップショットを取得します。</summary>
    public NousSnapshot Nous { get; init; } = new();

    /// <summary>EN: Gets optional semantic memory. JA: 任意の意味記憶を取得します。</summary>
    public SemanticMemorySnapshot? Memory { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a proposed goal, objective, or priority without executing it. JA: 実行せずに目標、行動目標、優先事項の提案を保持します。
/// </summary>
public sealed record TelosProposal
{
    /// <summary>EN: Gets the proposal identifier. JA: 提案識別子を取得します。</summary>
    public string ProposalId { get; init; } = string.Empty;

    /// <summary>EN: Gets the priority lane. JA: 優先レーンを取得します。</summary>
    public TelosPriorityKind PriorityKind { get; init; } = TelosPriorityKind.Unknown;

    /// <summary>EN: Gets the stable telos name. JA: 安定した TELOS 名を取得します。</summary>
    public string Telos { get; init; } = string.Empty;

    /// <summary>EN: Gets the stable objective name. JA: 安定した OBJECTIVE 名を取得します。</summary>
    public string Objective { get; init; } = string.Empty;

    /// <summary>EN: Gets the stable priority label. JA: 安定した PRIORITY ラベルを取得します。</summary>
    public string Priority { get; init; } = string.Empty;

    /// <summary>EN: Gets the proposal confidence. JA: 提案信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets proposal metadata. JA: 提案メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a Topos evaluation request. JA: Topos 評価要求を保持します。
/// </summary>
public sealed record ToposEvaluationRequest
{
    /// <summary>EN: Gets the cognition snapshot. JA: 認知スナップショットを取得します。</summary>
    public NousSnapshot Nous { get; init; } = new();

    /// <summary>EN: Gets the telos proposal. JA: TELOS 提案を取得します。</summary>
    public TelosProposal Telos { get; init; } = new();

    /// <summary>EN: Gets optional Kairos state. JA: 任意の Kairos 状態を取得します。</summary>
    public KairosState? Kairos { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries observed triadic scores and vectors without embedding gate logic. JA: ゲートロジックを埋め込まず、観測された三者スコアとベクトルを保持します。
/// </summary>
public sealed record ToposCarrier
{
    /// <summary>EN: Gets the carrier identifier. JA: carrier 識別子を取得します。</summary>
    public string CarrierId { get; init; } = string.Empty;

    /// <summary>EN: Gets the logos score. JA: Logos スコアを取得します。</summary>
    public double LogosScore { get; init; }

    /// <summary>EN: Gets the pathos score. JA: Pathos スコアを取得します。</summary>
    public double PathosScore { get; init; }

    /// <summary>EN: Gets the ethos score. JA: Ethos スコアを取得します。</summary>
    public double EthosScore { get; init; }

    /// <summary>EN: Gets the logos vector. JA: Logos ベクトルを取得します。</summary>
    public IntentionVector LogosVector { get; init; } = new() { Kind = TriadicVectorKind.Logos };

    /// <summary>EN: Gets the pathos vector. JA: Pathos ベクトルを取得します。</summary>
    public IntentionVector PathosVector { get; init; } = new() { Kind = TriadicVectorKind.Pathos };

    /// <summary>EN: Gets the ethos vector. JA: Ethos ベクトルを取得します。</summary>
    public IntentionVector EthosVector { get; init; } = new() { Kind = TriadicVectorKind.Ethos };

    /// <summary>EN: Gets the composed decision vector. JA: 合成決定ベクトルを取得します。</summary>
    public IntentionVector DecisionVector { get; init; } = new() { Kind = TriadicVectorKind.Decision };

    /// <summary>EN: Gets the dominant vector kind. JA: 支配的なベクトル種別を取得します。</summary>
    public TriadicVectorKind Dominant { get; init; } = TriadicVectorKind.Unknown;

    /// <summary>EN: Gets whether evaluation succeeded when used as a result. JA: 結果として使われる場合の評価成功状態を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when evaluation failed. JA: 評価に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when evaluation failed. JA: 評価に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets carrier metadata. JA: carrier メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a Kairos scheduling request. JA: Kairos スケジューリング要求を保持します。
/// </summary>
public sealed record KairosScheduleRequest
{
    /// <summary>EN: Gets the Topos carrier. JA: Topos carrier を取得します。</summary>
    public ToposCarrier Topos { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries timing state and trigger metadata. JA: タイミング状態と発火メタデータを保持します。
/// </summary>
public sealed record KairosState
{
    /// <summary>EN: Gets the Kairos identifier. JA: Kairos 識別子を取得します。</summary>
    public string KairosId { get; init; } = string.Empty;

    /// <summary>EN: Gets the timing state kind. JA: タイミング状態種別を取得します。</summary>
    public KairosStateKind Kind { get; init; } = KairosStateKind.Unknown;

    /// <summary>EN: Gets the trigger identifier. JA: 発火識別子を取得します。</summary>
    public string? TriggerId { get; init; }

    /// <summary>EN: Gets the timing confidence. JA: タイミング信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets whether scheduling succeeded when used as a result. JA: 結果として使われる場合のスケジューリング成功状態を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when scheduling failed. JA: スケジューリングに失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when scheduling failed. JA: スケジューリングに失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets state metadata. JA: 状態メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an abstract Kinesis action request. JA: 抽象 Kinesis 行動要求を保持します。
/// </summary>
public sealed record KinesisAction
{
    /// <summary>EN: Gets the action identifier. JA: 行動識別子を取得します。</summary>
    public string ActionId { get; init; } = string.Empty;

    /// <summary>EN: Gets the action kind. JA: 行動種別を取得します。</summary>
    public KinesisActionKind Kind { get; init; } = KinesisActionKind.Unknown;

    /// <summary>EN: Gets the action vector. JA: 行動ベクトルを取得します。</summary>
    public IntentionVector Vector { get; init; } = new();

    /// <summary>EN: Gets normalized action intensity. JA: 正規化済み行動強度を取得します。</summary>
    public double Intensity { get; init; }

    /// <summary>EN: Gets action metadata. JA: 行動メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries the result of a Kinesis action request. JA: Kinesis 行動要求の結果を保持します。
/// </summary>
public sealed record KinesisActionResult
{
    /// <summary>EN: Gets the action identifier. JA: 行動識別子を取得します。</summary>
    public string ActionId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether the action request succeeded. JA: 行動要求が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when the action request failed. JA: 行動要求に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when the action request failed. JA: 行動要求に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a Chronos trace entry. JA: Chronos トレースエントリを保持します。
/// </summary>
public sealed record ChronosTraceEntry
{
    /// <summary>EN: Gets the entry identifier. JA: エントリ識別子を取得します。</summary>
    public string EntryId { get; init; } = string.Empty;

    /// <summary>EN: Gets the trace kind. JA: トレース種別を取得します。</summary>
    public ChronosTraceKind Kind { get; init; } = ChronosTraceKind.Unknown;

    /// <summary>EN: Gets when the entry was observed. JA: エントリが観測された時刻を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets entry metadata. JA: エントリメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a chronological trace without replay implementation. JA: リプレイ実装を持たない時系列トレースを保持します。
/// </summary>
public sealed record ChronosTrace
{
    /// <summary>EN: Gets the trace identifier. JA: トレース識別子を取得します。</summary>
    public string TraceId { get; init; } = string.Empty;

    /// <summary>EN: Gets trace entries. JA: トレースエントリを取得します。</summary>
    public IReadOnlyList<ChronosTraceEntry> Entries { get; init; } = [];

    /// <summary>EN: Gets whether recording succeeded when used as a result. JA: 結果として使われる場合の記録成功状態を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when recording failed. JA: 記録に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when recording failed. JA: 記録に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets trace metadata. JA: トレースメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a Chronos record request. JA: Chronos 記録要求を保持します。
/// </summary>
public sealed record ChronosRecordRequest
{
    /// <summary>EN: Gets the trace to record. JA: 記録するトレースを取得します。</summary>
    public ChronosTrace Trace { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a Chronos record result. JA: Chronos 記録結果を保持します。
/// </summary>
public sealed record ChronosRecordResult
{
    /// <summary>EN: Gets the trace identifier. JA: トレース識別子を取得します。</summary>
    public string TraceId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether recording succeeded. JA: 記録が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when recording failed. JA: 記録に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when recording failed. JA: 記録に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a semantic memory query. JA: 意味記憶クエリを保持します。
/// </summary>
public sealed record SemanticMemoryQuery
{
    /// <summary>EN: Gets the query identifier. JA: クエリ識別子を取得します。</summary>
    public string QueryId { get; init; } = string.Empty;

    /// <summary>EN: Gets the semantic key. JA: 意味キーを取得します。</summary>
    public string Key { get; init; } = string.Empty;

    /// <summary>EN: Gets query metadata. JA: クエリメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries semantic memory facts. JA: 意味記憶の事実を保持します。
/// </summary>
public sealed record SemanticMemorySnapshot
{
    /// <summary>EN: Gets the memory identifier. JA: 記憶識別子を取得します。</summary>
    public string MemoryId { get; init; } = string.Empty;

    /// <summary>EN: Gets stable memory facts. JA: 安定した記憶事実を取得します。</summary>
    public IReadOnlyDictionary<string, string> Facts { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);

    /// <summary>EN: Gets memory confidence. JA: 記憶信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets whether memory access succeeded when used as a result. JA: 結果として使われる場合の記憶アクセス成功状態を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when memory access failed. JA: 記憶アクセスに失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when memory access failed. JA: 記憶アクセスに失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets memory metadata. JA: 記憶メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a phase inference request. JA: フェーズ推論要求を保持します。
/// </summary>
public sealed record PhaseInferenceRequest
{
    /// <summary>EN: Gets the cognition snapshot. JA: 認知スナップショットを取得します。</summary>
    public NousSnapshot Nous { get; init; } = new();

    /// <summary>EN: Gets optional memory context. JA: 任意の記憶文脈を取得します。</summary>
    public SemanticMemorySnapshot? Memory { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an inferred phase without enforcing scenario-specific transitions. JA: シナリオ固有遷移を強制せず、推論されたフェーズを保持します。
/// </summary>
public sealed record PhaseInferenceResult
{
    /// <summary>EN: Gets the inferred phase name. JA: 推論されたフェーズ名を取得します。</summary>
    public string Phase { get; init; } = string.Empty;

    /// <summary>EN: Gets the inference confidence. JA: 推論信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets whether inference succeeded. JA: 推論が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when inference failed. JA: 推論に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when inference failed. JA: 推論に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an objective inference request. JA: 行動目標推論要求を保持します。
/// </summary>
public sealed record ObjectiveInferenceRequest
{
    /// <summary>EN: Gets the telos proposal. JA: TELOS 提案を取得します。</summary>
    public TelosProposal Telos { get; init; } = new();

    /// <summary>EN: Gets optional phase inference. JA: 任意のフェーズ推論を取得します。</summary>
    public PhaseInferenceResult? Phase { get; init; }

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an inferred objective. JA: 推論された行動目標を保持します。
/// </summary>
public sealed record ObjectiveInferenceResult
{
    /// <summary>EN: Gets the inferred objective name. JA: 推論された行動目標名を取得します。</summary>
    public string Objective { get; init; } = string.Empty;

    /// <summary>EN: Gets the objective confidence. JA: 行動目標信頼度を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets whether inference succeeded. JA: 推論が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when inference failed. JA: 推論に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when inference failed. JA: 推論に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a council vote request for canonical triadic governance. JA: 正典的三分統治の評議会投票要求を保持します。
/// </summary>
public sealed record CouncilVoteRequest
{
    /// <summary>EN: Gets the Topos carrier. JA: Topos carrier を取得します。</summary>
    public ToposCarrier Topos { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a council vote snapshot without running the decision gate. JA: 決定ゲートを実行せず、評議会投票スナップショットを保持します。
/// </summary>
public sealed record CouncilVoteSnapshot
{
    /// <summary>EN: Gets the vote identifier. JA: 投票識別子を取得します。</summary>
    public string VoteId { get; init; } = string.Empty;

    /// <summary>EN: Gets the council kind. JA: 評議会種別を取得します。</summary>
    public CouncilKind Council { get; init; } = CouncilKind.Unknown;

    /// <summary>EN: Gets the vote value. JA: 投票値を取得します。</summary>
    public CouncilVoteValue Value { get; init; } = CouncilVoteValue.Unknown;

    /// <summary>EN: Gets vote confidence as an observation carrier only. JA: 観測 carrier としてのみ使う投票信頼度を取得します。</summary>
    public double? Confidence { get; init; }

    /// <summary>EN: Gets vote metadata. JA: 投票メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a CTG canon describe request. JA: CTG 正典記述要求を保持します。
/// </summary>
public sealed record CtgCanonRequest
{
    /// <summary>EN: Gets the canon identifier. JA: 正典識別子を取得します。</summary>
    public string CanonId { get; init; } = string.Empty;

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a CTG canon snapshot. JA: CTG 正典スナップショットを保持します。
/// </summary>
public sealed record CtgCanonSnapshot
{
    /// <summary>EN: Gets the canon identifier. JA: 正典識別子を取得します。</summary>
    public string CanonId { get; init; } = string.Empty;

    /// <summary>EN: Gets the canon version. JA: 正典バージョンを取得します。</summary>
    public string Version { get; init; } = string.Empty;

    /// <summary>EN: Gets canonical references. JA: 正典参照を取得します。</summary>
    public IReadOnlyList<string> References { get; init; } = [];

    /// <summary>EN: Gets whether describe succeeded. JA: 記述が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when describe failed. JA: 記述に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when describe failed. JA: 記述に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets canon metadata. JA: 正典メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a CTG ruleset evaluation request. JA: CTG ルールセット評価要求を保持します。
/// </summary>
public sealed record CtgRuleEvaluationRequest
{
    /// <summary>EN: Gets the canon snapshot. JA: 正典スナップショットを取得します。</summary>
    public CtgCanonSnapshot Canon { get; init; } = new();

    /// <summary>EN: Gets council votes. JA: 評議会投票を取得します。</summary>
    public IReadOnlyList<CouncilVoteSnapshot> Votes { get; init; } = [];

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries the result of a CTG ruleset evaluation without implementation logic. JA: 実装ロジックを持たず CTG ルールセット評価結果を保持します。
/// </summary>
public sealed record CtgRuleEvaluationResult
{
    /// <summary>EN: Gets the evaluation identifier. JA: 評価識別子を取得します。</summary>
    public string EvaluationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether evaluation succeeded. JA: 評価が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when evaluation failed. JA: 評価に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when evaluation failed. JA: 評価に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a CTG decision gate request using extracted votes only. JA: 抽出済み投票のみを用いる CTG 決定ゲート要求を保持します。
/// </summary>
public sealed record CtgDecisionGateRequest
{
    /// <summary>EN: Gets council votes. JA: 評議会投票を取得します。</summary>
    public IReadOnlyList<CouncilVoteSnapshot> Votes { get; init; } = [];

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a CTG decision gate result. JA: CTG 決定ゲート結果を保持します。
/// </summary>
public sealed record CtgDecisionGateResult
{
    /// <summary>EN: Gets the gate result identifier. JA: ゲート結果識別子を取得します。</summary>
    public string ResultId { get; init; } = string.Empty;

    /// <summary>EN: Gets the gate decision. JA: ゲート決定を取得します。</summary>
    public GateDecisionKind Decision { get; init; } = GateDecisionKind.Unknown;

    /// <summary>EN: Gets the rejection reason when denied. JA: 拒否時の拒否理由を取得します。</summary>
    public RejectReasonKind RejectReason { get; init; } = RejectReasonKind.Unknown;

    /// <summary>EN: Gets whether gate evaluation succeeded. JA: ゲート評価が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when gate evaluation failed. JA: ゲート評価に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when gate evaluation failed. JA: ゲート評価に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
