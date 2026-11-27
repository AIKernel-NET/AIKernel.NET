namespace AIKernel.Vfs;

/// <summary>
/// EN: 階層移動可能な Vfs セッション能力を定義します。
/// [EN] Documents this public package API member. [JA] INavigableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
public interface INavigableVfsSession : IVfsSessionHandle
{
    /// <summary>
    /// EN: ディレクトリを取得します。
    /// [EN] Documents this public package API member. [JA] GetNavigableDirectoryAsync 操作を実行します。
    /// </summary>
    /// <param name="path">[EN] Documents this public package API member. [JA] ディレクトリパス path パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 階層移動可能なディレクトリ 結果を返します。</returns>
    Task<INavigableVfsDirectory> GetNavigableDirectoryAsync(string path);
    /// <summary>EN: Checks cancellation before dispatch. JA: 要求取消を確認してから実行します。</summary>
    Task<INavigableVfsDirectory> GetNavigableDirectoryAsync(string path, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return GetNavigableDirectoryAsync(path);
    }
}
