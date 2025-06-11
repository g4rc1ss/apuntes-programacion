namespace PostgresqlDapper.Entities;

internal class Usuario
{
    internal string? IdUsuario { get; set; }
    internal string? NombreUsuario { get; set; }
    internal Pueblo? FKPueblo { get; set; }
}
