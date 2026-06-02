// SPDX-License-Identifier: Apache-2.0
namespace AIKernel.Hatl.Core;

public interface IHatlKeyRatchet
{
    ValueTask<byte[]> DeriveNextEpochKeyAsync(
        ReadOnlyMemory<byte> currentKey,
        ReadOnlyMemory<byte> eventHash,
        long sequenceNumber,
        CancellationToken cancellationToken = default);
}
