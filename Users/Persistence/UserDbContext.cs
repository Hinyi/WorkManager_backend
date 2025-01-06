using Microsoft.EntityFrameworkCore;

namespace Users.Persistence;

public class UserDbContext : DbContext
{ 
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
}