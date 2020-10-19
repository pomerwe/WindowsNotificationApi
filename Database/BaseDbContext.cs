using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Windows_Notification_API.Database
{
  public class BaseDbContext : DbContext
  {
    public BaseDbContext(DbContextOptions options) : base(options)
    {

    }

    public T AddOrUpdate<T>(T entity) where T : class
    {
      if (Entry(entity).State == EntityState.Detached)
      {
        Attach(entity);
      }
      if (Entry(entity).State != EntityState.Added)
      {
        Set<T>().Update(entity);
      }
      SaveChanges();
      Entry(entity).State = EntityState.Detached;
      return entity;
    }

    public bool TryDeleteEntity<T>(T entity) where T : class
    {
      try
      {
        Set<T>().Remove(entity);
        SaveChanges();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
