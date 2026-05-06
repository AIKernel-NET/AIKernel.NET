---
id: iprovidercapabilities
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCapabilities"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IProviderCapabilities.md](./IProviderCapabilities.md) を参照。

# IProviderCapabilities (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IProviderCapabilities` は、プロバイダーの機能・制約・性能特性を宣言し、ルーティング判断のスペックシートとなる境界インターフェースです。

- 役割:
  対応操作、対応データ型、同時接続上限、レート制限、静的能力ベクトル、動的能力情報を提供します。
- 非役割:
  推論実行そのものは責務外であり、能力宣言の提供に徹します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Providers;

using AIKernel.Abstractions.Models;

public interface IProviderCapabilities
{
    IReadOnlyList<string> SupportedOperations { get; }
    IReadOnlyList<string> SupportedDataTypes { get; }
    int MaxConcurrentConnections { get; }
    RateLimitInfo? RateLimit { get; }
    ModelCapacityVector Vector { get; }
    IDictionary<string, float>? GetDynamicCapacities(IExecutionConstraints constraints);
    ICapabilityProfile? GetCapabilityProfile();
    bool SupportsOperation(string operation);
    bool SupportsDataType(string dataType);
    bool SupportsQuantization(string quantizationLevel);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-03` モデルベクトルルーティング:
  `Vector` と動的能力を用いて最適候補を照合します。
- `UC-22` 動的キャパシティ制御:
  `RateLimit` と `GetDynamicCapacities(...)` で流量制御と候補重み付けを行います。

## 4. 統治上の制約 (Governance & Determinism)
- 能力宣言の正確性:
  宣言した操作が実行不能である場合は異常として扱い、Fail-Closed 側へ倒す必要があります。
- リプレイ整合:
  動的能力値は実行時スナップショットに残し、再現可能性を確保します。
- 透過性:
  クラウド/ローカル実装差異に依存せず、共通指標を返す必要があります。

## 5. 実装時の注意 (Notes)
- ベクトル次元管理:
  `ModelCapacityVector` 次元定義を固定し、比較可能性を保ってください。
- キャッシュ戦略:
  動的能力取得をキャッシュする場合はTTLを明示し、鮮度と安定性を両立してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
