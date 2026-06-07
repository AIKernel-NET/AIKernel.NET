namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.ISeedSlmDisciplineVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.ISeedSlmDisciplineVerifier']" />
public interface ISeedSlmDisciplineVerifier
{
    /// <summary>Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmCompatibilityResult> VerifyAsync(
        DynamicSlmModelAbi modelAbi,
        SeedSlmStructuralConstraints structuralConstraints,
        SeedSlmOutputDisciplinePolicy outputPolicy,
        CancellationToken cancellationToken = default);
}
