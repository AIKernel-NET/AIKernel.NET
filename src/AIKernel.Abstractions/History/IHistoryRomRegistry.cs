namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;

/// <summary>[EN] Documents this public package API member. [JA] IHistoryRomRegistry contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistoryRomRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistoryRomRegistry']" />
public interface IHistoryRomRegistry
{
    /// <summary>EN: Executes the RegisterAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RegisterAsync 操作を実行します。</summary>
    Task<HistoryRomMetadata> RegisterAsync(
        HistoryRomSnapshot snapshot,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the Contains operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Contains 操作を実行します。</summary>
    bool Contains(string romId);

    /// <summary>EN: Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    Task<HistoryRomSnapshot> ResolveAsync(
        string romId,
        CancellationToken cancellationToken = default);
}
