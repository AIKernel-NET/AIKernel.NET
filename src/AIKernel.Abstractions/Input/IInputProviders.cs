using AIKernel.Dtos.Input;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Input;

/// <summary>
/// Sends governed keyboard input packets.
/// JA: IKeyboardInputProvider の公開契約を定義します。
/// </summary>
public interface IKeyboardInputProvider : IKernelProvider
{
    /// <summary>
    /// Sends keyboard input.
    /// JA: SendKeyboardAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">The keyboard input packet. JA: packet パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendKeyboardAsync(
        KeyboardInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Sends governed pointer input packets.
/// JA: IPointerInputProvider の公開契約を定義します。
/// </summary>
public interface IPointerInputProvider : IKernelProvider
{
    /// <summary>
    /// Sends pointer input.
    /// JA: SendPointerAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">The pointer input packet. JA: packet パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendPointerAsync(
        PointerInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Sends governed gamepad input packets.
/// JA: IGamepadInputProvider の公開契約を定義します。
/// </summary>
public interface IGamepadInputProvider : IKernelProvider
{
    /// <summary>
    /// Sends gamepad input.
    /// JA: SendGamepadAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">The gamepad input packet. JA: packet パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendGamepadAsync(
        GamepadInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Sends governed virtual input packets.
/// JA: IVirtualInputProvider の公開契約を定義します。
/// </summary>
public interface IVirtualInputProvider :
    IKeyboardInputProvider,
    IPointerInputProvider,
    IGamepadInputProvider
{
    /// <summary>
    /// Sends virtual input.
    /// JA: SendAsync 操作を実行します。
    /// </summary>
    /// <param name="packet">The virtual input packet. JA: packet パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendAsync(
        VirtualInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides decomposed input operations on top of virtual input packets.
/// JA: IDecomposedInputProvider の公開契約を定義します。
/// </summary>
public interface IDecomposedInputProvider : IVirtualInputProvider
{
    /// <summary>
    /// Sends key presses.
    /// JA: SendKeysAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The send-keys request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendKeysAsync(
        SendKeysRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Types text.
    /// JA: TypeTextAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The type-text request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> TypeTextAsync(
        TypeTextRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Moves a pointer.
    /// JA: MoveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The pointer move request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> MoveAsync(
        PointerMoveRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Clicks a pointer button.
    /// JA: ClickAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The pointer click request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> ClickAsync(
        PointerClickRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Drags a pointer.
    /// JA: DragAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The pointer drag request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> DragAsync(
        PointerDragRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Sends virtual input state.
    /// JA: SendStateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The input state request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The input result. JA: 結果を返します。</returns>
    ValueTask<VirtualInputResult> SendStateAsync(
        InputStateRequest request,
        CancellationToken cancellationToken);
}
