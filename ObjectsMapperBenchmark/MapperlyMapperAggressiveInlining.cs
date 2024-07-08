using ObjectsMapperBenchmark.Models;
using Riok.Mapperly.Abstractions;

namespace ObjectsMapperBenchmark
{
    [Mapper]
    public static partial class MapperlyMapperAggressiveInlining
    {
        public static partial ClassSpotifyAlbum MapToClass(SpotifyAlbumDto spotifyAlbumDto);

        public static partial StructSpotifyAlbum MapToStruct(SpotifyAlbumDto spotifyAlbumDto);
    }
}