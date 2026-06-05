namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

public interface IHatlDigitalDeedResolver
{
    ValueTask<HatlDigitalDeed?> ResolveAsync(
        string subjectId,
        CancellationToken cancellationToken = default);

    ValueTask<HatlVerificationResult> VerifyAsync(
        HatlDigitalDeed deed,
        CancellationToken cancellationToken = default);
}
