using System;
using System.Threading.Tasks;

//
// 1. Result<T> monad
//
public readonly struct Result<T>
{
    public T? Value { get; }
    public string? Error { get; }
    public bool IsSuccess => Error == null;

    private Result(T? value, string? error)
    {
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value) => new(value, null);
    public static Result<T> Failure(string error) => new(default, error);

    public override string ToString() =>
        IsSuccess ? $"Success({Value})" : $"Failure({Error})";
}

//
// 2. LINQ extensions for Task<Result<T>>
//
public static class TaskResultExtensions
{
    // Map
    public static async Task<Result<U>> Select<T, U>(
        this Task<Result<T>> source,
        Func<T, U> selector)
    {
        var s = await source.ConfigureAwait(false);
        if (!s.IsSuccess)
            return Result<U>.Failure(s.Error!);

        return Result<U>.Success(selector(s.Value!));
    }

    // Bind
    public static async Task<Result<U>> SelectMany<T, C, U>(
        this Task<Result<T>> source,
        Func<T, Task<Result<C>>> collectionSelector,
        Func<T, C, U> resultSelector)
    {
        var s = await source.ConfigureAwait(false);
        if (!s.IsSuccess)
            return Result<U>.Failure(s.Error!);

        var c = await collectionSelector(s.Value!).ConfigureAwait(false);
        if (!c.IsSuccess)
            return Result<U>.Failure(c.Error!);

        return Result<U>.Success(resultSelector(s.Value!, c.Value!));
    }
}

//
// 3. Demo functions for an AI-like pipeline
//
public static class AiPipelineDemo
{
    public static Task<Result<string>> BuildPromptAsync(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Task.FromResult(Result<string>.Failure("Input was empty"));

        return Task.FromResult(Result<string>.Success($"Q: {input}"));
    }

    public static async Task<Result<string>> CallLLMAsync(string prompt)
    {
        await Task.Delay(100);

        if (prompt.Contains("error", StringComparison.OrdinalIgnoreCase))
            return Result<string>.Failure("LLM refused the request");

        return Result<string>.Success($"AI Response to '{prompt}'");
    }

    public static Task<Result<string>> ParseOutputAsync(string raw)
    {
        if (!raw.StartsWith("AI Response"))
            return Task.FromResult(Result<string>.Failure("Unexpected format"));

        return Task.FromResult(Result<string>.Success($"[Parsed] {raw}"));
    }

    public static Task<Result<string>> ExecuteAsync(string input)
    {
        return
            from prompt in BuildPromptAsync(input)
            from raw in CallLLMAsync(prompt)
            from parsed in ParseOutputAsync(raw)
            select parsed;
    }
}

public class Program
{
    public static async Task Main()
    {
        var ok = await AiPipelineDemo.ExecuteAsync("Hello AI");
        Console.WriteLine(ok);

        var fail = await AiPipelineDemo.ExecuteAsync("error please");
        Console.WriteLine(fail);
    }
}
