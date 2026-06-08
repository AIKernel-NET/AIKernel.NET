using AIKernel.Enums;

namespace AIKernel.Dtos.Memory;

/// <summary>
/// Contract-level metadata for an operating-system-backed memory region.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Memory.MemoryRegionInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Memory.MemoryRegionInfo']" />
public sealed record MemoryRegionInfo(
    string Path,
    long Length,
    MemoryAccessMode AccessMode);
