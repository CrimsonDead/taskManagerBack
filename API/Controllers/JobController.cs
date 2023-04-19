using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using DBL.Models;
using DBL.Models.Client;
using DBL.Models.Server;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IEntityRepository<JobModel, string> _jobRepository;
        private readonly IEntityRepository<ProjectModel, string> _projectRepository;
        private readonly ILogger<JobModel> _logger;
        public JobController(
            ILogger<JobModel> logger, 
            IEntityRepository<JobModel, string> jobRepository,
            IEntityRepository<ProjectModel, string> projectRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
            _projectRepository = projectRepository;
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

        [HttpGet("list/", Name = "GetJobList")]
        public ActionResult<List<object>> GetJobList()
        {
            try
            {
                var dataList = _jobRepository.GetItems();
                List<object> outList = new List<object>();

                foreach (var job in dataList)
                {
                    outList.Add( 
                        new {
                            JobId = job.JobId, 
                            Title = job.Title, 
                            Description = job.Description 
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
        public ActionResult<JobModel> GetJob([FromQuery] string id)
        {
            try
            {
                var data = _jobRepository.GetItem(id);

                data.ClearLinks();

                if (data is null)
                    throw new Exception($"Server has no data with id {id}");

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create/", Name = "AddJob")]
        public ActionResult AddJob([FromBody] Job job)
        {
            try
            {
                JobModel jobModel = ClientServerModelsMapping.Job2JobModel(job);
                jobModel.JobId = Guid.NewGuid().ToString();

                if (job.ProjectRefId != "")
                {
                    jobModel.Project = _projectRepository.GetItem(job.ProjectRefId);
                }

                if (job.JobRefId != "")
                {
                    jobModel.ParentJob = _jobRepository.GetItem(job.JobRefId);
                }

                _jobRepository.AddItem(jobModel);

                return Ok(jobModel.JobId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/", Name = "ChangeJob")]
        public ActionResult ChangeJob([FromBody] IdentifiableJob job)
        {
            try
            {
                JobModel jobModel = ClientServerModelsMapping.Job2JobModel(job);
                jobModel.JobId = job.JobId;

                _jobRepository.Update(jobModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/", Name = "DeleteJob")]
        public ActionResult DeleteJob([FromBody] string jobId)
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