namespace AIKernel.Abstractions.Compute;

using System.Text.RegularExpressions;

/// <summary>
/// [EN] Compute kernel descriptor shared by OS compute providers.
/// [JA] OS compute Provider で共有する compute kernel descriptor です。
/// </summary>
public sealed class ComputeKernel
{
    private static readonly Regex WorkgroupSizePattern = new(
        @"@workgroup_size\((?<x>\d+)(,\s*(?<y>\d+))?(,\s*(?<z>\d+))?\)",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    /// <summary>[EN] Initializes a compute kernel descriptor. [JA] compute kernel descriptor を初期化します。</summary>
    public ComputeKernel(
        string source,
        int dispatchX,
        int dispatchY = 1,
        int dispatchZ = 1,
        object? nativePipeline = null)
    {
        Source = string.IsNullOrWhiteSpace(source)
            ? throw new ArgumentException("Kernel source is required.", nameof(source))
            : source;
        DispatchX = dispatchX > 0 ? dispatchX : throw new ArgumentOutOfRangeException(nameof(dispatchX));
        DispatchY = dispatchY > 0 ? dispatchY : throw new ArgumentOutOfRangeException(nameof(dispatchY));
        DispatchZ = dispatchZ > 0 ? dispatchZ : throw new ArgumentOutOfRangeException(nameof(dispatchZ));
        NativePipeline = nativePipeline;

        var match = WorkgroupSizePattern.Match(source);
        WorkgroupSizeX = match.Success ? int.Parse(match.Groups["x"].Value) : 1;
        WorkgroupSizeY = match.Success && match.Groups["y"].Success ? int.Parse(match.Groups["y"].Value) : 1;
        WorkgroupSizeZ = match.Success && match.Groups["z"].Success ? int.Parse(match.Groups["z"].Value) : 1;
    }

    /// <summary>[EN] Kernel source code. [JA] kernel source code です。</summary>
    public string Source { get; }

    /// <summary>[EN] Alias for WGSL source code. [JA] WGSL source code の alias です。</summary>
    public string Wgsl => Source;

    /// <summary>[EN] Workgroup size in X. [JA] X 方向の workgroup size です。</summary>
    public int WorkgroupSizeX { get; }

    /// <summary>[EN] Workgroup size in Y. [JA] Y 方向の workgroup size です。</summary>
    public int WorkgroupSizeY { get; }

    /// <summary>[EN] Workgroup size in Z. [JA] Z 方向の workgroup size です。</summary>
    public int WorkgroupSizeZ { get; }

    /// <summary>[EN] Dispatch groups in X. [JA] X 方向の dispatch group 数です。</summary>
    public int DispatchX { get; }

    /// <summary>[EN] Dispatch groups in Y. [JA] Y 方向の dispatch group 数です。</summary>
    public int DispatchY { get; }

    /// <summary>[EN] Dispatch groups in Z. [JA] Z 方向の dispatch group 数です。</summary>
    public int DispatchZ { get; }

    /// <summary>[EN] Optional native pipeline handle. [JA] 任意の native pipeline handle です。</summary>
    public object? NativePipeline { get; }

    /// <summary>[EN] Creates a standard WGSL vector-add kernel descriptor. [JA] 標準 WGSL vector-add kernel descriptor を作成します。</summary>
    public static ComputeKernel CreateVectorAdd(int elementCount, int workgroupSize = 64)
    {
        if (elementCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(elementCount));
        }

        if (workgroupSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(workgroupSize));
        }

        var dispatch = (int)Math.Ceiling(elementCount / (double)workgroupSize);
        return new ComputeKernel(
            string.Join(
                System.Environment.NewLine,
                "@group(0) @binding(0) var<storage, read> a: array<f32>;",
                "@group(0) @binding(1) var<storage, read> b: array<f32>;",
                "@group(0) @binding(2) var<storage, read_write> out: array<f32>;",
                "",
                $"@compute @workgroup_size({workgroupSize})",
                "fn main(@builtin(global_invocation_id) gid: vec3<u32>) {",
                "    let i = gid.x;",
                "    out[i] = a[i] + b[i];",
                "}"),
            dispatch);
    }
}
