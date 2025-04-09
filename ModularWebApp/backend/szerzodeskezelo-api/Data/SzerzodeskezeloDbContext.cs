using Microsoft.EntityFrameworkCore;

namespace szerzodeskezelo_api.Data;

public class SzerzodeskezeloDbContext(DbContextOptions<SzerzodeskezeloDbContext> options) : DbContext(options)
{
    public DbSet<Szerzodes> Szerzodes => Set<Szerzodes>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Szerzodes>()
            .Property(x => x.Osszeg)
            .HasPrecision(18, 2);

        base.OnModelCreating(modelBuilder);
    }
}