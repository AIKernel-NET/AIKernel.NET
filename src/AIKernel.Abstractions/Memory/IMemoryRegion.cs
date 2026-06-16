using AIKernel.Dtos.Memory;

namespace AIKernel.Abstractions.Memory;

/// <summary>
/// EN: Represents a mapped memory region without exposing OS-specific mapping APIs.
/// EN: Documentation for public API. JA: IMemoryRegion の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Memory.IMemoryRegion']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Memory.IMemoryRegion']" />
public interface IMemoryRegion : IDisposable
{
    /// <summary>
    /// EN: Gets the contract metadata for this region.
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    MemoryRegionInfo Info { get; }

    /// <summary>
    /// EN: Gets the native pointer for consumers that intentionally cross the ABI boundary.
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    IntPtr Pointer { get; }

    /// <summary>
    /// EN: Gets the mapped byte length.
    /// EN: Documentation for public API. JA: Unmap 操作を実行します。
    /// </summary>
    long Length { get; }

    /// <summary>
    /// EN: Gets whether the mapping is currently active.
    /// EN: Documentation for public API. JA: Unmap 操作を実行します。
    /// </summary>
    bool IsMapped { get; }

    /// <summary>
    /// EN: Releases the mapping. Implementations must make repeated calls safe.
    /// EN: Documentation for public API. JA: Unmap 操作を実行します。
    /// </summary>
    bool Unmap();
}
