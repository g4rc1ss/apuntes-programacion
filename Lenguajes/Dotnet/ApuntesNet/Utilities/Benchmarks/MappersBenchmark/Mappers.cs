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
        ChatDTO? chatDTO = ClassFake.chatClass.ToDto();
    }

    [Benchmark]
    public void MapperObjectMapperly()
    {
        ChatDTO? chatDTO = _mapperly.ToChatDTO(ClassFake.chatClass);
    }

    [Benchmark]
    public void MapperObjectAutoMapper()
    {
        ChatDTO? chatDTO = _autoMapper.Map<ChatDTO>(ClassFake.chatClass);
    }

    [Benchmark]
    public void MapperListManual()
    {
        List<ChatDTO>? chatDTO = [.. ClassFake.chatEntityList.Select(x => x.ToDto())];
    }

    [Benchmark]
    public void MapperListMapperly()
    {
        List<ChatDTO>? chatDTO = [.. ClassFake.chatEntityList.Select(_mapperly.ToChatDTO)];
    }

    [Benchmark]
    public void MapperListAutoMapper()
    {
        List<ChatDTO>? chatDTO = _autoMapper.Map<List<ChatDTO>>(ClassFake.chatEntityList);
    }
}
