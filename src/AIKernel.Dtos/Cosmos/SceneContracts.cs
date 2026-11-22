namespace AIKernel.Providers.Cosmos;

public sealed record SceneActor(string ActorId, long AssetRevision, string Activity, bool Visible,
    string Facing = "unknown", string SpeakerState = "unknown");
public sealed record SceneTarget(string TargetId, string Kind);
public sealed record SceneAction(string ActionId, IReadOnlyList<string> ActorIds, IReadOnlyList<string> TargetIds);
public sealed record SceneMediaReference(string MediaId, string FrameId, string MimeType,
    int Width, int Height, int OffsetMs);
public sealed record SceneRequest(string SchemaVersion, string RequestId, string SessionEpoch,
    string SnapshotId, string CaptureSource, DateTimeOffset CapturedAtUtc,
    int MaxObservationAgeMs, int RemainingBudgetMs, long SceneRevision, long LayoutRevision,
    string CameraId, string PolicyRevision, string PermissionScope, string Mode,
    IReadOnlyList<SceneMediaReference> Media, IReadOnlyList<SceneActor> Actors,
    IReadOnlyList<SceneTarget> Targets, IReadOnlyList<SceneAction> AllowedActions, int MaxProposals);

public sealed record SceneSnapshot(string SessionEpoch, string SnapshotId, string CaptureSource,
    DateTimeOffset CapturedAtUtc, long SceneRevision, long LayoutRevision, string CameraId);
public sealed record SceneMediaRegistration(SceneSnapshot Snapshot, string FrameId, int OffsetMs,
    string MimeType, int Width, int Height, string ContentHash, DateTimeOffset ExpiresAtUtc);
public sealed record SceneMediaReceipt(string MediaId, string ContentHash, int SizeBytes, DateTimeOffset ExpiresAtUtc);
public sealed record SceneRegion(double X, double Y, double Width, double Height);
public sealed record SceneObservation(string ObservationId, string? ActorId, string? TargetId,
    string ReasonCode, bool Unknown, IReadOnlyList<string> EvidenceFrameIds, SceneRegion? Region = null);
public sealed record SceneModelProposal(string ActorId, long AssetRevision, string ActionId,
    string TargetId, IReadOnlyList<string> ObservationIds);
public sealed record SceneModelResult(IReadOnlyList<SceneObservation> Observations,
    IReadOnlyList<SceneModelProposal> Proposals);
public sealed record SceneProposal(string ProposalId, string ActorId, long AssetRevision,
    string ActionId, string TargetId, IReadOnlyList<string> ObservationIds, DateTimeOffset ExpiresAtUtc);

public sealed record SceneBackendIdentity(string Backend, string Model, string Revision,
    string Precision, string Runtime, string EndpointId, IReadOnlyList<string> GpuIds, bool IsMock, string? ImageDigest = null);
public sealed record SceneReadiness(string State, string ReasonCode, bool DeploymentVerified,
    SceneBackendIdentity Provider, int? RetryAfterMs = null);
public sealed record SceneTimings(double QueueMs, double PreparationMs, double InferenceMs,
    double ValidationMs, double ObservationAgeMs);
public sealed record SceneAnalysisResult(string SchemaVersion, string RequestId, string SessionEpoch,
    string SnapshotId, string Status, bool AnalysisOnly, bool FreshnessVerified, string? ErrorCode,
    long SceneRevision, long LayoutRevision, string CameraId, string PolicyRevision,
    DateTimeOffset CapturedAtUtc, DateTimeOffset ExpiresAtUtc,
    IReadOnlyList<SceneObservation> Observations, IReadOnlyList<SceneProposal> Proposals,
    SceneBackendIdentity Provider, SceneTimings Timings, string BackendCancellation,
    string Mode = "shadow", int? RetryAfterMs = null);

public sealed record SceneCapabilityCatalog(string CapabilityId, string SchemaVersion, string PackageVersion,
    IReadOnlyList<string> Operations, string RequestArgumentKey, string ResultMetadataKey,
    IReadOnlyList<string> ImageMimeTypes, bool VideoSupported, bool TimestampedImagesSupported, string Coordinates,
    int MaxFrames, int MaxActors, int MaxProposals, int MaxImageBytes, int MaxImagePixels, long MaxStoredMediaBytes,
    int MaxRequestBytes, int MaxResponseBytes, int MaxRunningPerCaller, int MaxPendingPerCaller,
    int MaxConcurrentInference, int MaxJobs, int MaxObservationAgeMs, double MediaRetentionSeconds,
    double IdempotencyRetentionSeconds, SceneReadiness Readiness, int ActiveInference, int Queued, bool ExecutesActions,
    int MaxConcurrentUploads = 2);

// Server UTC = caller UTC + Offset. Only the authenticated hosting adapter may
// supply a calibration. A request JSON cannot assert that its clock is trusted.
public sealed record SceneClockCalibration(TimeSpan Offset, TimeSpan Uncertainty, DateTimeOffset ValidUntilUtc);
public sealed record SceneGrant(string CallerId, string PermissionScope, string PolicyRevision,
    IReadOnlyDictionary<string, long> ActorRevisions, IReadOnlySet<string> ActionIds,
    IReadOnlySet<string> TargetIds, SceneClockCalibration? ClockCalibration = null);

public sealed record SceneBackendInput(SceneRequest Request, IReadOnlyList<ReadOnlyMemory<byte>> Images);
public sealed record SceneBackendReply(string ResultJson, SceneBackendIdentity Provider);
public sealed record SceneDeploymentEvidence(string Model, string Revision, string Precision,
    string Runtime, IReadOnlyList<string> GpuIds, string ImageDigest,
    DateTimeOffset ObservedAtUtc, DateTimeOffset ExpiresAtUtc, string State);
