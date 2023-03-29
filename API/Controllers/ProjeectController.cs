using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using DBL.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjeectController : ControllerBase
    {
        private readonly IRepository<Project> _repository;
        private readonly ILogger<Project> _logger;
        public ProjeectController(ILogger<Project> logger, IRepository<Project> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetProjectList")]
        [Route("GetProjectList")]
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

        [HttpGet(Name = "GetProject")]
        [Route("GetProject")]
        public ActionResult<Project> GetProject([FromQuery] int id)
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

        [HttpPost(Name = "AddProject")]
        [Route("AddProject")]
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

        [HttpPut(Name = "ChangeProject")]
        [Route("ChangeProject")]
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

        [HttpDelete(Name = "DeleteProject")]
        [Route("DeleteProject")]
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