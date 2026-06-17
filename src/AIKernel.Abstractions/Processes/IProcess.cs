namespace AIKernel.Abstractions.Processes;

using AIKernel.Abstractions.Providers;

/// <summary>[EN] Strongly typed AIKernel process identifier. [JA] 強く型付けされた AIKernel process identifier です。 JA: ProcessId 操作を実行します。</summary>
/// <param name="Value">EN: The process identifier value. JA: process identifier value です。</param>
public readonly record struct ProcessId(Guid Value);

/// <summary>[EN] AIKernel logical process state. [JA] AIKernel logical process state です。 JA: ProcessState の公開契約を定義します。</summary>
public enum ProcessState
{
    /// <summary>[EN] Process is starting. [JA] process は起動中です。 JA: Starting 値を表します。</summary>
    Starting,
    /// <summary>[EN] Process is running. [JA] process は実行中です。 JA: Running 値を表します。</summary>
    Running,
    /// <summary>[EN] Process is stopped. [JA] process は停止済みです。 JA: Stopped 値を表します。</summary>
    Stopped,
    /// <summary>[EN] Process is in an error state. [JA] process は error state です。 JA: ProcessInfo の公開契約を定義します。</summary>
    Error
}

/// <summary>[EN] Public AIKernel process snapshot. [JA] 公開 AIKernel process snapshot です。 JA: ProcessInfo の公開契約を定義します。</summary>
/// <param name="Id">EN: The process identifier. JA: process identifier です。</param>
/// <param name="Name">EN: The process name. JA: process name です。</param>
/// <param name="State">EN: The process state. JA: process state です。</param>
/// <param name="StartedAtUtc">EN: The UTC start timestamp. JA: UTC start timestamp です。</param>
/// <param name="Metadata">EN: The process metadata. JA: process metadata です。</param>
public sealed record ProcessInfo(
    ProcessId Id,
    string Name,
    ProcessState State,
    DateTimeOffset StartedAtUtc,
    IReadOnlyDictionary<string, string> Metadata);

/// <summary>[EN] AIKernel logical process abstraction. [JA] AIKernel logical process 抽象です。 JA: IProcess の公開契約を定義します。</summary>
public interface IProcess
{
    /// <summary>[EN] Process identifier. [JA] process identifier です。 JA: StartAsync 操作を実行します。</summary>
    ProcessId Id { get; }

    /// <summary>[EN] Current process state. [JA] 現在の process state です。 JA: StartAsync 操作を実行します。</summary>
    ProcessState State { get; }

    /// <summary>[EN] Starts the process. [JA] process を開始します。 JA: StartAsync 操作を実行します。</summary>
    Task StartAsync();

    /// <summary>[EN] Stops the process. [JA] process を停止します。 JA: StopAsync 操作を実行します。</summary>
    Task StopAsync();
}

/// <summary>[EN] Host that creates AIKernel logical processes. [JA] AIKernel logical process を作成する host です。 JA: IProcessHost の公開契約を定義します。</summary>
public interface IProcessHost
{
    /// <summary>[EN] Creates a process. [JA] process を作成します。 JA: CreateProcessAsync 操作を実行します。</summary>
    Task<IProcess> CreateProcessAsync(string name, object? args = null);
}

/// <summary>[EN] Provider contract for process supervision. [JA] process supervision 向け Provider contract です。 JA: IProcessSupervisorProvider の公開契約を定義します。</summary>
public interface IProcessSupervisorProvider : IProvider
{
    /// <summary>[EN] Lists managed processes. [JA] 管理対象 process を列挙します。 JA: ListAsync 操作を実行します。</summary>
    Task<ProcessInfo[]> ListAsync();

    /// <summary>[EN] Kills a process. [JA] process を kill します。 JA: KillAsync 操作を実行します。</summary>
    Task KillAsync(ProcessId id);

    /// <summary>[EN] Restarts a process. [JA] process を restart します。 JA: RestartAsync 操作を実行します。</summary>
    Task RestartAsync(ProcessId id);
}
