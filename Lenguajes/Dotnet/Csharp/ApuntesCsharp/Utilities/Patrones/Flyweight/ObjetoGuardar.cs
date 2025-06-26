namespace Flyweight;

internal class ObjetoGuardar
{
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Descripcion { get; set; }

    public override string ToString()
    {
        return $"{Nombre} - {Apellidos} - {Descripcion}";
    }
}
