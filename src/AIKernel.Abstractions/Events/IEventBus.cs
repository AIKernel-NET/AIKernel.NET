namespace AIKernel.Abstractions.Events;

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// EN: イベントを発行する capability interface です。
/// EN: Documentation for public API. JA: IEventPublisher の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventPublisher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventPublisher']" />
public interface IEventPublisher
{
    /// <summary>
    /// EN: イベントを発行します。
    /// EN: Documentation for public API. JA: PublishAsync 操作を実行します。
    /// </summary>
    /// <param name="eventName">EN: Documentation for public API. JA: イベント名 eventName パラメーターです。</param>
    /// <param name="eventData">EN: Documentation for public API. JA: イベントデータ eventData パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task PublishAsync(string eventName, object eventData, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// EN: すべての購読者へイベントを配信する capability interface です。
/// EN: Documentation for public API. JA: IEventBroadcaster の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventBroadcaster']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventBroadcaster']" />
public interface IEventBroadcaster
{
    /// <summary>
    /// EN: すべての購読者にイベントを配信します。
    /// EN: Documentation for public API. JA: BroadcastAsync 操作を実行します。
    /// </summary>
    /// <param name="eventName">EN: Documentation for public API. JA: イベント名 eventName パラメーターです。</param>
    /// <param name="eventData">EN: Documentation for public API. JA: イベントデータ eventData パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task BroadcastAsync(string eventName, object eventData, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// EN: イベント購読を管理する capability interface です。
/// EN: Documentation for public API. JA: IEventSubscriptionRegistry の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventSubscriptionRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventSubscriptionRegistry']" />
public interface IEventSubscriptionRegistry
{
    /// <summary>
    /// EN: イベントに購読します。
    /// EN: Documentation for public API. JA: Unsubscribe 操作を実行します。
    /// </summary>
    /// <typeparam name="T">EN: Documentation for public API. JA: イベントデータの型 T 型パラメーターです。</typeparam>
    /// <param name="eventName">EN: Documentation for public API. JA: イベント名 eventName パラメーターです。</param>
    /// <param name="handler">EN: Documentation for public API. JA: イベントハンドラー handler パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 購読ID（購読解除時に使用） 結果を返します。</returns>
    string Subscribe<T>(string eventName, Func<T, Task> handler);

    /// <summary>
    /// EN: イベント購読を解除します。
    /// EN: Documentation for public API. JA: Unsubscribe 操作を実行します。
    /// </summary>
    /// <param name="subscriptionId">EN: Documentation for public API. JA: 購読ID subscriptionId パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 解除成功の可否 結果を返します。</returns>
    bool Unsubscribe(string subscriptionId);

    /// <summary>
    /// EN: 指定されたイベント名の購読者数を取得します。
    /// EN: Documentation for public API. JA: GetSubscriberCount 操作を実行します。
    /// </summary>
    /// <param name="eventName">EN: Documentation for public API. JA: イベント名 eventName パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 購読者数 結果を返します。</returns>
    int GetSubscriberCount(string eventName);
}

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// イベントバスプロバイダーを定義する互換合成インターフェースです。
/// EN: アプリケーション全体のイベント配信と購読を管理します。
/// EN: Documentation for public API. JA: IEventBus の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventBus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IEventBus']" />
public interface IEventBus :
    IProvider,
    IEventPublisher,
    IEventBroadcaster,
    IEventSubscriptionRegistry
{
}
