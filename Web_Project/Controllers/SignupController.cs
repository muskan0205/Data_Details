using Data_Details.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web_Project.Interface;

namespace Web_Project.Controllers
{

    public class SignupController : Controller
    {
        private IMyProjectService _apiservice;
        
        public SignupController(IMyProjectService apiservice)
        {
            _apiservice = apiservice;
        }

        //----------------------------------------------------SIGN-UP-------------------------------------------------------

        public IActionResult SignUp()
        {
            var signUpData = new SignUp();
            return View(signUpData);
        }

        [HttpPost, ActionName("SignUp")]
        public IActionResult SignUp(SignUp signUpData)
        {
            var response = _apiservice.SignUp(signUpData);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var role = HttpContext.Session.GetString("role");
                //pop box your data inserted ..  use redirect to login controller
                // return View();
                return RedirectToAction("login", "Signup");
            }
            else
            {
                return View("Error");
            }
        }

        // -------------------------------------------LOG-IN---------------------------------------------------------------

        public IActionResult login()
        {
            var loginData = new CommonProperties();
            return View(loginData);
        }

        [HttpPost, ActionName("login")]
        public IActionResult login(CommonProperties loginData)
        {
            var response = _apiservice.Login(loginData);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var role = response.Content;

                //pop box your data inserted ..  use redirect to login controller
                // return View();
                if (role == "\"Employee\"")
                {
                    return RedirectToAction("Index", "Employee_");
                }
                else if (role == "\"Custormer\"")
                {
                    return RedirectToAction("Index", "Customer");
                }
                else if (role == "\"Admin\"")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

