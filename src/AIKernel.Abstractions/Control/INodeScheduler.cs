namespace AIKernel.Abstractions.Control;

public interface INodeScheduler
{
    ValueTask<IReadOnlyList<IExecutionNode>> ScheduleAsync(
        IExecutionGraph graph,
        CancellationToken cancellationToken = default);
}
