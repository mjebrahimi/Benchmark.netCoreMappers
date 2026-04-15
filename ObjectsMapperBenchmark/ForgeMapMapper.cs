using ForgeMap;
using ObjectsMapperBenchmark.Models;

namespace ObjectsMapperBenchmark;

[ForgeMap]
public partial class ForgeMapMapper
{
    // Class mappings — auto-wired nested objects
    public partial ClassSpotifyAlbum MapToClass(SpotifyAlbumDto source);
    public partial ClassArtist Forge(ArtistDto source);
    public partial ClassCopyright Forge(CopyrightDto source);
    public partial ClassExternalIds Forge(ExternalIdsDto source);
    public partial ClassExternalUrls Forge(ExternalUrlsDto source);
    public partial ClassImage Forge(ImageDto source);
    public partial ClassTracks Forge(TracksDto source);
    public partial ClassItem Forge(ItemDto source);
    public partial ClassArtist[] Forge(ArtistDto[] source);
    public partial ClassCopyright[] Forge(CopyrightDto[] source);
    public partial ClassImage[] Forge(ImageDto[] source);
    public partial ClassItem[] Forge(ItemDto[] source);

    // Struct mappings — auto-wired nested objects
    public partial StructSpotifyAlbum MapToStruct(SpotifyAlbumDto source);
    public partial StructArtist ForgeStruct(ArtistDto source);
    public partial StructCopyright ForgeStruct(CopyrightDto source);
    public partial StructExternalIds ForgeStruct(ExternalIdsDto source);
    public partial StructExternalUrls ForgeStruct(ExternalUrlsDto source);
    public partial StructImage ForgeStruct(ImageDto source);
    public partial StructTracks ForgeStruct(TracksDto source);
    public partial StructItem ForgeStruct(ItemDto source);
    public partial StructArtist[] ForgeStruct(ArtistDto[] source);
    public partial StructCopyright[] ForgeStruct(CopyrightDto[] source);
    public partial StructImage[] ForgeStruct(ImageDto[] source);
    public partial StructItem[] ForgeStruct(ItemDto[] source);
}
