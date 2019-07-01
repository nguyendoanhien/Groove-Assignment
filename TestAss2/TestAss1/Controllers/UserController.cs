using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestAss1.Models;

namespace TestAss1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationSettings _appSetting;
        private RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IOptions<ApplicationSettings> appSettings,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSetting = appSettings.Value;
            _roleManager = roleManager;
        }



        [HttpPost]
        [Route("Register")]
        public async Task<object> addUser(User user)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = user.UserName
            };
            var result = await _userManager.CreateAsync(applicationUser, user.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    var users = new IdentityRole("User");
                    var res = await _roleManager.CreateAsync(users);
                }

                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    var users = new IdentityRole("Admin");
                    var res = await _roleManager.CreateAsync(users);
                }
                await _userManager.AddToRoleAsync(applicationUser, "Admin");
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var item = await _userManager. FindByNameAsync(user.UserName);
            var role = await _userManager.GetRolesAsync(item);
            if (item != null && await _userManager.CheckPasswordAsync(item, user.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,item.UserName.ToString()),
                        new Claim("role",role[0].ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSetting.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });

            }
            else
                return BadRequest(new { message ="Username or Password incorrect" });
        }
    }

}