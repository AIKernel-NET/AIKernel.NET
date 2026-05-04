namespace AIKernel.Dtos.Governance;

using AIKernel.Enums;

public sealed record ContextLifecycleState(
    ContextStage CurrentStage,
    DateTime CreatedAt,
    DateTime LastModifiedAt,
    long TotalSize,
    int FragmentCount,
    float CompressionCapacity);
