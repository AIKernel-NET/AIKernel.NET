namespace AIKernel.Abstractions;

/// <summary>
/// パイプラインマネージャーを定義します。
/// DAG形式のパイプライン実行を管理します。
/// </summary>
public interface ITaskManager
{
    /// <summary>
    /// パイプラインを登録します。
    /// </summary>
    /// <param name="pipeline">パイプライン定義</param>
    /// <returns>登録されたパイプラインID</returns>
    Task<string> RegisterPipelineAsync(IPipeline pipeline);

    /// <summary>
    /// パイプラインを実行します。
    /// </summary>
    /// <param name="pipelineId">パイプラインID</param>
    /// <param name="context">実行コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>実行結果</returns>
    Task<IPipelineExecutionResult> ExecutePipelineAsync(string pipelineId, ITaskContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// タスクを実行します。
    /// </summary>
    /// <param name="task">実行するタスク</param>
    /// <param name="context">実行コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>タスク実行結果</returns>
    Task<ITaskExecutionResult> ExecuteTaskAsync(ITask task, ITaskContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// 実行中のパイプラインを一時停止します。
    /// </summary>
    /// <param name="executionId">実行ID</param>
    /// <returns>一時停止成功の可否</returns>
    Task<bool> PausePipelineAsync(string executionId);

    /// <summary>
    /// 一時停止中のパイプラインを再開します。
    /// </summary>
    /// <param name="executionId">実行ID</param>
    /// <returns>再開成功の可否</returns>
    Task<bool> ResumePipelineAsync(string executionId);

    /// <summary>
    /// 実行中のパイプラインをキャンセルします。
    /// </summary>
    /// <param name="executionId">実行ID</param>
    /// <returns>キャンセル成功の可否</returns>
    Task<bool> CancelPipelineAsync(string executionId);

    /// <summary>
    /// 実行結果を取得します。
    /// </summary>
    /// <param name="executionId">実行ID</param>
    /// <returns>実行結果</returns>
    Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId);
}

/// <summary>
/// パイプラインを定義します。
/// </summary>
public interface IPipeline
{
    /// <summary>
    /// パイプラインの一意識別子を取得します。
    /// </summary>
    string PipelineId { get; }

    /// <summary>
    /// パイプラインの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// パイプラインの説明を取得します。
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// パイプラインを構成するタスク一覧を取得します。
    /// </summary>
    IReadOnlyList<ITask> Tasks { get; }

    /// <summary>
    /// タスク間の依存関係を取得します（DAG）。
    /// キー: タスクID、値: 依存先タスクIDのリスト
    /// </summary>
    IReadOnlyDictionary<string, IReadOnlyList<string>> Dependencies { get; }

    /// <summary>
    /// パイプラインバージョンを取得します。
    /// </summary>
    string Version { get; }
}

/// <summary>
/// パイプラインを構成する単一のタスクを定義します。
/// </summary>
public interface ITask
{
    /// <summary>
    /// タスクの一意識別子を取得します。
    /// </summary>
    string TaskId { get; }

    /// <summary>
    /// タスクの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// タスクの説明を取得します。
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// タスクの実行タイプを取得します。
    /// </summary>
    TaskType TaskType { get; }

    /// <summary>
    /// タスクを実行します。
    /// </summary>
    /// <param name="context">実行コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>タスク結果</returns>
    Task<string?> ExecuteAsync(ITaskContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// タスクの入力スキーマを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string>? GetInputSchema();

    /// <summary>
    /// タスクの出力スキーマを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string>? GetOutputSchema();

    /// <summary>
    /// タスクが実行可能かどうかを判定します。
    /// </summary>
    /// <param name="context">実行コンテキスト</param>
    /// <returns>実行可能な場合 true</returns>
    bool CanExecute(ITaskContext context);
}

/// <summary>
/// タスク実行コンテキストを定義します。
/// </summary>
public interface ITaskContext
{
    /// <summary>
    /// 実行IDを取得します。
    /// </summary>
    string ExecutionId { get; }

    /// <summary>
    /// パイプラインIDを取得します。
    /// </summary>
    string PipelineId { get; }

