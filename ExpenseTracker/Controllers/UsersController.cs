using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserPorfileModel>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("family/{familyId}")]
        public async Task<IActionResult> GetUsersByFamilyId(int familyId)
        {
            var users = await _userService.GetUsersByFamilyIdAsync(familyId);
            return Ok(users);

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserPorfileModel userModel)
        {
            await _userService.AddUserAsync(userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = userModel.UserId }, userModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserPorfileModel userModel)
        {
            if (id != userModel.UserId)
            {
                return BadRequest();
            }
            await _userService.UpdateUserAsync(userModel);
            return NoContent();// can also return 200ok 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
             await _userService.DeleteUserAsync(id);
            return NoContent();
        }




    }
}
