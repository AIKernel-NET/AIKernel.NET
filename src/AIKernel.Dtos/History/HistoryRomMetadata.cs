namespace AIKernel.Dtos.History;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.HistoryRomMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.HistoryRomMetadata']" />
public sealed record HistoryRomMetadata(
    string Namespace,
    string Name,
    string Path,
    string RomId,
    string RomHash,
    DateTimeOffset CreatedAtUtc);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.HistoryRomMetadataKeys']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.History.HistoryRomMetadataKeys']" />
public static class HistoryRomMetadataKeys
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomHash']" />
    public const string RomHash = "history_rom_hash";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomId']" />
    public const string RomId = "history_rom_id";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomPath']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomPath']" />
    public const string RomPath = "history_rom_path";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomNamespace']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomNamespace']" />
    public const string RomNamespace = "history_rom_namespace";

    /// <include file="docs.en.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomName']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='F:AIKernel.Dtos.History.HistoryRomMetadataKeys.RomName']" />
    public const string RomName = "history_rom_name";
}
