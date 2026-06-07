namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 登録を行う capability interface です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineRegistrar']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineRegistrar']" />
public interface IPipelineRegistrar
{
    /// <summary>Executes the RegisterPipelineAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RegisterPipelineAsync 操作を実行します。</summary>
    Task<string> RegisterPipelineAsync(IPipeline pipeline);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 実行を行う capability interface です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutor']" />
public interface IPipelineExecutor
{
    /// <summary>Executes the ExecutePipelineAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecutePipelineAsync 操作を実行します。</summary>
    Task<IPipelineExecutionResult> ExecutePipelineAsync(string pipelineId, ITaskContext context, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Task 実行を行う capability interface です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskExecutor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskExecutor']" />
public interface ITaskExecutor
{
    /// <summary>Executes the ExecuteTaskAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteTaskAsync 操作を実行します。</summary>
    Task<ITaskExecutionResult> ExecuteTaskAsync(ITask task, ITaskContext context, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 実行状態を制御する capability interface です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutionController']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutionController']" />
public interface IPipelineExecutionController
{
    /// <summary>Executes the PausePipelineAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PausePipelineAsync 操作を実行します。</summary>
    Task<bool> PausePipelineAsync(string executionId);

    /// <summary>Executes the ResumePipelineAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResumePipelineAsync 操作を実行します。</summary>
    Task<bool> ResumePipelineAsync(string executionId);

    /// <summary>Executes the CancelPipelineAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CancelPipelineAsync 操作を実行します。</summary>
    Task<bool> CancelPipelineAsync(string executionId);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 実行結果を参照する capability interface です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutionResultReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutionResultReader']" />
public interface IPipelineExecutionResultReader
{
    /// <summary>Executes the GetExecutionResultAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetExecutionResultAsync 操作を実行します。</summary>
    Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId);
}

/// <summary>
/// UC-29 に基づく ITaskManager の互換合成 contract を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskManager']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskManager']" />
public interface ITaskManager :
    IPipelineRegistrar,
    IPipelineExecutor,
    ITaskExecutor,
    IPipelineExecutionController,
    IPipelineExecutionResultReader
{
}
