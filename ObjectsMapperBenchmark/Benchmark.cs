using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using EmitMapper;
using Mapster;
using System.IO;

namespace ObjectsMapperBenchmark;

#if RELEASE
[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
#endif
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class Benchmark
{
    private SpotifyAlbumDto _spotifyAlbumDto;
    private IMapper _autoMapper;
    private ObjectsMapper<SpotifyAlbumDto, SpotifyAlbum> _emitMapper;

    [GlobalSetup]
    public void Setup()
    {
        var json = File.ReadAllText("spotifyAlbum.json");
        _spotifyAlbumDto = SpotifyAlbumDto.FromJson(json);

        #region AutoMapper Configuration
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SpotifyAlbumDto, SpotifyAlbum>();
            cfg.CreateMap<CopyrightDto, Copyright>();
            cfg.CreateMap<ArtistDto, Artist>();
            cfg.CreateMap<ExternalIdsDto, ExternalIds>();
            cfg.CreateMap<ExternalUrlsDto, ExternalUrls>();
            cfg.CreateMap<TracksDto, Tracks>();
            cfg.CreateMap<ImageDto, Image>();
            cfg.CreateMap<ItemDto, Item>();
            cfg.CreateMap<SpotifyAlbum, SpotifyAlbumDto>();
            cfg.CreateMap<Copyright, CopyrightDto>();
            cfg.CreateMap<Artist, ArtistDto>();
            cfg.CreateMap<ExternalIds, ExternalIdsDto>();
            cfg.CreateMap<ExternalUrls, ExternalUrlsDto>();
            cfg.CreateMap<Tracks, TracksDto>();
            cfg.CreateMap<Image, ImageDto>();
            cfg.CreateMap<Item, ItemDto>();
        });
        _autoMapper = mapperConfig.CreateMapper();
        #endregion

        #region TinyMapper Configuration
        Nelibur.ObjectMapper.TinyMapper.Bind<SpotifyAlbumDto, SpotifyAlbum>();
        Nelibur.ObjectMapper.TinyMapper.Bind<CopyrightDto, Copyright>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ArtistDto, Artist>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalIdsDto, ExternalIds>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalUrlsDto, ExternalUrls>();
        Nelibur.ObjectMapper.TinyMapper.Bind<TracksDto, Tracks>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ImageDto, Image>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ItemDto, Item>();
        Nelibur.ObjectMapper.TinyMapper.Bind<SpotifyAlbum, SpotifyAlbumDto>();
        Nelibur.ObjectMapper.TinyMapper.Bind<Copyright, CopyrightDto>();
        Nelibur.ObjectMapper.TinyMapper.Bind<Artist, ArtistDto>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalIds, ExternalIdsDto>();
        Nelibur.ObjectMapper.TinyMapper.Bind<ExternalUrls, ExternalUrlsDto>();
        Nelibur.ObjectMapper.TinyMapper.Bind<Tracks, TracksDto>();
        Nelibur.ObjectMapper.TinyMapper.Bind<Image, ImageDto>();
        Nelibur.ObjectMapper.TinyMapper.Bind<Item, ItemDto>();
        #endregion

        #region ExpressMapper Configuration
        global::ExpressMapper.Mapper.Register<SpotifyAlbumDto, SpotifyAlbum>();
        global::ExpressMapper.Mapper.Register<CopyrightDto, Copyright>();
        global::ExpressMapper.Mapper.Register<ArtistDto, Artist>();
        global::ExpressMapper.Mapper.Register<ExternalIdsDto, ExternalIds>();
        global::ExpressMapper.Mapper.Register<ExternalUrlsDto, ExternalUrls>();
        global::ExpressMapper.Mapper.Register<TracksDto, Tracks>();
        global::ExpressMapper.Mapper.Register<ImageDto, Image>();
        global::ExpressMapper.Mapper.Register<ItemDto, Item>();
        global::ExpressMapper.Mapper.Register<SpotifyAlbum, SpotifyAlbumDto>();
        global::ExpressMapper.Mapper.Register<Copyright, CopyrightDto>();
        global::ExpressMapper.Mapper.Register<Artist, ArtistDto>();
        global::ExpressMapper.Mapper.Register<ExternalIds, ExternalIdsDto>();
        global::ExpressMapper.Mapper.Register<ExternalUrls, ExternalUrlsDto>();
        global::ExpressMapper.Mapper.Register<Tracks, TracksDto>();
        global::ExpressMapper.Mapper.Register<Image, ImageDto>();
        global::ExpressMapper.Mapper.Register<Item, ItemDto>();
        #endregion

        #region EmitMapper
        _emitMapper = ObjectMapperManager.DefaultInstance.GetMapper<SpotifyAlbumDto, SpotifyAlbum>();
        #endregion

        //Mapperly does not need configuration
        //Mapster does not need configuration
        //AgileMapper does not need configuration
        //ValueInjecter does not need configuration
    }

    [Benchmark]
    public SpotifyAlbum AutoMapper()
    {
        return _autoMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
    }

    [Benchmark]
    public SpotifyAlbum Mapster()
    {
        return _spotifyAlbumDto.Adapt<SpotifyAlbum>();
    }

    [Benchmark]
    public SpotifyAlbum TinyMapper()
    {
        return Nelibur.ObjectMapper.TinyMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
    }

    [Benchmark]
    public SpotifyAlbum AgileMapper()
    {
        return AgileObjects.AgileMapper.Mapper.Map(_spotifyAlbumDto).ToANew<SpotifyAlbum>();
    }

    [Benchmark]
    public SpotifyAlbum ExpressMapper()
    {
        return global::ExpressMapper.Mapper.Map<SpotifyAlbumDto, SpotifyAlbum>(_spotifyAlbumDto);
    }

    [Benchmark]
    public SpotifyAlbum EmitMapper()
    {
        return _emitMapper.Map(_spotifyAlbumDto);
    }

    [Benchmark]
    public SpotifyAlbum ValueInjecter()
    {
        return Omu.ValueInjecter.Mapper.Map<SpotifyAlbumDto, SpotifyAlbum>(_spotifyAlbumDto);
    }

    [Benchmark]
    public SpotifyAlbum ManualMapping()
    {
        return _spotifyAlbumDto.Map();
    }

    [Benchmark]
    public void Mapperly()
    {
        MapperlyMapper.Map(_spotifyAlbumDto);
    }
}