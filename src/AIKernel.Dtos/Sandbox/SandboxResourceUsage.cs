namespace AIKernel.Dtos.Sandbox;

/// <summary>
/// SandboxResourceUsage の契約を定義します。
/// JA: SandboxResourceUsage の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Sandbox.SandboxResourceUsage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Sandbox.SandboxResourceUsage']" />
public sealed class SandboxResourceUsage
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.CpuUsagePercent']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.CpuUsagePercent']" />
    public double CpuUsagePercent { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryUsageMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryUsageMb']" />
    public long MemoryUsageMb { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryLimitMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.MemoryLimitMb']" />
    public long MemoryLimitMb { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskUsageMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskUsageMb']" />
    public long DiskUsageMb { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskLimitMb']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxResourceUsage.DiskLimitMb']" />
    public long DiskLimitMb { get; init; }
}




