---
title: 'IKernelReplayer'
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

英語版は [IKernelReplayer.md](./IKernelReplayer.md) を参照。

# IKernelReplayer (カーネルリプレイ仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IKernelReplayer` は、Replay Dump から過去実行を決定論的に再現し、監査・デバッグ・回帰検証の基盤を提供する境界インターフェースです。

- 役割:
  ダンプ整合検証、再実行可否判定、再現実行の制御を担います。
- 非役割:
  ダンプ永続化や監査保管自体は別コンポーネント責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Execution;

public interface IKernelReplayer
{
    ValueTask<ExecutionResult> ReplayAsync(
        ReplayDump replayDump,
        TraceContext traceContext,
        CancellationToken cancellationToken = default);

    bool CanReplay(ReplayDump replayDump);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-20` 決定論的リプレイと監査証跡:
  実行時の入力・判断・出力を再構成し、説明可能性を担保します。
- `UC-03` ルーティング検証:
  過去実行条件を基準にルーティング妥当性を再評価します。

## 4. 統治上の制約 (Governance & Determinism)
- 完全再現性:
  同一 `ReplayDump` と同一実行条件に対して、同一 `ExecutionResult` へ収束する必要があります。
- 時間軸凍結:
  再現中は時刻・乱数・外部変動要素をダンプ基準へ固定します。
- 外部依存遮断:
  リプレイ中の実API呼び出しは避け、ダンプ由来の証跡応答を利用します。

## 5. 例外契約 (Exception Contract)
インターフェース自体は例外型を固定しません。現行契約コメントに基づき、以下の失敗を明示します。

- `ArgumentNullException`:
  必須引数が不足している場合。
- `InvalidOperationException`:
  ダンプ整合性検証が失敗した場合。

## 6. 実装時の注意 (Notes)
- バージョン整合:
  `CanReplay` はダンプ形式/エンジン互換性を厳格に検証してください。
- セキュリティ:
  リプレイデータ読込時に署名整合とアクセス制御を適用してください。
- リプレイの範囲:
  本インターフェースが提供するリプレイは、LLM の内部推論アルゴリズムそのもの（確率的ゆらぎの微小差分まで）の再現を目的としません。保証対象は、実行時のコンテキスト構成、パイプライン通過順序、および各ステップのデータ変換が、記録済み証跡と同一の論理パスを辿ることです。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
