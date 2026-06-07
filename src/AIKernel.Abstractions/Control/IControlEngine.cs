using AIKernel.Dtos.Control;

namespace AIKernel.Abstractions.Control;

public interface IControlEngine
{
    string EngineId { get; }

    ValueTask<ControlExecutionResult> ExecuteAsync(
        IExecutionGraph graph,
        ControlExecutionRequest request,
        CancellationToken cancellationToken = default);
}
