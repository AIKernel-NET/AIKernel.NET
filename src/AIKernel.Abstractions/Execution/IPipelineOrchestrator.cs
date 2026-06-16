using AIKernel.Dtos.Context;

namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// パイプラインオーケストレーションの契約。
/// EPS-004: フェーズ順序は固定であり、逆流は不可（MUST）。
/// EPS-006: 状態の不変性（State Immutability）の実装基盤。
/// EN: EPS-007: 3層バッファとのマッピング（Buffer Mapping）の調整。
/// EN: Documentation for public API. JA: IPipelineOrchestrator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPipelineOrchestrator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPipelineOrchestrator']" />
public interface IPipelineOrchestrator
{
    /// <summary>
    /// パイプラインを実行し、Structure -&gt; Generation -&gt; Polish の全フェーズを原子的に実行します。
    /// EPS-004: フェーズ順序は固定。
    /// EN: EPS-006: 状態不変性を保証。
    /// EN: Documentation for public API. JA: ExecuteAsync 操作を実行します。
    /// </summary>
    /// <param name="context">EN: Documentation for public API. JA: 統合コンテキスト context パラメーターです。</param>
    /// <param name="signatureVerificationResult">EN: Documentation for public API. JA: 署名検証結果（SGS-006 通過済みであることを示す） signatureVerificationResult パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 全フェーズメタデータを含む ExecutionResult 結果を返します。</returns>
    Task<ExecutionResult> ExecuteAsync(
        IContextCollection context,
        AIKernel.Dtos.Execution.SignatureVerificationResult signatureVerificationResult,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Replay Dump から別ブランチ再実行を行います。
    /// EPS-006: 状態不変性のための再実行メカニズム。
    /// EN: 「変更が必要な場合は Replay Dump を起点とした別ブランチ再実行を行う」
    /// EN: Documentation for public API. JA: ReplayFromDumpAsync 操作を実行します。
    /// </summary>
    /// <param name="replayDump">EN: Documentation for public API. JA: 再実行起点となるダンプ replayDump パラメーターです。</param>
    /// <param name="modificationContext">EN: Documentation for public API. JA: 修正情報コンテキスト modificationContext パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 再実行結果 結果を返します。</returns>
    Task<ExecutionResult> ReplayFromDumpAsync(
        ReplayDump replayDump,
        ModificationContext modificationContext,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// パイプラインの初期化・検証を行います。
    /// EN: EPS のフェーズ 1: Phase Initialization に対応。
    /// EN: Documentation for public API. JA: InitializeAsync 操作を実行します。
    /// </summary>
    /// <param name="context">EN: Documentation for public API. JA: コンテキスト context パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 初期化が成功したかどうか 結果を返します。</returns>
    Task<InitializationResult> InitializeAsync(
        IContextCollection context,
        CancellationToken cancellationToken = default);
}


