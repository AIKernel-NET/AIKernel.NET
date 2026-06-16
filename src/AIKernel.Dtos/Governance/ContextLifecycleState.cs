namespace AIKernel.Dtos.Governance;

using AIKernel.Enums;

/// <summary>
/// EN: ContextLifecycleState の契約を定義します。
/// EN: Documentation for public API. JA: ContextLifecycleState の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.ContextLifecycleState']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.ContextLifecycleState']" />
public sealed record ContextLifecycleState(
    ContextStage CurrentStage,
    DateTime CreatedAt,
    DateTime LastModifiedAt,
    long TotalSize,
    int FragmentCount,
    float CompressionCapacity);



