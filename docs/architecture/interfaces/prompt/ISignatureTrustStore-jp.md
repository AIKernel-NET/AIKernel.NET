---
version: 0.0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ISignatureTrustStore Interface Draft"
created: 2026-05-04
updated: 2026-05-04
tags:
  - aikernel
  - architecture
  - interfaces
  - prompt
  - governance
  - japanese
---

英語版は `ISignatureTrustStore.md` を参照。

# ISignatureTrustStore

## Purpose
署名付きプロンプト統治において、署名者信頼性・鍵有効性・失効状態を Provider 非依存で判定するための信頼アンカー抽象を定義する。

## Responsibility
- 信頼済み署名者 ID と検証素材（鍵識別子、アルゴリズム）を解決する。
- 信頼状態（trusted / revoked / expired / unknown）を判定する。
- 監査ログに必要な信頼メタデータを提供する。

## Key Members (Draft)
```csharp
public interface ISignatureTrustStore
{
    Task<SignerTrustRecord?> GetSignerAsync(string signerId, CancellationToken ct = default);
    Task<TrustDecision> EvaluateAsync(SignatureEnvelope envelope, CancellationToken ct = default);
    Task<IReadOnlyList<SignerTrustRecord>> ListTrustedSignersAsync(CancellationToken ct = default);
}
```

## Supporting Contracts (Draft)
```csharp
public sealed record SignerTrustRecord(
    string SignerId,
    string KeyId,
    string Algorithm,
    DateTimeOffset ValidFromUtc,
    DateTimeOffset ValidToUtc,
    bool IsRevoked,
    IReadOnlyDictionary<string, string>? Metadata = null);

public sealed record SignatureEnvelope(
    string SignerId,
    string KeyId,
    string Algorithm,
    string Signature,
    string PayloadHash,
    DateTimeOffset SignedAtUtc);

public enum TrustDecision
{
    Trusted = 1,
    Revoked = 2,
    Expired = 3,
    UnknownSigner = 4,
    InvalidKeyBinding = 5,
    Indeterminate = 6
}
```

## Use Cases
- `IPromptVerifier` の実行前署名検証
- `IPromptValidator` の認可判定
- Replay Dump 生成時の監査チェーン強化

## Fail-Closed Semantics
- `Indeterminate` や署名者未解決状態は実行拒否とする。
- 信頼アンカー不在時に warning-only モードへ降格してはならない。

