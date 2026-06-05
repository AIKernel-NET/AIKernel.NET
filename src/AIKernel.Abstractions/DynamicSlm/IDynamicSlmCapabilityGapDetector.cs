namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Execution;

public interface IDynamicSlmCapabilityGapDetector
{
    ValueTask<IReadOnlyList<DynamicSlmCapabilityGap>> DetectGapsAsync(
        DynamicSlmModelAbi modelAbi,
        IReadOnlyList<ReplayDump> replayTraces,
        CancellationToken cancellationToken = default);
}
