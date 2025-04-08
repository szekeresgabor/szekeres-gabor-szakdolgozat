using Microsoft.EntityFrameworkCore;

namespace identity_api.Data;

public static class UserSeeder
{
    public static async Task SeedAsync(IdentityDbContext context)
    {
        if (await context.Users.AnyAsync())
            return;

        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Username = "alice", Password = "alice123", Roles = ["panaszkezelo"], Permissions = ["panaszkezelo.read"] },
            new() { Id = Guid.NewGuid(), Username = "bob", Password = "bob123", Roles = ["szerzodeskezelo"], Permissions = ["szerzodeskezelo.read", "szerzodeskezelo.edit"] },
            new() { Id = Guid.NewGuid(), Username = "carol", Password = "carol123", Roles = ["ugyfelkezelo"], Permissions = ["ugyfelkezelo.read", "ugyfelkezelo.edit"] },
            new() { Id = Guid.NewGuid(), Username = "dave", Password = "dave123", Roles = ["panaszkezelo", "szerzodeskezelo", "ugyfelkezelo"], Permissions = ["panaszkezelo.read", "panaszkezelo.edit", "szerzodeskezelo.read", "szerzodeskezelo.edit","ugyfelkezelo.read", "ugyfelkezelo.edit" ] },
        };

        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();
    }
}