namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface ISeedSlmDisciplineVerifier
{
    ValueTask<DynamicSlmCompatibilityResult> VerifyAsync(
        DynamicSlmModelAbi modelAbi,
        SeedSlmStructuralConstraints structuralConstraints,
        SeedSlmOutputDisciplinePolicy outputPolicy,
        CancellationToken cancellationToken = default);
}
