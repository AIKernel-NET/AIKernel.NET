namespace AIKernel.Abstractions;

/// <summary>
/// ツール実行環境のサンドボックスを定義します。
/// セキュリティ境界を確立し、ツール実行を隔離します。
/// </summary>
public interface IToolSandbox
{
    /// <summary>
    /// サンドボックスの一意識別子を取得します。
    /// </summary>
    string SandboxId { get; }

    /// <summary>
    /// サンドボックス内でツールを実行します。
    /// </summary>
    /// <param name="toolName">ツール名</param>
    /// <param name="parameters">ツールパラメータ</param>
    /// <param name="permissions">実行権限</param>
    /// <returns>実行結果</returns>
    Task<SandboxExecutionResult> ExecuteToolAsync(
        string toolName,
        Dictionary<string, object> parameters,
        IToolPermission permissions);

    /// <summary>
    /// サンドボックスにファイルをアップロードします。
    /// </summary>
    /// <param name="fileName">ファイル名</param>
    /// <param name="content">ファイル内容</param>
    /// <returns>アップロード結果</returns>
    Task<bool> UploadFileAsync(string fileName, byte[] content);

    /// <summary>
    /// サンドボックスからファイルをダウンロードします。
    /// </summary>
    /// <param name="fileName">ファイル名</param>
    /// <returns>ファイル内容</returns>
    Task<byte[]?> DownloadFileAsync(string fileName);

    /// <summary>
    /// サンドボックスをクリーンアップします。
    /// </summary>
    Task CleanupAsync();

    /// <summary>
    /// サンドボックスのリソース使用状況を取得します。
    /// </summary>
    /// <returns>リソース使用状況</returns>
    Task<SandboxResourceUsage> GetResourceUsageAsync();
}

/// <summary>
/// サンドボックス実行結果を表現します。
/// </summary>
public sealed class SandboxExecutionResult
{
    /// <summary>
    /// 実行が成功したかどうかを取得または設定します。
    /// </summary>
    public required bool Success { get; init; }

    /// <summary>
    /// 実行結果を取得または設定します。
    /// </summary>
    public object? Result { get; init; }

    /// <summary>
    /// 実行エラーメッセージを取得または設定します。
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// 実行時間（ミリ秒）を取得または設定します。
    /// </summary>
    public long ExecutionTimeMs { get; init; }

    /// <summary>
    /// 標準出力を取得または設定します。
    /// </summary>
    public string? StdOut { get; init; }

    /// <summary>
    /// 標準エラー出力を取得または設定します。
    /// </summary>
    public string? StdErr { get; init; }
}

/// <summary>
/// サンドボックスのリソース使用状況を表現します。
/// </summary>
public sealed class SandboxResourceUsage
{
    /// <summary>
    /// CPU 使用率（0-100）を取得または設定します。
    /// </summary>
    public double CpuUsagePercent { get; init; }

    /// <summary>
    /// メモリ使用量（MB）を取得または設定します。
    /// </summary>
    public long MemoryUsageMb { get; init; }

    /// <summary>
    /// メモリ制限（MB）を取得または設定します。
    /// </summary>
    public long MemoryLimitMb { get; init; }

    /// <summary>
    /// ディスク使用量（MB）を取得または設定します。
    /// </summary>
    public long DiskUsageMb { get; init; }

    /// <summary>
    /// ディスク制限（MB）を取得または設定します。
    /// </summary>
    public long DiskLimitMb { get; init; }
}
