using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoPlan.Core.Dtos;
using TodoPlan.Core.Repositories;

namespace TodoPlan.Repo.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TodoPlanContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(TodoPlanContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();

    }

    public EntityList<T> Where(Expression<Func<T, bool>>? filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        IEnumerable<Expression<Func<T, object>>>? includes,
        int? page, int? pageSize)
    {
        page ??= 1;
        pageSize ??= 1;

        var query = _dbSet.AsQueryable();
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        int totalCount = query.Count();
        int filteredCount = totalCount;

        if (filter != null)
        {
            query = query.AsQueryable().Where(filter);
            totalCount = query.Count();
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }
        if (page != 0 && pageSize != 0)
        {
            query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            filteredCount = query.Count();
        }

        var pageData = query.ToList();

        return new EntityList<T>()
        {
            FilteredCount = filteredCount,
            TotalCount = totalCount,
            PageData = pageData
        };

        //return _dbSet.Where(expression);
    }
}