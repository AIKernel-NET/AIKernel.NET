namespace AIKernel.Dtos.Governance;

using AIKernel.Enums;

/// <summary>
/// ContextLifecycleState の契約を定義します。
/// </summary>
public sealed record ContextLifecycleState(
    ContextStage CurrentStage,
    DateTime CreatedAt,
    DateTime LastModifiedAt,
    long TotalSize,
    int FragmentCount,
    float CompressionCapacity);



