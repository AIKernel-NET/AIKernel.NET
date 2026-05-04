namespace AIKernel.Dtos.Sandbox;

public sealed class SandboxResourceUsage
{
    public double CpuUsagePercent { get; init; }
    public long MemoryUsageMb { get; init; }
    public long MemoryLimitMb { get; init; }
    public long DiskUsageMb { get; init; }
    public long DiskLimitMb { get; init; }
}

