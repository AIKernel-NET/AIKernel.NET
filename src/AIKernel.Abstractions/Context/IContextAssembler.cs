namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Rom;
using AIKernel.Vfs;

public interface IContextAssembler
{
    Task<IContextSnapshot> AssembleAsync(
        IVfsSession session,
        ContextAssemblyRequest request,
        CancellationToken cancellationToken = default);
}