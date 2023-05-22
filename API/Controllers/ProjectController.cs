using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using DBL.Models;
using DBL.Models.Client;
using DBL.Models.Server;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IEntityRepository<Project, string> _repository;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<Project> _logger;
        public ProjectController(
            ILogger<Project> logger, 
            IEntityRepository<Project, string> repository,
            SignInManager<User> signInManager)
        {
            _logger = logger;
            _repository = repository;
            _signInManager = signInManager;
        }

        [HttpGet("list/", Name = "GetProjectList")]
        public ActionResult<List<ProjectListedReturn>> GetProjectList()
        {
            try
            {
                var dataList = _repository.GetItems();
                List<ProjectListedReturn> outList = new List<ProjectListedReturn>();

                foreach (var project in dataList)
                {
                    outList.Add(
                        new ProjectListedReturn
                        {
                            ProjectId = project.ProjectId,
                            Title = project.Title,
                            Description = project.Description,

                            Progress = project.Jobs.Count != 0 ? 
                                (int)(project.Jobs.Sum(j => j.Progress) / project.Jobs.Count * 100) : 0,

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
        public ActionResult<int> GetProjectProgress([FromBody] string id)
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
        public ActionResult<ProjectItemReturn> GetProject([FromQuery] string id)
        {
            try
            {
                var data = _repository.GetItem(id);

                if (data is null)
                    throw new Exception($"Server has no data with id {id}");

                var ret = new ProjectItemReturn {
                    ProjectId = data.ProjectId,
                    Title = data.Title,
                    Description = data.Description,
                    TaskNum = data.Jobs.Count,

                    Progress = data.Jobs.Count != 0 ?
                                (int)(data.Jobs.Sum(j => j.Progress) / data.Jobs.Count * 100) : 0,

                    CreatedTasks = Task.Run(() =>
                    {
                        List<JobListedReturn> returnedTaskList = new List<JobListedReturn>();
                        
                        var createdTasklList = data.Jobs.Where(j => 
                            j.Status == JobStatus.Created && 
                            j.ProjectRefId == data.ProjectId &&
                            j.JobRefId == null).ToList();

                        foreach (var item in createdTasklList)
                        {
                            returnedTaskList.Add(
                                new JobListedReturn
                                {
                                    JobId = item.JobId,
                                    Title = item.Title,
                                    Description = item.Description,
                                    Progress = item.Progress,
                                    Status = item.Status
                                });
                        }

                        return returnedTaskList;
                    }).Result,

                    InProgressTasks = Task.Run(() =>
                    {
                        List<JobListedReturn> returnedTaskList = new List<JobListedReturn>();
                        
                        var createdTasklList = data.Jobs.Where(j =>
                            j.Status == JobStatus.InProgreess &&
                            j.ProjectRefId == data.ProjectId &&
                            j.JobRefId == null).ToList();

                        foreach (var item in createdTasklList)
                        {
                            returnedTaskList.Add(
                                new JobListedReturn
                                {
                                    JobId = item.JobId,
                                    Title = item.Title,
                                    Description = item.Description,
                                    Progress = item.Progress,
                                    Status = item.Status
                                });
                        }

                        return returnedTaskList;
                    }).Result,

                    CompleteTasks = Task.Run(() =>
                    {
                        List<JobListedReturn> returnedTaskList = new List<JobListedReturn>();
                        
                        var createdTasklList = data.Jobs.Where(j =>
                            j.Status == JobStatus.Completed &&
                            j.ProjectRefId == data.ProjectId &&
                            j.JobRefId == null).ToList();

                        foreach (var item in createdTasklList)
                        {
                            returnedTaskList.Add(
                                new JobListedReturn
                                {
                                    JobId = item.JobId,
                                    Title = item.Title,
                                    Description = item.Description,
                                    Progress = item.Progress,
                                    Status = item.Status
                                });
                        }

                        return returnedTaskList;
                    }).Result,

                    Users = Task.Run(() =>
                    {
                        List<UserListedReturn> returnedUserList = new List<UserListedReturn>();

                        var createdTasklList = data.Users.Where(up =>
                            up.ProjectId == data.ProjectId).ToList();

                        foreach (var item in createdTasklList)
                        {
                            var user = _signInManager.UserManager.FindByIdAsync(item.UserId).Result;

                            returnedUserList.Add(
                                new UserListedReturn
                                {
                                    Id = user.Id,
                                    Login = user.UserName,
                                });
                        }

                        return returnedUserList;
                    }).Result
                };

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create/", Name = "AddProject")]
        public ActionResult AddProject([FromBody] ProjectCreateIn project)
        {
            try
            {
                Project newProject = new()
                {
                    ProjectId = Guid.NewGuid().ToString(),
                    Title = project.Title,
                    Description = project.Description,
                };

                _repository.AddItem(newProject);

                return Ok(newProject.ProjectId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/", Name = "ChangeProject")]
        public ActionResult ChangeProject([FromBody] ProjectUpdateIn project)
        {
            try
            {
                Project updatedProject = _repository.GetItem(project.ProjectId);

                updatedProject.Title = project.Title;
                updatedProject.Description = project.Description;

                _repository.Update(updatedProject);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/", Name = "DeleteProject")]
        public ActionResult DeleteProject([FromQuery] string projectId)
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