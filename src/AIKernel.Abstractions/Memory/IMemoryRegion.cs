using AIKernel.Dtos.Memory;

namespace AIKernel.Abstractions.Memory;

/// <summary>
/// Represents a mapped memory region without exposing OS-specific mapping APIs.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Memory.IMemoryRegion']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Memory.IMemoryRegion']" />
public interface IMemoryRegion : IDisposable
{
    /// <summary>
    /// Gets the contract metadata for this region.
    /// </summary>
    MemoryRegionInfo Info { get; }

    /// <summary>
    /// Gets the native pointer for consumers that intentionally cross the ABI boundary.
    /// </summary>
    IntPtr Pointer { get; }

    /// <summary>
    /// Gets the mapped byte length.
    /// </summary>
    long Length { get; }

    /// <summary>
    /// Gets whether the mapping is currently active.
    /// </summary>
    bool IsMapped { get; }

    /// <summary>
    /// Releases the mapping. Implementations must make repeated calls safe.
    /// </summary>
    bool Unmap();
}
