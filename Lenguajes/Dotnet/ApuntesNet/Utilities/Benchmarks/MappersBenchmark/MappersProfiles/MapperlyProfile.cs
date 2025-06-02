using MappersBenchmark.ClassToMap;
using Riok.Mapperly.Abstractions;

namespace MappersBenchmark.MappersProfiles;

[Mapper]
public partial class MapperlyProfile
{
    [MapProperty(nameof(Chat.UserIdFromNavigation), nameof(@ChatDTO.FromUser))]
    [MapProperty(nameof(Chat.UserIdToNavigation), nameof(@ChatDTO.ToUser))]
    [MapProperty(nameof(Chat.PropiedadesNavigation), nameof(@ChatDTO.Properties))]
    [MapProperty(nameof(Chat.Message), nameof(@ChatDTO.Message))]
    [MapProperty(nameof(Chat.EstaLeido), nameof(@ChatDTO.IsRead))]
    public partial ChatDTO ToChatDTO(Chat chatEntity);

    public partial PropertyDTO ToPropiedadDTO(Propiedad propiedad);

    [MapProperty(nameof(@User.Name), nameof(@UserDTO.Nombre))]
    [MapProperty(nameof(@User.LastName), nameof(@UserDTO.Apellidos))]
    public partial UserDTO ToUserDTO(User user);
}
