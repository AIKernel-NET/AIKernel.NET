using AIKernel.Dtos.Control;

namespace AIKernel.Abstractions.Control;

public interface IControlStateObserver
{
    ValueTask ObserveAsync(
        ControlStateSnapshot snapshot,
        CancellationToken cancellationToken = default);
}
