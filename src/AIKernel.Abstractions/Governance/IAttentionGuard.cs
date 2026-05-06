namespace AIKernel.Abstractions.Governance;

/// <summary>
/// UC-06/UC-32 に基づく IAttentionGuard の契約を定義します。
/// </summary>
public interface IAttentionGuard
{
    void ValidateIsolation(Context.IContextCollection context);
    IReadOnlyList<string> DetectPollution(Context.IContextCollection context);
    bool FailClosed { get; }
}



