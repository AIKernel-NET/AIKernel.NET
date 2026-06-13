namespace AIKernel.Abstractions.Logging;

using AIKernel.Abstractions.Providers;

/// <summary>[EN] OS log severity. [JA] OS log severity です。 JA: LogLevel の公開契約を定義します。</summary>
public enum LogLevel
{
    /// <summary>[EN] Trace severity. [JA] trace severity です。 JA: Trace 値を表します。</summary>
    Trace,
    /// <summary>[EN] Debug severity. [JA] debug severity です。 JA: Debug 値を表します。</summary>
    Debug,
    /// <summary>[EN] Information severity. [JA] information severity です。 JA: Information 値を表します。</summary>
    Information,
    /// <summary>[EN] Warning severity. [JA] warning severity です。 JA: Warning 値を表します。</summary>
    Warning,
    /// <summary>[EN] Error severity. [JA] error severity です。 JA: Error 値を表します。</summary>
    Error,
    /// <summary>[EN] Critical severity. [JA] critical severity です。 JA: ILoggingProvider の公開契約を定義します。</summary>
    Critical
}

/// <summary>[EN] Provider contract for OS logging. [JA] OS logging 向け Provider contract です。 JA: ILoggingProvider の公開契約を定義します。</summary>
public interface ILoggingProvider : IProvider
{
    /// <summary>[EN] Writes a log entry. [JA] log entry を書き込みます。 JA: Log 操作を実行します。</summary>
    void Log(LogLevel level, string message, Exception? ex = null);
}
