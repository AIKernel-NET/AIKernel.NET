using System.Text.Json;
using System.Text.Json.Serialization;
using AIKernel.Dtos.Providers;
using PlacementKind = AIKernel.Dtos.Providers.ProviderKind;

namespace AIKernel.Abstractions.Tests;

public sealed class PlacementEnumTests
{
    [Fact]
    public void PlacementNamesAndNumbersRoundTrip()
    {
        Check<PlacementKind>(["Embedding", "Reranker", "SpeechRecognition", "Classification", "Scoring", "ChatGeneration"]);
        Check<ExecutionTarget>(["Cpu", "Cuda", "Vulkan"]);
    }

    private static void Check<T>(string[] names) where T : struct, Enum
    {
        var byName = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter<T>() } };
        for (var i = 0; i < names.Length; i++)
        {
            var value = Enum.Parse<T>(names[i]);
            var number = i.ToString(System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(number, JsonSerializer.Serialize(value));
            Assert.Equal(value, JsonSerializer.Deserialize<T>(number));
            var name = JsonSerializer.Serialize(names[i]);
            Assert.Equal(name, JsonSerializer.Serialize(value, byName));
            Assert.Equal(value, JsonSerializer.Deserialize<T>(name, byName));
        }
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<T>("\"FutureBackend\"", byName));
    }
}
