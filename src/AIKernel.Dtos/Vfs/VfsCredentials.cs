namespace AIKernel.Dtos.Vfs;

public sealed record VfsCredentials
{
    public string? Username { get; init; }

    public string? ApiKey { get; init; }

    public string? Token { get; init; }

    public IReadOnlyDictionary<string, string>? Parameters { get; init; }
}
