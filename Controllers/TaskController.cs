using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Windows.Security.Cryptography.Core;
using Windows_Notification_API.Services;

namespace Windows_Notification_API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TaskController : ControllerBase
  {

    private readonly TaskService taskService;
    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger, TaskService taskService)
    {
      _logger = logger;
      this.taskService = taskService;
    }

    [HttpGet]
    public ActionResult<List<Task>> Get()
    {
      try
      {
        return Ok(taskService.GetTasks());
      }
      catch (Exception ex)
      {
        return OnRequestFail(ex);
      }
      
    }

    [HttpGet("{taskId}")]
    public ActionResult<Task> Get(int taskId)
    {
      try
      {
        return Ok(taskService.GetTask(taskId));
      }
      catch (Exception ex)
      {
        return OnRequestFail(ex);
      }

    }

    [HttpPost]
    public ActionResult<Task> Post([FromBody] Task task)
    {
      try
      {
        return Created("task", taskService.AddOrUpdateTask(task));
      }
      catch (Exception ex)
      {
        return OnRequestFail(ex);
      }
    }

    [HttpPut]
    public ActionResult<Task> Put([FromBody] Task task)
    {
      try
      {
        return Ok(taskService.AddOrUpdateTask(task));
      }
      catch (Exception ex)
      {
        return OnRequestFail(ex);
      }
    }

    [HttpDelete("{taskId}")]
    public ActionResult Delete(int taskId)
    {
      try
      {
        taskService.DeleteTask(taskId);
        return NoContent();
      }
      catch (Exception ex)
      {
        return OnRequestFail(ex);
      }
    }

    public ActionResult OnRequestFail(Exception ex)
    {
      return BadRequest(ex.Message);
    }

  }
}
