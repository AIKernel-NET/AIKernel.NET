namespace AIKernel.Dtos.Sandbox;

/// <summary>
/// SandboxResourceUsage の契約を定義します。
/// </summary>
public sealed class SandboxResourceUsage
{
    public double CpuUsagePercent { get; init; }
    public long MemoryUsageMb { get; init; }
    public long MemoryLimitMb { get; init; }
    public long DiskUsageMb { get; init; }
    public long DiskLimitMb { get; init; }
}




