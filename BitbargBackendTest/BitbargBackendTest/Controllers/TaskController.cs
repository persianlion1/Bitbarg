using BitbargBackendTest.Models;
using BitbargBackendTest.Models.ApiViewModels;
using BitbargBackendTest.Models.Entities;
using BitbargBackendTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;

namespace BitbargBackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public TaskController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id) =>
            Ok(ResponseViewModel.CreateResponse(DefaultNotifs.Success, "", _toDoService.GetById(id)));

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int id) =>
            Ok(ResponseViewModel.CreateResponse(DefaultNotifs.Success, "", _toDoService.GetToDosByUserId(id)));

        [HttpPost("Insert")]
        public IActionResult Insert(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                string error = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return Ok(ResponseViewModel.CreateResponse(DefaultNotifs.InvalidModel, error, null));
            }

            _toDoService.Insert(toDo);

            return Ok(ResponseViewModel.CreateResponse(DefaultNotifs.Success, "", null));
        }

        [HttpPut("Update")]
        public IActionResult Update(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                string error = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return Ok(ResponseViewModel.CreateResponse(DefaultNotifs.InvalidModel, error, null));
            }

            var record = _toDoService.GetById(toDo.Id);
            if (record == null)
            {
                return Ok(ResponseViewModel.CreateResponse(DefaultNotifs.NotFound, "Invalid Id", null));
            }

            record.Color = toDo.Color;
            record.Description = toDo.Description;
            record.UserId = toDo.UserId;
            record.TimeToDo = toDo.TimeToDo;
            record.Title = toDo.Title;

            _toDoService.Update(record);
            return Ok(ResponseViewModel.CreateResponse(DefaultNotifs.Success, "", null));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var record = _toDoService.GetById(id);
            if (record == null)
            {
                return Ok(ResponseViewModel.CreateResponse(DefaultNotifs.NotFound, "Invalid Id", null));
            }

            _toDoService.Delete(record);
            return Ok(ResponseViewModel.CreateResponse(DefaultNotifs.Success, "", null));
        }
    }
}
