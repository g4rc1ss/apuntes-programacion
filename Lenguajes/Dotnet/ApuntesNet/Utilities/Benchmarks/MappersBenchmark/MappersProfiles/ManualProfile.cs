using MappersBenchmark.ClassToMap;

namespace MappersBenchmark.MappersProfiles;

public static class ManualProfile
{
    public static ChatDTO ToDto(this Chat chat)
    {
        return new()
        {
            Id = chat.Id,
            CreateMessage = chat.CreateMessage,
            IsRead = chat.EstaLeido,
            Message = chat.Message,
            FromUser = chat.UserIdFromNavigation.ToUserModelEntity(),
            ToUser = chat.UserIdToNavigation.ToUserModelEntity(),
            Properties = [.. chat.PropiedadesNavigation.Select(x => x.ToPropertyModelEntity())],
        };
    }

    public static UserDTO ToUserModelEntity(this User user)
    {
        return new() { Nombre = user.Name, Apellidos = user.LastName };
    }

    public static PropertyDTO ToPropertyModelEntity(this Propiedad propiedad)
    {
        return new()
        {
            Id = propiedad.Id,
            NBanos = propiedad.NBanos,
            NGarajes = propiedad.NGarajes,
            NHabitaciones = propiedad.NHabitaciones,
            Nombre = propiedad.Nombre,
            PrecioPropiedad = propiedad.PrecioPropiedad,
            SuperficieMedida = propiedad.SuperficieMedida,
        };
    }
}
