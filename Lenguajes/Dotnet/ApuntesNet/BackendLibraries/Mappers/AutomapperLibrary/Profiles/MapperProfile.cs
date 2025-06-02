using AutoMapper;
using AutomapperLibrary.Internal;

namespace AutomapperLibrary.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<PuebloEntity, PuebloEntityResponse>()
            .ForMember(x => x.Nombre, y => y.MapFrom(x => x.Name))
            .ForMember(x => x.Ubicacion, y => y.MapFrom(x => x.Location));
    }
}
