namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: ReplayDump の契約を定義します。
/// EN: Documentation for public API. JA: ReplayDump の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ReplayDump']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ReplayDump']" />
public sealed record ReplayDump
{
    /// <summary>EN: Documentation for public API. JA: DumpId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.DumpId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.DumpId']" />
    public required string DumpId { get; init; }
    /// <summary>EN: Documentation for public API. JA: OriginalResult を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.OriginalResult']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.OriginalResult']" />
    public required ExecutionResult OriginalResult { get; init; }
    /// <summary>EN: Documentation for public API. JA: StructureOutput を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.StructureOutput']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.StructureOutput']" />
    public required RawLogic StructureOutput { get; init; }
    /// <summary>EN: Documentation for public API. JA: GenerationOutput を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.GenerationOutput']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.GenerationOutput']" />
    public required string GenerationOutput { get; init; }
    /// <summary>EN: Documentation for public API. JA: CreatedAt を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.CreatedAt']" />
    public required DateTime CreatedAt { get; init; }
    /// <summary>EN: Documentation for public API. JA: HashChain を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.HashChain']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ReplayDump.HashChain']" />
    public required HashChain HashChain { get; init; }
}




