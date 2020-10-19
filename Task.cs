using NSwag.Annotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Windows_Notification_API
{
 
  public class Task
  {
    public int TaskId { get; set; }
    public bool Daily { get; set; }
    public DateTime? LastSentNotification { get; set; }
    [NotMapped]
    [JsonIgnore]
    public HourMinute HourMinute 
    { 
      get
      {
        return new HourMinute(Hour, Minute);
      }
    }
    public int Hour { get; set; }
    public int Minute { get; set; }

    public string TaskDescription { get; set; }

    public Task()
    {
      
    }
    public Task(HourMinute hourMinute, string description)
    {
      Hour = hourMinute.Hour;
      Minute = hourMinute.Minute;
      TaskDescription = description;
    }
  }

  public class HourMinute
  {
    public int Hour { get; set; }
    public int Minute { get; set; }
    public HourMinute(int hour, int minute)
    {
      Hour = hour;
      Minute = minute;
    }
  }
}
