namespace MapperlyLibrary.ClassToMap;

public class ChatDTO
{
    public string? Id { get; set; }
    public UserDTO? FromUser { get; set; }
    public UserDTO? ToUser { get; set; }
    public List<PropertyDTO>? Properties { get; set; }
    public string? Message { get; set; }
    public DateTime CreateMessage { get; set; }
    public bool IsRead { get; set; }
    public bool IsMyMessage { get; set; }
}

public class PropertyDTO
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public decimal SuperficieMedida { get; set; }
    public int NBanos { get; set; }
    public int NHabitaciones { get; set; }
    public int NGarajes { get; set; }
    public decimal PrecioPropiedad { get; set; }
}

public class UserDTO
{
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
}
