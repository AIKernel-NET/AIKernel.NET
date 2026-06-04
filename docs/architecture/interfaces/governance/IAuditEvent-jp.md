---
id: iauditevent
title: "IAuditEvent"
created: 2026-05-03
updated: 2026-06-04
published: 2026-05-16
version: "0.0.4"
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

英語版: [IAuditEvent.md](IAuditEvent.md)

# IAuditEvent

## Responsibility
IAuditEvent が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `EventId` | `string` | 監査イベントの一意識別子。 |
| `EventType` | `string` | イベント種別またはカテゴリ。 |
| `Timestamp` | `DateTime` | イベント発生日時。 |
| `Subject` | `string` | 監査対象。 |
| `Description` | `string` | 人間が読める監査説明。 |
| `Severity` | `AuditSeverity` | 監査重要度。 |
| `Metadata` | `IReadOnlyDictionary<string, string>` | 構造化された監査メタデータ。 |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IAuditEvent 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.4 (2026-06-04): 現行 `IAuditEvent` contract に member table を合わせた。
