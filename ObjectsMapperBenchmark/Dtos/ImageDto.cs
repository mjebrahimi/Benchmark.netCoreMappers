namespace ObjectsMapperBenchmark.Dtos;

public class ImageDto
{
    [JsonPropertyName("height")]
    public long Height { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("width")]
    public long Width { get; set; }
}
