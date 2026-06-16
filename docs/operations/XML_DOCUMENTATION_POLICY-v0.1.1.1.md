# XML Documentation Policy for v0.1.1.1

AIKernel.NET public APIs must provide bilingual XML documentation.

This policy applies to public interfaces, DTO records, enum types, enum values,
public DTO properties, and public test skeleton members that intentionally
document the contract surface.

---

## Required Format

Inline XML documentation should include English and Japanese text in the same
XML element. The preferred compact form uses explicit `EN:` and `JA:` markers.

```csharp
/// <summary>
/// EN: Describes a runtime status snapshot. JA: runtime status snapshot を記述します。
/// </summary>
public sealed record RuntimeStatusSnapshot
{
    /// <summary>EN: Gets the runtime identifier. JA: runtime identifier を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;
}
```

For method documentation, `param`, `typeparam`, and `returns` elements must also
include Japanese text.

```csharp
/// <summary>
/// EN: Executes a runtime control operation. JA: runtime control 操作を実行します。
/// </summary>
/// <param name="request">EN: The request. JA: request パラメーターです。</param>
/// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
/// <returns>EN: The control result. JA: 結果を返します。</returns>
ValueTask<RuntimeControlResult> ControlAsync(
    RuntimeControlRequest request,
    CancellationToken cancellationToken);
```

---

## External Include Format

Existing contract surfaces can use external XML documentation when both English
and Japanese include files are present.

```csharp
/// <include file="docs.en.xml" path="doc/members/member[@name='T:Example.Type']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:Example.Type']" />
public interface IExample
{
}
```

Using only one language include file is not compliant.

---

## Review Checklist

- Every public type has a bilingual `summary` or paired English/Japanese
  external include.
- Every public member has a bilingual `summary` or paired external include.
- Every public method parameter has bilingual `param` documentation.
- Every public generic parameter has bilingual `typeparam` documentation.
- Every public method return value has bilingual `returns` documentation.
- XML documentation describes the contract surface and does not describe
  implementation logic.

---

## Verification

The repository can be checked with a documentation scan that verifies public
declarations have bilingual XML documentation or paired `docs.en.xml` /
`docs.ja.xml` includes. The normal build and test surface must also pass:

```powershell
py tools\check_bilingual_xml_docs.py src
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
```

For cross-repository validation from the shared workspace root:

```powershell
py AIKernel.NET\tools\check_bilingual_xml_docs.py `
  AIKernel.NET\src AIKernel.Core\src AIKernel.Control\src `
  AIKernel.Providers\src AIKernel.Wasm\src AIKernel.Cuda13.0\src `
  AIKernel.Tools\src AIKernel.Demo\src AIKernel.Doom\src
```
