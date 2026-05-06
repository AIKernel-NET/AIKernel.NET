---
title: "移行ガイド（Migration Guide）"
status: "Planned"
version: 0.0.1
updated: 2026-05-06
---

# 移行ガイド（Migration Guide）

本ガイドは、初期コンセプト版（v0.0.0）から、正典化されたアーキテクチャ（v0.0.1）へ移行するための手順を定義します。

## 1. 根本的な変更点
v0.0.1 では、`決定論（Determinism）` と `非推論型ガバナンス` を軸に、全体設計が再編されました。

- `Namespace の厳格化`:
  `AIKernel.Models` は廃止され、`Routing` / `Rom` / `Rules` へ責務分割されました。
- `DTO の純粋化`:
  DTO 層からロジックとカスタム例外を排除し、データ契約に限定しました。
- `信頼チェーンの導入`:
  ROM 処理は、`IROMCanonicalizer` を経由してから `ISemanticHasher` で検証する流れへ統一されました。

## 2. インターフェースの代替マッピング
旧語彙から新語彙への置換ルールです。

| 旧インターフェース (v0.0.0) | 新インターフェース (v0.0.1) | 移行ポイント |
|---|---|---|
| `IPromptSigner` | `ISemanticHasher` + `IPromptSignatureProvider` | 署名のみの発想から、正準化 + 意味ハッシュ + 署名検証の連鎖へ移行。 |
| `IContextSerializer` | （廃止） | `IKernelContext` と `IContextSnapshot` に責務を再配置。 |
| `IRoutingDecisionEngine` | `IModelVectorRouter` | モデル名中心の選択から、能力ベクトル中心の決定へ移行。 |
| `IPromptRuleSet` | `IPolicy` / `IRuleEngine` | ルール集合の曖昧運用を廃止し、決定論的ポリシー評価へ移行。 |

## 3. 推奨移行ステップ
1. `Namespace の修正`:
   物理ディレクトリ構造に合わせて `using` を更新します。
2. `例外処理の移動`:
   DTO 層の例外前提実装を廃止し、Provider/Kernel 実行層で Fail-Closed を実装します。
3. `ROM 処理の修正`:
   ハッシュ計算の前に必ず `IROMCanonicalizer.Canonicalize()` を呼び出します。
4. `テストの再整備`:
   Use-Case 駆動テストを、`UC-xx` と対応 Interface に再マッピングします。

## 4. 検証チェックリスト
- `Abstractions` が外部 SDK 型をシグネチャに露出していない。
- `Dtos` がロジックや例外型に依存していない。
- `IRomDocument -> IROMCanonicalizer -> ISemanticHasher` の順序が守られている。
- `IPdp` 判定経路に LLM 推論を含めず、`Indeterminate => Deny` を保証している。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
