using ApiJwt.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt;

public class DatabaseDbContext(
    DbContextOptions<DatabaseDbContext> options
) : DbContext(options)
{
    public DbSet<UserJwtTokensEntity> UserJwtTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(DatabaseDbContext).Assembly);
    }
}