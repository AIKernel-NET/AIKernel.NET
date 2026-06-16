namespace AIKernel.Abstractions.Control;

/// <summary>EN: Documentation for public API. JA: INodeScheduler contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.INodeScheduler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.INodeScheduler']" />
public interface INodeScheduler
{
    /// <summary>EN: Executes the ScheduleAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ScheduleAsync 操作を実行します。</summary>
    ValueTask<IReadOnlyList<IExecutionNode>> ScheduleAsync(
        IExecutionGraph graph,
        CancellationToken cancellationToken = default);
}
