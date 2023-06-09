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
    public class JobController : ControllerBase
    {
        private readonly IEntityRepository<Job, string> _jobRepository;
        private readonly ILogger<Job> _logger;
        private readonly SignInManager<User> _signInManager;

        public JobController(
            ILogger<Job> logger, 
            IEntityRepository<Job, string> jobRepository,
            SignInManager<User> signInManager)
        {
            _logger = logger;
            _jobRepository = jobRepository;
            _signInManager = signInManager;
        }

        [HttpGet("statuslist/", Name = "GetJobStatusList")]
        public ActionResult<List<Job>> GetJobStatusList()
        {
            try
            {
                var statuses = new Dictionary<int, string>();

                foreach (var item in Enum.GetValues<JobStatus>())
                {
                    statuses.Add((int)item, item.ToString());
                }

                return Ok(statuses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("projectjoblist/", Name = "GetJobListByProject")]
        public ActionResult<List<JobListedReturn>> GetJobListByProject([FromQuery] string projectId)
        {
            try
            {
                var dataList = _jobRepository.GetItems().Where(j => 
                    j.ProjectRefId == projectId &&
                    (j.JobRefId == null ||
                    j.JobRefId == string.Empty)).ToList();

                List<JobListedReturn> outList = new List<JobListedReturn>();

                foreach (var job in dataList)
                {
                    outList.Add(
                        new JobListedReturn
                        {
                            JobId = job.JobId,
                            Title = job.Title,
                            Description = job.Description,
                            Progress = job.Progress,
                            Status = job.Status,
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

        [HttpGet("item/", Name = "GetJob")]
        public ActionResult<Job> GetJob([FromQuery] string id)
        {
            try
            {
                var data = _jobRepository.GetItem(id);

                if (data is null)
                    throw new Exception($"Server has no data with id {id}");

                var ret = new JobItemReturn
                {
                    JobId = data.JobId,
                    Title = data.Title,
                    Description = data.Description,
                    StartDate = data.StartDate,
                    EndDate = data.EndDate,
                    EstimetedTime = data.EstimetedTime,
                    SpentTime = data.SpentTime,
                    Status = data.Status,
                    Progress = data.Progress,
                    ProjectRefId = data.ProjectRefId,
                    JobRefId = data.JobRefId,

                    SubTasks = Task.Run(() =>
                    {
                        List<JobListedReturn> returnedTaskList = new List<JobListedReturn>();
                        var subTaskList = data.Jobs.ToList();

                        foreach (var item in subTaskList)
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

                        var createdTasklList = data.Users.Where(uj =>
                            uj.JobId == data.JobId).ToList();

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

        [HttpPost("create/", Name = "AddJob")]
        public ActionResult AddJob([FromBody] JobCreateIn job)
        {
            try
            {
                Job newJob = new()
                {
                    JobId = Guid.NewGuid().ToString(),
                    Title = job.Title,
                    Description = job.Description,
                    StartDate = job.StartDate,
                    EndDate = job.EndDate,
                    EstimetedTime = job.EstimetedTime,
                    SpentTime = job.SpentTime,
                    Progress = job.Progress,
                    ProjectRefId = job.ProjectRefId,
                    JobRefId = job.JobRefId,
                };

                _jobRepository.AddItem(newJob);

                return Ok(newJob.JobId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/", Name = "ChangeJob")]
        public ActionResult ChangeJob([FromBody] JobUpdateIn job)
        {
            try
            {
                Job updatedJob = _jobRepository.GetItem(job.JobId);

                updatedJob.Title = job.Title;
                updatedJob.Description = job.Description;
                updatedJob.StartDate = job.StartDate;
                updatedJob.EndDate = job.EndDate;
                updatedJob.EstimetedTime = job.EstimetedTime;
                updatedJob.SpentTime = job.SpentTime;
                updatedJob.Progress = job.Progress;
                updatedJob.ProjectRefId = job.ProjectRefId;
                updatedJob.JobRefId = job.JobRefId;

                _jobRepository.Update(updatedJob);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/", Name = "DeleteJob")]
        public ActionResult DeleteJob([FromQuery] string jobId)
        {
            try
            {
                _jobRepository.Delete(jobId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}