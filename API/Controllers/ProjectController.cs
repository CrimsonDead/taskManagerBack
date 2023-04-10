using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using DBL.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Project> _repository;
        private readonly ILogger<Project> _logger;
        public ProjectController(ILogger<Project> logger, IRepository<Project> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("list/", Name = "GetProjectList")]
        public ActionResult<List<Project>> GetProjectList()
        {
            try
            {
                var dataList = _repository.GetItems();
                if (dataList.Count() == 0)
                    throw new Exception("Server has no data");
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("item/", Name = "GetProject")]
        public ActionResult<Project> GetProject([FromQuery] string id)
        {
            try
            {
                var data = _repository.GetItem(id);
                if (data is null)
                    throw new Exception($"Server has no data with id {id}");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create/", Name = "AddProject")]
        public ActionResult AddProject([FromForm] Project project)
        {
            try
            {
                _repository.AddItem(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/", Name = "ChangeProject")]
        public ActionResult ChangeProject([FromForm] Project project)
        {
            try
            {
                _repository.Update(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/", Name = "DeleteProject")]
        public ActionResult DeleteProject([FromForm] Project project)
        {
            try
            {
                _repository.Delete(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}