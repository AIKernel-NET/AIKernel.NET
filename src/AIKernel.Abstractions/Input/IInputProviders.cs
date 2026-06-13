using AIKernel.Dtos.Input;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Input;

/// <summary>
/// Sends governed keyboard input packets.
/// </summary>
public interface IKeyboardInputProvider : IProviderExtended
{
    /// <summary>
    /// Sends keyboard input.
    /// </summary>
    /// <param name="packet">The keyboard input packet.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> SendKeyboardAsync(
        KeyboardInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Sends governed pointer input packets.
/// </summary>
public interface IPointerInputProvider : IProviderExtended
{
    /// <summary>
    /// Sends pointer input.
    /// </summary>
    /// <param name="packet">The pointer input packet.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> SendPointerAsync(
        PointerInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Sends governed gamepad input packets.
/// </summary>
public interface IGamepadInputProvider : IProviderExtended
{
    /// <summary>
    /// Sends gamepad input.
    /// </summary>
    /// <param name="packet">The gamepad input packet.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> SendGamepadAsync(
        GamepadInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Sends governed virtual input packets.
/// </summary>
public interface IVirtualInputProvider :
    IKeyboardInputProvider,
    IPointerInputProvider,
    IGamepadInputProvider
{
    /// <summary>
    /// Sends virtual input.
    /// </summary>
    /// <param name="packet">The virtual input packet.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> SendAsync(
        VirtualInputPacket packet,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Extends virtual input with decomposed input operations.
/// </summary>
public interface IInputProviderExtended : IVirtualInputProvider
{
    /// <summary>
    /// Sends key presses.
    /// </summary>
    /// <param name="request">The send-keys request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> SendKeysAsync(
        SendKeysRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Types text.
    /// </summary>
    /// <param name="request">The type-text request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> TypeTextAsync(
        TypeTextRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Moves a pointer.
    /// </summary>
    /// <param name="request">The pointer move request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> MoveAsync(
        PointerMoveRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Clicks a pointer button.
    /// </summary>
    /// <param name="request">The pointer click request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> ClickAsync(
        PointerClickRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Drags a pointer.
    /// </summary>
    /// <param name="request">The pointer drag request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> DragAsync(
        PointerDragRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Sends virtual input state.
    /// </summary>
    /// <param name="request">The input state request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The input result.</returns>
    ValueTask<VirtualInputResult> SendStateAsync(
        InputStateRequest request,
        CancellationToken cancellationToken);
}
