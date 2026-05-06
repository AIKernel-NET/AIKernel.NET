---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IMessageContract'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
updated: 2026-05-06
---

英語版は [IMessageContract.md](./IMessageContract.md) を参照。

# IMessageContract (契約仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IMessageContract` は、カーネル内部および外部連携で交換されるメッセージ封筒の標準形式を定義する契約です。

- 役割:
  識別子、種類、時刻、送信元/宛先、ヘッダー、ペイロードの共通枠を提供し、疎結合な通信を成立させます。
- 非役割:
  配送制御、再送、キュー管理、ペイロード解釈は責務外です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Contracts;

/// <summary>
/// メッセージ契約を定義します。
/// カーネル内通信のメッセージ形式を標準化します。
/// </summary>
public interface IMessageContract
{
    /// <summary>
    /// メッセージの一意識別子を取得します。
    /// </summary>
    string MessageId { get; }

    /// <summary>
    /// メッセージの種類を取得します。
    /// </summary>
    string MessageType { get; }

    /// <summary>
    /// メッセージ送信時刻を取得します。
    /// </summary>
    DateTime Timestamp { get; }

    /// <summary>
    /// メッセージの送信元を取得します。
    /// </summary>
    string Source { get; }

    /// <summary>
    /// メッセージの宛先を取得します。
    /// </summary>
    string Destination { get; }

    /// <summary>
    /// メッセージのペイロードを取得します。
    /// </summary>
    object? Payload { get; }

    /// <summary>
    /// メッセージのヘッダーを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string>? Headers { get; }
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-25` Event Bus 配信:
  コンポーネント間イベント伝達の共通パケットとして機能します。
- `UC-20` 決定論的リプレイと監査証跡:
  `Timestamp` と `Headers`（相関情報）を基に時系列追跡を可能にします。
- `UC-29` タスクパイプライン管理:
  非同期ステップ間の進捗通知・状態遷移シグナルに利用されます。

## 4. 統治上の制約 (Governance & Determinism)
- 不変性:
  配送中に `MessageId` と `Payload` が改変されない前提を維持します。
- 追跡可能性:
  `Headers` に `CorrelationId` 等を含め、関連メッセージ連鎖を横断追跡可能にします。
- 時系列整合:
  `Timestamp` は監査時系列の基準となるため、UTC規約で一貫運用することが推奨されます。

## 5. 実装時の注意 (Notes)
- 直列化容易性:
  実装DTOは JSON 等で安定してシリアライズできる構造を推奨します。
- 型安全:
  `object? Payload` を使う場合も、実運用では型付きラッパーやジェネリック契約の併用で安全性を補完してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
