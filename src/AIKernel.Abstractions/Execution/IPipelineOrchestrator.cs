using AIKernel.Abstractions.Context;

namespace AIKernel.Abstractions.Execution;

/// <summary>
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
        SignatureVerificationResult signatureVerificationResult,
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

/// <summary>
/// 署名検証結果（SGS-006通過を示す）。
/// </summary>
public sealed record SignatureVerificationResult
{
    /// <summary>
    /// 検証が成功したかどうか。
    /// </summary>
    public required bool IsValid { get; init; }

    /// <summary>
    /// 署名者 ID。
    /// </summary>
    public required string SignerId { get; init; }

    /// <summary>
    /// 信頼スコア（0.0-1.0）。
    /// SGS-003: ISignatureTrustStore の判定結果。
    /// </summary>
    public required double TrustScore { get; init; }

    /// <summary>
    /// 署名検証メッセージ。
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// 検証タイムスタンプ。
    /// </summary>
    public required DateTime VerificationTimestamp { get; init; }
}

/// <summary>
/// Replay Dump: 再実行用の実行スナップショット。
/// EPS-006 の実装基盤。
/// </summary>
public sealed record ReplayDump
{
    /// <summary>
    /// ダンプの一意識別子。
    /// </summary>
    public required string DumpId { get; init; }

    /// <summary>
    /// 元の ExecutionResult。
    /// </summary>
    public required ExecutionResult OriginalResult { get; init; }

    /// <summary>
    /// Structure フェーズ出力（中間表現）。
    /// </summary>
    public required RawLogic StructureOutput { get; init; }

    /// <summary>
    /// Generation フェーズ出力。
    /// </summary>
    public required string GenerationOutput { get; init; }

    /// <summary>
    /// ダンプ作成タイムスタンプ。
    /// </summary>
    public required DateTime CreatedAt { get; init; }

    /// <summary>
    /// ハッシュチェーン（EPS-005）。
    /// 各フェーズの出力ハッシュを連鎖させたもの。
    /// </summary>
    public required HashChain HashChain { get; init; }
}

/// <summary>
/// 修正情報コンテキスト（Replay 時）。
/// </summary>
public sealed record ModificationContext
{
    /// <summary>
    /// 修正理由。
    /// </summary>
    public required string Reason { get; init; }

    /// <summary>
    /// 修正する対象フェーズ。
    /// "structure", "generation", "polish" など。
    /// </summary>
    public required string TargetPhase { get; init; }

    /// <summary>
    /// 修正内容（例：新しいプロンプト入力）。
    /// </summary>
    public required string ModificationData { get; init; }

    /// <summary>
    /// 修正者 ID。
    /// </summary>
    public required string ModifiedBy { get; init; }
}

/// <summary>
/// パイプライン初期化結果。
/// </summary>
public sealed record InitializationResult
{
    /// <summary>
    /// 初期化が成功したかどうか。
    /// </summary>
    public required bool IsInitialized { get; init; }

    /// <summary>
    /// 初期化メッセージ。
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// 検出された問題（初期化失敗時）。
    /// </summary>
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();

    /// <summary>
    /// 実行前コンテキストハッシュ（EPS フェーズ 1）。
    /// </summary>
    public string? PreExecutionContextHash { get; init; }
}

/// <summary>
/// ハッシュチェーン（EPS-005）。
/// 各フェーズの出力ハッシュを連鎖させることで、改ざん検知と再現性を保証する。
/// </summary>
public sealed record HashChain
{
    /// <summary>
    /// Structure フェーズ出力のハッシュ。
    /// </summary>
    public required string StructureHash { get; init; }

    /// <summary>
    /// Generation フェーズ出力のハッシュ。
    /// Structure ハッシュを親として記録（EPS-007フェーズ 3）。
    /// </summary>
    public required string GenerationHash { get; init; }

    /// <summary>
    /// Generation ハッシュへのリンク（親ハッシュとして記録）。
    /// EPS-007フェーズ 3: Structure 出力ハッシュを Generation の親ハッシュとして記録し、連鎖を形成する。
    /// </summary>
    public required string GenerationParentHash { get; init; }

    /// <summary>
    /// Polish フェーズ出力のハッシュ。
    /// </summary>
    public required string PolishHash { get; init; }

    /// <summary>
    /// Polish ハッシュへのリンク（親ハッシュ）。
    /// </summary>
    public required string PolishParentHash { get; init; }

    /// <summary>
    /// ハッシュアルゴリズム（"SHA256" など）。
    /// </summary>
    public string HashAlgorithm { get; init; } = "SHA256";

    /// <summary>
    /// ハッシュチェーンの検証（完全性確認）。
    /// </summary>
    public bool IsChainValid()
    {
        // Simple validation: all hashes present and parent links point correctly
        return !string.IsNullOrEmpty(StructureHash)
            && !string.IsNullOrEmpty(GenerationHash)
            && !string.IsNullOrEmpty(GenerationParentHash)
            && !string.IsNullOrEmpty(PolishHash)
            && !string.IsNullOrEmpty(PolishParentHash)
            && GenerationParentHash == StructureHash; // Parent link integrity
    }
}
