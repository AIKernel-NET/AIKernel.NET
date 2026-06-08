namespace AIKernel.Dtos.Dsl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadata']" />
public sealed record DslRomMetadata(
    string Namespace,
    string Name,
    string Path,
    string CapabilityName,
    string RomHash,
    DateTimeOffset CreatedAtUtc);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadataKeys']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadataKeys']" />
public static class DslRomMetadataKeys
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomHash']" />
    public const string RomHash = "dsl_rom_hash";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomCall']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomCall']" />
    public const string RomCall = "dsl_rom_call";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomPath']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomPath']" />
    public const string RomPath = "dsl_rom_path";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomNamespace']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomNamespace']" />
    public const string RomNamespace = "dsl_rom_namespace";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomName']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomName']" />
    public const string RomName = "dsl_rom_name";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogCount']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogCount']" />
    public const string RomReplayLogCount = "dsl_rom_replay_log_count";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogHash']" />
    public const string RomReplayLogHash = "dsl_rom_replay_log_hash";
}
