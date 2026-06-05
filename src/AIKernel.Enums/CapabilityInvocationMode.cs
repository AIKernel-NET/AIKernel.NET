namespace AIKernel.Enums;

/// <summary>
/// Declares the invocation boundary used for an external capability.
/// </summary>
public enum CapabilityInvocationMode
{
    Unknown = 0,
    Direct = 1,
    Sandbox = 2,
    AssemblyReference = 3,
    NativeAbi = 4,
    DslPipeline = 5,
    Remote = 6
}
