namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmThoughtArtifactSink']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmThoughtArtifactSink']" />
public interface IDynamicSlmThoughtArtifactSink
{
    /// <summary>Executes the AppendAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AppendAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmReplayLogEntry> AppendAsync(
        DynamicSlmThoughtArtifact artifact,
        DynamicSlmPipelineMetadata metadata,
        CancellationToken cancellationToken = default);
}
