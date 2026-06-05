namespace AIKernel.Enums;

public enum DynamicSlmFailureKind
{
    Unknown = 0,
    FailClosed = 1,
    CompatibilityRejected = 2,
    LineageRejected = 3,
    CapabilityGraphRejected = 4,
    AdmissionRejected = 5,
    PayloadLoadFailed = 6,
    SchedulingFailed = 7,
    Quarantined = 8
}
