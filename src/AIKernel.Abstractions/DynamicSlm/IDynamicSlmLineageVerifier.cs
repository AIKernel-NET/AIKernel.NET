namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmLineageVerifier
{
    ValueTask<DynamicSlmAdmissionResult> VerifyAsync(
        DynamicSlmModelAbi modelAbi,
        CancellationToken cancellationToken = default);
}
