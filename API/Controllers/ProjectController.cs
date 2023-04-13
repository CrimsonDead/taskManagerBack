using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using DBL.Models;
using DBL.Models.Client;
using DBL.Models.Server;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IEntityRepository<ProjectModel, string> _repository;
        private readonly ILogger<ProjectModel> _logger;
        public ProjectController(ILogger<ProjectModel> logger, IEntityRepository<ProjectModel, string> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("list/", Name = "GetProjectList")]
        public ActionResult<List<object>> GetProjectList()
        {
            try
            {
                var dataList = _repository.GetItems();
                List<object> outList = new List<object>();

                foreach (var project in dataList)
                {
                    outList.Add(
                        new
                        {
                            ProjectId = project.ProjectId,
                            Title = project.Title,
                            Description = project.Description
                        }
                    );
                }

                return Ok(outList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("item/", Name = "GetProject")]
        public ActionResult<ProjectModel> GetProject([FromQuery] string id)
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
        public ActionResult AddProject([FromBody] Project project)
        {
            try
            {
                ProjectModel projectModel = ClientServerModelsMapping.Project2ProjectModel(project);
                projectModel.ProjectId = Guid.NewGuid().ToString();

                _repository.AddItem(projectModel);

                return Ok(projectModel.ProjectId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/", Name = "ChangeProject")]
        public ActionResult ChangeProject([FromBody] IdentifiableProject project)
        {
            try
            {
                ProjectModel projectModel = ClientServerModelsMapping.Project2ProjectModel(project);
                projectModel.ProjectId = project.ProjectId;

                _repository.Update(projectModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/", Name = "DeleteProject")]
        public ActionResult DeleteProject([FromBody] string projectId)
        {
            try
            {
                _repository.Delete(projectId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}