    /// <summary>
    /// パイプラインコンテキスト契約を取得します。
    /// </summary>
    UnifiedContextDto? ContextContract { get; }

    /// <summary>
    /// タスク入力パラメータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string?> GetInputParameters();

    /// <summary>
    /// タスク入力パラメータを設定します。
    /// </summary>
    /// <param name="key">パラメータキー</param>
    /// <param name="value">パラメータ値</param>
    void SetInputParameter(string key, string? value);

    /// <summary>
    /// 依存タスクの出力結果を取得します。
    /// </summary>
    /// <param name="taskId">タスクID</param>
    /// <returns>タスク出力</returns>
    ITaskExecutionResult? GetDependencyOutput(string taskId);

    /// <summary>
    /// コンテキスト変数を取得します。
    /// </summary>
    /// <param name="key">変数キー</param>
    /// <returns>変数値</returns>
    string? GetVariable(string key);

    /// <summary>
    /// コンテキスト変数を設定します。
    /// </summary>
    /// <param name="key">変数キー</param>
    /// <param name="value">変数値</param>
    void SetVariable(string key, string? value);

    /// <summary>
    /// 実行時刻を取得します。
    /// </summary>
    DateTime ExecutionTime { get; }

    /// <summary>
    /// タイムアウト（ミリ秒）を取得します。
    /// </summary>
    int? TimeoutMs { get; }
}

/// <summary>
/// パイプライン実行結果を定義します。
/// </summary>
public interface IPipelineExecutionResult
{
    /// <summary>
    /// 実行IDを取得します。
    /// </summary>
    string ExecutionId { get; }

    /// <summary>
    /// パイプラインIDを取得します。
    /// </summary>
    string PipelineId { get; }

    /// <summary>
    /// 実行開始時刻を取得します。
    /// </summary>
    DateTime StartTime { get; }

    /// <summary>
    /// 実行終了時刻を取得します。
    /// </summary>
    DateTime? EndTime { get; }

    /// <summary>
    /// パイプライン実行が成功したかどうかを取得します。
    /// </summary>
    bool Success { get; }

    /// <summary>
    /// パイプラインの最終出力を取得します。
    /// </summary>
    string? FinalOutput { get; }

    /// <summary>
    /// 各タスクの実行結果を取得します。
    /// </summary>
    IReadOnlyDictionary<string, ITaskExecutionResult> TaskResults { get; }

    /// <summary>
    /// 全体的なエラーメッセージを取得します。
    /// </summary>
    string? Error { get; }

    /// <summary>
    /// 実行ログを取得します。
    /// </summary>
    string? ExecutionLog { get; }
}

/// <summary>
/// 単一タスクの実行結果を定義します。
/// </summary>
public interface ITaskExecutionResult
{
    /// <summary>
    /// タスクIDを取得します。
    /// </summary>
    string TaskId { get; }

    /// <summary>
    /// 実行が成功したかどうかを取得します。
    /// </summary>
    bool Success { get; }

    /// <summary>
    /// タスク出力を取得します。
    /// </summary>
    string? Output { get; }

    /// <summary>
    /// エラーメッセージを取得します。
    /// </summary>
    string? Error { get; }

    /// <summary>
    /// 実行にかかった時間（ミリ秒）を取得します。
    /// </summary>
    long DurationMs { get; }

    /// <summary>
    /// リトライ回数を取得します。
    /// </summary>
    int RetryCount { get; }
}

/// <summary>
/// タスク入出力スキーマを定義します。
/// </summary>
public interface ITaskSchema
{
    /// <summary>
    /// スキーマ名を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// スキーマバージョンを取得します。
    /// </summary>
    string Version { get; }

    /// <summary>
    /// フィールド定義を取得します。
    /// </summary>
    IReadOnlyDictionary<string, string> Fields { get; }
}

/// <summary>
/// タスクの実行タイプを定義します。
/// </summary>
public enum TaskType
{
    /// <summary>同期タスク</summary>
    Sync = 1,

    /// <summary>非同期タスク</summary>
    Async = 2,

    /// <summary>条件付きタスク</summary>
    Conditional = 3,

    /// <summary>ループタスク</summary>
    Loop = 4,

    /// <summary>並列実行タスク</summary>
    Parallel = 5
}
