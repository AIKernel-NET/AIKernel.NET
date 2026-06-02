namespace AIKernel.Vfs;

public sealed class VfsAuthenticationFailedException : UnauthorizedAccessException
{
    public VfsAuthenticationFailedException(string providerId)
        : base($"VFS credentials were rejected. ProviderId='{providerId}'.")
    {
        ProviderId = providerId;
    }

    public string ProviderId { get; }
}
