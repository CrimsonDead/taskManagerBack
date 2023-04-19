using Microsoft.AspNetCore.Mvc;
using DBL.Repositories;
using Microsoft.AspNetCore.Identity;
using DBL.Models.Client;
using DBL.Models.Server;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserModel> _logger;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly RoleManager<UserRoleModel> _roleManager;

        public UserController(ILogger<UserModel> logger, SignInManager<UserModel> signInManager, RoleManager<UserRoleModel> roleManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("roles/", Name = "GetUserRoleList")]
        public ActionResult<List<UserRoleModel>> GetUserRoleList()
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

        [HttpPost("login/", Name = "LoginUser")]
        public async Task<ActionResult> LoginUser([FromBody] UserModel user, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    _signInManager.UserManager.Users.Where(u => u.Equals(user));

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/", Name = "RegUser")]
        public async Task<ActionResult<object>> RegisterUser([FromBody] UserModel user, string password)
        {
            try
            {
                //var result = await _signInManager.UserManager.CreateAsync(user, password);
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                
                var code = await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    _logger.LogInformation("User successfully registered");
                    //result = _signInManager.UserManager.GetUserId()
                    return Ok(await _signInManager.UserManager.GetUserIdAsync(user));
                }
                else
                {
                    //List<string> errors = new List<string>();
                    _logger.LogError("Failed to register user");
                    //foreach (var error in result.Errors)
                    //{
                    //    _logger.LogError(error.Description);
                    //    errors.Add(error.Description);
                    //}
                    return BadRequest("Failed to register user");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/", Name = "ChangeUser")]
        public ActionResult ChangeUser([FromBody] UserModel user)
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

        [HttpGet("logout/", Name = "LogoutUser")]
        public async Task<ActionResult> LogoutUser()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}