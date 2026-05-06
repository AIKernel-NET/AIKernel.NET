namespace AIKernel.Enums;

/// <summary>
/// ContextStage の契約を定義します。
/// </summary>
public enum ContextStage
{
    Initialized = 0,
    OrchestrationActive = 1,
    Materialized = 2,
    Compressed = 3,
    Summarized = 4,
    Cleared = 5
}



