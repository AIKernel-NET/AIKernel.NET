namespace AIKernel.Dtos.Execution;

/// <summary>
/// PhaseHandoverResult の契約を定義します。
/// JA: PhaseHandoverResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PhaseHandoverResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PhaseHandoverResult']" />
public sealed record PhaseHandoverResult(
    bool IsValid,
    string Message,
    IReadOnlyList<string> Issues,
    IReadOnlyList<string> Warnings);



