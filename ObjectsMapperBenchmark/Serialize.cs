namespace ObjectsMapperBenchmark;

public static class Serialize
{
    public static string ToJson(this SpotifyAlbumDto self)
    {
        return JsonSerializer.Serialize(self);
    }
}