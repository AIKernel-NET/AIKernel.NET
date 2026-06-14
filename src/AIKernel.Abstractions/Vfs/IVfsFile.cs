namespace AIKernel.Vfs;

/// <summary>
/// Vfs ファイルの互換合成インターフェースを定義します。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// JA: IVfsFile の公開契約を定義します。
/// </summary>
/// <remarks>
/// v0.0.2 以降、読み取り能力は <see cref="IReadableVfsFile"/> で表現します。
/// 本インターフェースは既存実装との互換性を維持するための読み取り可能ファイル contract です。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsFile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsFile']" />
public interface IVfsFile : IReadableVfsFile
{
}

