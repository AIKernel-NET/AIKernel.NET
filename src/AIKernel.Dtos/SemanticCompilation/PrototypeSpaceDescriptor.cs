namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// EN: Finite, closed set of verified governed circuits available to one compilation decision.
/// EN: Documentation for public API. JA: PrototypeSpaceDescriptor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.PrototypeSpaceDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.PrototypeSpaceDescriptor']" />
public sealed record PrototypeSpaceDescriptor(
    string PrototypeSpaceId,
    IReadOnlyList<GovernedCircuitDescriptor> Circuits,
    string? Version,
    string? PrototypeSpaceHash,
    IReadOnlyDictionary<string, string> Metadata);
