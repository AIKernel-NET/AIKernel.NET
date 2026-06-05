namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmThoughtArtifactSink
{
    ValueTask<DynamicSlmReplayLogEntry> AppendAsync(
        DynamicSlmThoughtArtifact artifact,
        DynamicSlmPipelineMetadata metadata,
        CancellationToken cancellationToken = default);
}
