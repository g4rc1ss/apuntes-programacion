namespace MappersBenchmark.ClassToMap;

public class ChatDto
{
    public string? Id { get; set; }
    public UserDto? FromUser { get; set; }
    public UserDto? ToUser { get; set; }
    public List<PropertyDto>? Properties { get; set; }
    public string? Message { get; set; }
    public DateTime CreateMessage { get; set; }
    public bool IsRead { get; set; }
    public bool IsMyMessage { get; set; }
}

public class PropertyDto
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public decimal SuperficieMedida { get; set; }
    public int NBanos { get; set; }
    public int NHabitaciones { get; set; }
    public int NGarajes { get; set; }
    public decimal PrecioPropiedad { get; set; }
}

public class UserDto
{
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
}
