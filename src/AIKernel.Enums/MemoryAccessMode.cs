namespace AIKernel.Enums;

/// <summary>
/// Describes the requested access mode for a mapped memory region.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.MemoryAccessMode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.MemoryAccessMode']" />
public enum MemoryAccessMode
{
    /// <summary>
    /// The region is opened for read-only access.
    /// </summary>
    Read = 0,

    /// <summary>
    /// The region is opened for read and write access.
    /// </summary>
    ReadWrite = 1
}
