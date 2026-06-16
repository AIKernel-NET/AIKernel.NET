namespace AIKernel.Dtos.Dsl;

/// <summary>EN: Documentation for public API. JA: DslRomMetadata を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadata']" />
public sealed record DslRomMetadata(
    string Namespace,
    string Name,
    string Path,
    string CapabilityName,
    string RomHash,
    DateTimeOffset CreatedAtUtc);

/// <summary>EN: Documentation for public API. JA: DslRomMetadataKeys を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadataKeys']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomMetadataKeys']" />
public static class DslRomMetadataKeys
{
    /// <summary>EN: Documentation for public API. JA: RomHash 定数を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomHash']" />
    public const string RomHash = "dsl_rom_hash";

    /// <summary>EN: Documentation for public API. JA: RomCall 定数を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomCall']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomCall']" />
    public const string RomCall = "dsl_rom_call";

    /// <summary>EN: Documentation for public API. JA: RomPath 定数を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomPath']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomPath']" />
    public const string RomPath = "dsl_rom_path";

    /// <summary>EN: Documentation for public API. JA: RomNamespace 定数を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomNamespace']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomNamespace']" />
    public const string RomNamespace = "dsl_rom_namespace";

    /// <summary>EN: Documentation for public API. JA: RomName 定数を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomName']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomName']" />
    public const string RomName = "dsl_rom_name";

    /// <summary>EN: Documentation for public API. JA: RomReplayLogCount 定数を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogCount']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogCount']" />
    public const string RomReplayLogCount = "dsl_rom_replay_log_count";

    /// <summary>EN: Documentation for public API. JA: RomReplayLogHash 定数を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.Dsl.DslRomMetadataKeys.RomReplayLogHash']" />
    public const string RomReplayLogHash = "dsl_rom_replay_log_hash";
}
