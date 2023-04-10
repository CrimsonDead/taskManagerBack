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

        [HttpGet("statuslist/", Name = "GetJobStatusList")]
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

        [HttpGet("list/", Name = "GetJobList")]
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

        [HttpGet("item/", Name = "GetJob")]
        public ActionResult<Job> GetJob([FromQuery] string id)
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

        [HttpPost("create/", Name = "AddJob")]
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

        [HttpPut("update/", Name = "ChangeJob")]
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

        [HttpDelete("delete/", Name = "DeleteJob")]
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