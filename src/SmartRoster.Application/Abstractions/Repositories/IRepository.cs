using System.Linq.Expressions;
using SmartRoster.Domain.Entities.Base;

namespace SmartRoster.Application.Abstractions.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id,CancellationToken ct=default);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> predicate,CancellationToken ct=default);
    Task AddAsync(T entity,CancellationToken ct=default);
    void Update(T entity);
    void Remove(T entity);
}