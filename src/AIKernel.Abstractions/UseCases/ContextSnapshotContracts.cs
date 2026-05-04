namespace AIKernel.Abstractions.UseCases;

public interface IContextSnapshot
{
    string SnapshotId { get; }
    string? ParentSnapshotId { get; }
    DateTimeOffset CreatedAtUtc { get; }
    string ContextHash { get; }
    Context.IContextCollection Context { get; }
}
