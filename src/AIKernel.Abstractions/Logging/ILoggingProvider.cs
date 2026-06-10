namespace AIKernel.Abstractions.Logging;

using AIKernel.Abstractions.Providers;

/// <summary>[EN] OS log severity. [JA] OS log severity です。</summary>
public enum LogLevel
{
    /// <summary>[EN] Trace severity. [JA] trace severity です。</summary>
    Trace,
    /// <summary>[EN] Debug severity. [JA] debug severity です。</summary>
    Debug,
    /// <summary>[EN] Information severity. [JA] information severity です。</summary>
    Information,
    /// <summary>[EN] Warning severity. [JA] warning severity です。</summary>
    Warning,
    /// <summary>[EN] Error severity. [JA] error severity です。</summary>
    Error,
    /// <summary>[EN] Critical severity. [JA] critical severity です。</summary>
    Critical
}

/// <summary>[EN] Provider contract for OS logging. [JA] OS logging 向け Provider contract です。</summary>
public interface ILoggingProvider : IProvider
{
    /// <summary>[EN] Writes a log entry. [JA] log entry を書き込みます。</summary>
    void Log(LogLevel level, string message, Exception? ex = null);
}
