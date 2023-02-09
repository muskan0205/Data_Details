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
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Registration successful. Please login to continue.";
                return RedirectToAction("login", "Signup");
            }
            else
            {
                TempData["ErrorMessage"] = "Error registering. Please try again.";
                return View();
            }

            //TempData["Message"] = "User registered successfully";

            //else
            //{
            //    return View("Error");
            //}

        }

        // -------------------------------------------LOG-IN---------------------------------------------------------------

        public IActionResult login()
        {
            var loginData = new CommonProperties();
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Enter Valid emailAdress and Password";
            }
            
            return View(loginData);
        }

        [HttpPost, ActionName("login")]
        public IActionResult Login(CommonProperties loginData)
        {
            var response = _apiservice.Login(loginData);

            if (response == null)
            {
                TempData["ErrorMessage"] = "Enter Valid emailAdress and Password";
                return RedirectToAction("login", "Signup");
            }

            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Enter Valid emailAdress and Password";
                return RedirectToAction("login", "Signup");
            }

            var role = response.Content;

            if (role == "\"Employee\"")
            {
                TempData["Employee"] = true;
                return RedirectToAction("Index", "Employee");
            }
            else if (role == "Customer")
            {
                TempData["Custormer"] = true;
                return RedirectToAction("Index", "Customer");
            }
            else if (role == "\"Admin\"")
            {
                TempData["Admin"] = true;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Enter Valid emailAdress and Password";
                return RedirectToAction("login", "Signup");
            }
        }



        //public IActionResult login(CommonProperties loginData)
        //{
        //    var response = _apiservice.Login(loginData);
        //    try
        //    {
        //        if (response != null)
        //        {
        //            TempData["ErrorMessage"] = "Enter Valid emailAdress and Password";
        //        }

        //        else if (!response.IsSuccessStatusCode)
        //        {
        //            TempData["ErrorMessage"] = "Enter Valid emailAdress and Password";
        //        }

        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            var role = response.Content;

        //            if (!ModelState.IsValid)
        //            {
        //                TempData["ErrorMessage"] = "Enter Valid emailAdress and Password";

        //            }
        //            // string IsInRole = null;
        //            //pop box your data inserted ..  use redirect to login controller
        //            // return View();

        //            if (role == "\"Employee\"")
        //            {

        //                TempData["Employee"] = true;


        //                // ViewBag.Layout = "~/Views/Shared/_Layout_Employee.cshtml";
        //                return RedirectToAction("Index", "Employee_");
        //            }
        //            else if (role == "\"Custormer\"")
        //            {
        //                TempData["Custormer"] = true;

        //                // ViewBag.Layout = "~/Views/Shared/_Layout_Customer.cshtml";
        //                return RedirectToAction("Index", "Customer");
        //            }
        //            else
        //            {
        //                TempData["Admin"] = true;
        //                return RedirectToAction("Index", "Admin");
        //            }

        //        }
        //        return View();

        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        TempData["ErrorMessage"] = ex.Message;
        //        return RedirectToAction("Index");
        //    }
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

