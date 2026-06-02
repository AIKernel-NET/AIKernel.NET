namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Rom;

public interface IContextCollectionFactory
{
    IContextCollection Create(
        IReadOnlyList<RomSnapshot> roms,
        IReadOnlyList<RomContextEdge> edges,
        ContextAssemblyScope scope);
}
