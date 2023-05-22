using Microsoft.AspNetCore.Mvc;
using OfficeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace OfficeAPI.Controllers
{
    public class LoginTodoController : Controller
    {
        private readonly LoginTodoContext newLoginContext;

        public LoginTodoController(LoginTodoContext newLoginContext)
        {
            this.newLoginContext = newLoginContext;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password)
        { 
            var loginItem = await newLoginContext.LoginItems.SingleOrDefaultAsync(item => item.Username == username);

            if (loginItem != null)
            {
                if (loginItem.Password == password)
                {
                    return Ok();
                }
            }
            return NotFound();
        }
    }
 }
