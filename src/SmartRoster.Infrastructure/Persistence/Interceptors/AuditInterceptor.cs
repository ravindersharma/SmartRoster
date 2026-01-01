using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SmartRoster.Domain.Entities.Base;

namespace SmartRoster.Infrastructure.Persistence.Interceptors;

/// <summary>
/// Automatically populates audit fields for tracked entities.
/// ensures CreatedBy / UpdatedBy / DeletedBy NEVER NULL
/// </summary>
public sealed class AuditInterceptor:SaveChangesInterceptor
{
    private readonly string _userName;

    public AuditInterceptor(string userName ="system")
    {
        _userName = userName;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken ct = default
        )
    {
        if (eventData.Context is not DbContext context)
            return base.SavingChangesAsync(eventData, result, ct);

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {       
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                case EntityState.Modified:
                    entry.Entity.MarkUpdated(_userName);
                    break;
                case EntityState.Added:
                    entry.Entity.MarkCreated(_userName);
                    break;
                default:
                    break;
            }

        };

        return base.SavingChangesAsync(eventData, result, ct);


    }
}
