namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCapabilityGapDetector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCapabilityGapDetector']" />
public interface IDynamicSlmCapabilityGapDetector
{
    /// <summary>Executes the DetectGapsAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで DetectGapsAsync 操作を実行します。</summary>
    ValueTask<IReadOnlyList<DynamicSlmCapabilityGap>> DetectGapsAsync(
        DynamicSlmModelAbi modelAbi,
        IReadOnlyList<ReplayDump> replayTraces,
        CancellationToken cancellationToken = default);
}
