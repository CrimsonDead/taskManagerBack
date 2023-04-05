using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using DBL.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IRepository<Job> _repository;
        private readonly ILogger<Job> _logger;
        public JobController(ILogger<Job> logger, IRepository<Job> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("GetJobStatusList", Name = "statuslist/")]
        public ActionResult<List<Job>> GetJobStatusList()
        {
            try
            {
                var statuses = new Dictionary<int, string>();

                foreach (var item in  Enum.GetValues<JobStatus>())
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

        [HttpGet("GetJobList", Name = "list/")]
        public ActionResult<List<Job>> GetJobList()
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

        [HttpGet("GetJob", Name = "item/")]
        public ActionResult<Job> GetJob([FromQuery] int id)
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

        [HttpPost("AddJob", Name = "create/")]
        public ActionResult AddJob([FromForm] Job job)
        {
            try
            {
                _repository.AddItem(job);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeJob", Name = "update/")]
        public ActionResult ChangeJob([FromForm] Job job)
        {
            try
            {
                _repository.Update(job);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteJob", Name = "delete/")]
        public ActionResult DeleteJob([FromForm] Job job)
        {
            try
            {
                _repository.Delete(job);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}