namespace AIKernel.Dtos.DynamicSlm;

public static class DynamicSlmMetadataKeys
{
    public const string ModelAbiHash = "dynamicslm_model_abi_hash";

    public const string CapabilityGraphHash = "dynamicslm_capability_graph_hash";

    public const string LineageHash = "dynamicslm_lineage_hash";

    public const string PayloadHash = "dynamicslm_payload_hash";

    public const string ReplayLogHash = "dynamicslm_replay_log_hash";

    public const string DistillationRequestId = "dynamicslm_distillation_request_id";

    public const string PipelineId = "dynamicslm_pipeline_id";

    public const string PipelineStage = "dynamicslm_pipeline_stage";

    public const string PipelineTraceCount = "dynamicslm_pipeline_trace_count";

    public const string FailureKind = "dynamicslm_failure_kind";

    public const string DistillationJobId = "dynamicslm_distillation_job_id";

    public const string OffloadStatus = "dynamicslm_offload_status";

    public const string TeacherFallbackUsed = "dynamicslm_teacher_fallback_used";

    public const string GapDetected = "dynamicslm_gap_detected";

    public const string StrictOutputMode = "dynamicslm_strict_output_mode";

    public const string DelegationId = "dynamicslm_delegation_id";

    public const string DelegationKind = "dynamicslm_delegation_kind";

    public const string DelegationReason = "dynamicslm_delegation_reason";

    public const string ThoughtArtifactId = "dynamicslm_thought_artifact_id";

    public const string ReasoningTraceFormat = "dynamicslm_reasoning_trace_format";

    public const string TrajectoryId = "dynamicslm_trajectory_id";

    public const string BaseModelState = "dynamicslm_base_model_state";

    public const string ResidentModelId = "dynamicslm_resident_model_id";

    public const string HotSwapPolicy = "dynamicslm_hot_swap_policy";

    public const string MemoryPlacementId = "dynamicslm_memory_placement_id";
}
