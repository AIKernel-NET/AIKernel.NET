namespace AIKernel.Enums.Retrieval;

/// <summary>Optional retrieval operations. Keyword retrieval is always enabled.</summary>
[Flags]
public enum RagSearchStages
{
    /// <summary>Search eligible source text.</summary>
    Keyword = 0,
    /// <summary>Query the vector index with the authorized subset.</summary>
    Vector = 1,
    /// <summary>Expand authorized references from ranked seeds.</summary>
    Graph = 2,
    /// <summary>Score the authorized candidates with the configured model.</summary>
    Rerank = 4
}
