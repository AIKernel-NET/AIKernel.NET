using AIKernel.Dtos.Diagnostics;

namespace AIKernel.Dtos.Runtime;

/// <summary>
/// EN: Describes a portable WebAssembly buffer boundary without exposing host implementation details. JA: ホスト実装詳細を公開せず portable WebAssembly buffer 境界を記述します。
/// </summary>
public sealed record WasmBufferDescriptor
{
    /// <summary>EN: Gets the buffer identifier. JA: バッファ識別子を取得します。</summary>
    public string BufferId { get; init; } = string.Empty;

    /// <summary>EN: Gets the buffer role. JA: バッファの役割を取得します。</summary>
    public string Role { get; init; } = string.Empty;

    /// <summary>EN: Gets the element type name. JA: 要素型名を取得します。</summary>
    public string ElementType { get; init; } = string.Empty;

    /// <summary>EN: Gets the shape as a comma-separated value. JA: カンマ区切りの shape を取得します。</summary>
    public string Shape { get; init; } = string.Empty;

    /// <summary>EN: Gets the buffer length in bytes. JA: バッファ長をバイト単位で取得します。</summary>
    public long LengthBytes { get; init; }

    /// <summary>EN: Gets buffer metadata. JA: バッファメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a WebAssembly invocation request without binding to a JavaScript host. JA: JavaScript host に束縛されず WebAssembly 呼び出し要求を保持します。
/// </summary>
public sealed record WasmInvocationRequest
{
    /// <summary>EN: Gets the invocation identifier. JA: 呼び出し識別子を取得します。</summary>
    public string InvocationId { get; init; } = string.Empty;

    /// <summary>EN: Gets the module identifier. JA: モジュール識別子を取得します。</summary>
    public string ModuleId { get; init; } = string.Empty;

    /// <summary>EN: Gets the exported member name. JA: export されたメンバー名を取得します。</summary>
    public string ExportName { get; init; } = string.Empty;

    /// <summary>EN: Gets input buffers. JA: 入力バッファを取得します。</summary>
    public IReadOnlyList<WasmBufferDescriptor> InputBuffers { get; init; } = [];

    /// <summary>EN: Gets output buffers. JA: 出力バッファを取得します。</summary>
    public IReadOnlyList<WasmBufferDescriptor> OutputBuffers { get; init; } = [];

    /// <summary>EN: Gets invocation metadata. JA: 呼び出しメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a WebAssembly invocation result. JA: WebAssembly 呼び出し結果を保持します。
/// </summary>
public sealed record WasmInvocationResult
{
    /// <summary>EN: Gets the invocation identifier. JA: 呼び出し識別子を取得します。</summary>
    public string InvocationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether invocation succeeded. JA: 呼び出しが成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when invocation failed. JA: 呼び出しに失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when invocation failed. JA: 呼び出しに失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result buffers. JA: 結果バッファを取得します。</summary>
    public IReadOnlyList<WasmBufferDescriptor> ResultBuffers { get; init; } = [];

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a WebAssembly execution context snapshot. JA: WebAssembly 実行文脈スナップショットを保持します。
/// </summary>
public sealed record WasmExecutionSnapshot
{
    /// <summary>EN: Gets the context identifier. JA: 文脈識別子を取得します。</summary>
    public string ContextId { get; init; } = string.Empty;

    /// <summary>EN: Gets the runtime identifier. JA: ランタイム識別子を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>EN: Gets loaded module identifiers. JA: 読み込み済みモジュール識別子を取得します。</summary>
    public IReadOnlyList<string> ModuleIds { get; init; } = [];

    /// <summary>EN: Gets whether context capture succeeded. JA: 文脈取得が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when context capture failed. JA: 文脈取得に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when context capture failed. JA: 文脈取得に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: スナップショットメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
