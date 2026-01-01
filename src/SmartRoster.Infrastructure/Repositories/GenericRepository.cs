using Microsoft.EntityFrameworkCore;
using SmartRoster.Application.Abstractions.Repositories;
using SmartRoster.Domain.Entities.Base;
using SmartRoster.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace SmartRoster.Infrastructure.Repositories;

/// <summary>
/// Generic repository providing CRUD access for entities.
/// </summary>
public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _set;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _set = context.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity, CancellationToken ct = default)
    => await _set.AddAsync(entity, ct);

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
    => await _set.Where(predicate).AsNoTracking().ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default)
    => await _set.FirstOrDefaultAsync(x => x.Id == id, ct);

    public void Remove(TEntity entity)
    => _set.Remove(entity);

    public void Update(TEntity entity)
   => _set.Update(entity);
}
