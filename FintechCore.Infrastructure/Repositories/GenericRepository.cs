using FintechCore.Domain.Interfaces;
using FintechCore.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FintechCore.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly FintechCoreContext _context;
    private readonly DbSet<T> _dbSet;
    private readonly ILogger<GenericRepository<T>> _logger;

    public GenericRepository(FintechCoreContext context, ILogger<GenericRepository<T>> logger)
    {
        _context = context;
        _logger = logger;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<T?> GetByShortId(short id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}