namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmPayloadLoader
{
    ValueTask<IReadOnlyList<DynamicSlmLoadedPayload>> MaterializeAsync(
        IReadOnlyList<DynamicSlmPayloadDescriptor> payloads,
        CancellationToken cancellationToken = default);

    ValueTask UnloadAsync(
        IReadOnlyList<string> payloadIds,
        CancellationToken cancellationToken = default);
}
