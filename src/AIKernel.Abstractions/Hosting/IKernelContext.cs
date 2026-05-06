namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IKernelContext の契約を定義します。
/// </summary>
public interface IKernelContext
{
    string ContextId { get; }
    UnifiedContextDto? Contract { get; }
    DateTimeOffset CreatedAtUtc { get; }
    IReadOnlyDictionary<string, string> Attributes { get; }
    TraceContext? TraceContext { get; }
    Identity? Identity { get; }
    IReadOnlyList<Permission> Permissions { get; }
    Budget? Budget { get; }
    DataClassification? DataClassification { get; }
    TrustContext? TrustContext { get; }
}



