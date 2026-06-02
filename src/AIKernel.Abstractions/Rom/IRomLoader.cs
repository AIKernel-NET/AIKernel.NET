namespace AIKernel.Abstractions.Rom;

using AIKernel.Dtos.Rom;
using AIKernel.Vfs;

public interface IRomLoader
{
    Task<RomSnapshot> LoadAsync(
        IVfsSession session,
        string path,
        CancellationToken cancellationToken = default);
}