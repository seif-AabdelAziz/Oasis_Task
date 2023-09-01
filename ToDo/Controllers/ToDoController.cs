using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.BL;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoManager manager;

        public ToDoController(IToDoManager _manager)
        {
            manager = _manager;
        }

        [HttpGet]
        [Authorize(Policy = "ForAdmin")]
        public ActionResult<List<ToDoReadDto>> GetAll()
        {
            return manager.GetAll();
        }

        [HttpGet]
        [Authorize(Policy = "ForAdmin")]
        [Route("{id}")]
        public ActionResult<ToDoReadDto> GetByID(int id)
        {
            ToDoReadDto? toDo = manager.GetById(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return toDo;
        }

        [HttpPost]
        [Authorize(Policy = "ForAdmin")]

        public ActionResult Add(ToDoAddDto toDoAdd)
        {
            int response = manager.Add(toDoAdd);

            if (response != 0)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpPut]
        [Authorize(Policy = "ForAdmin")]

        public ActionResult Edit(ToDoReadDto toDoEdit)
        {
            int response = manager.Edit(toDoEdit);
            if (response != 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize(Policy = "ForAdmin")]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            int response = manager.Delete(id);
            if (response != 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
