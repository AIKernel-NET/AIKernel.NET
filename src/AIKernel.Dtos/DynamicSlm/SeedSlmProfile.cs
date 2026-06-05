namespace AIKernel.Dtos.DynamicSlm;

public sealed record SeedSlmProfile(
    string SeedModelId,
    SeedSlmStructuralConstraints StructuralConstraints,
    SeedSlmOutputDisciplinePolicy OutputDisciplinePolicy,
    DynamicSlmAdapterCompatibilityProfile AdapterCompatibility,
    DynamicSlmNeutralityMetadata Neutrality,
    DynamicSlmResidentModelDescriptor ResidentModel,
    IReadOnlyDictionary<string, string> Metadata);
