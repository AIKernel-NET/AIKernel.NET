namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// EN: DataClassification の契約を定義します。
/// [EN] Documents this public package API member. [JA] DataClassification の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.DataClassification']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.DataClassification']" />
public sealed record DataClassification(
    string Level,
    IReadOnlyList<string> HandlingPolicies,
    bool RequiresEncryption,
    bool RequiresAuditLog,
    DateTime ClassifiedAt,
    string? Reason);


