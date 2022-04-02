using System.Linq.Expressions;
using TodoPlan.Core.Dtos;

namespace TodoPlan.Core.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    IQueryable<T> GetAll();

    EntityList<T> Where(Expression<Func<T, bool>>? filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        IEnumerable<Expression<Func<T, object>>>? includes,
        int? page, int? pageSize);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);

}