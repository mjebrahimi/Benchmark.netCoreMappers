namespace ObjectsMapperBenchmark.Models;

public class ClassSpotifyAlbum
{
    public string AlbumType { get; set; }
    public ClassArtist[] Artists { get; set; }
    public string[] AvailableMarkets { get; set; }
    public ClassCopyright[] Copyrights { get; set; }
    public ClassExternalIds ExternalIds { get; set; }
    public ClassExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public ClassImage[] Images { get; set; }
    public string Name { get; set; }
    public long Popularity { get; set; }
    public string ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public ClassTracks Tracks { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public class ClassTracks
{
    public string Href { get; set; }
    public ClassItem[] Items { get; set; }
    public long Limit { get; set; }
    public long Offset { get; set; }
    public long Total { get; set; }
}

public class ClassItem
{
    public ClassArtist[] Artists { get; set; }
    public string[] AvailableMarkets { get; set; }
    public long DiscNumber { get; set; }
    public long DurationMs { get; set; }
    public bool Explicit { get; set; }
    public ClassExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string PreviewUrl { get; set; }
    public long TrackNumber { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public class ClassImage
{
    public long Height { get; set; }
    public string Url { get; set; }
    public long Width { get; set; }
}

public class ClassExternalIds
{
    public string Upc { get; set; }
}

public class ClassCopyright
{
    public string Text { get; set; }
    public string Type { get; set; }
}

public class ClassArtist
{
    public ClassExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public class ClassExternalUrls
{
    public string Spotify { get; set; }
}