namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく IStructurePlanner の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IStructurePlanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IStructurePlanner']" />
public interface IStructurePlanner
{
    /// <summary>Gets the Name value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Name 値を取得します。</summary>
    string Name { get; }
    /// <summary>Executes the PlanAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PlanAsync 操作を実行します。</summary>
    Task<IReadOnlyList<string>> PlanAsync(Context.IContextCollection orchestrationContext, CancellationToken ct = default);
    /// <summary>Executes the EstimateComplexity operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EstimateComplexity 操作を実行します。</summary>
    double EstimateComplexity(Context.IContextCollection orchestrationContext);
}




