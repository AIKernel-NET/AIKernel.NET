using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Scheduling;
using AIKernel.Abstractions.Tasks;

namespace AIKernel.Abstractions.Tests;

public sealed class TaskAndSchedulingCapabilityContractTests
{
    [Fact]
    public void CompositeTaskManagerExposesGranularTaskCapabilities()
    {
        ITaskManager manager = new FullTaskManager();

        Assert.IsAssignableFrom<IPipelineRegistrar>(manager);
        Assert.IsAssignableFrom<IPipelineExecutor>(manager);
        Assert.IsAssignableFrom<ITaskExecutor>(manager);
        Assert.IsAssignableFrom<IPipelineExecutionController>(manager);
        Assert.IsAssignableFrom<IPipelineExecutionResultReader>(manager);
    }

    [Fact]
    public void PipelineResultReaderDoesNotExposeExecutionCapabilities()
    {
        IPipelineExecutionResultReader reader = new PipelineResultOnlyReader();

        Assert.False(reader is IPipelineExecutor);
        Assert.False(reader is ITaskExecutor);
        Assert.False(reader is IPipelineExecutionController);
    }

    [Fact]
    public void CompositeSchedulerExposesGranularScheduleCapabilities()
    {
        IScheduler scheduler = new FullScheduler();

        Assert.IsAssignableFrom<IProvider>(scheduler);
        Assert.IsAssignableFrom<IScheduledJobReader>(scheduler);
        Assert.IsAssignableFrom<IJobScheduler>(scheduler);
        Assert.IsAssignableFrom<IScheduledJobCanceller>(scheduler);
        Assert.IsAssignableFrom<IScheduledExecutionResultReader>(scheduler);
    }

    [Fact]
    public void ScheduledJobReaderDoesNotExposeMutationCapabilities()
    {
        IScheduledJobReader reader = new ScheduledJobOnlyReader();

        Assert.False(reader is IJobScheduler);
        Assert.False(reader is IScheduledJobCanceller);
    }

    private sealed class PipelineResultOnlyReader : IPipelineExecutionResultReader
    {
        public Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId)
        {
            return Task.FromResult<IPipelineExecutionResult?>(null);
        }
    }

    private sealed class FullTaskManager : ITaskManager
    {
        public Task<string> RegisterPipelineAsync(IPipeline pipeline)
        {
            return Task.FromResult("pipeline");
        }

        public Task<IPipelineExecutionResult> ExecutePipelineAsync(
            string pipelineId,
            ITaskContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IPipelineExecutionResult>(null!);
        }

        public Task<ITaskExecutionResult> ExecuteTaskAsync(
            ITask task,
            ITaskContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<ITaskExecutionResult>(null!);
        }

        public Task<bool> PausePipelineAsync(string executionId)
        {
            return Task.FromResult(true);
        }

        public Task<bool> ResumePipelineAsync(string executionId)
        {
            return Task.FromResult(true);
        }

        public Task<bool> CancelPipelineAsync(string executionId)
        {
            return Task.FromResult(true);
        }

        public Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId)
        {
            return Task.FromResult<IPipelineExecutionResult?>(null);
        }
    }

    private sealed class ScheduledJobOnlyReader : IScheduledJobReader
    {
        public Task<IScheduledJob?> GetJobAsync(string jobId)
        {
            return Task.FromResult<IScheduledJob?>(null);
        }

        public Task<IReadOnlyList<IScheduledJob>> ListJobsAsync()
        {
            IReadOnlyList<IScheduledJob> jobs = [];
            return Task.FromResult(jobs);
        }
    }

    private sealed class FullScheduler : IScheduler
    {
        public string ProviderId => "scheduler";

        public string Name => "Scheduler";

        public string Version => "0.0.2";

        public IProviderCapabilities GetCapabilities()
        {
            return null!;
        }

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }

        public Task<IScheduledJob?> GetJobAsync(string jobId)
        {
            return Task.FromResult<IScheduledJob?>(null);
        }

        public Task<IScheduledJob> ScheduleAsync(IScheduleSpec job)
        {
            return Task.FromResult<IScheduledJob>(null!);
        }

        public Task<bool> CancelAsync(string jobId)
        {
            return Task.FromResult(true);
        }

        public Task<IReadOnlyList<IScheduledJob>> ListJobsAsync()
        {
            IReadOnlyList<IScheduledJob> jobs = [];
            return Task.FromResult(jobs);
        }

        public Task<IExecutionResult?> GetExecutionResultAsync(string jobId)
        {
            return Task.FromResult<IExecutionResult?>(null);
        }
    }
}
