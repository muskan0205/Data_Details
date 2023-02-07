using Data_Details.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web_Project.Interface;
using Web_Project.Models;

namespace Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMyProjectService _apiservice;

        public HomeController(ILogger<HomeController> logger, IMyProjectService apiservice)
        {
            _apiservice = apiservice;
            _logger = logger;
        }

       // [HttpPost]
        [HttpPost, ActionName("SignUp")]
        public IActionResult SignUp(SignUp signUpData)
        {
            var response = _apiservice.SignUp(signUpData); 

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Error");
            }
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
