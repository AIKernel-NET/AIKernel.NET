using AIKernel.Enums;

namespace AIKernel.Abstractions.Memory;

/// <summary>
/// EN: Opens OS-backed memory regions through a contract-safe abstraction.
/// [EN] Documents this public package API member. [JA] IMemoryMapper の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Memory.IMemoryMapper']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Memory.IMemoryMapper']" />
public interface IMemoryMapper
{
    /// <summary>
    /// EN: Opens a memory region for the supplied path and access mode.
    /// [EN] Documents this public package API member. [JA] Open 操作を実行します。
    /// </summary>
    IMemoryRegion Open(
        string path,
        MemoryAccessMode accessMode = MemoryAccessMode.Read);
}
