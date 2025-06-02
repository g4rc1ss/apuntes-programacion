namespace MappersBenchmark.ClassToMap;

public static class ClassFake
{
    public static Chat chatClass = new()
    {
        Id = Guid.NewGuid().ToString(),
        Message = "Hola, me llamo Ralph",
        CreateMessage = DateTime.Now,
        EstaLeido = true,
        PropiedadId = Guid.NewGuid().ToString(),
        UserIdFrom = 2,
        UserIdTo = 5,
        PropiedadesNavigation =
        [
            .. Enumerable
                .Range(0, 1000)
                .Select(x => new Propiedad()
                {
                    Id = Guid.NewGuid().ToString(),
                    ImagenId = Guid.NewGuid().ToString(),
                    MunicipioId = Guid.NewGuid().ToString(),
                    NBanos = 3,
                    NGarajes = 1,
                    NHabitaciones = 5,
                    Nombre = Guid.NewGuid().ToString(),
                    PrecioPropiedad = 5455,
                    PropiedadDetalleId = Guid.NewGuid().ToString(),
                    SuperficieMedida = 560,
                    TipoOperacionId = Guid.NewGuid().ToString(),
                }),
        ],
        UserIdFromNavigation = new User { Name = "Ralph", LastName = "Bigun" },
        UserIdToNavigation = new User { Name = "Bart", LastName = "Simpson" },
    };

    public static IEnumerable<Chat> chatEntityList =
    [
        .. Enumerable.Range(0, 1000).Select(x => chatClass),
    ];
}
