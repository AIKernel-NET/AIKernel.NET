namespace AIKernel.Vfs;

/// <summary>
/// EN: 読み取り可能な Vfs セッション能力を定義します。
/// [EN] Documents this public package API member. [JA] IReadableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsSession']" />
public interface IReadableVfsSession
{
    /// <summary>
    /// EN: セッションの一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] ReadReadableFileAsync 操作を実行します。
    /// </summary>
    string SessionId { get; }

    /// <summary>
    /// EN: ファイルを読み取ります。
    /// [EN] Documents this public package API member. [JA] ReadReadableFileAsync 操作を実行します。
    /// </summary>
    /// <param name="path">[EN] Documents this public package API member. [JA] ファイルパス path パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 読み取り可能なファイル 結果を返します。</returns>
    Task<IReadableVfsFile> ReadReadableFileAsync(string path);

    /// <summary>
    /// EN: ファイル/ディレクトリが存在するかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] ExistsAsync 操作を実行します。
    /// </summary>
    /// <param name="path">[EN] Documents this public package API member. [JA] パス path パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 存在する場合は true。 結果を返します。</returns>
    Task<bool> ExistsAsync(string path);
}
