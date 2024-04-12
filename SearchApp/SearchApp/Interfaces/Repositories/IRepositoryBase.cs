using SearchApp.Models;
using System.Linq.Expressions;

namespace SearchApp.Interfaces.Repositories;

public interface IRepositoryBase<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
    T GetById(Guid id);
    void Post(T entity);
    void Put(T entity);
    Task DeleteAsync(Guid id);
    void Commit();
}
