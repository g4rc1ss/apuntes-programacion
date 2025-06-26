using System.ComponentModel.DataAnnotations.Schema;

namespace SqlServerEfCore.Database.Entities;

public class Pueblo : ISoftDelete
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public string? Nombre { get; set; }

    public ICollection<Usuario>? Usuarios { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
}
