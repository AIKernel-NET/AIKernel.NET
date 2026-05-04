namespace AIKernel.Abstractions.UseCases;

public interface IConversationSnapshot
{
    string SnapshotId { get; }
    string BranchId { get; }
    DateTimeOffset TimestampUtc { get; }
    int MessageCount { get; }
}

public interface IConversationBranch
{
    string BranchId { get; }
    string Name { get; }
    string HeadSnapshotId { get; }
    Task<IConversationBranch> ForkFromAsync(string snapshotId, string newBranchName, CancellationToken ct = default);
}

public interface IConversationCheckpoint
{
    string CheckpointId { get; }
    string SnapshotId { get; }
    string Label { get; }
    DateTimeOffset PinnedAtUtc { get; }
}

public interface IConversationDiff
{
    string BaseSnapshotId { get; }
    string TargetSnapshotId { get; }
    IReadOnlyList<string> ChangedSections { get; }
    bool HasConflicts { get; }
}

public interface IConversationTimeline
{
    Task<IReadOnlyList<IConversationSnapshot>> GetTimelineAsync(string branchId, CancellationToken ct = default);
    Task<IConversationSnapshot?> GetHeadAsync(string branchId, CancellationToken ct = default);
    Task<IConversationCheckpoint?> FindCheckpointAsync(string checkpointId, CancellationToken ct = default);
}

public interface IConversationStore
{
    Task SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default);
    Task<IConversationSnapshot?> GetSnapshotAsync(string snapshotId, CancellationToken ct = default);
    Task<IReadOnlyList<IConversationBranch>> ListBranchesAsync(CancellationToken ct = default);
    Task DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default);
}

public interface IDiffFormatter
{
    string Format(IConversationDiff diff);
    string FormatAsMarkdown(IConversationDiff diff);
    string FormatAsJson(IConversationDiff diff);
}
