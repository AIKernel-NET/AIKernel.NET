namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Rom;

public interface IContextHashCalculator
{
    string ComputeHash(
        ContextAssemblyRequest request,
        IReadOnlyList<RomSnapshot> roms,
        IReadOnlyList<RomContextEdge> edges);
}
