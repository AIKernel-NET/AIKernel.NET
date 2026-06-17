namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] SeedSlmProfile を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.SeedSlmProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.SeedSlmProfile']" />
public sealed record SeedSlmProfile(
    string SeedModelId,
    SeedSlmStructuralConstraints StructuralConstraints,
    SeedSlmOutputDisciplinePolicy OutputDisciplinePolicy,
    DynamicSlmAdapterCompatibilityProfile AdapterCompatibility,
    DynamicSlmNeutralityMetadata Neutrality,
    DynamicSlmResidentModelDescriptor ResidentModel,
    IReadOnlyDictionary<string, string> Metadata);
