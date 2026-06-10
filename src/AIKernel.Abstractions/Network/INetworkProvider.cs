namespace AIKernel.Abstractions.Network;

using AIKernel.Abstractions.Providers;

/// <summary>[EN] Network stream abstraction. [JA] network stream 抽象です。</summary>
public interface INetworkStream : IAsyncDisposable
{
    /// <summary>[EN] Reads bytes from the stream. [JA] stream から byte を読み取ります。</summary>
    ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>[EN] Writes bytes to the stream. [JA] stream へ byte を書き込みます。</summary>
    ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
}

/// <summary>[EN] HTTP response abstraction. [JA] HTTP response 抽象です。</summary>
public interface IHttpResponse
{
    /// <summary>[EN] HTTP status code. [JA] HTTP status code です。</summary>
    int StatusCode { get; }

    /// <summary>[EN] Response body bytes. [JA] response body byte です。</summary>
    byte[] Body { get; }

    /// <summary>[EN] Response headers. [JA] response header です。</summary>
    IReadOnlyDictionary<string, string> Headers { get; }
}

/// <summary>[EN] Provider contract for OS-level network access. [JA] OS-level network access 向け Provider contract です。</summary>
public interface INetworkProvider : IProvider
{
    /// <summary>[EN] Connects to a host and port. [JA] host と port へ接続します。</summary>
    Task<INetworkStream> ConnectAsync(string host, int port);

    /// <summary>[EN] Executes an HTTP GET. [JA] HTTP GET を実行します。</summary>
    Task<IHttpResponse> HttpGetAsync(string url);

    /// <summary>[EN] Executes an HTTP POST. [JA] HTTP POST を実行します。</summary>
    Task<IHttpResponse> HttpPostAsync(string url, byte[] body);
}
