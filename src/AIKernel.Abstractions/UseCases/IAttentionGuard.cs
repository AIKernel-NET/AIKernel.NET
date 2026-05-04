namespace AIKernel.Abstractions.UseCases;

public interface IAttentionGuard
{
    void ValidateIsolation(Context.IContextCollection context);
    IReadOnlyList<string> DetectPollution(Context.IContextCollection context);
    bool FailClosed { get; }
}
