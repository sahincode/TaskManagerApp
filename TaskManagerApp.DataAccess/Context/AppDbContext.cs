using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Entities;

namespace TaskManagerApp.DataAccess.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; }
}