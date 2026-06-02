---
id: ikernelhost
title: "IKernelHost"
created: 2026-05-03
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

英語版: [IKernelHost](architecture/interfaces/hosting/IKernelHost.md)

# IKernelHost

## 1. 概要
`IKernelHost` は、AIKernel 実行環境（KernelContext）のライフサイクル管理、および外部アプリケーションに対する唯一の統治窓口です。  
実行要求を受理する前に、コンポーネント整合性とガバナンスポリシーを検証し、安全が確認された場合のみカーネルを起動する責務を持ちます。

## 2. 設計原則
- Fail-Closed Orchestration: `SGS` が有効でない、または必須コンポーネント欠落時は即時に起動を破棄する。
- Identity Integrity: ホスト識別情報を監査チェーンに刻印し、どのホスト経由で実行されたかを追跡可能にする。
- Environment Determinism: 環境変数・DI状態の揺らぎが再現性を壊さないよう、初期化経路を固定化する。

## 3. Signature
| Member | Type | 説明 |
| --- | --- | --- |
| `Name` | `string` | 契約インスタンスの論理識別名。 |
| `Version` | `string` | 互換性確認に用いる契約バージョン。 |
| `Metadata` | `IReadOnlyDictionary<string, string>` | 実装固有拡張のためのメタデータ。 |

## 4. 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IKernelHost 参照箇所を基準とする。

## 5. Spec Links
- [01.EXECUTION_PIPELINE_SPEC-jp.md](../../../specs/01.EXECUTION_PIPELINE_SPEC-jp.md) / `EPS-004`, `EPS-F002`  
  実行前検証失敗時は直ちに停止し、未検証フローを許可しない。
- [02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md](../../../specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md) / `SGS-001`, `SGS-F001`  
  未署名・判定不能入力の受理禁止（Fail-Closed）。
- [06.REPLAY_DUMP_SPEC-jp.md](../../../specs/06.REPLAY_DUMP_SPEC-jp.md) / `RDS-001`, `RDS-F002`  
  必須リプレイ情報欠落時のロード拒否。

## 6. 決定論に関する注記 (Determinism Note)
同一 `Seed` と同一環境設定が与えられた場合、ホストは決定論的なカーネル初期化経路を提供しなければならない。  
環境差異やガバナンス判定不能時は安全側で起動拒否する。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
