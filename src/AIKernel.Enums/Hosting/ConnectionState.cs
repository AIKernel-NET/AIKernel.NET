namespace AIKernel.Dtos.Hosting;

/// <summary>[EN] Last observed connection state. [JA] 接続監視で最後に確認した状態です。</summary>
public enum ConnectionState { Unchecked, Connecting, Online, Unavailable, Unauthorized, IdentityMismatch }
