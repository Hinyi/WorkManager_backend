using Microsoft.EntityFrameworkCore;
using Users.Entities;
using Users.Persistence.Config;

namespace Users.Persistence;

public sealed class UserDbContext : DbContext
{ 
    public DbSet<User> Users { get; set; }
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        var configuration = new UserConfiguration();
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        modelBuilder.ApplyConfiguration(configuration);
    }
}