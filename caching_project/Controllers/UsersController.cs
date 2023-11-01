using Microsoft.AspNetCore.Mvc;
using dotnetcaching.Entities;
using dotnetcaching.Services;

namespace dotnetcaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        public UsersController(
            IUsersService userService
        )
        {
            _userService = userService;
        }

        /// <summary>User all list</summary>
        /// <remarks>It is possible return users list.</remarks>
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<UsersRolPolicy>> GetUserAll()
        {
            try
            {
                var response = await _userService.SelectPolicyUsersAllService();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>User by id list</summary>
        /// <remarks>It is possible return user list.</remarks>
        /// <param name="idUser" example="1">Parameters to get user.</param>
        [HttpGet("ById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<UsersRolPolicy>> GetUserById(int idUser)
        {
            try
            {
                var response = await _userService.SelectPolicyUserByIdService(idUser);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>User creation</summary>
        /// <remarks>It is possible return user creation.</remarks>
        /// <param name="userDto">Parameters to post user.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> PostUser(UserDto userDto)
        {
            try
            {
                var response = await _userService.InsertUserService(userDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}