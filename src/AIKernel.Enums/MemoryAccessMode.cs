namespace AIKernel.Enums;

/// <summary>
/// EN: Describes the requested access mode for a mapped memory region.
/// [EN] Documents this public package API member. [JA] MemoryAccessMode の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.MemoryAccessMode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.MemoryAccessMode']" />
public enum MemoryAccessMode
{
    /// <summary>
    /// EN: The region is opened for read-only access.
    /// [EN] Documents this public package API member. [JA] Read 値を表します。
    /// </summary>
    Read = 0,

    /// <summary>
    /// EN: The region is opened for read and write access.
    /// [EN] Documents this public package API member. [JA] ReadWrite 値を表します。
    /// </summary>
    ReadWrite = 1
}
