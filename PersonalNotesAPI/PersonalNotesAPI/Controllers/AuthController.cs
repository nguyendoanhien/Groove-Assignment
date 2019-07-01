using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]

    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        public AuthController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        // GET api/<controller>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            var user = await userManager.FindByNameAsync(loginVM.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                var userRole = await userManager.GetRolesAsync(user);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("role",userRole[0])
                };
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));
                var token = new JwtSecurityToken(
                    issuer: "*",
                    audience: "*",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    email = user.Email
                });
            }
            return Unauthorized();
        }
    }
}
