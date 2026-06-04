---
title: 'IUnifiedContextContract'
created: 2026-05-06
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IUnifiedContextContract.md](./IUnifiedContextContract.md) を参照。

# IUnifiedContextContract (統合契約仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IUnifiedContextContract` は、Orchestration / Expression / Material の各契約を束ね、3層バッファ境界の維持を全域で統治する上位契約です。

- 役割:
  Orchestration / Expression / Material の各契約 view への統合参照を提供します。
- 非役割:
  全体整合性検証、レイヤー分離検証、汚染検知、統合SNR評価、実データ操作は
  専門の service interface と DTO 境界へ委譲します。

## 2. 契約シグネチャ (Signature)
```csharp
using AIKernel.Dtos.Context;

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
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-06` 3層バッファ境界:
  単一契約点で層分離の健全性を保証します。
- `UC-20` 決定論的リプレイと監査証跡:
  統合コンテキスト単位で保存・再現し、再実行の整合性を担保します。

## 4. 統治上の制約 (Governance & Determinism)
- クロスレイヤー検証:
  `IUnifiedContextContractValidator.ValidateAll()` は層間矛盾や混入を包括検知する前提です。
- 不変性連鎖:
  統合契約が有効な間、下位契約群も不変運用を前提とします。
- Fail-Closed:
  `ILayerSeparationValidator.ValidateLayerSeparation()` 失敗や重大汚染検知時は推論移行を拒否します。

## 5. 指標: SNR (Signal-to-Noise Ratio)
- 統合評価:
  `ISignalToNoiseRatioCalculator.CalculateSignalToNoiseRatio()` は単層ではなく全コンテキスト窓の信号密度を測定します。
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
