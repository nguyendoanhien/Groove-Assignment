using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace PersonalNotesAPI.Controllers
{

    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
      
        public HomeController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            //if (!_signInManager.IsSignedIn(User))
            //    RedirectToPage()

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
