namespace AIKernel.Enums;

/// <summary>
/// Declares how an external capability module is packaged or invoked.
/// </summary>
public enum CapabilityModuleKind
{
    Unknown = 0,
    CliExecutable = 1,
    ManagedAssembly = 2,
    NativeLibrary = 3,
    DslRom = 4,
    RemoteEndpoint = 5
}
