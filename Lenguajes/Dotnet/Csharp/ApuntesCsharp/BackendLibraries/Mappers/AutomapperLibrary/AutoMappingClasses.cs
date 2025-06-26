using AutoMapper;
using AutomapperLibrary.Internal;

namespace AutomapperLibrary;

public class AutoMappingClasses(IMapper mapper)
{
    public void Mapping()
    {
        PuebloEntity? entidad = new()
        {
            Id = 1,
            Location = "Algun sitio",
            Name = "bilbao",
        };
        PuebloEntityResponse? response = mapper.Map<PuebloEntityResponse>(entidad);
    }
}
