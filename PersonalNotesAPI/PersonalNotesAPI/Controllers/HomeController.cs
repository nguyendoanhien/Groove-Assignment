using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Services;

namespace PersonalNotesAPI.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        public HomeController(UptimeService up) => uptime = up;
        public IActionResult Index() => View(new Dictionary<string, string>
        {
            ["Message"] = "This is the Index action",
            ["Uptime"] = $"{uptime.Uptime}ms"
        });
        //{
        //    return View();
        //}
       


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
