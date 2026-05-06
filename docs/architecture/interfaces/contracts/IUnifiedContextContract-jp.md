---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IUnifiedContextContract'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [IUnifiedContextContract.md](./IUnifiedContextContract.md) を参照。

# IUnifiedContextContract (統合契約仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IUnifiedContextContract` は、Orchestration / Expression / Material の各契約を束ね、3層バッファ境界の維持を全域で統治する上位契約です。

- 役割:
  契約群の統合参照、全体整合性検証、レイヤー分離検証、汚染検知、統合SNR評価を提供します。
- 非役割:
  個別契約の詳細定義や実データ操作は各専門契約へ委譲します。

## 2. 契約シグネチャ (Signature)
```csharp
using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を定義します。
/// OrchestrationContract、ExpressionContract、MaterialContract を統合管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IUnifiedContextContract
{
    /// <summary>
    /// 統合コンテキストの一意識別子を取得します。
    /// </summary>
    string GetId();

    /// <summary>
    /// OrchestrationContract を取得します。
    /// </summary>
    IOrchestrationContract GetOrchestration();

    /// <summary>
    /// ExpressionContract を取得します。
    /// </summary>
    IExpressionContract? GetExpression();

    /// <summary>
    /// MaterialContract を取得します。
    /// </summary>
    IMaterialContract? GetMaterial();

    /// <summary>
    /// 統合コンテキストのデータを取得します。
    /// </summary>
    UnifiedContextDto GetContext();

    /// <summary>
    /// 全体の検証を実行します。
    /// カテゴリ分離、コンテキスト隔離、Attention 汚染検出を行います。
    /// </summary>
    ValidationResult ValidateAll();

    /// <summary>
    /// 3 層分離が正しく保たれていることを確認します。
    /// </summary>
    bool ValidateLayerSeparation();

    /// <summary>
    /// Attention 汚染の可能性を評価します。
    /// </summary>
    IReadOnlyList<FailureMode> DetectPollution();

    /// <summary>
    /// Signal-to-Noise Ratio（SNR）を計算します。
    /// </summary>
    double CalculateSignalToNoiseRatio();
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-06` 3層バッファ境界:
  単一契約点で層分離の健全性を保証します。
- `UC-20` 決定論的リプレイと監査証跡:
  統合コンテキスト単位で保存・再現し、再実行の整合性を担保します。

## 4. 統治上の制約 (Governance & Determinism)
- クロスレイヤー検証:
  `ValidateAll()` は層間矛盾や混入を包括検知する前提です。
- 不変性連鎖:
  統合契約が有効な間、下位契約群も不変運用を前提とします。
- Fail-Closed:
  `ValidateLayerSeparation()` 失敗や重大汚染検知時は推論移行を拒否します。

## 5. 指標: SNR (Signal-to-Noise Ratio)
- 統合評価:
  `CalculateSignalToNoiseRatio()` は単層ではなく全コンテキスト窓の信号密度を測定します。
- 閾値運用:
  低SNR時の警告、ルーティング戦略変更、実行抑止などの統治判断に活用します。

## 6. 実装時の注意 (Notes)
- 遅延評価:
  大規模 `Material` を含む場合、必要時ロード戦略で負荷を抑制してください。
- 直列化互換:
  `GetContext()` が返す DTO は保存/復元互換（JSON等）を維持してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
