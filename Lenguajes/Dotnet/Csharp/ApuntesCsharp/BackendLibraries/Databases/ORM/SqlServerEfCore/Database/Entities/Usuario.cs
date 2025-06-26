using System.ComponentModel.DataAnnotations.Schema;

namespace SqlServerEfCore.Database.Entities;

public class Usuario : ISoftDelete
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int PuebloId { get; set; }
    public string? Nombre { get; set; }
    public int Edad { get; set; }
    public DateTime FechaHoy { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }

    public Pueblo? PuebloNavigation { get; set; }
}
