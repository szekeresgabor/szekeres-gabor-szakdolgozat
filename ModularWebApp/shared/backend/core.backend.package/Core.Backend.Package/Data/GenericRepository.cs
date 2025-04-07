namespace Core.Backend.Package.Data;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

/// <summary>
/// Egy általános célú repository implementáció, amely lehetővé teszi
/// az entitásokkal való egységes adatbázis-műveletek végrehajtását.
/// Az osztály újrahasznosítható különböző DbContext típusokkal.
/// </summary>
/// <typeparam name="T">Az entitás típusa, amelynek a kezelését végzi.</typeparam>
/// <typeparam name="TContext">A DbContext típus, amely az adatbázis kapcsolatot biztosítja.</typeparam>
public class GenericRepository<T, TContext> : IGenericRepository<T>
    where T : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext _context;
    protected readonly DbSet<T> _dbSet;

    /// <summary>
    /// Konstruktor, amely beállítja az aktuálisan használt DbContext-et és DbSet-et.
    /// </summary>
    /// <param name="context">A specifikus DbContext implementáció példánya.</param>
    public GenericRepository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Visszaadja az összes entitást az adott típusból.
    /// </summary>
    public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.ToListAsync();

    /// <summary>
    /// Egy entitás lekérdezése azonosító alapján.
    /// </summary>
    public async Task<T?> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);

    /// <summary>
    /// Új entitás hozzáadása az adatbázishoz.
    /// </summary>
    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    /// <summary>
    /// Egy meglévő entitás módosítása.
    /// </summary>
    public void Update(T entity)
        => _dbSet.Update(entity);

    /// <summary>
    /// Egy entitás eltávolítása az adatbázisból.
    /// </summary>
    public void Delete(T entity)
        => _dbSet.Remove(entity);

    /// <summary>
    /// Az aktuális változások mentése az adatbázisba.
    /// </summary>
    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

    /// <summary>
    /// Olyan entitások lekérdezése, amelyek megfelelnek egy adott feltételnek.
    /// </summary>
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.Where(predicate).ToListAsync();

    /// <summary>
    /// Annak ellenőrzése, hogy létezik-e olyan entitás, amely megfelel az adott feltételnek.
    /// </summary>
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.AnyAsync(predicate);

    /// <summary>
    /// Egy IQueryable lekérdezés visszaadása, opcionálisan kapcsolt entitások betöltésével (Include).
    /// </summary>
    /// <param name="includes">Kapcsolt entitások betöltésére használt kifejezések.</param>
    /// <returns>Az adott entitásra vonatkozó lekérdezés, az include-olt kapcsolatokkal.</returns>
    public IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }
}