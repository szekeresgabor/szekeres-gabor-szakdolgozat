namespace Core.Backend.Package.Data;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T, TContext> : IGenericRepository<T>
    where T : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public void Update(T entity) => _dbSet.Update(entity);
    public void Delete(T entity) => _dbSet.Remove(entity);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}