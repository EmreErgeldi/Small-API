using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Small_API.Models;
using Small_API.Services.BlogService;
using Small_API.Services.UserService;

namespace Small_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static IUserService? _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> LogIn(string username,  string password)
        {
            var result = await _userService.LogIn(username, password);
            
            if(result == null) return NotFound();

            return Ok(result);
        }
    }
}
