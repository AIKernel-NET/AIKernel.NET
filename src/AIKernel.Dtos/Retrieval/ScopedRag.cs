using AIKernel.Dtos.Context;
using AIKernel.Enums.Retrieval;

namespace AIKernel.Dtos.Retrieval;

/// <summary>A host-authorized program, speaker and published edition; identifiers are exact and case-sensitive.</summary>
public sealed record RagPublicationScope(string ProgramId, string CharacterId, string PublicationVersion);

/// <summary>Search exactly the published materials in the supplied scope.</summary>
public sealed record ScopedRagRequest(string Query, RagPublicationScope Scope, int TopK = 10,
    RagSearchStages Stages = RagSearchStages.Keyword);

/// <summary>The entire pre-TopK reranker distribution, for calibrating an application's abstention rule.</summary>
public sealed record RagScoreDistribution(string ModelId, IReadOnlyList<double> RawScores);

/// <summary>Verifiable source excerpts and optional model-specific calibration data.</summary>
public sealed record ScopedRagResult(IReadOnlyList<MaterialContextDto> Materials, int EligibleCount,
    int CandidateCount, RagScoreDistribution? Distribution);
