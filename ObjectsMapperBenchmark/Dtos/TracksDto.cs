namespace ObjectsMapperBenchmark.Dtos;

public class TracksDto
{
    [JsonPropertyName("href")]
    public string Href { get; set; }

    [JsonPropertyName("items")]
    public ItemDto[] Items { get; set; }

    [JsonPropertyName("limit")]
    public long Limit { get; set; }

    [JsonPropertyName("next")]
    public object Next { get; set; }

    [JsonPropertyName("offset")]
    public long Offset { get; set; }

    [JsonPropertyName("previous")]
    public object Previous { get; set; }

    [JsonPropertyName("total")]
    public long Total { get; set; }
}
