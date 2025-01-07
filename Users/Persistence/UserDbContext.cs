using Microsoft.EntityFrameworkCore;
using Users.Entities;

namespace Users.Persistence;

public sealed class UserDbContext : DbContext
{ 
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
    public DbSet<User> Users { get; set; }
}