namespace AIKernel.Abstractions.Compute;

/// <summary>
/// [EN] Public compute provider contract used by CPU, CUDA, WebGPU, and fallback compute implementations.
/// [JA] CPU、CUDA、WebGPU、fallback compute 実装で使用する public compute provider contract です。
/// </summary>
public interface IComputeProvider
{
    /// <summary>[EN] Human-readable provider name. [JA] 人間可読な Provider 名です。</summary>
    string Name { get; }

    /// <summary>[EN] Returns whether compute execution is available. [JA] compute execution が利用可能かどうかを返します。</summary>
    bool IsAvailable();

    /// <summary>[EN] Creates a compute buffer. [JA] compute buffer を作成します。</summary>
    Task<ComputeBuffer> CreateBufferAsync(int size);

    /// <summary>[EN] Writes bytes into a compute buffer. [JA] compute buffer へ byte を書き込みます。</summary>
    Task WriteBufferAsync(ComputeBuffer buffer, ReadOnlyMemory<byte> data);

    /// <summary>[EN] Reads bytes from a compute buffer. [JA] compute buffer から byte を読み取ります。</summary>
    Task ReadBufferAsync(ComputeBuffer buffer, Memory<byte> destination);

    /// <summary>[EN] Executes a compute kernel against one or more buffers. [JA] 1 つ以上の buffer に対して compute kernel を実行します。</summary>
    Task ExecuteKernelAsync(ComputeKernel kernel, params ComputeBuffer[] buffers);
}
