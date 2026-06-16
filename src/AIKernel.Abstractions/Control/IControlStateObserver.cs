using AIKernel.Dtos.Control;

namespace AIKernel.Abstractions.Control;

/// <summary>EN: Documentation for public API. JA: IControlStateObserver contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IControlStateObserver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IControlStateObserver']" />
public interface IControlStateObserver
{
    /// <summary>EN: Executes the ObserveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ObserveAsync 操作を実行します。</summary>
    ValueTask ObserveAsync(
        ControlStateSnapshot snapshot,
        CancellationToken cancellationToken = default);
}
