---
id: ioutputpolisher
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IOutputPolisher"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IOutputPolisher.md](./IOutputPolisher.md) を参照。

# IOutputPolisher (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IOutputPolisher` は、AI 推論の中間結果（`RawLogic`）を、文脈に適合した最終表現（Expression）へ変換・洗練する境界インターフェースです。

- 役割:
  構文妥当性チェック、Markdown/構造化形式への整形、トーン・スタイルの最終調整を行います。
- 非役割:
  根本推論の生成は `IThoughtProcess` の責務です。`IOutputPolisher` は「現像と定着」に集中します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Execution;

/// <summary>
/// 中間推論結果を最終的な出力形式へ整形します。
/// </summary>
public interface IOutputPolisher
{
    /// <summary>
    /// このポリッシャー実行に必要な最小モデル能力。
    /// </summary>
    ModelCapacityVector RequiredCapacity { get; }

    /// <summary>
    /// 中間論理と表現コンテキストから最終出力をレンダリングします。
    /// </summary>
    /// <param name="logic">モデルが生成した中間論理データ</param>
    /// <param name="expressionContext">出力形式・文体制約を含むコンテキスト</param>
    /// <param name="ct">キャンセル通知用トークン</param>
    /// <returns>整形済みの最終出力文字列</returns>
    Task<string> RenderAsync(RawLogic logic, ExpressionContext expressionContext, CancellationToken ct = default);
}
```

注記:
`OutputValidationException` は実装層で採用し得る代表例です。現行の抽象契約では例外型名を固定していません。

## 3. 関連ユースケース (Related UCs)
- `UC-04` 生成と出力整形:
  `ExpressionBuffer` へ反映する直前の最終処理として機能します。
- `UC-17` Chat Diffing:
  比較可能な出力正準化における間接制約として機能します。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論的レンダリング:
  同一 `RawLogic` と同一 `ExpressionContext` に対し、同一出力へ収束することを要求します。
- Fail-Closed 原則:
  `expressionContext` の制約（例: 有効 JSON 必須）を満たせない場合、不完全出力を返さず拒否側で終了します。

## 5. 実装時の注意 (Notes)
- 能力ベースルーティング:
  `RequiredCapacity` を適切に定義することで、`IModelVectorRouter` が整形処理の実行先を最適化できます。
- 正準化推奨:
  空行揺れ、JSON プロパティ順序揺れなど、意味を変えない非決定要素の排除を推奨します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
