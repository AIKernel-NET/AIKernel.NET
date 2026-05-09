namespace AIKernel.Abstractions.Events;

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// イベントを発行する capability interface です。
/// </summary>
public interface IEventPublisher
{
    /// <summary>
    /// イベントを発行します。
    /// </summary>
    /// <param name="eventName">イベント名</param>
    /// <param name="eventData">イベントデータ</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task PublishAsync(string eventName, object eventData, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// すべての購読者へイベントを配信する capability interface です。
/// </summary>
public interface IEventBroadcaster
{
    /// <summary>
    /// すべての購読者にイベントを配信します。
    /// </summary>
    /// <param name="eventName">イベント名</param>
    /// <param name="eventData">イベントデータ</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task BroadcastAsync(string eventName, object eventData, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// イベント購読を管理する capability interface です。
/// </summary>
public interface IEventSubscriptionRegistry
{
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
    /// 指定されたイベント名の購読者数を取得します。
    /// </summary>
    /// <param name="eventName">イベント名</param>
    /// <returns>購読者数</returns>
    int GetSubscriberCount(string eventName);
}

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// イベントバスプロバイダーを定義する互換合成インターフェースです。
/// アプリケーション全体のイベント配信と購読を管理します。
/// </summary>
public interface IEventBus :
    IProvider,
    IEventPublisher,
    IEventBroadcaster,
    IEventSubscriptionRegistry
{
}
