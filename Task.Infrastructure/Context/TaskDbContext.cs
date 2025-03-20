using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using Task.Domain.Entities;

namespace Task.Infrastructure.Context;

public class TaskDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks { get; set; }
    
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // This is required
        modelBuilder.Entity<TaskEntity>().ToCollection("Tasks");
    }
}