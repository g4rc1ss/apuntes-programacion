using System.Text;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PubSubRabbitMQ.Serialization;

internal class Serializer(JsonSerializerSettings serializerSettings) : ISerializer
{
    private static readonly Encoding Encoding = new UTF8Encoding(false);

    private static readonly JsonSerializerSettings DefaultSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto,
    };

    private const int DEFAULTBUFFERSIZE = 1024;

    private readonly Newtonsoft.Json.JsonSerializer _jsonSerializer =
        Newtonsoft.Json.JsonSerializer.Create(serializerSettings);

    public Serializer()
        : this(DefaultSerializerSettings) { }

    public T DeserializeObject<T>(string input)
    {
        return JsonSerializer.Deserialize<T>(input) ?? throw new InvalidOperationException();
    }

    public T DeserializeObject<T>(byte[] input)
        where T : class
    {
        return (DeserializeObject(input, typeof(T)) as T)!;
    }

    public object DeserializeObject(byte[] input, Type type)
    {
        using MemoryStream? memoryStream = new(input, false);
        using StreamReader? streamReader = new(
            memoryStream,
            Encoding,
            false,
            DEFAULTBUFFERSIZE,
            true
        );
        using JsonTextReader? reader = new(streamReader);
        return _jsonSerializer.Deserialize(reader, type) ?? throw new InvalidOperationException();
    }

    public string SerializeObject<T>(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public byte[] SerializeObjectToByteArray<T>(T obj)
    {
        using MemoryStream? memoryStream = new(DEFAULTBUFFERSIZE);
        using (StreamWriter? streamWriter = new(memoryStream, Encoding, DEFAULTBUFFERSIZE, true))
        using (JsonTextWriter? jsonWriter = new(streamWriter))
        {
            jsonWriter.Formatting = _jsonSerializer.Formatting;
            _jsonSerializer.Serialize(jsonWriter, obj, obj!.GetType());
        }

        return memoryStream.ToArray();
    }
}
