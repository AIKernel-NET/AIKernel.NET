namespace AIKernel.Vfs;

/// <summary>EN: Identity and lifetime of an authenticated session. JA: 認証済みセッションの識別子と寿命を表します。</summary>
public interface IVfsSessionHandle : IAsyncDisposable
{
    /// <summary>EN: Identifies this open session. JA: 開いたセッションの識別子です。</summary>
    string SessionId { get; }
}
