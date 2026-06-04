namespace AIKernel.Abstractions.Time;

using AIKernel.Dtos.Time;

/// <summary>
/// Provides deterministic time to Kernel, DSL, ROM, and replay components.
/// </summary>
public interface IKernelClock
{
    KernelTimestamp GetCurrentTimestamp();
}
