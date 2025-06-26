using MapperlyLibrary.ClassToMap;
using Riok.Mapperly.Abstractions;

namespace MapperlyLibrary.Profiles;

[Mapper]
public partial class MapperlyProfile
{
    [MapProperty(nameof(Chat.UserIdFromNavigation), nameof(ChatDto.FromUser))]
    [MapProperty(nameof(Chat.UserIdToNavigation), nameof(ChatDto.ToUser))]
    [MapProperty(nameof(Chat.PropiedadesNavigation), nameof(ChatDto.Properties))]
    [MapProperty(nameof(Chat.Message), nameof(ChatDto.Message))]
    [MapProperty(nameof(Chat.EstaLeido), nameof(ChatDto.IsRead))]
    public partial ChatDto ToChatDto(Chat chatEntity);

    public partial PropertyDto ToPropiedadDto(Propiedad propiedad);

    [MapProperty(nameof(@User.Name), nameof(UserDto.Nombre))]
    [MapProperty(nameof(@User.LastName), nameof(UserDto.Apellidos))]
    public partial UserDto ToUserDto(User user);
}
