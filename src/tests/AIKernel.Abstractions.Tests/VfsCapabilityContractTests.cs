using AIKernel.Dtos.Vfs;
using AIKernel.Vfs;

namespace AIKernel.Abstractions.Tests;

public sealed class VfsCapabilityContractTests
{
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
    public void ReadOnlySessionDoesNotExposeMutationCapabilities()
    {
        IReadableVfsSession session = new ReadOnlyVfsSession();

        Assert.False(session is IWritableVfsSession);
        Assert.False(session is IDeletableVfsSession);
        Assert.False(session is IQueryableVfsSession);
    }

    private sealed class ReadOnlyVfsSession : IReadableVfsSession
    {
        public string SessionId => "readonly";

        public Task<IReadableVfsFile> ReadReadableFileAsync(string path)
        {
            return Task.FromResult<IReadableVfsFile>(new ReadableFile(path));
        }

        public Task<bool> ExistsAsync(string path)
        {
            return Task.FromResult(path == "/context.md");
        }
    }

    private sealed class FullVfsSession : IVfsSession
    {
        public string SessionId => "full";

        public Task<IVfsFile> ReadFileAsync(string path)
        {
            return Task.FromResult<IVfsFile>(new ReadableFile(path));
        }

        public Task WriteFileAsync(string path, byte[] content)
        {
            return Task.CompletedTask;
        }

        public Task<IVfsDirectory> GetDirectoryAsync(string path)
        {
            return Task.FromResult<IVfsDirectory>(new NavigableDirectory(path));
        }

        public Task<bool> ExistsAsync(string path)
        {
            return Task.FromResult(true);
        }

        public Task DeleteAsync(string path)
        {
            return Task.CompletedTask;
        }

        public Task<IVfsQueryResult> QueryAsync(IVfsQuery query)
        {
            return Task.FromResult<IVfsQueryResult>(new EmptyQueryResult());
        }

        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
    }

    private sealed class ReadableFile(string path) : IVfsFile
    {
        public string Name => System.IO.Path.GetFileName(path);

        public string Path => path;

        public long Size => 0;

        public DateTime CreatedAt => DateTime.UnixEpoch;

        public DateTime ModifiedAt => DateTime.UnixEpoch;

        public Task<byte[]> ReadAsync()
        {
            return Task.FromResult(Array.Empty<byte>());
        }

        public Task<string> ReadAsTextAsync()
        {
            return Task.FromResult(string.Empty);
        }

        public IReadOnlyDictionary<string, string>? GetMetadata()
        {
            return null;
        }
    }

    private sealed class NavigableDirectory(string path) : IVfsDirectory
    {
        public string Name => path == "/" ? string.Empty : System.IO.Path.GetFileName(path);

        public string Path => path;

        public Task<IReadOnlyList<IVfsFile>> GetFilesAsync(bool recursive = false)
        {
            IReadOnlyList<IVfsFile> files = [new ReadableFile("/context.md")];
            return Task.FromResult(files);
        }

        public Task<IReadOnlyList<IVfsDirectory>> GetDirectoriesAsync()
        {
            IReadOnlyList<IVfsDirectory> directories = [];
            return Task.FromResult(directories);
        }

        public Task<IReadOnlyList<VfsEntry>> GetEntriesAsync()
        {
            IReadOnlyList<VfsEntry> entries = [];
            return Task.FromResult(entries);
        }

        public Task<IVfsDirectory?> GetSubdirectoryAsync(string name)
        {
            return Task.FromResult<IVfsDirectory?>(null);
        }

        public IReadOnlyDictionary<string, string>? GetMetadata()
        {
            return null;
        }
    }

    private sealed class EmptyQueryResult : IVfsQueryResult
    {
        public bool IsSuccessful => true;

        public int RowCount => 0;

        public IReadOnlyList<string> ColumnNames => [];

        public IReadOnlyList<VfsQueryRow> Rows => [];

        public string? ErrorMessage => null;
    }
}
