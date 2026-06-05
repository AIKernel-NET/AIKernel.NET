namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Enums;

public interface IDynamicSlmFailure
{
    DynamicSlmFailureKind Kind { get; }

    DynamicSlmPipelineStage Stage { get; }

    string Code { get; }

    string Message { get; }

    string? ReplayLogHash { get; }

    IReadOnlyDictionary<string, string> Metadata { get; }
}
