using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using Microsoft.AspNetCore.Identity;
using DBL.Models.Client;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<User> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;

        public UserController(ILogger<User> logger, SignInManager<User> signInManager, RoleManager<UserRole> roleManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("roles/", Name = "GetUserRoleList")]
        public ActionResult<List<UserRole>> GetUserRoleList()
        {
            try
            {
                var roleList = _roleManager.Roles.ToList();
                if (roleList.Count() == 0)
                    throw new Exception("Server has no data");
                return Ok(roleList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public ActionResult LoginUser([FromBody] User user)
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
        public ActionResult RegisterUser([FromBody] User user)
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
        public ActionResult ChangeUser([FromBody] User user)
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
        public ActionResult DeleteUser([FromBody] User user)
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