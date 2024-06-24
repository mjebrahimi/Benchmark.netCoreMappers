namespace ObjectsMapperBenchmark.Dtos;

public class CopyrightDto
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
