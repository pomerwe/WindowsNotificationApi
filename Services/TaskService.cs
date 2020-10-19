using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Windows_Notification_API.Database;
using Windows_Notification_API.Util;

namespace Windows_Notification_API.Services
{
  public sealed class TaskService
  {
    private readonly IServiceScopeFactory scopeFactory;
    private TaskDbContext dbContext;
    Timer t;
    public TaskService(IServiceScopeFactory scopeFactory)
    {
      this.scopeFactory = scopeFactory;
      dbContext = this.scopeFactory.CreateScope().ServiceProvider.GetRequiredService<TaskDbContext>();
      t = new Timer(CheckIfTasksNeedNotification, "", 0, 1000);
    }

    public List<Task> GetTasks()
    {
      return dbContext.Tasks.AsNoTracking().ToList();
    }

    public Task AddOrUpdateTask(Task task)
    {
      return dbContext.AddOrUpdate(task);
    }

    public void CheckIfTasksNeedNotification(object callback)
    {
      using(var context = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<TaskDbContext>())
      {
        List<Task> tasks = context.Tasks.ToList();
        tasks.ForEach(t =>
        {
          if (IsInTime(t))
          {
            if (t.LastSentNotification == null || (t.Daily && ((DateTime)t.LastSentNotification).Day < DateTime.Now.Day))
            {
              ToastSender.SendToast(t.TaskDescription);
              UpdateSentTask(t);
            }
          }
        });
      }
      
    }

    public void UpdateSentTask(Task t)
    {
      t.LastSentNotification = DateTime.Now;
      AddOrUpdateTask(t);
    }

    public bool IsInTime(Task t)
    {
      var hour = DateTime.Now.Hour;

      return t.Hour == hour;
    }
  }
}
