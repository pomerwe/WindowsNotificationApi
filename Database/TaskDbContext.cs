using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows_Notification_API.Database.Configurations;

namespace Windows_Notification_API.Database
{
  public class TaskDbContext : BaseDbContext
  {
    public TaskDbContext(DbContextOptions options) : base(options)
    {
      base.Database.EnsureCreated();
    }

    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Configurations
      modelBuilder.ApplyConfiguration(new TaskConfiguration());
    }
  }
}
