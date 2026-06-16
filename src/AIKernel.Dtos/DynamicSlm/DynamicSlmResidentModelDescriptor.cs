using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmResidentModelDescriptor を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmResidentModelDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmResidentModelDescriptor']" />
public sealed record DynamicSlmResidentModelDescriptor(
    string ModelId,
    DynamicSlmBaseModelStateKind StateKind,
    DynamicSlmAcceleratorKind Accelerator,
    string? FixedAddressHint,
    long VramBudgetBytes,
    IReadOnlyDictionary<string, string> Metadata);
