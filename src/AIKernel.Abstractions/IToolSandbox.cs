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
        IReadOnlyDictionary<string, string> parameters,
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
