using AIKernel.Enums;

namespace AIKernel.Abstractions.Memory;

/// <summary>
/// Opens OS-backed memory regions through a contract-safe abstraction.
/// </summary>
public interface IMemoryMapper
{
    /// <summary>
    /// Opens a memory region for the supplied path and access mode.
    /// </summary>
    IMemoryRegion Open(
        string path,
        MemoryAccessMode accessMode = MemoryAccessMode.Read);
}
