using AIKernel.Enums;

namespace AIKernel.Dtos.Memory;

/// <summary>
/// Contract-level metadata for an operating-system-backed memory region.
/// </summary>
public sealed record MemoryRegionInfo(
    string Path,
    long Length,
    MemoryAccessMode AccessMode);
