namespace AIKernel.Dtos.Sandbox;

/// <summary>
/// EN: SandboxResourceUsage の契約を定義します。
/// EN: Documentation for public API. JA: SandboxResourceUsage の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Sandbox.SandboxResourceUsage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Sandbox.SandboxResourceUsage']" />
public sealed class SandboxResourceUsage
{
    /// <summary>EN: Documentation for public API. JA: CpuUsagePercent を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.CpuUsagePercent']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.CpuUsagePercent']" />
    public double CpuUsagePercent { get; init; }
    /// <summary>EN: Documentation for public API. JA: MemoryUsageMb を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryUsageMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryUsageMb']" />
    public long MemoryUsageMb { get; init; }
    /// <summary>EN: Documentation for public API. JA: MemoryLimitMb を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryLimitMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryLimitMb']" />
    public long MemoryLimitMb { get; init; }
    /// <summary>EN: Documentation for public API. JA: DiskUsageMb を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskUsageMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskUsageMb']" />
    public long DiskUsageMb { get; init; }
    /// <summary>EN: Documentation for public API. JA: DiskLimitMb を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskLimitMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskLimitMb']" />
    public long DiskLimitMb { get; init; }
}




