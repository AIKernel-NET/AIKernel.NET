namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslCapabilityRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslCapabilityRegistry']" />
public interface IDslCapabilityRegistry
{
    /// <summary>Executes the Contains operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Contains 操作を実行します。</summary>
    bool Contains(string name);

    /// <summary>Executes the InvokeAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで InvokeAsync 操作を実行します。</summary>
    Task<DslPipelineValue> InvokeAsync(
        string name,
        DslPipelineValue input,
        IReadOnlyDictionary<string, string> args,
        CancellationToken cancellationToken = default);
}
