---
id: imaterialquarantine
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IMaterialQuarantine"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IMaterialQuarantine.md を参照。

# IMaterialQuarantine (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IMaterialQuarantine` は、AI システムへ取り込まれる素材（外部データ、RAG 結果、ユーザーファイル等）の安全性確保と構造的正準化を司る境界インターフェースです。

- 役割:
  未検証の `ContextFragment` を、信頼済みかつ構造化された `IStructuredMaterial` へ昇格します。
- 非役割:
  物理スキャン（ウイルス検知、破損検知等）は `IMaterialScanner` の責務です。`IMaterialQuarantine` はスキャン結果に基づく検疫ロジックと形式変換に集中します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Material;

/// <summary>
/// 外部素材を検疫し、システムが安全に扱える構造化データへ変換します。
/// </summary>
public interface IMaterialQuarantine
{
    /// <summary>
    /// 未検証フラグメントを検疫し、正規化します。
    /// </summary>
    /// <param name="rawFragment">検疫対象の生データ</param>
    /// <param name="ct">キャンセル通知用トークン</param>
    /// <returns>検疫済みの構造化素材</returns>
    Task<IStructuredMaterial> QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default);
}
```

注記:
`QuarantineViolationException` や `InvalidMaterialFormatException` は実装層で利用し得る代表例です。現行の抽象契約では例外型名を固定していません。

## 3. 関連ユースケース (Related UCs)
- `UC-07` 素材検疫:
  外部データ取り込み時の第一段ガードレールとして機能します。
- `UC-21` マテリアル検疫とポリシー実行:
  `IPdp` や `IMaterialScanner` と連携し、ポリシー非準拠素材の混入を遮断します。

## 4. 統治上の制約 (Governance & Determinism)
- Fail-Closed 原則:
  判定不能エラー、またはポリシー評価 `Indeterminate` の場合、処理は必ず拒否側で終了させます。
- 正準化の強制:
  論理的に同一な入力は、同一の `IStructuredMaterial` 表現へ収束する必要があります。これは決定論的リプレイの前提です。

## 5. 実装時の注意 (Notes)
- `IMaterialScanner` の信頼スコアが閾値を下回る場合は、検疫拒否として扱う実装を推奨します。
- `IStructuredMaterial` への変換時に、PII マスキングと機密情報除去をポリシーに基づき適用することを推奨します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
