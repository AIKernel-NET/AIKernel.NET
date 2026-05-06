namespace AIKernel.Abstractions.Context;

/// <summary>
/// UC-06/UC-08 に基づく IContextSnapshot の契約を定義します。
/// </summary>
public interface IContextSnapshot
{
    string SnapshotId { get; }
    string? ParentSnapshotId { get; }
    DateTimeOffset CreatedAtUtc { get; }
    string ContextHash { get; }
    IContextCollection Context { get; }
}



