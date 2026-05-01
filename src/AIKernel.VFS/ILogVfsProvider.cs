namespace AIKernel.VFS;

/// <summary>
/// ログファイルへの VFS アクセス。
/// </summary>
public interface ILogVfsProvider : IVfsProvider
{
    /// <summary>
    /// ログファイルをクエリします。
    /// </summary>
    /// <param name="session">VFS セッション</param>
    /// <param name="filter">フィルター条件</param>
    Task<IReadOnlyList<LogEntry>> QueryLogsAsync(IVfsSession session, LogFilter filter);
}
