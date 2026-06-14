namespace AIKernel.Dtos.Sandbox;

/// <summary>
/// SandboxExecutionResult の契約を定義します。
/// JA: SandboxExecutionResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Sandbox.SandboxExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Sandbox.SandboxExecutionResult']" />
public sealed class SandboxExecutionResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.Success']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.Success']" />
    public required bool Success { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.Result']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.Result']" />
    public string? Result { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.ErrorMessage']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.ErrorMessage']" />
    public string? ErrorMessage { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.ExecutionTimeMs']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.ExecutionTimeMs']" />
    public long ExecutionTimeMs { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.StdOut']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.StdOut']" />
    public string? StdOut { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.StdErr']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Sandbox.SandboxExecutionResult.StdErr']" />
    public string? StdErr { get; init; }
}




