namespace AIKernel.Abstractions.Tooling;

/// <summary>
/// UC-31 に基づく契約です。
/// EN: ツール実行環境のサンドボックス識別情報を公開します。
/// EN: Documentation for public API. JA: IToolSandboxIdentity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxIdentity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxIdentity']" />
public interface IToolSandboxIdentity
{
    /// <summary>
    /// EN: サンドボックスの一意識別子を取得します。
    /// EN: Documentation for public API. JA: IToolExecutor の公開契約を定義します。
    /// </summary>
    string SandboxId { get; }
}

/// <summary>
/// UC-31 に基づく契約です。
/// EN: サンドボックス内のツール実行 capability です。
/// EN: Documentation for public API. JA: IToolExecutor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolExecutor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolExecutor']" />
public interface IToolExecutor
{
    /// <summary>
    /// EN: サンドボックス内でツールを実行します。
    /// EN: Documentation for public API. JA: ExecuteToolAsync 操作を実行します。
    /// </summary>
    /// <param name="toolName">EN: Documentation for public API. JA: ツール名 toolName パラメーターです。</param>
    /// <param name="parameters">EN: Documentation for public API. JA: ツールパラメータ parameters パラメーターです。</param>
    /// <param name="permissions">EN: Documentation for public API. JA: 実行権限 permissions パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 実行結果 結果を返します。</returns>
    Task<SandboxExecutionResult> ExecuteToolAsync(
        string toolName,
        IReadOnlyDictionary<string, string> parameters,
        IToolPermission permissions);
}

/// <summary>
/// UC-31 に基づく契約です。
/// EN: サンドボックスへのファイルアップロード capability です。
/// EN: Documentation for public API. JA: IToolFileUploadSink の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileUploadSink']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileUploadSink']" />
public interface IToolFileUploadSink
{
    /// <summary>
    /// EN: サンドボックスにファイルをアップロードします。
    /// EN: Documentation for public API. JA: UploadFileAsync 操作を実行します。
    /// </summary>
    /// <param name="fileName">EN: Documentation for public API. JA: ファイル名 fileName パラメーターです。</param>
    /// <param name="content">EN: Documentation for public API. JA: ファイル内容 content パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: アップロード結果 結果を返します。</returns>
    Task<bool> UploadFileAsync(string fileName, byte[] content);
}

/// <summary>
/// UC-31 に基づく契約です。
/// EN: サンドボックスからのファイルダウンロード capability です。
/// EN: Documentation for public API. JA: IToolFileDownloadSource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileDownloadSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileDownloadSource']" />
public interface IToolFileDownloadSource
{
    /// <summary>
    /// EN: サンドボックスからファイルをダウンロードします。
    /// EN: Documentation for public API. JA: DownloadFileAsync 操作を実行します。
    /// </summary>
    /// <param name="fileName">EN: Documentation for public API. JA: ファイル名 fileName パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: ファイル内容 結果を返します。</returns>
    Task<byte[]?> DownloadFileAsync(string fileName);
}

/// <summary>
/// UC-31 に基づく契約です。
/// EN: サンドボックス cleanup capability です。
/// EN: Documentation for public API. JA: IToolSandboxCleanup の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxCleanup']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxCleanup']" />
public interface IToolSandboxCleanup
{
    /// <summary>
    /// EN: サンドボックスをクリーンアップします。
    /// EN: Documentation for public API. JA: CleanupAsync 操作を実行します。
    /// </summary>
    Task CleanupAsync();
}

/// <summary>
/// UC-31 に基づく契約です。
/// EN: サンドボックスのリソース使用状況を公開する capability です。
/// EN: Documentation for public API. JA: IToolResourceUsageSource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolResourceUsageSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolResourceUsageSource']" />
public interface IToolResourceUsageSource
{
    /// <summary>
    /// EN: サンドボックスのリソース使用状況を取得します。
    /// EN: Documentation for public API. JA: GetResourceUsageAsync 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: リソース使用状況 結果を返します。</returns>
    Task<SandboxResourceUsage> GetResourceUsageAsync();
}

/// <summary>
/// UC-31 に基づく契約です。
/// ツール実行環境のサンドボックスを定義する互換合成インターフェースです。
/// EN: セキュリティ境界を確立し、ツール実行を隔離します。
/// EN: Documentation for public API. JA: IToolSandbox の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandbox']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandbox']" />
public interface IToolSandbox :
    IToolSandboxIdentity,
    IToolExecutor,
    IToolFileUploadSink,
    IToolFileDownloadSource,
    IToolSandboxCleanup,
    IToolResourceUsageSource
{
}
