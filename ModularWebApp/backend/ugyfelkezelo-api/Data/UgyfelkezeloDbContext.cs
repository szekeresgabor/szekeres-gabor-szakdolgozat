using Microsoft.EntityFrameworkCore;

namespace ugyfelkezelo_api.Data;

public class UgyfelkezeloDbContext(DbContextOptions<UgyfelkezeloDbContext> options) : DbContext(options)
{
    public DbSet<Ugyfel> Ugyfel => Set<Ugyfel>();
}