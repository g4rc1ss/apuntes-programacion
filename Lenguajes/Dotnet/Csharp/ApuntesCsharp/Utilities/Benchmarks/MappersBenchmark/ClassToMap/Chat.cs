namespace MappersBenchmark.ClassToMap;

public class Chat
{
    public string? Id { get; set; }

    public int UserIdFrom { get; set; }
    public int UserIdTo { get; set; }
    public string? PropiedadId { get; set; }
    public string? Message { get; set; }
    public DateTime CreateMessage { get; set; }
    public bool EstaLeido { get; set; }

    // Navigation
    public User? UserIdFromNavigation { get; set; }
    public User? UserIdToNavigation { get; set; }
    public IEnumerable<Propiedad>? PropiedadesNavigation { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? NormalizedUserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SecurityStamp { get; set; }
}

public class Propiedad
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }

    public decimal SuperficieMedida { get; set; }
    public int NBanos { get; set; }
    public int NHabitaciones { get; set; }
    public int NGarajes { get; set; }

    public decimal PrecioPropiedad { get; set; }

    // Claves Foraneas
    public string? PropiedadDetalleId { get; set; }
    public string? ImagenId { get; set; }
    public string? TipoOperacionId { get; set; }
    public string? MunicipioId { get; set; }
}
