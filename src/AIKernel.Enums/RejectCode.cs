namespace AIKernel.Enums;

/// <summary>
/// RejectCode の契約を定義します。
/// </summary>
public enum RejectCode
{
    AuthenticationFailed = 1,
    AuthorizationFailed = 2,
    ResourceNotFound = 3,
    PolicyViolation = 4,
    RateLimitExceeded = 5,
    ResourceUnavailable = 6,
    InsufficientPermissions = 7,
    SessionExpired = 8
}



