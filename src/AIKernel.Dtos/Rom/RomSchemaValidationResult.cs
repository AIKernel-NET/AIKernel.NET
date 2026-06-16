namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: RomSchemaValidationResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] RomSchemaValidationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSchemaValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSchemaValidationResult']" />
public sealed record RomSchemaValidationResult
{
    /// <summary>[EN] Documents this public package API member. [JA] IsValid を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.IsValid']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.IsValid']" />
    public required bool IsValid { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.Message']" />
    public required string Message { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Issues を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomSchemaValidationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomSchemaValidationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();
}




