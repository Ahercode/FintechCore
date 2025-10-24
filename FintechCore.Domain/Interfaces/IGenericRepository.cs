namespace FintechCore.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task<T?> GetByShortId(short id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}