namespace AIKernel.Abstractions.Tooling;

/// <summary>
/// UC-31 に基づく契約です。
/// ツール実行環境のサンドボックス識別情報を公開します。
/// JA: IToolSandboxIdentity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxIdentity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxIdentity']" />
public interface IToolSandboxIdentity
{
    /// <summary>
    /// サンドボックスの一意識別子を取得します。
    /// JA: IToolExecutor の公開契約を定義します。
    /// </summary>
    string SandboxId { get; }
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックス内のツール実行 capability です。
/// JA: IToolExecutor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolExecutor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolExecutor']" />
public interface IToolExecutor
{
    /// <summary>
    /// サンドボックス内でツールを実行します。
    /// JA: ExecuteToolAsync 操作を実行します。
    /// </summary>
    /// <param name="toolName">ツール名 JA: toolName パラメーターです。</param>
    /// <param name="parameters">ツールパラメータ JA: parameters パラメーターです。</param>
    /// <param name="permissions">実行権限 JA: permissions パラメーターです。</param>
    /// <returns>実行結果 JA: 結果を返します。</returns>
    Task<SandboxExecutionResult> ExecuteToolAsync(
        string toolName,
        IReadOnlyDictionary<string, string> parameters,
        IToolPermission permissions);
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックスへのファイルアップロード capability です。
/// JA: IToolFileUploadSink の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileUploadSink']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileUploadSink']" />
public interface IToolFileUploadSink
{
    /// <summary>
    /// サンドボックスにファイルをアップロードします。
    /// JA: UploadFileAsync 操作を実行します。
    /// </summary>
    /// <param name="fileName">ファイル名 JA: fileName パラメーターです。</param>
    /// <param name="content">ファイル内容 JA: content パラメーターです。</param>
    /// <returns>アップロード結果 JA: 結果を返します。</returns>
    Task<bool> UploadFileAsync(string fileName, byte[] content);
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックスからのファイルダウンロード capability です。
/// JA: IToolFileDownloadSource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileDownloadSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileDownloadSource']" />
public interface IToolFileDownloadSource
{
    /// <summary>
    /// サンドボックスからファイルをダウンロードします。
    /// JA: DownloadFileAsync 操作を実行します。
    /// </summary>
    /// <param name="fileName">ファイル名 JA: fileName パラメーターです。</param>
    /// <returns>ファイル内容 JA: 結果を返します。</returns>
    Task<byte[]?> DownloadFileAsync(string fileName);
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックス cleanup capability です。
/// JA: IToolSandboxCleanup の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxCleanup']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxCleanup']" />
public interface IToolSandboxCleanup
{
    /// <summary>
    /// サンドボックスをクリーンアップします。
    /// JA: CleanupAsync 操作を実行します。
    /// </summary>
    Task CleanupAsync();
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックスのリソース使用状況を公開する capability です。
/// JA: IToolResourceUsageSource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolResourceUsageSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolResourceUsageSource']" />
public interface IToolResourceUsageSource
{
    /// <summary>
    /// サンドボックスのリソース使用状況を取得します。
    /// JA: GetResourceUsageAsync 操作を実行します。
    /// </summary>
    /// <returns>リソース使用状況 JA: 結果を返します。</returns>
    Task<SandboxResourceUsage> GetResourceUsageAsync();
}

/// <summary>
/// UC-31 に基づく契約です。
/// ツール実行環境のサンドボックスを定義する互換合成インターフェースです。
/// セキュリティ境界を確立し、ツール実行を隔離します。
/// JA: IToolSandbox の公開契約を定義します。
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
