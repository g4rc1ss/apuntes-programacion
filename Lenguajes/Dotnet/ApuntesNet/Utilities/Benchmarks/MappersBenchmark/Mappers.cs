using AutoMapper;
using BenchmarkDotNet.Attributes;
using MappersBenchmark.ClassToMap;
using MappersBenchmark.MappersProfiles;

namespace MappersBenchmark;

[MemoryDiagnoser]
public class Mappers
{
    private readonly IMapper _autoMapper;
    private readonly MapperlyProfile _mapperly;

    public Mappers()
    {
        _autoMapper = new MapperConfiguration(x =>
            x.AddProfile(new AutoMapperProfile())
        ).CreateMapper();
        _mapperly = new MapperlyProfile();
    }

    [Benchmark]
    public void MapperObjectManual()
    {
        ChatDto? chatDto = ClassFake.chatClass.ToDto();
    }

    [Benchmark]
    public void MapperObjectMapperly()
    {
        ChatDto? chatDto = _mapperly.ToChatDto(ClassFake.chatClass);
    }

    [Benchmark]
    public void MapperObjectAutoMapper()
    {
        ChatDto? chatDto = _autoMapper.Map<ChatDto>(ClassFake.chatClass);
    }

    [Benchmark]
    public void MapperListManual()
    {
        List<ChatDto>? chatDto = [.. ClassFake.chatEntityList.Select(x => x.ToDto())];
    }

    [Benchmark]
    public void MapperListMapperly()
    {
        List<ChatDto>? chatDto = [.. ClassFake.chatEntityList.Select(_mapperly.ToChatDto)];
    }

    [Benchmark]
    public void MapperListAutoMapper()
    {
        List<ChatDto>? chatDto = _autoMapper.Map<List<ChatDto>>(ClassFake.chatEntityList);
    }
}
