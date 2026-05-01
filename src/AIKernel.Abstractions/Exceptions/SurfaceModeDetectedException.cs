namespace AIKernel.Abstractions.Exceptions;

/// <summary>
/// 表面的な模写/生成が検出されたことを示す例外。
/// 実質的な推論ではなく、パターンマッチングや表面的な処理が行われていることを示します。
/// </summary>
public class SurfaceModeDetectedException : Exception
{
    /// <summary>
    /// SurfaceModeDetectedException を初期化します。
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    public SurfaceModeDetectedException(string message) : base(message)
    {
    }

    /// <summary>
    /// SurfaceModeDetectedException を初期化します。
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    /// <param name="innerException">内部例外</param>
    public SurfaceModeDetectedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
