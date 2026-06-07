namespace AIKernel.Abstractions.Time;

using AIKernel.Dtos.Time;

/// <summary>
/// Provides deterministic time to Kernel, DSL, ROM, and replay components.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Time.IKernelClock']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Time.IKernelClock']" />
public interface IKernelClock
{
    /// <summary>Executes the GetCurrentTimestamp operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetCurrentTimestamp 操作を実行します。</summary>
    KernelTimestamp GetCurrentTimestamp();
}
