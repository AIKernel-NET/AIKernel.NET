namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IServiceRegistrar の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IServiceRegistrar']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IServiceRegistrar']" />
public interface IServiceRegistrar
{
    /// <summary>Executes the AddSingleton&lt;TService, TImplementation&gt; operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AddSingleton&lt;TService, TImplementation&gt; 操作を実行します。</summary>
    void AddSingleton<TService, TImplementation>() where TImplementation : class, TService where TService : class;
    /// <summary>Executes the AddScoped&lt;TService, TImplementation&gt; operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AddScoped&lt;TService, TImplementation&gt; 操作を実行します。</summary>
    void AddScoped<TService, TImplementation>() where TImplementation : class, TService where TService : class;
    /// <summary>Executes the AddTransient&lt;TService, TImplementation&gt; operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AddTransient&lt;TService, TImplementation&gt; 操作を実行します。</summary>
    void AddTransient<TService, TImplementation>() where TImplementation : class, TService where TService : class;
}



