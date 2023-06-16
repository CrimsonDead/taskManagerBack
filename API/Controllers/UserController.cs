using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using DBL.Repositories;
using DBL.Models.Client;
using DBL.Models.Server;
using DBL.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<User> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRelationEntityRepository<UserJob, string, string> _userJobRepository;
        private readonly IRelationEntityRepository<UserProject, string, string> _userProjectRepository;

        public UserController(
            ILogger<User> logger, 
            SignInManager<User> signInManager, 
            RoleManager<Role> roleManager,
            IRelationEntityRepository<UserJob, string, string> userJobRepository,
            IRelationEntityRepository<UserProject, string, string> userProjectRepository)
        {
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userJobRepository = userJobRepository;
            _userProjectRepository = userProjectRepository;
        }

        [HttpPost("assigntorole/", Name = "AssignToRole")]
        public async Task<ActionResult> AssignToRole([FromQuery] string roleName, string userId)
        {
            try
            {
                Role role = _roleManager.Roles.FirstOrDefault(r => r.Name == roleName);

                if (role == null)
                    throw new Exception("Wrong role name");

                var assignResult = await _signInManager.UserManager.AddToRoleAsync(
                    _signInManager.UserManager.FindByIdAsync(userId).Result,
                    role.Name);

                if (!assignResult.Succeeded)
                {
                    List<string> errors = new List<string>();

                    foreach (var error in assignResult.Errors)
                    {
                        _logger.LogError(error.Description);
                        errors.Add(error.Description);
                    }

                    _logger.LogError("Failed to register user");
                    return BadRequest(errors);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("assigntoprojct/", Name = "AssignToProjeect")]
        public ActionResult AssignToProjeect([FromQuery] string projectId, string userId)
        {
            try
            {
                UserProject userProject = new()
                {
                    UserId = userId,
                    ProjectId = projectId,
                };

                _userProjectRepository.AddItem(userProject);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("assigntojob/", Name = "AssignToJob")]
        public ActionResult AssignToJob([FromQuery] string jobId, string userId)
        {
            try
            {
                UserJob userJob = new()
                {
                    UserId = userId,
                    JobId = jobId,
                };

                _userJobRepository.AddItem(userJob);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("roles/", Name = "GetUserRoleList")]
        public ActionResult<List<RoleListedReturn>> GetUserRoleList()
        {
            try
            {
                var roleList = _roleManager.Roles.ToList();
                List<RoleListedReturn> outList = new List<RoleListedReturn>();

                if (roleList.Count() == 0)
                    throw new Exception("Server has no data");

                foreach (var item in roleList)
                {
                    outList.Add(
                        new RoleListedReturn
                        {
                            Id = item.Id,
                            Name = item.Name
                        });
                }

                return Ok(outList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("user/", Name = "GetUser")]
        public async Task<ActionResult<UserItemReturn>> GetUser(UserGetIn user)
        {
            try
            {
                var claim = new Claim(ClaimTypes.NameIdentifier, user.Hash);
                var serverUser = (await _signInManager.UserManager.GetUsersForClaimAsync(claim))[0];

                if (serverUser != null)
                {
                    var clientUser =
                        new UserItemReturn
                        {
                            Id = serverUser.Id,
                            UserName = serverUser.UserName,
                            Email = serverUser.Email,
                            PhoneNumber = serverUser.PhoneNumber,

                            Projects = Task.Run(() =>
                            {
                                List<ProjectListedReturn> returnedProjectList = new List<ProjectListedReturn>();

                                var userProjectList = _userProjectRepository.GetItems().Where(up =>
                                    up.UserId == serverUser.Id).ToList();

                                foreach (var item in userProjectList)
                                {
                                    returnedProjectList.Add(
                                        new ProjectListedReturn 
                                        {
                                            ProjectId = item.Project.ProjectId,
                                            Title = item.Project.Title,
                                            Description = item.Project.Description,
                                            
                                            Progress = item.Project.Jobs.Count != 0 ?
                                                (int)(item.Project.Jobs.Sum(j => j.Progress) / item.Project.Jobs.Count * 100) : 0,
                                            
                                            TaskNum = item.Project.Jobs.Count,
                                            CreatedTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.Created),
                                            InProgressTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.InProgreess),
                                            CompleteTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.Completed),

                                        });
                                }

                                return returnedProjectList;
                            }).Result,

                            Jobs = Task.Run(() =>
                            {
                                List<JobListedReturn> returnedTaskList = new List<JobListedReturn>();

                                var createdTasklList = _userJobRepository.GetItems().Where(uj =>
                                    uj.JobId == serverUser.Id).ToList();


                                foreach (var item in createdTasklList)
                                {
                                    returnedTaskList.Add(
                                        new JobListedReturn
                                        {
                                            JobId = item.Job.JobId,
                                            Title = item.Job.Title,
                                            Description = item.Job.Description,
                                            Progress = item.Job.Progress,
                                            Status = item.Job.Status
                                        });
                                }

                                return returnedTaskList;
                            }).Result, 

                            Role = Task.Run(() =>
                            {
                                var roles = _signInManager.UserManager.GetRolesAsync(serverUser).Result;

                                return roles.Contains("Admin") == false ? roles.Contains("Manager") == false ? roles.Contains("User") == false ? "User" : "User" : "Manager" : "Amin"; 
                            }).Result
                        };

                    return Ok(clientUser);
                }
                else
                {
                    throw new Exception("Not authorized");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("userbyid/", Name = "GetUserById")]
        public async Task<ActionResult<UserItemReturn>> GetUserById([FromQuery] string id)
        {
            try
            {
                var serverUser = await _signInManager.UserManager.FindByIdAsync(id);

                if (serverUser != null)
                {
                    var clientUser =
                        new UserItemReturn
                        {
                            Id = serverUser.Id,
                            UserName = serverUser.UserName,
                            Email = serverUser.Email,
                            PhoneNumber = serverUser.PhoneNumber,

                            Projects = Task.Run(() =>
                            {
                                List<ProjectListedReturn> returnedProjectList = new List<ProjectListedReturn>();

                                var userProjectList = _userProjectRepository.GetItems().Where(up =>
                                    up.UserId == serverUser.Id).ToList();


                                foreach (var item in userProjectList)
                                {
                                    returnedProjectList.Add(
                                        new ProjectListedReturn
                                        {
                                            ProjectId = item.Project.ProjectId,
                                            Title = item.Project.Title,
                                            Description = item.Project.Description,

                                            Progress = item.Project.Jobs.Count != 0 ?
                                                (int)(item.Project.Jobs.Sum(j => j.Progress) / item.Project.Jobs.Count * 100) : 0,

                                            TaskNum = item.Project.Jobs.Count,
                                            CreatedTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.Created),
                                            InProgressTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.InProgreess),
                                            CompleteTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.Completed),

                                        });
                                }

                                return returnedProjectList;
                            }).Result,

                            Jobs = Task.Run(() =>
                            {
                                List<JobListedReturn> returnedTaskList = new List<JobListedReturn>();

                                var createdTasklList = _userJobRepository.GetItems().Where(uj =>
                                    uj.JobId == serverUser.Id).ToList();


                                foreach (var item in createdTasklList)
                                {
                                    returnedTaskList.Add(
                                        new JobListedReturn
                                        {
                                            JobId = item.Job.JobId,
                                            Title = item.Job.Title,
                                            Description = item.Job.Description,
                                            Progress = item.Job.Progress,
                                            Status = item.Job.Status
                                        });
                                }

                                return returnedTaskList;
                            }).Result,

                            Role = Task.Run(() =>
                            {
                                var roles = _signInManager.UserManager.GetRolesAsync(serverUser).Result;

                                return roles.Contains("Admin") == false ? roles.Contains("Manager") == false ? roles.Contains("User") == false ? "User" : "User" : "Manager" : "Admin";
                            }).Result
                        };

                    return Ok(clientUser);
                }
                else
                {
                    throw new Exception("Failed to get user");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login/", Name = "LoginUser")]
        public async Task<ActionResult> LoginUser([FromBody] UserLoginIn userLogin)
        {
            try
            {
                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(userLogin.Login, userLogin.Password, true, false);

                if (result.Succeeded)
                {
                    var serverUser = await _signInManager.UserManager.FindByNameAsync(userLogin.Login);

                    var retUser =
                        new UserLoginReturn
                        {
                            Id = serverUser.Id,
                            UserName = serverUser.UserName,
                            Email = serverUser.Email,
                            PhoneNumber = serverUser.PhoneNumber,
                            Hash = (await _signInManager.UserManager.GetClaimsAsync(serverUser)).FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,

                            Projects = Task.Run(() =>
                            {
                                List<ProjectListedReturn> returnedProjectList = new List<ProjectListedReturn>();

                                var userProjectList = _userProjectRepository.GetItems().Where(up =>
                                    up.UserId == serverUser.Id).ToList();


                                foreach (var item in userProjectList)
                                {
                                    returnedProjectList.Add(
                                        new ProjectListedReturn
                                        {
                                            ProjectId = item.Project.ProjectId,
                                            Title = item.Project.Title,
                                            Description = item.Project.Description,

                                            Progress = item.Project.Jobs.Count != 0 ?
                                                (int)(item.Project.Jobs.Sum(j => j.Progress) / item.Project.Jobs.Count * 100) : 0,

                                            TaskNum = item.Project.Jobs.Count,
                                            CreatedTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.Created),
                                            InProgressTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.InProgreess),
                                            CompleteTaskNum = item.Project.Jobs.Count(j => j.Status == JobStatus.Completed),

                                        });
                                }

                                return returnedProjectList;
                            }).Result,

                            Jobs = Task.Run(() =>
                            {
                                List<JobListedReturn> returnedTaskList = new List<JobListedReturn>();

                                var createdTasklList = _userJobRepository.GetItems().Where(uj =>
                                    uj.JobId == serverUser.Id).ToList();


                                foreach (var item in createdTasklList)
                                {
                                    returnedTaskList.Add(
                                        new JobListedReturn
                                        {
                                            JobId = item.Job.JobId,
                                            Title = item.Job.Title,
                                            Description = item.Job.Description,
                                            Progress = item.Job.Progress,
                                            Status = item.Job.Status
                                        });
                                }

                                return returnedTaskList;
                            }).Result,

                            Role = Task.Run(() =>
                            {
                                var roles = _signInManager.UserManager.GetRolesAsync(serverUser).Result;

                                return roles.Contains("Admin") == false ? roles.Contains("Manager") == false ? roles.Contains("User") == false ? "User" : "User" : "Manager" : "Admin";
                            }).Result
                        };

                    return Ok(retUser);
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
        public async Task<ActionResult> RegisterUser([FromBody] UserRegisterIn userCridentials)
        {
            try
            {
                User user = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = userCridentials.Login,
                    Email = userCridentials.Email,
                    PhoneNumber = userCridentials.PhoneNumber,
                    EmailConfirmed = true,
                };

                await _signInManager.SignOutAsync();

                var regiterResult = await _signInManager.UserManager.CreateAsync(user, userCridentials.Password);

                var signInResult = await _signInManager.PasswordSignInAsync(user, userCridentials.Password, true, false);

                if (signInResult.Succeeded && regiterResult.Succeeded)
                {
                    Role role = _roleManager.Roles.FirstOrDefault(r => r.Name == "User");

                    if (role == null)
                        throw new Exception("Wrong role name");

                    var assignResult = await _signInManager.UserManager.AddToRoleAsync(
                        _signInManager.UserManager.FindByIdAsync(user.Id).Result,
                        role.Name);

                    //var code = await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(user);

                    var serverUser = await _signInManager.UserManager.FindByNameAsync(user.UserName);

                    var principal = await _signInManager.ClaimsFactory.CreateAsync(serverUser);

                    var res = await _signInManager.UserManager.AddClaimsAsync(serverUser, principal.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier));

                    await _signInManager.SignInAsync(user, false);
                    _logger.LogInformation("User successfully registered");
                    return Ok();
                }
                else
                {
                    List<string> errors = new List<string>();

                    foreach (var error in regiterResult.Errors)
                    {
                        _logger.LogError(error.Description);
                        errors.Add(error.Description);
                    }

                    _logger.LogError("Failed to register user");
                    return BadRequest(errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/", Name = "ChangeUser")]
        public async Task<ActionResult> ChangeUser([FromBody] UserUpdateIn userUpdate)
        {
            try
            {
                var user = await _signInManager.UserManager.GetUserAsync(_signInManager.Context.User);

                user.UserName = userUpdate.Login;
                user.NormalizedUserName = userUpdate.Login.ToUpper();
                user.Email = userUpdate.Email;
                user.NormalizedEmail = userUpdate.Email.ToUpper();
                user.PhoneNumber = userUpdate.PhoneNumber;

                var upateResult = await _signInManager.UserManager.UpdateAsync(user);

                if (upateResult.Succeeded)
                {
                    _logger.LogInformation("User successfuly upated");
                }
                else
                {
                    throw new ApplicationException("Update failed");
                }

                return Ok();
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