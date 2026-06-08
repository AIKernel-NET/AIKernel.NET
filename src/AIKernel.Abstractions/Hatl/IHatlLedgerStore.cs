namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlLedgerStore']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlLedgerStore']" />
public interface IHatlLedgerStore
{
    /// <summary>Executes the AppendAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AppendAsync 操作を実行します。</summary>
    ValueTask AppendAsync(
        HatlLedgerEntry entry,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the ReadAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ReadAsync 操作を実行します。</summary>
    ValueTask<HatlLedgerEntry?> ReadAsync(
        string ledgerId,
        long sequenceNumber,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the ReadRangeAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ReadRangeAsync 操作を実行します。</summary>
    ValueTask<IReadOnlyList<HatlLedgerEntry>> ReadRangeAsync(
        string ledgerId,
        long startSequenceNumber,
        long endSequenceNumber,
        CancellationToken cancellationToken = default);
}
