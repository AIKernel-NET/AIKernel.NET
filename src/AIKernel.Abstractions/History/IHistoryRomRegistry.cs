namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistoryRomRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistoryRomRegistry']" />
public interface IHistoryRomRegistry
{
    /// <summary>Executes the RegisterAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RegisterAsync 操作を実行します。</summary>
    Task<HistoryRomMetadata> RegisterAsync(
        HistoryRomSnapshot snapshot,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the Contains operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Contains 操作を実行します。</summary>
    bool Contains(string romId);

    /// <summary>Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    Task<HistoryRomSnapshot> ResolveAsync(
        string romId,
        CancellationToken cancellationToken = default);
}
