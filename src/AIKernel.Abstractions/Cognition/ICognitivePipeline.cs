using AIKernel.Dtos.Cognition;

namespace AIKernel.Abstractions.Cognition;

/// <summary>
/// EN: Captures canonical sensory input without deciding actions. JA: 行動を決定せず正典的な感覚入力を取得します。
/// </summary>
public interface IAisthesis
{
    /// <summary>
    /// EN: Captures a sensory snapshot. JA: 感覚スナップショットを取得します。
    /// </summary>
    /// <param name="request">EN: The sensory request. JA: 感覚要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The sensory snapshot. JA: 感覚スナップショットを返します。</returns>
    ValueTask<AisthesisSnapshot> SenseAsync(AisthesisRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Converts sensory input into symbolic representation. JA: 感覚入力を記号的表象へ変換します。
/// </summary>
public interface IPhantasia
{
    /// <summary>
    /// EN: Builds a representation snapshot. JA: 表象スナップショットを構築します。
    /// </summary>
    /// <param name="request">EN: The representation request. JA: 表象要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The representation snapshot. JA: 表象スナップショットを返します。</returns>
    ValueTask<PhantasiaSnapshot> RepresentAsync(PhantasiaRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Interprets representations into situation labels without issuing actions. JA: 行動を発行せず表象を状況ラベルへ解釈します。
/// </summary>
public interface INous
{
    /// <summary>
    /// EN: Analyzes a representation snapshot. JA: 表象スナップショットを解析します。
    /// </summary>
    /// <param name="request">EN: The cognition request. JA: 認知要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The cognition snapshot. JA: 認知スナップショットを返します。</returns>
    ValueTask<NousSnapshot> AnalyzeAsync(NousRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Proposes telos, objective, and priority carriers without enforcing execution. JA: 実行を強制せず TELOS、OBJECTIVE、PRIORITY carrier を提案します。
/// </summary>
public interface ITelos
{
    /// <summary>
    /// EN: Proposes a telos carrier. JA: TELOS carrier を提案します。
    /// </summary>
    /// <param name="request">EN: The telos request. JA: TELOS 要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The telos proposal. JA: TELOS 提案を返します。</returns>
    ValueTask<TelosProposal> ProposeAsync(TelosRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Schedules timing windows without replacing governance gates. JA: 統治ゲートを置き換えずタイミング窓をスケジュールします。
/// </summary>
public interface IKairosScheduler
{
    /// <summary>
    /// EN: Schedules a Kairos state. JA: Kairos 状態をスケジュールします。
    /// </summary>
    /// <param name="request">EN: The schedule request. JA: スケジュール要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The Kairos state. JA: Kairos 状態を返します。</returns>
    ValueTask<KairosState> ScheduleAsync(KairosScheduleRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Emits abstract action requests to an actuator boundary. JA: アクチュエータ境界へ抽象行動要求を発行します。
/// </summary>
public interface IKinesisActuator
{
    /// <summary>
    /// EN: Sends an action request to the actuator boundary. JA: アクチュエータ境界へ行動要求を送信します。
    /// </summary>
    /// <param name="action">EN: The action request. JA: 行動要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The action result. JA: 行動結果を返します。</returns>
    ValueTask<KinesisActionResult> ActuateAsync(KinesisAction action, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Records chronological traces without replay implementation. JA: リプレイ実装を持たず時系列トレースを記録します。
/// </summary>
public interface IChronosRecorder
{
    /// <summary>
    /// EN: Records a Chronos trace. JA: Chronos トレースを記録します。
    /// </summary>
    /// <param name="request">EN: The record request. JA: 記録要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The record result. JA: 記録結果を返します。</returns>
    ValueTask<ChronosRecordResult> RecordAsync(ChronosRecordRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Reads and writes semantic memory snapshots. JA: 意味記憶スナップショットを読み書きします。
/// </summary>
public interface ISemanticMemory
{
    /// <summary>
    /// EN: Reads semantic memory. JA: 意味記憶を読み取ります。
    /// </summary>
    /// <param name="query">EN: The memory query. JA: 記憶クエリです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The memory snapshot. JA: 記憶スナップショットを返します。</returns>
    ValueTask<SemanticMemorySnapshot> ReadAsync(SemanticMemoryQuery query, CancellationToken cancellationToken);

    /// <summary>
    /// EN: Writes semantic memory. JA: 意味記憶を書き込みます。
    /// </summary>
    /// <param name="snapshot">EN: The memory snapshot. JA: 記憶スナップショットです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The written memory snapshot. JA: 書き込み済み記憶スナップショットを返します。</returns>
    ValueTask<SemanticMemorySnapshot> WriteAsync(SemanticMemorySnapshot snapshot, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Infers semantic phases without scenario-specific shortcuts. JA: シナリオ固有の近道を使わず意味フェーズを推論します。
/// </summary>
public interface IPhaseInference
{
    /// <summary>
    /// EN: Infers a semantic phase. JA: 意味フェーズを推論します。
    /// </summary>
    /// <param name="request">EN: The phase inference request. JA: フェーズ推論要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The phase inference result. JA: フェーズ推論結果を返します。</returns>
    ValueTask<PhaseInferenceResult> InferAsync(PhaseInferenceRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Infers objectives from telos and semantic context. JA: TELOS と意味文脈から行動目標を推論します。
/// </summary>
public interface IObjectiveInference
{
    /// <summary>
    /// EN: Infers an objective. JA: 行動目標を推論します。
    /// </summary>
    /// <param name="request">EN: The objective inference request. JA: 行動目標推論要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The objective inference result. JA: 行動目標推論結果を返します。</returns>
    ValueTask<ObjectiveInferenceResult> InferAsync(ObjectiveInferenceRequest request, CancellationToken cancellationToken);
}
