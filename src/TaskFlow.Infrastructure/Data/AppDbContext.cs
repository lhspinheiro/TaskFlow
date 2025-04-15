using Microsoft.EntityFrameworkCore;
using Task = TaskFlow.Domain.Entities.Task;

namespace TaskFlow.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Task> task  { get; set; }

  
}