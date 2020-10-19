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
    public IEnumerable<Task> Get()
    {
      return taskService.GetTasks();
    }

    [HttpPost]
    public ActionResult<Task> Post([FromBody] Task task)
    {
      return Created("task", taskService.AddOrUpdateTask(task));
    }

    [HttpPut]
    public ActionResult<Task> Put([FromBody] Task task)
    {
      return Ok(taskService.AddOrUpdateTask(task));
    }

  }
}
