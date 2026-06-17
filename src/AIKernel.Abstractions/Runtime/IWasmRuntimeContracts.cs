using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// EN: Represents a portable WebAssembly runtime boundary without JavaScript or browser implementation details. JA: JavaScript や browser 実装詳細を持たない portable WebAssembly runtime 境界を表します。
/// </summary>
public interface IWasmRuntime
{
    /// <summary>
    /// EN: Invokes a WebAssembly export through the runtime boundary. JA: ランタイム境界を通じて WebAssembly export を呼び出します。
    /// </summary>
    /// <param name="request">EN: The invocation request. JA: 呼び出し要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The invocation result. JA: 呼び出し結果を返します。</returns>
    ValueTask<WasmInvocationResult> InvokeAsync(WasmInvocationRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Represents a portable WebAssembly buffer boundary. JA: portable WebAssembly buffer 境界を表します。
/// </summary>
public interface IWasmBuffer
{
    /// <summary>
    /// EN: Describes the buffer. JA: バッファを記述します。
    /// </summary>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The buffer descriptor. JA: バッファ記述子を返します。</returns>
    ValueTask<WasmBufferDescriptor> DescribeAsync(CancellationToken cancellationToken);
}

/// <summary>
/// EN: Represents a portable WebAssembly execution context boundary. JA: portable WebAssembly execution context 境界を表します。
/// </summary>
public interface IWasmExecutionContext
{
    /// <summary>
    /// EN: Captures the execution context snapshot. JA: 実行文脈スナップショットを取得します。
    /// </summary>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The execution context snapshot. JA: 実行文脈スナップショットを返します。</returns>
    ValueTask<WasmExecutionSnapshot> SnapshotAsync(CancellationToken cancellationToken);
}
