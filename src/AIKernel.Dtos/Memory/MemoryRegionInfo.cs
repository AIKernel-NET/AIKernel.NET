using AIKernel.Enums;

namespace AIKernel.Dtos.Memory;

/// <summary>
/// EN: Contract-level metadata for an operating-system-backed memory region.
/// EN: Documentation for public API. JA: MemoryRegionInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Memory.MemoryRegionInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Memory.MemoryRegionInfo']" />
public sealed record MemoryRegionInfo(
    string Path,
    long Length,
    MemoryAccessMode AccessMode);
