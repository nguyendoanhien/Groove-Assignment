using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAss1.Models;
using TestAss1.Services;

namespace TestAss1.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
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


//private readonly IEmployeeRepository _employeeRepository;

//public HomeController(IEmployeeRepository employeeRepository)
//{
//    _employeeRepository = employeeRepository;
//}

//public JsonResult Index()
//{
//    Employee model = _employeeRepository.GetEmployee(1);
//    return Json(model);
//}