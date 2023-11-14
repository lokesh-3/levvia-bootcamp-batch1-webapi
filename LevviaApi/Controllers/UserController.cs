using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Services.Interface;
using Services.ServicesRepos;

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser(UserDTO user)
        {

            try
            {
                await _userService.CreateUser(user);
                return StatusCode(StatusCodes.Status200OK, true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {

            try
            {
                return await _userService.GetAllUsers();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
        }

        /// <summary>
        /// Get users by role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsersByRole")]
        public async Task<ActionResult<List<UserDTO>>> GetUsersByRole(string role)
        {

            try
            {
                return await _userService.GetUsersByRole(role);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {

            try
            {
                return await _userService.GetUserById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
        }
    }
}
