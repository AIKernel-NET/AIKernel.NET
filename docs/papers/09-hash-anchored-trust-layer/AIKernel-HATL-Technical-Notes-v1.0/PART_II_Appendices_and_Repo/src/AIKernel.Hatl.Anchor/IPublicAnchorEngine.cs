// SPDX-License-Identifier: Apache-2.0
namespace AIKernel.Hatl.Anchor;

public interface IPublicAnchorEngine
{
    ValueTask<HatlPublicAnchor> GenerateIntervalAnchorAsync(
        long startSequence,
        long endSequence,
        CancellationToken cancellationToken = default);

    ValueTask<bool> PublishAnchorAsync(
        HatlPublicAnchor anchor,
        CancellationToken cancellationToken = default);
}

public sealed record HatlPublicAnchor(
    long AnchorId,
    string LedgerIdentity,
    int PolicyEpoch,
    long BatchStartSequence,
    long BatchEndSequence,
    string AccumulatedMerkleRoot,
    string PreviousAnchorHash,
    string HbsSignatureType,
    string HbsSignatureRaw);
