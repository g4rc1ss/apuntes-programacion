using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Database;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        if (eventData.Context is not null)
        {
            IEnumerable<EntityEntry<ISoftDelete>> entries = eventData
                .Context.ChangeTracker.Entries<ISoftDelete>()
                .Where(x => x.State == EntityState.Deleted);

            foreach (EntityEntry<ISoftDelete> softDetele in entries)
            {
                softDetele.State = EntityState.Modified;
                softDetele.Entity.IsDeleted = true;
                softDetele.Entity.DeletedOn = DateTime.UtcNow;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
