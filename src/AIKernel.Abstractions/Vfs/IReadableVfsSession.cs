namespace AIKernel.Vfs;

/// <summary>
/// 読み取り可能な Vfs セッション能力を定義します。
/// JA: IReadableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsSession']" />
public interface IReadableVfsSession
{
    /// <summary>
    /// セッションの一意識別子を取得します。
    /// JA: ReadReadableFileAsync 操作を実行します。
    /// </summary>
    string SessionId { get; }

    /// <summary>
    /// ファイルを読み取ります。
    /// JA: ReadReadableFileAsync 操作を実行します。
    /// </summary>
    /// <param name="path">ファイルパス JA: path パラメーターです。</param>
    /// <returns>読み取り可能なファイル JA: 結果を返します。</returns>
    Task<IReadableVfsFile> ReadReadableFileAsync(string path);

    /// <summary>
    /// ファイル/ディレクトリが存在するかどうかを確認します。
    /// JA: ExistsAsync 操作を実行します。
    /// </summary>
    /// <param name="path">パス JA: path パラメーターです。</param>
    /// <returns>存在する場合は true。 JA: 結果を返します。</returns>
    Task<bool> ExistsAsync(string path);
}
