namespace AIKernel.Vfs;

/// <summary>
/// 階層移動可能な Vfs セッション能力を定義します。
/// </summary>
public interface INavigableVfsSession
{
    /// <summary>
    /// ディレクトリを取得します。
    /// </summary>
    /// <param name="path">ディレクトリパス</param>
    /// <returns>階層移動可能なディレクトリ</returns>
    /// <exception cref="ArgumentException">path が不正な場合にスローされます。</exception>
    /// <exception cref="DirectoryNotFoundException">対象ディレクトリが存在しない場合にスローされます。</exception>
    Task<INavigableVfsDirectory> GetNavigableDirectoryAsync(string path);
}
