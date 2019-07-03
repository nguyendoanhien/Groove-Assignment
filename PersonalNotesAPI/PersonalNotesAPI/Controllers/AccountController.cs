using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersonalNotesAPI.Auth;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Models.User;

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        public AccountController(SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _config = config;
        }
        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        [Route("Login")]
        public async Task<ObjectResult> Post([FromBody] UserModel value)
        {


            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(value.Username, value.Password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User logged in.");
                    //return LocalRedirect(returnUrl);

                    var tokenString = AuthTokenUtil.GetJwtTokenString(value.Username, _config);
                    return new OkObjectResult(tokenString);
                }

            }

            // If we got this far, something failed, redisplay form
            return BadRequest("Error !");
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
