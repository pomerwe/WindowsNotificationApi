using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Windows_Notification_API.Database.Configurations
{
  public class TaskConfiguration : IEntityTypeConfiguration<Task>
  {
    public void Configure(EntityTypeBuilder<Task> builder)
    {
      builder.ToTable("Task");

      builder.HasKey(t => t.TaskId);

      builder.Property(t => t.TaskId)
        .IsRequired()
        .UseIdentityColumn();
    }
  }
}
