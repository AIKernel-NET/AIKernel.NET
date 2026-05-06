---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IOrchestrationContract'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [IOrchestrationContract.md](./IOrchestrationContract.md) を参照。

# IOrchestrationContract (契約仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IOrchestrationContract` は、Structure フェーズに投入する純粋推論入力を定義し、推論層と表現層の境界を強制する契約です。

- 役割:
  目的、制約、抽象構造、推論パターン、および整合性検証情報を提供します。
- 非役割:
  文体・例示など出力装飾情報の供給は責務外です（`IExpressionContract` 側の責務）。

## 2. 契約シグネチャ (Signature)
```csharp
using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 推論（Orchestration）契約を定義します。
/// 目的、制約、抽象構造を含む不変な入力フォーマットです。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IOrchestrationContract
{
    /// <summary>
    /// 推論に必要なコンテキストを取得します。
    /// 例・文体・RAG は含まれていません。
    /// </summary>
    OrchestrationContextDto GetContext();

    /// <summary>
    /// 推論のための目的を取得します。
    /// </summary>
    string GetPurpose();

    /// <summary>
    /// 推論に課される制約条件を取得します。
    /// </summary>
    IReadOnlyList<string> GetConstraints();

    /// <summary>
    /// 推論の抽象構造を取得します。
    /// </summary>
    string GetStructure();

    /// <summary>
    /// 推論パターンを取得します。
    /// </summary>
    string? GetReasoningPattern();

    /// <summary>
    /// このコントラクトが有効であることを確認します。
    /// Attention 汚染の検出も行います。
    /// </summary>
    ValidationResult Validate();

    /// <summary>
    /// Signal-to-Noise Ratio（SNR）を計算します。
    /// </summary>
    double CalculateSignalToNoiseRatio();
}

/// <summary>
/// OrchestrationContract の検証結果を表現します。
/// </summary>
public sealed class ValidationResult
{
    /// <summary>
    /// 検証が成功したかどうかを取得します。
    /// </summary>
    public bool IsValid { get; init; }

    /// <summary>
    /// 検出されたエラーメッセージを取得します。
    /// </summary>
    public List<string> Errors { get; init; } = new();

    /// <summary>
    /// 警告メッセージを取得します。
    /// </summary>
    public List<string> Warnings { get; init; } = new();

    /// <summary>
    /// 検出された attention 汚染を取得します。
    /// </summary>
    public List<FailureMode> DetectedFailureModes { get; init; } = new();
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-02` Structure フェーズ実行:
  `IThoughtProcess` が `RawLogic` を構築するための中核入力です。
- `UC-06` 3層バッファ境界:
  推論データへの表現ノイズ混入（Attention 汚染）を契約上で抑制します。

## 4. 統治上の制約 (Governance & Determinism)
- Attention 汚染拒絶:
  `Validate()` は表現層語彙の混入や不要装飾を検知し、拒否側判断を可能にします。
- 決定論的入力:
  同一コンテキスト状態では、各メソッドが同一値を返す運用が必要です。
- Fail-Closed:
  重大な整合違反検知時は実行継続ではなく停止を優先します。

## 5. 指標と品質 (Metrics)
- `CalculateSignalToNoiseRatio()`:
  推論入力の信号密度（目的/制約/構造の明確性）を評価する補助指標です。
- 低SNR対応:
  低SNRは曖昧推論や逸脱の温床となるため、警告または拒否判定の材料とします。

## 6. 実装時の注意 (Notes)
- 不変性:
  推論サイクル中に契約内容を変化させない運用を推奨します。
- 構造化優先:
  `GetStructure()` は自由文よりもスキーマ化表現（YAML/JSON等）を用いると再現性が向上します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
