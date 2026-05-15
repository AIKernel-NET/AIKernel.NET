---
title: 'IRuleEngine'
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

英語版は [IRuleEngine.md](./IRuleEngine.md) を参照。

# IRuleEngine (ルールエンジン仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IRuleEngine` は、入力・出力・実行プロセスが組織ルールや不変条件に適合しているかを評価する統治インターフェースです。

- 役割:
  ルール評価の合否判定、違反理由、違反レベルの判定結果を返却します。
- 非役割:
  ルール定義の保存管理や永続化は責務外であり、評価実行のみに集中します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Rules;

public interface IRuleEngine
{
    ValueTask<RuleEvaluationResult> EvaluateAsync(
        string ruleId,
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-13` 実行時署名検証とガバナンス:
  署名整合に加えて内容規範適合性を検証します。
- `UC-04` 生成と出力整形:
  生成物が形式・安全ルールに適合するかを後段で評価します。
- `UC-21` ポリシー実行:
  ガードレール判定の中核として機能します。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論的評価:
  同一 `ruleId` と同一 `RuleEvaluationContext` には同一結果を返す必要があります。
- 不変条件の強制:
  重大違反判定時は上位層が Fail-Closed 側で実行停止できる結果を返す必要があります。
- 副作用排除:
  `EvaluateAsync` は評価専用であり、入力コンテキストや外部状態を変更しません。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装では以下の失敗類型を明示することが推奨されます。

- ルール未解決:
  指定 `ruleId` が存在しない/読み込めない場合。
- 評価基盤障害:
  評価エンジンのタイムアウトや実行不可が発生した場合。

## 6. 実装時の注意 (Notes)
- 実装多様性:
  ルールベース、正規表現、特化型モデル評価など用途に応じて実装可能です。
- スコア統合:
  違反累積は `IUnifiedContextContract` の健全性指標（SNR/HealthScore）に連携可能です。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
