using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmResidentModelDescriptor(
    string ModelId,
    DynamicSlmBaseModelStateKind StateKind,
    DynamicSlmAcceleratorKind Accelerator,
    string? FixedAddressHint,
    long VramBudgetBytes,
    IReadOnlyDictionary<string, string> Metadata);
