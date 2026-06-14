namespace AIKernel.Vfs;

/// <summary>
/// [EN] Alias contract for OS file system providers. It preserves IVfsProvider while exposing file-system terminology.
/// [JA] OS file system Provider 向けの alias contract です。IVfsProvider を維持しつつ file-system terminology を公開します。
/// JA: IFileSystemProvider の公開契約を定義します。
/// </summary>
public interface IFileSystemProvider : IVfsProvider
{
}
