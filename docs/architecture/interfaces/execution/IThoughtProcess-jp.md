---
id: ithoughtprocess
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IThoughtProcess"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IThoughtProcess.md](./IThoughtProcess.md) を参照。

# IThoughtProcess (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IThoughtProcess` は、AIKernel の二段階実行モデルにおける第一段階「Structure フェーズ」を担う境界インターフェースです。

- 役割:
  コンテキストを分析し、タスク分解・制約抽出・解決方針を含む中間論理構造（`RawLogic`）を構築します。
- 非役割:
  最終応答（Expression）の生成は `IOutputPolisher` の責務です。
  また、実装は Provider への直接 API 呼び出しではなく、オーケストレーション層の抽象を通じて推論を扱います。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Execution;

/// <summary>
/// コンテキストから中間推論論理を構築します。
/// </summary>
public interface IThoughtProcess
{
    /// <summary>
    /// この思考プロセスに必要な最小モデル能力（ベクトル）。
    /// </summary>
    ModelCapacityVector RequiredCapacity { get; }

    /// <summary>
    /// オーケストレーションコンテキストに基づいて中間論理を構築します。
    /// </summary>
    /// <param name="orchestrationContext">指示・素材・履歴を含む実行コンテキスト</param>
    /// <param name="ct">キャンセル通知用トークン</param>
    /// <returns>構築された中間論理データ（RawLogic）</returns>
    Task<RawLogic> BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default);
}
```

注記:
`LogicConstructionException` は実装層で採用し得る代表例です。現行の抽象契約では例外型名を固定していません。

## 3. 関連ユースケース (Related UCs)
- `UC-02` Structure フェーズ実行:
  タスク分解と実行計画構築の中核として機能します。
- `UC-29` タスクパイプライン管理:
  DAG 形式タスクを組み立てる際の知能ユニットとして利用されます。

## 4. 統治上の制約 (Governance & Determinism)
- 純粋推論の維持:
  `BuildLogicAsync` は入力コンテキストから副作用を最小化して `RawLogic` を導出することを要求します。
- Fail-Closed 原則:
  指示と素材に解消不能な矛盾がある場合、不確実な計画を生成せず拒否側で終了させます。

## 5. 実装時の注意 (Notes)
- 能力の明示:
  `RequiredCapacity` を適切に定義することで、`IModelVectorRouter` が最適な実行先を選択できます。
- コンテキスト隔離の遵守:
  `orchestrationContext` のバッファ境界（指示・素材・履歴分離）を尊重し、Attention 汚染を避ける構成を維持してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
