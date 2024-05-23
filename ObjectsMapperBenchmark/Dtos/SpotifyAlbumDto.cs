namespace ObjectsMapperBenchmark.Dtos;

public partial class SpotifyAlbumDto
{
    [JsonPropertyName("album_type")]
    public string AlbumType { get; set; }

    [JsonPropertyName("artists")]
    public ArtistDto[] Artists { get; set; }

    [JsonPropertyName("available_markets")]
    public string[] AvailableMarkets { get; set; }

    [JsonPropertyName("copyrights")]
    public CopyrightDto[] Copyrights { get; set; }

    [JsonPropertyName("external_ids")]
    public ExternalIdsDto ExternalIds { get; set; }

    [JsonPropertyName("external_urls")]
    public ExternalUrlsDto ExternalUrls { get; set; }

    [JsonPropertyName("genres")]
    public object[] Genres { get; set; }

    [JsonPropertyName("href")]
    public string Href { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("images")]
    public ImageDto[] Images { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("popularity")]
    public long Popularity { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }

    [JsonPropertyName("release_date_precision")]
    public string ReleaseDatePrecision { get; set; }

    [JsonPropertyName("tracks")]
    public TracksDto Tracks { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }
}

public partial class SpotifyAlbumDto
{
    public static SpotifyAlbumDto FromJson(string json)
    {
        return JsonSerializer.Deserialize<SpotifyAlbumDto>(json);
    }
}
