using Microsoft.AspNetCore.Mvc;
using OfficeAPI.Data;
using Microsoft.EntityFrameworkCore;
using OfficeAPI.Models;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.IdentityModel.Tokens;

namespace OfficeAPI.Controllers
{
    public class LoginTodoController : Controller
    {
        private readonly LoginTodoContext newLoginContext;
        private readonly IConfiguration configuration;

        public LoginTodoController(LoginTodoContext newLoginContext, IConfiguration configuration)
        {
            this.newLoginContext = newLoginContext;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginItemTodo loginItemTodo)
        { 
            if(loginItemTodo != null)
            {
                var userData = await newLoginContext.LoginItems.FirstOrDefaultAsync
                                     (x => x.Username == loginItemTodo.Username && x.Password == loginItemTodo.Password);

                var jwt = configuration.GetSection("Jwt").Get<Jwt>();

                if(userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Iss, jwt.Issuer),
                        new Claim(JwtRegisteredClaimNames.Aud, jwt.Audience),

                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                        new Claim("Username", userData.Username),
                        new Claim("Password", userData.Password)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: signIn
                        );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                return NotFound();
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }            
        }
    }
 }
