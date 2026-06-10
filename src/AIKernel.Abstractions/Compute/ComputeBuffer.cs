namespace AIKernel.Abstractions.Compute;

/// <summary>
/// [EN] Compute buffer abstraction shared by OS compute providers.
/// [JA] OS compute Provider で共有する compute buffer 抽象です。
/// </summary>
public sealed class ComputeBuffer : IDisposable
{
    private readonly byte[] _storage;
    private bool _disposed;

    /// <summary>[EN] Initializes a compute buffer. [JA] compute buffer を初期化します。</summary>
    public ComputeBuffer(int size, object? nativeBuffer = null)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Buffer size must be non-negative.");
        }

        Size = size;
        NativeBuffer = nativeBuffer;
        _storage = new byte[size];
    }

    /// <summary>[EN] Buffer size in bytes. [JA] byte 単位の buffer size です。</summary>
    public int Size { get; }

    /// <summary>[EN] Optional native buffer handle. [JA] 任意の native buffer handle です。</summary>
    public object? NativeBuffer { get; }

    /// <summary>[EN] Returns whether this buffer has been disposed. [JA] buffer が dispose 済みかどうかを返します。</summary>
    public bool IsDisposed => _disposed;

    /// <summary>[EN] Writes data into this buffer. [JA] この buffer へ data を書き込みます。</summary>
    public void Write(ReadOnlyMemory<byte> data)
    {
        ThrowIfDisposed();
        if (data.Length > Size)
        {
            throw new ArgumentException("Data length exceeds buffer size.", nameof(data));
        }

        data.CopyTo(_storage);
    }

    /// <summary>[EN] Reads data from this buffer. [JA] この buffer から data を読み取ります。</summary>
    public void Read(Memory<byte> destination)
    {
        ThrowIfDisposed();
        if (destination.Length < Size)
        {
            throw new ArgumentException("Destination is smaller than buffer size.", nameof(destination));
        }

        _storage.CopyTo(destination);
    }

    /// <summary>[EN] Returns mutable storage memory for fallback providers. [JA] fallback Provider 向けの mutable storage memory を返します。</summary>
    public Memory<byte> AsMemory()
    {
        ThrowIfDisposed();
        return _storage;
    }

    /// <summary>[EN] Disposes the compute buffer. [JA] compute buffer を dispose します。</summary>
    public void Dispose()
    {
        _disposed = true;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(ComputeBuffer));
        }
    }
}
