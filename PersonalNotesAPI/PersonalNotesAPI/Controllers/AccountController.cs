using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalNotesAPI.Auth;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Models.User;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, IConfiguration config)
        {
            _signInManager = signInManager;
            _logger = logger;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.userName, user.passWord, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                var tokenString = AuthTokenUtil.GetJwtSecurityTokenString(user.userName, _config);
                return new ObjectResult(tokenString);
            }
            return new ObjectResult("Invalid login attempt.");

        }
    }
}