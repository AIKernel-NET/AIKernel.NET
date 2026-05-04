namespace AIKernel.Abstractions;

/// <summary>
/// イベントバスプロバイダーを定義します。
/// アプリケーション全体のイベント配信と購読を管理します。
/// </summary>
public interface IEventBus : IProvider
{
    /// <summary>
    /// イベントを発行します。
    /// </summary>
    /// <param name="eventName">イベント名</param>
    /// <param name="eventData">イベントデータ</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task PublishAsync(string eventName, object eventData, CancellationToken cancellationToken = default);

    /// <summary>
    /// イベントに購読します。
    /// </summary>
    /// <typeparam name="T">イベントデータの型</typeparam>
    /// <param name="eventName">イベント名</param>
    /// <param name="handler">イベントハンドラー</param>
    /// <returns>購読ID（購読解除時に使用）</returns>
    string Subscribe<T>(string eventName, Func<T, Task> handler);

    /// <summary>
    /// イベント購読を解除します。
    /// </summary>
    /// <param name="subscriptionId">購読ID</param>
    /// <returns>解除成功の可否</returns>
    bool Unsubscribe(string subscriptionId);

    /// <summary>
    /// すべての購読者にイベントを配信します。
    /// </summary>
    /// <param name="eventName">イベント名</param>
    /// <param name="eventData">イベントデータ</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task BroadcastAsync(string eventName, object eventData, CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定されたイベント名の購読者数を取得します。
    /// </summary>
    /// <param name="eventName">イベント名</param>
    /// <returns>購読者数</returns>
    int GetSubscriberCount(string eventName);
}

/// <summary>
/// イベントバスで配信されるイベント情報を定義します。
/// </summary>
public class EventBusMessage
{
    /// <summary>
    /// イベントの一意識別子を取得または設定します。
    /// </summary>
    public required string EventId { get; set; }

    /// <summary>
    /// イベント名を取得または設定します。
    /// </summary>
    public required string EventName { get; set; }

    /// <summary>
    /// イベントが発生した時刻を取得または設定します。
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// イベントデータを取得または設定します。
    /// </summary>
    public required object Data { get; set; }

    /// <summary>
    /// イベントソースを取得または設定します。
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// イベントの優先度を取得または設定します。
    /// </summary>
    public EventPriority Priority { get; set; } = EventPriority.Normal;
}

/// <summary>
/// イベント優先度を定義します。
/// </summary>
public enum EventPriority
{
    /// <summary>低優先度</summary>
    Low = 0,

    /// <summary>通常優先度</summary>
    Normal = 1,

    /// <summary>高優先度</summary>
    High = 2,

    /// <summary>緊急</summary>
    Critical = 3
}
