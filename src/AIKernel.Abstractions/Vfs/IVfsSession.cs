namespace AIKernel.Vfs;

/// <summary>
/// Vfs セッションの互換合成インターフェースを定義します。
/// EN: ファイルシステム操作を行うセッション。
/// EN: Documentation for public API. JA: IVfsSession の公開契約を定義します。
/// </summary>
/// <remarks>
/// v0.0.2 以降、読み取り、書き込み、削除、階層移動、クエリは能力別 interface で表現します。
/// UC-08/UC-18 の全権限セッションは、本合成契約を通じて実行されます。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsSession']" />
public interface IVfsSession :
    IReadableVfsSession,
    IWritableVfsSession,
    IDeletableVfsSession,
    INavigableVfsSession,
    IQueryableVfsSession,
    IAsyncDisposable
{
    /// <summary>
    /// EN: ファイルを読み取ります。
    /// EN: Documentation for public API. JA: ReadFileAsync 操作を実行します。
    /// </summary>
    /// <param name="path">EN: Documentation for public API. JA: ファイルパス path パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: ファイル 結果を返します。</returns>
    Task<IVfsFile> ReadFileAsync(string path);

    /// <summary>
    /// EN: ディレクトリを取得します。
    /// EN: Documentation for public API. JA: GetDirectoryAsync 操作を実行します。
    /// </summary>
    /// <param name="path">EN: Documentation for public API. JA: ディレクトリパス path パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: ディレクトリ 結果を返します。</returns>
    Task<IVfsDirectory> GetDirectoryAsync(string path);

    async Task<IReadableVfsFile> IReadableVfsSession.ReadReadableFileAsync(string path)
    {
        return await ReadFileAsync(path).ConfigureAwait(false);
    }

    async Task<INavigableVfsDirectory> INavigableVfsSession.GetNavigableDirectoryAsync(string path)
    {
        return await GetDirectoryAsync(path).ConfigureAwait(false);
    }
}

