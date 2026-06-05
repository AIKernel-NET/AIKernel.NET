namespace AIKernel.Enums;

public enum DynamicSlmDistillationJobStatus
{
    Unknown = 0,
    Pending = 1,
    Queued = 2,
    Running = 3,
    Completed = 4,
    Failed = 5,
    Cancelled = 6,
    Quarantined = 7
}
