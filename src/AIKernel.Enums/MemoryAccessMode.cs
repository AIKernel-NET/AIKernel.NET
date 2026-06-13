namespace AIKernel.Enums;

/// <summary>
/// Describes the requested access mode for a mapped memory region.
/// JA: MemoryAccessMode の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.MemoryAccessMode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.MemoryAccessMode']" />
public enum MemoryAccessMode
{
    /// <summary>
    /// The region is opened for read-only access.
    /// JA: Read 値を表します。
    /// </summary>
    Read = 0,

    /// <summary>
    /// The region is opened for read and write access.
    /// JA: ReadWrite 値を表します。
    /// </summary>
    ReadWrite = 1
}
