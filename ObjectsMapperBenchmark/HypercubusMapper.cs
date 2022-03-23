namespace ObjectsMapperBenchmark
{
    internal static class HypercubusMapper
    {
        public static Hypercubus.Mapping.Mapper Create()
        {
            Hypercubus.Mapping.Mapper mapper = new Hypercubus.Mapping.Mapper();

            mapper.Configure<SpotifyAlbumDto, SpotifyAlbum>((m, s) => {
                return new SpotifyAlbum()
                {
                    AlbumType = s.AlbumType,
                    Href = s.Href,
                    Id = s.Id,
                    Name = s.Name,
                    Popularity = s.Popularity,
                    ReleaseDate = s.ReleaseDate,
                    ReleaseDatePrecision = s.ReleaseDatePrecision,
                    Type = s.Type,
                    Uri = s.Uri,
                    AvailableMarkets = s.AvailableMarkets,
                    Genres = s.Genres,
                    Artists = m.Map<ArtistDto[], Artist[]>(s.Artists),
                    ExternalUrls = m.Map<ExternalUrlsDto, ExternalUrls>(s.ExternalUrls),
                    ExternalIds = m.Map<ExternalIdsDto, ExternalIds>(s.ExternalIds),
                    Copyrights = m.Map<CopyrightDto[], Copyright[]>(s.Copyrights),
                    Images = m.Map<ImageDto[], Image[]>(s.Images),
                    Tracks = m.Map<TracksDto, Tracks>(s.Tracks),
                };
            });
            mapper.Configure<CopyrightDto, Copyright>((m, s) =>
                new Copyright()
                {
                    Text = s.Text,
                    Type = s.Type
                }
                );
            mapper.Configure<ArtistDto, Artist>((m, s) =>
                new Artist()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Href = s.Href,
                    Type = s.Type,
                    Uri = s.Uri,
                    ExternalUrls = m.Map<ExternalUrlsDto, ExternalUrls>(s.ExternalUrls)
                }
                );
            mapper.Configure<ExternalIdsDto, ExternalIds>((m, s) =>
                new ExternalIds()
                {
                    Upc = s.Upc
                }
                );
            mapper.Configure<ExternalUrlsDto, ExternalUrls>((m, s) =>
                new ExternalUrls()
                {
                    Spotify = s.Spotify
                }
                );
            mapper.Configure<TracksDto, Tracks>((m, s) =>
                new Tracks()
                {
                    Href = s.Href,
                    Limit = s.Limit,
                    Next = s.Next,
                    Offset = s.Offset,
                    Previous = s.Previous,
                    Total = s.Total,
                    Items = m.Map<ItemDto[], Item[]>(s.Items)
                }
                );
            mapper.Configure<ImageDto, Image>((m, s) =>
                new Image()
                {
                    Height = s.Height,
                    Url = s.Url,
                    Width = s.Width
                }
                );
            mapper.Configure<ItemDto, Item>((m, s) =>
                new Item()
                {
                    DiscNumber = s.DiscNumber,
                    DurationMs = s.DurationMs,
                    Explicit = s.Explicit,
                    Href = s.Href,
                    Id = s.Id,
                    Name = s.Name,
                    PreviewUrl = s.PreviewUrl,
                    TrackNumber = s.TrackNumber,
                    Type = s.Type,
                    Uri = s.Uri,
                    AvailableMarkets = s.AvailableMarkets,
                    Artists = m.Map<ArtistDto[], Artist[]>(s.Artists),
                    ExternalUrls = m.Map<ExternalUrlsDto, ExternalUrls>(s.ExternalUrls)
                }
                );

            return mapper;
        }
    }
}
