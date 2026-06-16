namespace AIKernel.Abstractions.Compute;

using System.Text.RegularExpressions;

/// <summary>
/// [EN] Compute kernel descriptor shared by OS compute providers.
/// [JA] OS compute Provider で共有する compute kernel descriptor です。
/// EN: Documentation for public API. JA: ComputeKernel の公開契約を定義します。
/// </summary>
public sealed class ComputeKernel
{
    private static readonly Regex WorkgroupSizePattern = new(
        @"@workgroup_size\((?<x>\d+)(,\s*(?<y>\d+))?(,\s*(?<z>\d+))?\)",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    /// <summary>[EN] Initializes a compute kernel descriptor. [JA] compute kernel descriptor を初期化します。 JA: ComputeKernel 操作を実行します。</summary>
    /// <param name="source">EN: The kernel source code. JA: kernel source code です。</param>
    /// <param name="dispatchX">EN: The dispatch group count in X. JA: X 方向の dispatch group 数です。</param>
    /// <param name="dispatchY">EN: The dispatch group count in Y. JA: Y 方向の dispatch group 数です。</param>
    /// <param name="dispatchZ">EN: The dispatch group count in Z. JA: Z 方向の dispatch group 数です。</param>
    /// <param name="nativePipeline">EN: The optional native pipeline handle. JA: 任意の native pipeline handle です。</param>
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

    /// <summary>[EN] Kernel source code. [JA] kernel source code です。 JA: Source を取得します。</summary>
    public string Source { get; }

    /// <summary>[EN] Alias for WGSL source code. [JA] WGSL source code の alias です。 JA: WorkgroupSizeX を取得します。</summary>
    public string Wgsl => Source;

    /// <summary>[EN] Workgroup size in X. [JA] X 方向の workgroup size です。 JA: WorkgroupSizeX を取得します。</summary>
    public int WorkgroupSizeX { get; }

    /// <summary>[EN] Workgroup size in Y. [JA] Y 方向の workgroup size です。 JA: WorkgroupSizeY を取得します。</summary>
    public int WorkgroupSizeY { get; }

    /// <summary>[EN] Workgroup size in Z. [JA] Z 方向の workgroup size です。 JA: WorkgroupSizeZ を取得します。</summary>
    public int WorkgroupSizeZ { get; }

    /// <summary>[EN] Dispatch groups in X. [JA] X 方向の dispatch group 数です。 JA: DispatchX を取得します。</summary>
    public int DispatchX { get; }

    /// <summary>[EN] Dispatch groups in Y. [JA] Y 方向の dispatch group 数です。 JA: DispatchY を取得します。</summary>
    public int DispatchY { get; }

    /// <summary>[EN] Dispatch groups in Z. [JA] Z 方向の dispatch group 数です。 JA: DispatchZ を取得します。</summary>
    public int DispatchZ { get; }

    /// <summary>[EN] Optional native pipeline handle. [JA] 任意の native pipeline handle です。 JA: NativePipeline を取得します。</summary>
    public object? NativePipeline { get; }

    /// <summary>[EN] Creates a standard WGSL vector-add kernel descriptor. [JA] 標準 WGSL vector-add kernel descriptor を作成します。 JA: CreateVectorAdd 操作を実行します。</summary>
    /// <param name="elementCount">EN: The vector element count. JA: vector element count です。</param>
    /// <param name="workgroupSize">EN: The workgroup size. JA: workgroup size です。</param>
    /// <returns>EN: The compute kernel descriptor. JA: compute kernel descriptor を返します。</returns>
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
