namespace AIKernel.Contracts;

/// <summary>
/// メッセージ契約を定義します。
/// カーネル内通信のメッセージ形式を標準化します。
/// EN: UC-25（Event Bus 配信）
/// [EN] Documents this public package API member. [JA] IMessageContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMessageContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMessageContract']" />
public interface IMessageContract
{
    /// <summary>
    /// EN: メッセージの一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string MessageId { get; }

    /// <summary>
    /// EN: メッセージの種類を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string MessageType { get; }

    /// <summary>
    /// EN: メッセージ送信時刻を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    DateTime Timestamp { get; }

    /// <summary>
    /// EN: メッセージの送信元を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Source { get; }

    /// <summary>
    /// EN: メッセージの宛先を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Destination { get; }

    /// <summary>
    /// EN: メッセージのペイロードを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    object? Payload { get; }

    /// <summary>
    /// EN: メッセージのヘッダーを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, string>? Headers { get; }
}

