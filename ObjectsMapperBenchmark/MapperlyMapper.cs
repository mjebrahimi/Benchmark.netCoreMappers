using Riok.Mapperly.Abstractions;

namespace ObjectsMapperBenchmark;

[Mapper]
public static partial class MapperlyMapper
{
    public static partial SpotifyAlbum Map(SpotifyAlbumDto spotifyAlbumDto);
}