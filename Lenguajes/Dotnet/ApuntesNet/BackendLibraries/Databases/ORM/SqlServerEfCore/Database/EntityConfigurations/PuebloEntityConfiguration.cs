using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Database.EntityConfigurations;

public class PuebloEntityConfiguration : IEntityTypeConfiguration<Pueblo>
{
    // private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };

    public void Configure(EntityTypeBuilder<Pueblo> builder)
    {
        builder.ToTable("pueblos");

        builder.HasKey(x => x.Id);

        // Podemos indicar indices
        builder.HasIndex(x => x.IsDeleted);

        // Indicamos un filtro por defecto que siempre se va a aplicar en esta entidad
        // Muy utilizada para el SoftDelete
        builder.HasQueryFilter(x => !x.IsDeleted);

        // Un pueblo puede tener varios usuarios, 1 usuario solo puede pertenecer a un pueblo
        builder
            .HasMany<Usuario>(x => x.Usuarios)
            .WithOne(x => x.PuebloNavigation)
            .HasForeignKey(usuario => usuario.PuebloId)
            .OnDelete(DeleteBehavior.Cascade);

        // ValueConverter<List<object>?, string?> referencesConverter = new(
        //     v => JsonSerializer.Serialize(v, _jsonSerializerOptions),
        //     v => JsonSerializer.Deserialize<List<object>>(v, _jsonSerializerOptions) ?? new List<object>()
        // );

        builder.Property(x => x.Nombre).IsRequired().HasColumnType("varchar(100)");
        // Creamos una conversion automatica, por ejemplo, cuando guardamos un JSON en BBDD.
        // HasConversion(referencesConverter);
    }
}
