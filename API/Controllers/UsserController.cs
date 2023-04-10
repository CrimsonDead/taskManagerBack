using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using DBL.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<User> _logger;
        private readonly SignInManager<User> _signInManager;

        public UserController(ILogger<User> logger, SignInManager<User> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        [HttpGet("list/", Name = "GetUserList")]
        public ActionResult<List<User>> GetUserList()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpGet("item/", Name = "GetUser")]
        public ActionResult<User> GetUser([FromQuery] int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login/", Name = "LoginUser")]
        public ActionResult LoginUser([FromForm] User user)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/", Name = "RegUser")]
        public ActionResult RegisterUser([FromForm] User user)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/", Name = "ChangeUser")]
        public ActionResult ChangeUser([FromForm] User user)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/", Name = "DeleteUser")]
        public ActionResult DeleteUser([FromForm] User user)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}