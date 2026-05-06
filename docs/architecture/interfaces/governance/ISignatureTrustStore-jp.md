---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ISignatureTrustStore Interface Draft"
created: 2026-05-04
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - prompt
  - governance
  - japanese
---

英語版は [ISignatureTrustStore.md](./ISignatureTrustStore.md) を参照。

# ISignatureTrustStore (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`ISignatureTrustStore` は、署名者信頼性・鍵失効・証明書連鎖・信頼アンカー健全性を判定する、ガバナンスの最終信頼境界です。

- 役割:
  署名者信頼スコア解決、鍵失効確認、有効期限確認、証明書連鎖検証、信頼アンカー列挙、ストア健全性判定を提供します。
- 非役割:
  暗号学的署名照合そのものは `IPromptVerifier` 側の責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Governance;

public interface ISignatureTrustStore
{
    Task<double> ResolveTrustScoreAsync(string signerId, CancellationToken cancellationToken = default);
    Task<bool> IsKeyRevokedAsync(string keyId, CancellationToken cancellationToken = default);
    Task<DateTime?> GetKeyExpiryAsync(string keyId, CancellationToken cancellationToken = default);
    Task<bool> VerifyCertificateChainAsync(string signerId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<string>> GetTrustedAnchorsAsync(CancellationToken cancellationToken = default);
    Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-13` 実行時署名検証とガバナンス:
  検証前提となる署名者信頼状態を判定します。
- `UC-20` 決定論的リプレイと監査チェーン:
  実行時の信頼判定根拠を後追い検証可能にします。
- `UC-32` 信頼アンカー運用:
  失効・期限・連鎖状態を統合監視します。

## 4. Fail-Closed 原則
- `ResolveTrustScoreAsync` が負値（到達不能/不信）を返す場合は実行拒否が必要です。
- `IsHealthyAsync` が `false` の場合、警告モードへ降格せず拒否側に倒します。
- 鍵失効または期限切れが検知された場合は即時遮断対象です。

## 5. 統治上の制約 (Governance & Determinism)
- 決定論的判定:
  同一時点・同一入力に対する信頼判定結果は再現可能である必要があります。
- 監査整合:
  判定結果と根拠（keyId, expiry, chain, anchors）を監査ログへ連携可能にします。

## 6. 実装時の注意 (Notes)
- 失効情報の鮮度:
  CRL/OCSP など外部情報利用時は取得失敗を fail-closed として扱います。
- スナップショット運用:
  実行時点の信頼状態を保存し、リプレイ時の「当時判定」を再現できるようにします。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
