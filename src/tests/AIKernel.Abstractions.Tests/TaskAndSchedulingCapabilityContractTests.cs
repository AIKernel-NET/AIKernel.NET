using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Scheduling;
using AIKernel.Abstractions.Tasks;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// EN: Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class TaskAndSchedulingCapabilityContractTests
{
    /// <summary>
    /// EN: Executes CompositeTaskManagerExposesGranularTaskCapabilities.
    /// EN: Documentation for public API. JA: CompositeTaskManagerExposesGranularTaskCapabilities を実行します。
    /// </summary>
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
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void PipelineResultReaderDoesNotExposeExecutionCapabilities()
    {
        IPipelineExecutionResultReader reader = new PipelineResultOnlyReader();

        Assert.False(reader is IPipelineExecutor);
        Assert.False(reader is ITaskExecutor);
        Assert.False(reader is IPipelineExecutionController);
    }
    /// <summary>
    /// EN: Executes CompositeSchedulerExposesGranularScheduleCapabilities.
    /// EN: Documentation for public API. JA: CompositeSchedulerExposesGranularScheduleCapabilities を実行します。
    /// </summary>

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
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ScheduledJobReaderDoesNotExposeMutationCapabilities()
    {
        IScheduledJobReader reader = new ScheduledJobOnlyReader();

        Assert.False(reader is IJobScheduler);
        Assert.False(reader is IScheduledJobCanceller);
    }

    private sealed class PipelineResultOnlyReader : IPipelineExecutionResultReader
    {
        /// <summary>
        /// EN: Executes GetExecutionResultAsync.
        /// EN: Documentation for public API. JA: GetExecutionResultAsync を実行します。
        /// </summary>
        public Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId)
        {
            return Task.FromResult<IPipelineExecutionResult?>(null);
        }
    }

    private sealed class FullTaskManager : ITaskManager
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<string> RegisterPipelineAsync(IPipeline pipeline)
        {
            return Task.FromResult("pipeline");
        }
        /// <summary>
        /// EN: Gets ExecutePipelineAsync.
        /// EN: Documentation for public API. JA: ExecutePipelineAsync を取得します。
        /// </summary>

        public Task<IPipelineExecutionResult> ExecutePipelineAsync(
            string pipelineId,
            ITaskContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IPipelineExecutionResult>(null!);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<ITaskExecutionResult> ExecuteTaskAsync(
            ITask task,
            ITaskContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<ITaskExecutionResult>(null!);
        }
        /// <summary>
        /// EN: Executes PausePipelineAsync.
        /// EN: Documentation for public API. JA: PausePipelineAsync を実行します。
        /// </summary>

        public Task<bool> PausePipelineAsync(string executionId)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<bool> ResumePipelineAsync(string executionId)
        {
            return Task.FromResult(true);
        }
        /// <summary>
        /// EN: Executes CancelPipelineAsync.
        /// EN: Documentation for public API. JA: CancelPipelineAsync を実行します。
        /// </summary>

        public Task<bool> CancelPipelineAsync(string executionId)
        {
            return Task.FromResult(true);
        }
        /// <summary>
        /// EN: Executes GetExecutionResultAsync.
        /// EN: Documentation for public API. JA: GetExecutionResultAsync を実行します。
        /// </summary>

        public Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId)
        {
            return Task.FromResult<IPipelineExecutionResult?>(null);
        }
    }

    private sealed class ScheduledJobOnlyReader : IScheduledJobReader
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IScheduledJob?> GetJobAsync(string jobId)
        {
            return Task.FromResult<IScheduledJob?>(null);
        }
        /// <summary>
        /// EN: Executes ListJobsAsync.
        /// EN: Documentation for public API. JA: ListJobsAsync を実行します。
        /// </summary>

        public Task<IReadOnlyList<IScheduledJob>> ListJobsAsync()
        {
            IReadOnlyList<IScheduledJob> jobs = [];
            return Task.FromResult(jobs);
        }
    }

    private sealed class FullScheduler : IScheduler
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string ProviderId => "scheduler";
        /// <summary>
        /// EN: Gets Name.
        /// EN: Documentation for public API. JA: Name を取得します。
        /// </summary>

        public string Name => "Scheduler";
        /// <summary>
        /// EN: Gets Version.
        /// EN: Documentation for public API. JA: Version を取得します。
        /// </summary>

        public string Version => "0.0.2";
        /// <summary>
        /// EN: Executes GetCapabilities.
        /// EN: Documentation for public API. JA: GetCapabilities を実行します。
        /// </summary>

        public IProviderCapabilities GetCapabilities()
        {
            return null!;
        }
        /// <summary>
        /// EN: Executes IsAvailableAsync.
        /// EN: Documentation for public API. JA: IsAvailableAsync を実行します。
        /// </summary>

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes ShutdownAsync.
        /// EN: Documentation for public API. JA: ShutdownAsync を実行します。
        /// </summary>

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes GetHealthAsync.
        /// EN: Documentation for public API. JA: GetHealthAsync を実行します。
        /// </summary>

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IScheduledJob?> GetJobAsync(string jobId)
        {
            return Task.FromResult<IScheduledJob?>(null);
        }
        /// <summary>
        /// EN: Executes ScheduleAsync.
        /// EN: Documentation for public API. JA: ScheduleAsync を実行します。
        /// </summary>

        public Task<IScheduledJob> ScheduleAsync(IScheduleSpec job)
        {
            return Task.FromResult<IScheduledJob>(null!);
        }
        /// <summary>
        /// EN: Executes CancelAsync.
        /// EN: Documentation for public API. JA: CancelAsync を実行します。
        /// </summary>

        public Task<bool> CancelAsync(string jobId)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadOnlyList<IScheduledJob>> ListJobsAsync()
        {
            IReadOnlyList<IScheduledJob> jobs = [];
            return Task.FromResult(jobs);
        }
        /// <summary>
        /// EN: Executes GetExecutionResultAsync.
        /// EN: Documentation for public API. JA: GetExecutionResultAsync を実行します。
        /// </summary>

        public Task<IScheduledExecutionResult?> GetExecutionResultAsync(string jobId)
        {
            return Task.FromResult<IScheduledExecutionResult?>(null);
        }
    }
}
