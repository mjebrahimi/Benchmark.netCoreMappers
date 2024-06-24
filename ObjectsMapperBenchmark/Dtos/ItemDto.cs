namespace ObjectsMapperBenchmark.Dtos;

public class ItemDto
{
    [JsonPropertyName("artists")]
    public ArtistDto[] Artists { get; set; }

    [JsonPropertyName("available_markets")]
    public string[] AvailableMarkets { get; set; }

    [JsonPropertyName("disc_number")]
    public long DiscNumber { get; set; }

    [JsonPropertyName("duration_ms")]
    public long DurationMs { get; set; }

    [JsonPropertyName("explicit")]
    public bool Explicit { get; set; }

    [JsonPropertyName("external_urls")]
    public ExternalUrlsDto ExternalUrls { get; set; }

    [JsonPropertyName("href")]
    public string Href { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("preview_url")]
    public string PreviewUrl { get; set; }

    [JsonPropertyName("track_number")]
    public long TrackNumber { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }
}
