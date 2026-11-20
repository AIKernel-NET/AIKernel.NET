namespace AIKernel.Abstractions.Compute;

/// <summary>
/// [EN] Public compute provider contract used by CPU, CUDA, WebGPU, and fallback compute implementations.
/// [JA] CPU、CUDA、WebGPU、fallback compute 実装で使用する public compute provider contract です。
/// [EN] Documents this public package API member. [JA] IComputeProvider の公開契約を定義します。
/// </summary>
public interface IComputeProvider
{
    /// <summary>[EN] Human-readable provider name. [JA] 人間可読な Provider 名です。 JA: IsAvailable 操作を実行します。</summary>
    string Name { get; }

    /// <summary>[EN] Returns whether compute execution is available. [JA] compute execution が利用可能かどうかを返します。 JA: IsAvailable 操作を実行します。</summary>
    bool IsAvailable();

    /// <summary>[EN] Creates a compute buffer. [JA] compute buffer を作成します。 JA: CreateBufferAsync 操作を実行します。</summary>
    Task<ComputeBuffer> CreateBufferAsync(int size);

    /// <summary>Checks cancellation before dispatch. Implementations can override this overload to cancel active work.</summary>
    Task<ComputeBuffer> CreateBufferAsync(int size, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return CreateBufferAsync(size);
    }

    /// <summary>[EN] Writes bytes into a compute buffer. [JA] compute buffer へ byte を書き込みます。 JA: WriteBufferAsync 操作を実行します。</summary>
    Task WriteBufferAsync(ComputeBuffer buffer, ReadOnlyMemory<byte> data);

    /// <summary>Checks cancellation before dispatch. Implementations can override this overload to cancel active work.</summary>
    Task WriteBufferAsync(ComputeBuffer buffer, ReadOnlyMemory<byte> data, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return WriteBufferAsync(buffer, data);
    }

    /// <summary>[EN] Reads bytes from a compute buffer. [JA] compute buffer から byte を読み取ります。 JA: ReadBufferAsync 操作を実行します。</summary>
    Task ReadBufferAsync(ComputeBuffer buffer, Memory<byte> destination);

    /// <summary>Checks cancellation before dispatch. Implementations can override this overload to cancel active work.</summary>
    Task ReadBufferAsync(ComputeBuffer buffer, Memory<byte> destination, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return ReadBufferAsync(buffer, destination);
    }

    /// <summary>[EN] Executes a compute kernel against one or more buffers. [JA] 1 つ以上の buffer に対して compute kernel を実行します。 JA: ExecuteKernelAsync 操作を実行します。</summary>
    Task ExecuteKernelAsync(ComputeKernel kernel, params ComputeBuffer[] buffers);

    /// <summary>Checks cancellation before dispatch. Implementations can override this overload to cancel active work.</summary>
    Task ExecuteKernelAsync(ComputeKernel kernel, CancellationToken cancellationToken, params ComputeBuffer[] buffers)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return ExecuteKernelAsync(kernel, buffers);
    }
}
