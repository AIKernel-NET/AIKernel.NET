namespace AIKernel.Dtos.Execution;

public enum ExecutionStatus
{
    Succeeded = 0,

    Rejected = 1,

    Failed = 2,

    Canceled = 3,

    TimedOut = 4,

    RateLimited = 5
}
