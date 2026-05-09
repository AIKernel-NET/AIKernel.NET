namespace AIKernel.Vfs;

/// <summary>
/// 削除可能な Vfs セッション能力を定義します。
/// </summary>
public interface IDeletableVfsSession
{
    /// <summary>
    /// ファイル/ディレクトリを削除します。
    /// </summary>
    /// <param name="path">パス</param>
    /// <returns>削除完了を表すタスク</returns>
    /// <exception cref="ArgumentException">path が不正な場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">削除権限がない場合にスローされます。</exception>
    Task DeleteAsync(string path);
}
