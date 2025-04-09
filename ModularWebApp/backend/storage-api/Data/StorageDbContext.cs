using Microsoft.EntityFrameworkCore;

namespace storage_api.Data;

public class StorageDbContext(DbContextOptions<StorageDbContext> options) : DbContext(options)
{
    public DbSet<StoredFile> StoredFile => Set<StoredFile>();
}