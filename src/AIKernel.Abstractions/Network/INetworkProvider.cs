namespace AIKernel.Abstractions.Network;

using AIKernel.Abstractions.Providers;

/// <summary>[EN] Network stream abstraction. [JA] network stream 抽象です。 JA: INetworkStream の公開契約を定義します。</summary>
public interface INetworkStream : IAsyncDisposable
{
    /// <summary>[EN] Reads bytes from the stream. [JA] stream から byte を読み取ります。 JA: ReadAsync 操作を実行します。</summary>
    ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>[EN] Writes bytes to the stream. [JA] stream へ byte を書き込みます。 JA: WriteAsync 操作を実行します。</summary>
    ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
}

/// <summary>[EN] HTTP response abstraction. [JA] HTTP response 抽象です。 JA: IHttpResponse の公開契約を定義します。</summary>
public interface IHttpResponse
{
    /// <summary>[EN] HTTP status code. [JA] HTTP status code です。 JA: INetworkProvider の公開契約を定義します。</summary>
    int StatusCode { get; }

    /// <summary>[EN] Response body bytes. [JA] response body byte です。 JA: INetworkProvider の公開契約を定義します。</summary>
    byte[] Body { get; }

    /// <summary>[EN] Response headers. [JA] response header です。 JA: INetworkProvider の公開契約を定義します。</summary>
    IReadOnlyDictionary<string, string> Headers { get; }
}

/// <summary>[EN] Provider contract for OS-level network access. [JA] OS-level network access 向け Provider contract です。 JA: INetworkProvider の公開契約を定義します。</summary>
public interface INetworkProvider : IProvider
{
    /// <summary>[EN] Connects to a host and port. [JA] host と port へ接続します。 JA: ConnectAsync 操作を実行します。</summary>
    Task<INetworkStream> ConnectAsync(string host, int port);

    /// <summary>[EN] Executes an HTTP GET. [JA] HTTP GET を実行します。 JA: HttpGetAsync 操作を実行します。</summary>
    Task<IHttpResponse> HttpGetAsync(string url);

    /// <summary>[EN] Executes an HTTP POST. [JA] HTTP POST を実行します。 JA: HttpPostAsync 操作を実行します。</summary>
    Task<IHttpResponse> HttpPostAsync(string url, byte[] body);
}
