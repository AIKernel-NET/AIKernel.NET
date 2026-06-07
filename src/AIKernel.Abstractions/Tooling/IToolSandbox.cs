namespace AIKernel.Abstractions.Tooling;

/// <summary>
/// UC-31 に基づく契約です。
/// ツール実行環境のサンドボックス識別情報を公開します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxIdentity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxIdentity']" />
public interface IToolSandboxIdentity
{
    /// <summary>
    /// サンドボックスの一意識別子を取得します。
    /// </summary>
    string SandboxId { get; }
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックス内のツール実行 capability です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolExecutor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolExecutor']" />
public interface IToolExecutor
{
    /// <summary>
    /// サンドボックス内でツールを実行します。
    /// </summary>
    /// <param name="toolName">ツール名</param>
    /// <param name="parameters">ツールパラメータ</param>
    /// <param name="permissions">実行権限</param>
    /// <returns>実行結果</returns>
    Task<SandboxExecutionResult> ExecuteToolAsync(
        string toolName,
        IReadOnlyDictionary<string, string> parameters,
        IToolPermission permissions);
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックスへのファイルアップロード capability です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileUploadSink']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileUploadSink']" />
public interface IToolFileUploadSink
{
    /// <summary>
    /// サンドボックスにファイルをアップロードします。
    /// </summary>
    /// <param name="fileName">ファイル名</param>
    /// <param name="content">ファイル内容</param>
    /// <returns>アップロード結果</returns>
    Task<bool> UploadFileAsync(string fileName, byte[] content);
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックスからのファイルダウンロード capability です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileDownloadSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolFileDownloadSource']" />
public interface IToolFileDownloadSource
{
    /// <summary>
    /// サンドボックスからファイルをダウンロードします。
    /// </summary>
    /// <param name="fileName">ファイル名</param>
    /// <returns>ファイル内容</returns>
    Task<byte[]?> DownloadFileAsync(string fileName);
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックス cleanup capability です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxCleanup']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolSandboxCleanup']" />
public interface IToolSandboxCleanup
{
    /// <summary>
    /// サンドボックスをクリーンアップします。
    /// </summary>
    Task CleanupAsync();
}

/// <summary>
/// UC-31 に基づく契約です。
/// サンドボックスのリソース使用状況を公開する capability です。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolResourceUsageSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolResourceUsageSource']" />
public interface IToolResourceUsageSource
{
    /// <summary>
    /// サンドボックスのリソース使用状況を取得します。
    /// </summary>
    /// <returns>リソース使用状況</returns>
    Task<SandboxResourceUsage> GetResourceUsageAsync();
}

/// <summary>
/// UC-31 に基づく契約です。
/// ツール実行環境のサンドボックスを定義する互換合成インターフェースです。
/// セキュリティ境界を確立し、ツール実行を隔離します。
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
