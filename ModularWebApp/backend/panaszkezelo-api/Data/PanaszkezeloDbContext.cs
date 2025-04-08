using Microsoft.EntityFrameworkCore;

namespace panaszkezelo_api.Data;

public class PanaszkezeloDbContext(DbContextOptions<PanaszkezeloDbContext> options) : DbContext(options)
{
    public DbSet<Panasz> Panasz => Set<Panasz>();
}