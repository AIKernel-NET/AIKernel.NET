namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Rom;

public interface IRomPathResolver
{
    ValueTask<string> ResolvePathAsync(
        RomId romId,
        CancellationToken cancellationToken = default);
}
