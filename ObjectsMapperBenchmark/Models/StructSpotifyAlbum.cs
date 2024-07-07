namespace ObjectsMapperBenchmark.Models;

public struct StructSpotifyAlbum
{
    public string AlbumType { get; set; }
    public StructArtist[] Artists { get; set; }
    public string[] AvailableMarkets { get; set; }
    public StructCopyright[] Copyrights { get; set; }
    public StructExternalIds ExternalIds { get; set; }
    public StructExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public StructImage[] Images { get; set; }
    public string Name { get; set; }
    public long Popularity { get; set; }
    public string ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public StructTracks Tracks { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public struct StructTracks
{
    public string Href { get; set; }
    public StructItem[] Items { get; set; }
    public long Limit { get; set; }
    public long Offset { get; set; }
    public long Total { get; set; }
}

public struct StructItem
{
    public StructArtist[] Artists { get; set; }
    public string[] AvailableMarkets { get; set; }
    public long DiscNumber { get; set; }
    public long DurationMs { get; set; }
    public bool Explicit { get; set; }
    public StructExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string PreviewUrl { get; set; }
    public long TrackNumber { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public struct StructImage
{
    public long Height { get; set; }
    public string Url { get; set; }
    public long Width { get; set; }
}

public struct StructExternalIds
{
    public string Upc { get; set; }
}

public struct StructCopyright
{
    public string Text { get; set; }
    public string Type { get; set; }
}

public struct StructArtist
{
    public StructExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public struct StructExternalUrls
{
    public string Spotify { get; set; }
}