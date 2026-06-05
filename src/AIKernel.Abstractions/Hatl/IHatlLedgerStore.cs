namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

public interface IHatlLedgerStore
{
    ValueTask AppendAsync(
        HatlLedgerEntry entry,
        CancellationToken cancellationToken = default);

    ValueTask<HatlLedgerEntry?> ReadAsync(
        string ledgerId,
        long sequenceNumber,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<HatlLedgerEntry>> ReadRangeAsync(
        string ledgerId,
        long startSequenceNumber,
        long endSequenceNumber,
        CancellationToken cancellationToken = default);
}
