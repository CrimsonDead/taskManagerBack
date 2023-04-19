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
                            Description = project.Description,
                            Progress = (int)(project.Jobs.Sum(j => j.Progress) / project.Jobs.Count * 100),
                            TaskNum = project.Jobs.Count,
                            CreatedTaskNum = project.Jobs.Count(j => j.Status == JobStatus.Created),
                            InProgressTaskNum = project.Jobs.Count(j => j.Status == JobStatus.InProgreess),
                            CompleteTaskNum = project.Jobs.Count(j => j.Status == JobStatus.Completed),
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

        [HttpGet("progress/", Name = "GetProjectProgress")]
        public ActionResult<int> GetProjectProgress([FromQuery] string id)
        {
            try
            {
                var data = _repository.GetItem(id);

                int? flatProgress = data.Jobs.Sum(j => j.Progress);

                int progress = (int)(flatProgress / data.Jobs.Count * 100);

                return Ok(progress);
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

                data.ClearLinks();

                object ret = new {
                    ProjectId = data.ProjectId,
                    Title = data.Title,
                    Description = data.Description,
                    Progress = (int)(data.Jobs.Sum(j => j.Progress) / data.Jobs.Count * 100),
                    CreatedTasks = data.Jobs.Where(j => j.Status == JobStatus.Created).ToList(),
                    InProgressTasks = data.Jobs.Where(j => j.Status == JobStatus.InProgreess).ToList(),
                    CompleteTasks = data.Jobs.Where(j => j.Status == JobStatus.Completed).ToList(),

                };

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

        [HttpPatch("update/", Name = "ChangeProject")]
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