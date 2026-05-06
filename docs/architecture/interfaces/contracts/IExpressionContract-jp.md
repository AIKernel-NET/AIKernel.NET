---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IExpressionContract'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [IExpressionContract.md](./IExpressionContract.md) を参照。

# IExpressionContract (契約仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IExpressionContract` は、推論結果の表現方法を定義し、推論層と表現層を分離するための契約インターフェースです。

- 役割:
  文体、例示、テンプレート、比喩など、出力現像時にのみ使用する表現規約を提供します。
- 非役割:
  推論ロジックの生成・改変は責務外です。表現データを推論入力へ混入させてはなりません。

## 2. 契約シグネチャ (Signature)
```csharp
using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 表現（Expression）契約を定義します。
/// 推論が完全に終了した後にのみ適用される、出力表現層の契約です。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IExpressionContract
{
    /// <summary>
    /// 表現層のコンテキストを取得します。
    /// </summary>
    ExpressionContextDto GetContext();

    /// <summary>
    /// 出力の文体を取得します。
    /// </summary>
    string? GetStyle();

    /// <summary>
    /// 説明用の例を取得します。
    /// 注意: これらは推論には混入しません。
    /// </summary>
    IReadOnlyList<string> GetExamples();

    /// <summary>
    /// 説明テンプレートを取得します。
    /// </summary>
    string? GetDescriptionTemplate();

    /// <summary>
    /// 比喩・類推を取得します。
    /// </summary>
    IReadOnlyList<string> GetAnalogies();

    /// <summary>
    /// このコントラクトが推論結果に混入していないことを確認します。
    /// </summary>
    ValidationResult ValidateIsolation();

    /// <summary>
    /// 推論後の適用タイミングを確認します。
    /// </summary>
    bool CanApplyAfterInference();
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-04` 生成と出力整形:
  `IOutputPolisher` が最終出力へ現像する際の規約ソースとなります。
- `UC-06` 3層バッファ境界:
  推論コンテキストと表現コンテキストの隔離規律を支えます。

## 4. 統治上の制約 (Governance & Determinism)
- 隔離の徹底:
  `ValidateIsolation()` は表現データの推論側リークを検知するための必須ゲートです。
- 後置適用:
  `CanApplyAfterInference()` は Structure フェーズ完了後にのみ true となる運用を前提とします。
- 決定論的整形:
  同一入力に対して同一の表現結果を導く、再現可能な適用規約が必要です。

## 5. 実装時の注意 (Notes)
- 多言語運用:
  `GetStyle()` / `GetExamples()` / `GetAnalogies()` は言語切替規約に従って一貫選択されるべきです。
- 監査可能性:
  テンプレートや例示の適用履歴を追跡可能にし、出力差分の説明責任を確保してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
