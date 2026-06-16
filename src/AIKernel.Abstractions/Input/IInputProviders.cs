using AIKernel.Dtos.Input;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Input;

/// <summary>
/// EN: Sends governed keyboard input packets.
/// EN: Documentation for public API. JA: IKeyboardInputProvider の公開契約を定義します。
/// </summary>
public interface IKeyboardInputProvider : IKernelProvider
{
    /// <summary>
    /// EN: Sends keyboard input.
    /// EN: Documentation for public API. JA: SendKeyboardAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">EN: The keyboard input packet. JA: packet パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendKeyboardAsync(
        KeyboardInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Sends governed pointer input packets.
/// EN: Documentation for public API. JA: IPointerInputProvider の公開契約を定義します。
/// </summary>
public interface IPointerInputProvider : IKernelProvider
{
    /// <summary>
    /// EN: Sends pointer input.
    /// EN: Documentation for public API. JA: SendPointerAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">EN: The pointer input packet. JA: packet パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendPointerAsync(
        PointerInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Sends governed gamepad input packets.
/// EN: Documentation for public API. JA: IGamepadInputProvider の公開契約を定義します。
/// </summary>
public interface IGamepadInputProvider : IKernelProvider
{
    /// <summary>
    /// EN: Sends gamepad input.
    /// EN: Documentation for public API. JA: SendGamepadAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">EN: The gamepad input packet. JA: packet パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendGamepadAsync(
        GamepadInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Sends governed virtual input packets.
/// EN: Documentation for public API. JA: IVirtualInputProvider の公開契約を定義します。
/// </summary>
public interface IVirtualInputProvider :
    IKeyboardInputProvider,
    IPointerInputProvider,
    IGamepadInputProvider
{
    /// <summary>
    /// EN: Sends virtual input.
    /// EN: Documentation for public API. JA: SendAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">EN: The virtual input packet. JA: packet パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendAsync(
        VirtualInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Provides decomposed input operations on top of virtual input packets.
/// EN: Documentation for public API. JA: IDecomposedInputProvider の公開契約を定義します。
/// </summary>
public interface IDecomposedInputProvider : IVirtualInputProvider
{
    /// <summary>
    /// EN: Sends key presses.
    /// EN: Documentation for public API. JA: SendKeysAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The send-keys request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendKeysAsync(
        SendKeysRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Types text.
    /// EN: Documentation for public API. JA: TypeTextAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The type-text request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> TypeTextAsync(
        TypeTextRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Moves a pointer.
    /// EN: Documentation for public API. JA: MoveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The pointer move request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> MoveAsync(
        PointerMoveRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Clicks a pointer button.
    /// EN: Documentation for public API. JA: ClickAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The pointer click request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> ClickAsync(
        PointerClickRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Drags a pointer.
    /// EN: Documentation for public API. JA: DragAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The pointer drag request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> DragAsync(
        PointerDragRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Sends virtual input state.
    /// EN: Documentation for public API. JA: SendStateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The input state request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendStateAsync(
        InputStateRequest request,
        CancellationToken cancellationToken);
}
