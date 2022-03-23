using System.IO;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Mapster;

namespace ObjectsMapperBenchmark
{
    //[DryJob]
    //[ShortRunJob]
    [SimpleJob(RunStrategy.Throughput)]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles(false)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkContainer
    {
        private readonly SpotifyAlbumDto _spotifyAlbumDto;
        private readonly IMapper _autoMapper;
        private readonly MapperlyMapper _mapperlyMapper;
        private readonly Hypercubus.Mapping.Mapper _hypercubusMapper;

        public BenchmarkContainer()
        {
            var json = File.ReadAllText("spotifyAlbum.json");
            _spotifyAlbumDto = SpotifyAlbumDto.FromJson(json);

            //Automapper Configuration 
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

            //TinyMapper Configuration 
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

            //ExpressMapper Configuration 
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
            
            // Mapperly
            _mapperlyMapper = new MapperlyMapper();

            // HypercubusMapper
            _hypercubusMapper = HypercubusMapper.Create();

            //Mapster don't need configuration
            //AgileMapper don't need configuration
        }

        [Benchmark]
        public void AgileMapper()
        {
            AgileObjects.AgileMapper.Mapper.Map(_spotifyAlbumDto).ToANew<SpotifyAlbum>();
        }

        [Benchmark]
        public void TinyMapper()
        {
            Nelibur.ObjectMapper.TinyMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
        }

        [Benchmark]
        public void ExpressMapper()
        {
            global::ExpressMapper.Mapper.Map<SpotifyAlbumDto, SpotifyAlbum>(_spotifyAlbumDto);
        }

        [Benchmark]
        public void AutoMapper()
        {
            _autoMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
        }

        [Benchmark]
        public void ManualMapping()
        {
            //Generated by MappingGenerator
            _spotifyAlbumDto.Map();
        }

        [Benchmark]
        public void Mapster()
        {
            _spotifyAlbumDto.Adapt<SpotifyAlbum>();
        }

        [Benchmark]
        public void Mapperly()
        {
            _mapperlyMapper.Map(_spotifyAlbumDto);
        }
        
        [Benchmark]
        public void HypercubusMapping()
        {
            _hypercubusMapper.Map<SpotifyAlbumDto, SpotifyAlbum>(_spotifyAlbumDto);
        }
    }
}
