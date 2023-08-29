using CrimeReportApp.Models;
using CrimeReportApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;


namespace CrimeReportApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /*
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            await _userService.Register(user);
            return Ok();
        }
        */

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            await _userService.Register(user);
            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            bool isAuthenticated = await _userService.Login(user);
            if (isAuthenticated)
            {
                HttpContext.Session.SetString("LoggedInUsername", user.Username);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("check")]
        public IActionResult CheckLogin()
        {
            var loggedInUsername = HttpContext.Session.GetString("LoggedInUsername");
            if (!string.IsNullOrEmpty(loggedInUsername))
            {
                return Ok(new { loggedInUsername });
            }
            return Unauthorized();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session on logout
            return Ok();
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            User user = await _userService.GetUserByEmail(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("register/registerByEmail")]
        public async Task<IActionResult> RegisterByEmail([FromForm] string email,[FromForm] string password)
        {
            bool isRegistered = await _userService.RegisterByEmail(email, password);
            if (isRegistered)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Email already taken.");
            }
        }

        [HttpPost("login/loginByEmail")]
        public async Task<IActionResult> LoginByEmail([FromForm] string email, [FromForm]string password)
        {
            bool isAuthenticated = await _userService.LoginByEmail(email, password);
            if (isAuthenticated)
            {
                return Ok();
            }
            else
            {
                return Unauthorized("Invalid email or password.");
            }
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            bool isUpdated = await _userService.UpdateUser(user);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return NotFound("User not found.");
            }
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            bool isDeleted = await _userService.DeleteUser(id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound("User not found.");
            }
        }

    }

}

