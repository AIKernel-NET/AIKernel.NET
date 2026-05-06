using AIKernel.Dtos.Context;

namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// パイプラインオーケストレーションの契約。
/// EPS-004: フェーズ順序は固定であり、逆流は不可（MUST）。
/// EPS-006: 状態の不変性（State Immutability）の実装基盤。
/// EPS-007: 3層バッファとのマッピング（Buffer Mapping）の調整。
/// </summary>
public interface IPipelineOrchestrator
{
    /// <summary>
    /// パイプラインを実行し、Structure -> Generation -> Polish の全フェーズを原子的に実行します。
    /// EPS-004: フェーズ順序は固定。
    /// EPS-006: 状態不変性を保証。
    /// </summary>
    /// <param name="context">統合コンテキスト</param>
    /// <param name="signatureVerificationResult">署名検証結果（SGS-006 通過済みであることを示す）</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>全フェーズメタデータを含む ExecutionResult</returns>
    Task<ExecutionResult> ExecuteAsync(
        IContextCollection context,
        AIKernel.Dtos.Execution.SignatureVerificationResult signatureVerificationResult,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Replay Dump から別ブランチ再実行を行います。
    /// EPS-006: 状態不変性のための再実行メカニズム。
    /// 「変更が必要な場合は Replay Dump を起点とした別ブランチ再実行を行う」
    /// </summary>
    /// <param name="replayDump">再実行起点となるダンプ</param>
    /// <param name="modificationContext">修正情報コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>再実行結果</returns>
    Task<ExecutionResult> ReplayFromDumpAsync(
        ReplayDump replayDump,
        ModificationContext modificationContext,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// パイプラインの初期化・検証を行います。
    /// EPS のフェーズ 1: Phase Initialization に対応。
    /// </summary>
    /// <param name="context">コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>初期化が成功したかどうか</returns>
    Task<InitializationResult> InitializeAsync(
        IContextCollection context,
        CancellationToken cancellationToken = default);
}


