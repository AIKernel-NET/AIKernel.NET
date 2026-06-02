// SPDX-License-Identifier: Apache-2.0
namespace AIKernel.Hatl.Core;

public interface ISymmetricLedgerProvider
{
    ValueTask<HatlBlockMac> CommitTransactionAsync(
        ReadOnlyMemory<byte> canonicalEvent,
        ReadOnlyMemory<byte> capabilityScopeHash,
        CancellationToken cancellationToken = default);

    ValueTask<bool> VerifyBlockChainIntegrityAsync(
        CancellationToken cancellationToken = default);
}

public sealed record HatlBlockMac(
    long SequenceNumber,
    int EpochId,
    string PreviousBlockMac,
    string EventHash,
    string ExecutionOutcomeHash,
    string CapabilityScopeHash,
    string HmacSignature);
