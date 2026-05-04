namespace AIKernel.Abstractions;

/// <summary>
/// ジョブスケジューラプロバイダーを定義します。
/// 非同期タスク、定期実行、スケジューリングを管理します。
/// </summary>
public interface IScheduler : IProvider
{
    /// <summary>
    /// スケジュール済みジョブを取得します。
    /// </summary>
    /// <param name="jobId">ジョブID</param>
    /// <returns>ジョブ情報</returns>
    Task<IScheduledJob?> GetJobAsync(string jobId);

    /// <summary>
    /// 新しいジョブをスケジュールします。
    /// </summary>
    /// <param name="job">スケジュール設定</param>
    /// <returns>作成されたジョブ</returns>
    Task<IScheduledJob> ScheduleAsync(IScheduleSpec job);

    /// <summary>
    /// ジョブをキャンセルします。
    /// </summary>
    /// <param name="jobId">ジョブID</param>
    /// <returns>キャンセル成功の可否</returns>
    Task<bool> CancelAsync(string jobId);

    /// <summary>
    /// スケジュール済みすべてのジョブを取得します。
    /// </summary>
    /// <returns>ジョブリスト</returns>
    Task<IReadOnlyList<IScheduledJob>> ListJobsAsync();

    /// <summary>
    /// ジョブの実行結果を取得します。
    /// </summary>
    /// <param name="jobId">ジョブID</param>
    /// <returns>実行結果</returns>
    Task<IExecutionResult?> GetExecutionResultAsync(string jobId);
}

/// <summary>
/// スケジュール設定を定義します。
/// </summary>
public interface IScheduleSpec
{
    /// <summary>
    /// ジョブの一意識別子を取得します。
    /// </summary>
    string JobId { get; }

    /// <summary>
    /// ジョブの説明を取得します。
    /// </summary>
    string Description { get; }

    /// <summary>
    /// 実行対象の作業を識別する名前またはIDを取得します。
    /// DI Container で実装を解決するために使用されます。
    /// </summary>
    string WorkId { get; }

    /// <summary>
    /// Cron形式のスケジュール式を取得します（例: "0 9 * * MON"）。
    /// </summary>
    string? CronExpression { get; }

    /// <summary>
    /// 最大実行時間（ミリ秒）を取得します。
    /// </summary>
    int? TimeoutMs { get; }

    /// <summary>
    /// リトライ回数を取得します。
    /// </summary>
    int MaxRetries { get; }
}

/// <summary>
/// スケジュール済みジョブを定義します。
/// </summary>
public interface IScheduledJob
{
    /// <summary>
    /// ジョブの一意識別子を取得します。
    /// </summary>
    string JobId { get; }

    /// <summary>
    /// ジョブの説明を取得します。
    /// </summary>
    string Description { get; }

    /// <summary>
    /// 前回実行時刻を取得します。
    /// </summary>
    DateTime? LastExecutionTime { get; }

    /// <summary>
    /// 次回実行予定時刻を取得します。
    /// </summary>
    DateTime? NextExecutionTime { get; }

    /// <summary>
    /// ジョブの状態を取得します。
    /// </summary>
    ScheduleStatus Status { get; }

    /// <summary>
    /// 実行回数を取得します。
    /// </summary>
    int ExecutionCount { get; }

    /// <summary>
    /// 最後のエラーメッセージを取得します。
    /// </summary>
    string? LastError { get; }
}

/// <summary>
/// スケジューラの実行結果を定義します。
/// </summary>
public interface IExecutionResult
{
    /// <summary>
    /// 実行ID を取得します。
    /// </summary>
    string ExecutionId { get; }

    /// <summary>
    /// ジョブIDを取得します。
    /// </summary>
    string JobId { get; }

    /// <summary>
    /// 実行開始時刻を取得します。
    /// </summary>
    DateTime StartTime { get; }

    /// <summary>
    /// 実行終了時刻を取得します。
    /// </summary>
    DateTime? EndTime { get; }

    /// <summary>
    /// 実行が成功したかどうかを取得します。
    /// </summary>
    bool Success { get; }

    /// <summary>
    /// エラーメッセージを取得します（失敗時）。
    /// </summary>
    string? Error { get; }

    /// <summary>
    /// 実行ログを取得します。
    /// </summary>
    string? Log { get; }
}
