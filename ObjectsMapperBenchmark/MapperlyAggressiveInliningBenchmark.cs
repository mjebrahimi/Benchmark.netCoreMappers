using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DeepEqual.Syntax;
using ObjectsMapperBenchmark.Models;

namespace ObjectsMapperBenchmark;

#if RELEASE
[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
//[ShortRunJob]
#endif
[CategoriesColumn]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
public class MapperlyAggressiveInliningBenchmark
{
    private SpotifyAlbumDto _spotifyAlbumDto;

    [GlobalSetup]
    public void Setup()
    {
        _spotifyAlbumDto = SpotifyAlbumDto.FromJson();

        ManualMapping_Class().ShouldDeepEqual(_spotifyAlbumDto);
        Mapperly_Class().ShouldDeepEqual(_spotifyAlbumDto);
        MapperlyAggressiveInlining_Class().ShouldDeepEqual(_spotifyAlbumDto);

        ManualMapping_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        Mapperly_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        MapperlyAggressiveInlining_Struct().ShouldDeepEqual(_spotifyAlbumDto);
    }

    #region Class

    [Benchmark(Description = "ManualMapping"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum ManualMapping_Class() => ManualMapper.MapToClass(_spotifyAlbumDto);

    [Benchmark(Description = "Mapperly"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum Mapperly_Class() => MapperlyMapperOld.MapToClass(_spotifyAlbumDto);

    [Benchmark(Description = "MapperlyAggressiveInlining"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum MapperlyAggressiveInlining_Class() => MapperlyMapperAggressiveInlining.MapToClass(_spotifyAlbumDto);
    #endregion

    #region Struct

    [Benchmark(Description = "ManualMapping"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum ManualMapping_Struct() => ManualMapper.MapToStruct(_spotifyAlbumDto);

    [Benchmark(Description = "Mapperly"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum Mapperly_Struct() => MapperlyMapperOld.MapToStruct(_spotifyAlbumDto);

    [Benchmark(Description = "MapperlyAggressiveInlining"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum MapperlyAggressiveInlining_Struct() => MapperlyMapperAggressiveInlining.MapToStruct(_spotifyAlbumDto);
    #endregion
}