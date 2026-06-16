using AIKernel.Dtos.Vfs;
using AIKernel.Vfs;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// EN: Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class VfsCapabilityContractTests
{
    /// <summary>
    /// EN: Executes CompositeSessionExposesGranularCapabilities.
    /// EN: Documentation for public API. JA: CompositeSessionExposesGranularCapabilities を実行します。
    /// </summary>
    [Fact]
    public async Task CompositeSessionExposesGranularCapabilities()
    {
        IVfsSession session = new FullVfsSession();

        Assert.IsAssignableFrom<IReadableVfsSession>(session);
        Assert.IsAssignableFrom<IWritableVfsSession>(session);
        Assert.IsAssignableFrom<IDeletableVfsSession>(session);
        Assert.IsAssignableFrom<INavigableVfsSession>(session);
        Assert.IsAssignableFrom<IQueryableVfsSession>(session);

        IReadableVfsFile readableFile = await ((IReadableVfsSession)session).ReadReadableFileAsync("/context.md");
        INavigableVfsDirectory navigableDirectory = await ((INavigableVfsSession)session).GetNavigableDirectoryAsync("/");

        Assert.Equal("context.md", readableFile.Name);
        Assert.Equal("/", navigableDirectory.Path);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ReadOnlySessionDoesNotExposeMutationCapabilities()
    {
        IReadableVfsSession session = new ReadOnlyVfsSession();

        Assert.False(session is IWritableVfsSession);
        Assert.False(session is IDeletableVfsSession);
        Assert.False(session is IQueryableVfsSession);
    }

    private sealed class ReadOnlyVfsSession : IReadableVfsSession
    {
        /// <summary>
        /// EN: Gets SessionId.
        /// EN: Documentation for public API. JA: SessionId を取得します。
        /// </summary>
        public string SessionId => "readonly";

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadableVfsFile> ReadReadableFileAsync(string path)
        {
            return Task.FromResult<IReadableVfsFile>(new ReadableFile(path));
        }
        /// <summary>
        /// EN: Executes ExistsAsync.
        /// EN: Documentation for public API. JA: ExistsAsync を実行します。
        /// </summary>

        public Task<bool> ExistsAsync(string path)
        {
            return Task.FromResult(path == "/context.md");
        }
    }

    private sealed class FullVfsSession : IVfsSession
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string SessionId => "full";
        /// <summary>
        /// EN: Executes ReadFileAsync.
        /// EN: Documentation for public API. JA: ReadFileAsync を実行します。
        /// </summary>

        public Task<IVfsFile> ReadFileAsync(string path)
        {
            return Task.FromResult<IVfsFile>(new ReadableFile(path));
        }
        /// <summary>
        /// EN: Executes WriteFileAsync.
        /// EN: Documentation for public API. JA: WriteFileAsync を実行します。
        /// </summary>

        public Task WriteFileAsync(string path, byte[] content)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IVfsDirectory> GetDirectoryAsync(string path)
        {
            return Task.FromResult<IVfsDirectory>(new NavigableDirectory(path));
        }
        /// <summary>
        /// EN: Executes ExistsAsync.
        /// EN: Documentation for public API. JA: ExistsAsync を実行します。
        /// </summary>

        public Task<bool> ExistsAsync(string path)
        {
            return Task.FromResult(true);
        }
        /// <summary>
        /// EN: Executes DeleteAsync.
        /// EN: Documentation for public API. JA: DeleteAsync を実行します。
        /// </summary>

        public Task DeleteAsync(string path)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IVfsQueryResult> QueryAsync(IVfsQuery query)
        {
            return Task.FromResult<IVfsQueryResult>(new EmptyQueryResult());
        }
        /// <summary>
        /// EN: Executes DisposeAsync.
        /// EN: Documentation for public API. JA: DisposeAsync を実行します。
        /// </summary>

        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
    }

    private sealed class ReadableFile(string path) : IVfsFile
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string Name => System.IO.Path.GetFileName(path);
        /// <summary>
        /// EN: Gets Path.
        /// EN: Documentation for public API. JA: Path を取得します。
        /// </summary>

        public string Path => path;
        /// <summary>
        /// EN: Gets Size.
        /// EN: Documentation for public API. JA: Size を取得します。
        /// </summary>

        public long Size => 0;
        /// <summary>
        /// EN: Gets CreatedAt.
        /// EN: Documentation for public API. JA: CreatedAt を取得します。
        /// </summary>

        public DateTime CreatedAt => DateTime.UnixEpoch;
        /// <summary>
        /// EN: Gets ModifiedAt.
        /// EN: Documentation for public API. JA: ModifiedAt を取得します。
        /// </summary>

        public DateTime ModifiedAt => DateTime.UnixEpoch;
        /// <summary>
        /// EN: Executes ReadAsync.
        /// EN: Documentation for public API. JA: ReadAsync を実行します。
        /// </summary>

        public Task<byte[]> ReadAsync()
        {
            return Task.FromResult(Array.Empty<byte>());
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<string> ReadAsTextAsync()
        {
            return Task.FromResult(string.Empty);
        }
        /// <summary>
        /// EN: Executes GetMetadata.
        /// EN: Documentation for public API. JA: GetMetadata を実行します。
        /// </summary>

        public IReadOnlyDictionary<string, string>? GetMetadata()
        {
            return null;
        }
    }

    private sealed class NavigableDirectory(string path) : IVfsDirectory
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string Name => path == "/" ? string.Empty : System.IO.Path.GetFileName(path);
        /// <summary>
        /// EN: Gets Path.
        /// EN: Documentation for public API. JA: Path を取得します。
        /// </summary>

        public string Path => path;
        /// <summary>
        /// EN: Executes GetFilesAsync.
        /// EN: Documentation for public API. JA: GetFilesAsync を実行します。
        /// </summary>

        public Task<IReadOnlyList<IVfsFile>> GetFilesAsync(bool recursive = false)
        {
            IReadOnlyList<IVfsFile> files = [new ReadableFile("/context.md")];
            return Task.FromResult(files);
        }
        /// <summary>
        /// EN: Executes GetDirectoriesAsync.
        /// EN: Documentation for public API. JA: GetDirectoriesAsync を実行します。
        /// </summary>

        public Task<IReadOnlyList<IVfsDirectory>> GetDirectoriesAsync()
        {
            IReadOnlyList<IVfsDirectory> directories = [];
            return Task.FromResult(directories);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadOnlyList<VfsEntry>> GetEntriesAsync()
        {
            IReadOnlyList<VfsEntry> entries = [];
            return Task.FromResult(entries);
        }
        /// <summary>
        /// EN: Executes GetSubdirectoryAsync.
        /// EN: Documentation for public API. JA: GetSubdirectoryAsync を実行します。
        /// </summary>

        public Task<IVfsDirectory?> GetSubdirectoryAsync(string name)
        {
            return Task.FromResult<IVfsDirectory?>(null);
        }
        /// <summary>
        /// EN: Executes GetMetadata.
        /// EN: Documentation for public API. JA: GetMetadata を実行します。
        /// </summary>

        public IReadOnlyDictionary<string, string>? GetMetadata()
        {
            return null;
        }
    }

    private sealed class EmptyQueryResult : IVfsQueryResult
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public bool IsSuccessful => true;
        /// <summary>
        /// EN: Gets RowCount.
        /// EN: Documentation for public API. JA: RowCount を取得します。
        /// </summary>

        public int RowCount => 0;
        /// <summary>
        /// EN: Gets ColumnNames.
        /// EN: Documentation for public API. JA: ColumnNames を取得します。
        /// </summary>

        public IReadOnlyList<string> ColumnNames => [];
        /// <summary>
        /// EN: Gets Rows.
        /// EN: Documentation for public API. JA: Rows を取得します。
        /// </summary>

        public IReadOnlyList<VfsQueryRow> Rows => [];
        /// <summary>
        /// EN: Gets ErrorMessage.
        /// EN: Documentation for public API. JA: ErrorMessage を取得します。
        /// </summary>

        public string? ErrorMessage => null;
    }
}
