---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IAuditLogger'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [IAuditLogger.md](./IAuditLogger.md) を参照。

# IAuditLogger (監査ロガー仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IAuditLogger` は、AIKernel 内で発生する意思決定・実行・検閲・転送イベントを改ざん耐性のある監査証跡として記録する境界インターフェースです。

- 役割:
  推論実行、ガード判定、パイプライン遷移、プロバイダー通信、転送追跡を分類記録し、説明責任と再現性を担保します。
- 非役割:
  リアルタイム通知は `IEventBus` 側の責務であり、本契約は永続証跡記録に集中します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Events;

public interface IAuditLogger
{
    ValueTask LogAuditEventAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default);

    ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default);

    ValueTask LogGuardEventAsync(GuardEvent guardEvent, CancellationToken cancellationToken = default);

    ValueTask LogPipelineEventAsync(PipelineEvent pipelineEvent, CancellationToken cancellationToken = default);

    ValueTask LogProviderEventAsync(ProviderEvent providerEvent, CancellationToken cancellationToken = default);

    ValueTask LogTransferTraceAsync(TransferTrace transferTrace, CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-20` 決定論的リプレイと監査証跡:
  実行時の入力/判断/出力/通信を再構成可能に記録します。
- `UC-13` 実行時署名検証とガバナンス:
  検証失敗・違反イベントを監査トリガーとして保存します。
- `UC-24` 監査証跡出力:
  検索可能な構造化証跡を外部監査系へ連携します。

## 4. 統治上の制約 (Governance & Determinism)
- 時系列整合:
  追記順序は因果復元可能な時系列整合性を維持する必要があります。
- 不変性:
  監査ログは append-only を前提とし、事後改変を禁止します。
- Fail-Closed:
  監査記録不能時は証跡欠落推論を避けるため、安全側停止または厳格フォールバックが必要です。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装では以下の失敗類型を明示することが推奨されます。

- ストレージ障害:
  永続化先書き込み失敗や容量不足。
- 直列化障害:
  ログイベントの構造化出力失敗。

## 6. 実装時の注意 (Notes)
- 構造化ログ:
  JSON 等の検索可能形式で保存し、横断分析を容易にしてください。
- 秘匿情報保護:
  APIキーやPIIはマスキング・トークン化して記録します。
- 性能:
  非同期書き込み/バッファリングで推論クリティカルパスへの影響を最小化してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
