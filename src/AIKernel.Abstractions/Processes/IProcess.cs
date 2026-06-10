namespace AIKernel.Abstractions.Processes;

using AIKernel.Abstractions.Providers;

/// <summary>[EN] Strongly typed AIKernel process identifier. [JA] 強く型付けされた AIKernel process identifier です。</summary>
public readonly record struct ProcessId(Guid Value);

/// <summary>[EN] AIKernel logical process state. [JA] AIKernel logical process state です。</summary>
public enum ProcessState
{
    /// <summary>[EN] Process is starting. [JA] process は起動中です。</summary>
    Starting,
    /// <summary>[EN] Process is running. [JA] process は実行中です。</summary>
    Running,
    /// <summary>[EN] Process is stopped. [JA] process は停止済みです。</summary>
    Stopped,
    /// <summary>[EN] Process is in an error state. [JA] process は error state です。</summary>
    Error
}

/// <summary>[EN] Public AIKernel process snapshot. [JA] 公開 AIKernel process snapshot です。</summary>
public sealed record ProcessInfo(
    ProcessId Id,
    string Name,
    ProcessState State,
    DateTimeOffset StartedAtUtc,
    IReadOnlyDictionary<string, string> Metadata);

/// <summary>[EN] AIKernel logical process abstraction. [JA] AIKernel logical process 抽象です。</summary>
public interface IProcess
{
    /// <summary>[EN] Process identifier. [JA] process identifier です。</summary>
    ProcessId Id { get; }

    /// <summary>[EN] Current process state. [JA] 現在の process state です。</summary>
    ProcessState State { get; }

    /// <summary>[EN] Starts the process. [JA] process を開始します。</summary>
    Task StartAsync();

    /// <summary>[EN] Stops the process. [JA] process を停止します。</summary>
    Task StopAsync();
}

/// <summary>[EN] Host that creates AIKernel logical processes. [JA] AIKernel logical process を作成する host です。</summary>
public interface IProcessHost
{
    /// <summary>[EN] Creates a process. [JA] process を作成します。</summary>
    Task<IProcess> CreateProcessAsync(string name, object? args = null);
}

/// <summary>[EN] Provider contract for process supervision. [JA] process supervision 向け Provider contract です。</summary>
public interface IProcessSupervisorProvider : IProvider
{
    /// <summary>[EN] Lists managed processes. [JA] 管理対象 process を列挙します。</summary>
    Task<ProcessInfo[]> ListAsync();

    /// <summary>[EN] Kills a process. [JA] process を kill します。</summary>
    Task KillAsync(ProcessId id);

    /// <summary>[EN] Restarts a process. [JA] process を restart します。</summary>
    Task RestartAsync(ProcessId id);
}
