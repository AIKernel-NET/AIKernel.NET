namespace AIKernel.Dtos.Context;

using AIKernel.Enums;

public sealed class ValidationResult
{
    public bool IsValid { get; init; }

    public List<string> Errors { get; init; } = new();

    public List<string> Warnings { get; init; } = new();

    public List<FailureMode> DetectedFailureModes { get; init; } = new();
}
