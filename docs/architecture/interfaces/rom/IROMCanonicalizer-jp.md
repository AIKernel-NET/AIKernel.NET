---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IROMCanonicalizer'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [IROMCanonicalizer.md](./IROMCanonicalizer.md) を参照。

# IROMCanonicalizer (ROM 正準化インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IROMCanonicalizer` は、多様なROM表現を意味保存した正準形へ変換し、比較・署名・検証の基盤となるハッシュ不変性を担保する境界インターフェースです。

- 役割:
  改行・順序・空白・参照表現を正規化し、同一意味の入力から同一正準出力を生成します。
- 非役割:
  ROM実行や物理I/Oは責務外であり、純粋に正規化変換へ集中します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Rom;

public interface IROMCanonicalizer
{
    CanonicalizedRomDto Canonicalize(IRomDocument document);

    Task<CanonicalizedRomDto> CanonicalizeAsync(IRomDocument document, CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-13` 実行時署名検証とガバナンス:
  記述揺れの影響を排し、論理同一性に基づく署名検証を実現します。
- `UC-20` 決定論的リプレイ:
  実行時ROMとの意味同一性比較を厳密化します。
- `UC-01` ROMロードと解析:
  参照解決前段での構造安定化に寄与します。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論的安定性:
  意味的に同一な入力からは環境非依存で同一 `CanonicalizedRomDto` を返す必要があります。
- 意味保存:
  正準化によってROMセマンティクスを損なってはなりません。
- ハッシュ不変性基盤:
  本出力は署名・検証の前提となるため、互換性を重視して変更管理する必要があります。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装では以下の失敗類型を明示することが推奨されます。

- 構文不整合:
  正準化不能なROM構造。
- 非対応版:
  サポート外ROMバージョンやスキーマ。

## 6. 実装時の注意 (Notes)
- メタデータ正規化:
  YAMLフロントマターやキー順序の規約を統一してください。
- 拡張対応:
  将来のマルチモーダル資産参照でも正準化規則を一貫適用できる設計が望まれます。
- 言語依存差分管理:
  バイリンガル文書運用では文字種正規化ポリシーを明示し、再現性を維持してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
