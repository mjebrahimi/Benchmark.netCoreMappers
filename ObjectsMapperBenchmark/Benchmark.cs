using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DeepEqual.Syntax;
using EmitMapper;
using Mapster;
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
public class Benchmark
{
    private SpotifyAlbumDto _spotifyAlbumDto;
    private IMapper _autoMapper;
    private ObjectsMapper<SpotifyAlbumDto, ClassSpotifyAlbum> _emitMapperClass;
    private ObjectsMapper<SpotifyAlbumDto, StructSpotifyAlbum> _emitMapperStruct;

    [GlobalSetup]
    public void Setup()
    {
        _spotifyAlbumDto = SpotifyAlbumDto.FromJson();

        #region AutoMapper Configuration
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SpotifyAlbumDto, ClassSpotifyAlbum>();
            cfg.CreateMap<CopyrightDto, ClassCopyright>();
            cfg.CreateMap<ArtistDto, ClassArtist>();
            cfg.CreateMap<ExternalIdsDto, ClassExternalIds>();
            cfg.CreateMap<ExternalUrlsDto, ClassExternalUrls>();
            cfg.CreateMap<TracksDto, ClassTracks>();
            cfg.CreateMap<ImageDto, ClassImage>();
            cfg.CreateMap<ItemDto, ClassItem>();

            cfg.CreateMap<SpotifyAlbumDto, StructSpotifyAlbum>();
            cfg.CreateMap<CopyrightDto, StructCopyright>();
            cfg.CreateMap<ArtistDto, StructArtist>();
            cfg.CreateMap<ExternalIdsDto, StructExternalIds>();
            cfg.CreateMap<ExternalUrlsDto, StructExternalUrls>();
            cfg.CreateMap<TracksDto, StructTracks>();
            cfg.CreateMap<ImageDto, StructImage>();
            cfg.CreateMap<ItemDto, StructItem>();
        });
        _autoMapper = mapperConfig.CreateMapper();
        #endregion

        #region TinyMapper Configuration
        Nelibur.ObjectMapper.TinyMapper.Bind<SpotifyAlbumDto, ClassSpotifyAlbum>();
        Nelibur.ObjectMapper.TinyMapper.Bind<CopyrightDto, ClassCopyright>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ArtistDto, ClassArtist>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalIdsDto, ClassExternalIds>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalUrlsDto, ClassExternalUrls>();
        Nelibur.ObjectMapper.TinyMapper.Bind<TracksDto, ClassTracks>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ImageDto, ClassImage>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ItemDto, ClassItem>();

        Nelibur.ObjectMapper.TinyMapper.Bind<SpotifyAlbumDto, StructSpotifyAlbum>();
        Nelibur.ObjectMapper.TinyMapper.Bind<CopyrightDto, StructCopyright>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ArtistDto, StructArtist>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalIdsDto, StructExternalIds>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalUrlsDto, StructExternalUrls>();
        Nelibur.ObjectMapper.TinyMapper.Bind<TracksDto, StructTracks>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ImageDto, StructImage>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ItemDto, StructItem>();
        #endregion

        #region ExpressMapper Configuration
        ExpressMapper.Mapper.Register<SpotifyAlbumDto, ClassSpotifyAlbum>();
        ExpressMapper.Mapper.Register<CopyrightDto, ClassCopyright>();
        ExpressMapper.Mapper.Register<ArtistDto, ClassArtist>();
        ExpressMapper.Mapper.Register<ExternalIdsDto, ClassExternalIds>();
        ExpressMapper.Mapper.Register<ExternalUrlsDto, ClassExternalUrls>();
        ExpressMapper.Mapper.Register<TracksDto, ClassTracks>();
        ExpressMapper.Mapper.Register<ImageDto, ClassImage>();
        ExpressMapper.Mapper.Register<ItemDto, ClassItem>();

        ExpressMapper.Mapper.Register<SpotifyAlbumDto, StructSpotifyAlbum>();
        ExpressMapper.Mapper.Register<CopyrightDto, StructCopyright>();
        ExpressMapper.Mapper.Register<ArtistDto, StructArtist>();
        ExpressMapper.Mapper.Register<ExternalIdsDto, StructExternalIds>();
        ExpressMapper.Mapper.Register<ExternalUrlsDto, StructExternalUrls>();
        ExpressMapper.Mapper.Register<TracksDto, StructTracks>();
        ExpressMapper.Mapper.Register<ImageDto, StructImage>();
        ExpressMapper.Mapper.Register<ItemDto, StructItem>();
        #endregion

        #region EmitMapper
        _emitMapperClass = ObjectMapperManager.DefaultInstance.GetMapper<SpotifyAlbumDto, ClassSpotifyAlbum>();

        _emitMapperStruct = ObjectMapperManager.DefaultInstance.GetMapper<SpotifyAlbumDto, StructSpotifyAlbum>();
        #endregion

        //Mapperly does not need configuration
        //Mapster does not need configuration
        //AgileMapper does not need configuration

        //Make sure all mappers are working correctly
        AutoMapper_Class().ShouldDeepEqual(_spotifyAlbumDto);
        Mapster_Class().ShouldDeepEqual(_spotifyAlbumDto);
        TinyMapper_Class().ShouldDeepEqual(_spotifyAlbumDto);
        AgileMapper_Class().ShouldDeepEqual(_spotifyAlbumDto);
        ExpressMapper_Class().ShouldDeepEqual(_spotifyAlbumDto);
        EmitMapper_Class().ShouldDeepEqual(_spotifyAlbumDto);
        ManualMapping_Class().ShouldDeepEqual(_spotifyAlbumDto);
        Mapperly_Class().ShouldDeepEqual(_spotifyAlbumDto);

        AutoMapper_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        Mapster_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        //TinyMapper_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        //AgileMapper_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        ExpressMapper_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        EmitMapper_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        ManualMapping_Struct().ShouldDeepEqual(_spotifyAlbumDto);
        Mapperly_Struct().ShouldDeepEqual(_spotifyAlbumDto);
    }

    #region Class
    [Benchmark(Description = "AutoMapper"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum AutoMapper_Class() => _autoMapper.Map<ClassSpotifyAlbum>(_spotifyAlbumDto);

    [Benchmark(Description = "Mapster"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum Mapster_Class() => _spotifyAlbumDto.Adapt<ClassSpotifyAlbum>();

    [Benchmark(Description = "TinyMapper"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum TinyMapper_Class() => Nelibur.ObjectMapper.TinyMapper.Map<ClassSpotifyAlbum>(_spotifyAlbumDto);

    [Benchmark(Description = "AgileMapper"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum AgileMapper_Class() => AgileObjects.AgileMapper.Mapper.Map(_spotifyAlbumDto).ToANew<ClassSpotifyAlbum>();

    [Benchmark(Description = "ExpressMapper"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum ExpressMapper_Class() => ExpressMapper.Mapper.Map<SpotifyAlbumDto, ClassSpotifyAlbum>(_spotifyAlbumDto);

    [Benchmark(Description = "EmitMapper"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum EmitMapper_Class() => _emitMapperClass.Map(_spotifyAlbumDto);

    [Benchmark(Description = "ManualMapping"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum ManualMapping_Class() => ManualMapper.MapToClass(_spotifyAlbumDto);

    [Benchmark(Description = "Mapperly"), BenchmarkCategory("Class")]
    public ClassSpotifyAlbum Mapperly_Class() => MapperlyMapperOld.MapToClass(_spotifyAlbumDto);
    #endregion

    #region Struct
    [Benchmark(Description = "AutoMapper"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum AutoMapper_Struct() => _autoMapper.Map<StructSpotifyAlbum>(_spotifyAlbumDto);

    [Benchmark(Description = "Mapster"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum Mapster_Struct() => _spotifyAlbumDto.Adapt<StructSpotifyAlbum>();

    //[Benchmark(Description = "TinyMapper"), BenchmarkCategory("Struct")] //========= Does not work, throws exception =========
    //public StructSpotifyAlbum TinyMapper_Struct() => Nelibur.ObjectMapper.TinyMapper.Map<StructSpotifyAlbum>(_spotifyAlbumDto);

    //[Benchmark(Description = "AgileMapper"), BenchmarkCategory("Struct")] //========= Does not work, throws exception =========
    //public StructSpotifyAlbum AgileMapper_Struct() => AgileObjects.AgileMapper.Mapper.Map(_spotifyAlbumDto).ToANew<StructSpotifyAlbum>();

    [Benchmark(Description = "ExpressMapper"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum ExpressMapper_Struct() => ExpressMapper.Mapper.Map<SpotifyAlbumDto, StructSpotifyAlbum>(_spotifyAlbumDto);

    [Benchmark(Description = "EmitMapper"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum EmitMapper_Struct() => _emitMapperStruct.Map(_spotifyAlbumDto);

    [Benchmark(Description = "ManualMapping"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum ManualMapping_Struct() => ManualMapper.MapToStruct(_spotifyAlbumDto);

    [Benchmark(Description = "Mapperly"), BenchmarkCategory("Struct")]
    public StructSpotifyAlbum Mapperly_Struct() => MapperlyMapperOld.MapToStruct(_spotifyAlbumDto);
    #endregion
}