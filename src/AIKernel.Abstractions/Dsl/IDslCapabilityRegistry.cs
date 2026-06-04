namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

public interface IDslCapabilityRegistry
{
    bool Contains(string name);

    Task<DslPipelineValue> InvokeAsync(
        string name,
        DslPipelineValue input,
        IReadOnlyDictionary<string, string> args,
        CancellationToken cancellationToken = default);
}
