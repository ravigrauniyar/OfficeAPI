using Microsoft.AspNetCore.Mvc;
using OfficeAPI.Data;
using Microsoft.EntityFrameworkCore;
using OfficeAPI.Models;

namespace OfficeAPI.Controllers
{
    public class LoginTodoController : Controller
    {
        private readonly LoginTodoContext newLoginContext;

        public LoginTodoController(LoginTodoContext newLoginContext)
        {
            this.newLoginContext = newLoginContext;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginItemTodo loginItemTodo)
        { 
            var loginItem = await newLoginContext.LoginItems.SingleOrDefaultAsync(item => item.Username == loginItemTodo.Username);

            if (loginItem != null)
            {
                if (loginItem.Password == loginItemTodo.Password)
                {
                    return Ok("Welcome");
                }
            }
            return NotFound();
        }
    }
 }
