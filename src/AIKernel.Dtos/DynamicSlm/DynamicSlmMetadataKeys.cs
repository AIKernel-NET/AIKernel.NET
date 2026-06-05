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
}
