---
title: 'ISemanticHasher'
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

英語版は [ISemanticHasher.md](./ISemanticHasher.md) を参照。

# ISemanticHasher (セマンティックハッシュ・インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`ISemanticHasher` は、正準化済みROMの意味内容を一意に代表するハッシュ指紋を算出・検証する境界インターフェースです。

- 役割:
  指定アルゴリズムで決定論的ハッシュを生成し、期待値との整合を検証します。
- 非役割:
  正準化処理そのものは `IRomCanonicalizer` の責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Rom;

public interface ISemanticHasher
{
    string Algorithm { get; }

    string ComputeHash(CanonicalizedRomDto canonicalized);

    Task<string> ComputeHashAsync(CanonicalizedRomDto canonicalized, CancellationToken cancellationToken = default);

    bool VerifyHash(CanonicalizedRomDto canonicalized, string expectedHash);

    Task<bool> VerifyHashAsync(
        CanonicalizedRomDto canonicalized,
        string expectedHash,
        CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-13` 実行時署名検証とガバナンス:
  署名対象ダイジェストの算出・照合基盤を提供します。
- `UC-20` 決定論的リプレイ:
  実行時ROMと保存ROMの意味同一性を高速比較します。
- `UC-01` ROMロード検証:
  ロード資産の整合チェックに利用されます。

## 4. 統治上の制約 (Governance & Determinism)
- 完全決定論:
  同一 `Algorithm`・同一 `CanonicalizedRomDto` で同一文字列を返す必要があります。
- 衝突耐性:
  異なる意味内容の衝突を最小化する安全なハッシュ関数採用が必要です。
- アルゴリズム一貫性:
  永続化済みハッシュとの互換性を壊す挙動変更は厳格管理されるべきです。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装では以下の失敗類型を明示することが推奨されます。

- 暗号基盤障害:
  ハッシュ計算サブシステム障害。
- 非対応アルゴリズム:
  指定アルゴリズム未サポート。

## 6. 実装時の注意 (Notes)
- プレフィックス形式:
  `sha256:...` のようなアルゴリズム明示形式を採用すると将来拡張に有利です。
- 資産連鎖:
  参照バイナリ資産のハッシュを正準表現へ組み込むことで全体整合性を強化できます。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
