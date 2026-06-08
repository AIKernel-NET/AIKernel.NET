namespace AIKernel.Contracts;

/// <summary>
/// メッセージ契約を定義します。
/// カーネル内通信のメッセージ形式を標準化します。
/// UC-25（Event Bus 配信）
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMessageContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMessageContract']" />
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

