using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Database;

public partial class EntityFrameworkSqlServerContext(DbContextOptions optionsBuilder)
    : DbContext(optionsBuilder)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pueblo> Pueblos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(EntityFrameworkSqlServerContext).Assembly
        );
        base.OnModelCreating(modelBuilder);
    }
}
