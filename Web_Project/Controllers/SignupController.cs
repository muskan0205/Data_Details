using Data_Details.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            HttpContext.Session.SetString("mode", "Signup");
            return View(signUpData);
        }
        //sucess message -1

        [HttpPost, ActionName("SignUp")]
        public IActionResult SignUp(SignUp signUpData)
        {
            HttpContext.Session.SetString("mode", "Signup");
            var response = _apiservice.SignUp(signUpData);
           // var First_name=signUpData.First_name.Trim();


            var result = response.Content;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success-Message-1"] = "Registration Successful. Please login To Continue.";
                return RedirectToAction("login", "Signup");
            }
            if (!response.IsSuccessStatusCode)
            {
                //if (!new[] { signUpData.First_name, signUpData.Last_name, signUpData.Password, signUpData.EmailID, signUpData.Password, signUpData.role }
                //          .Any(prop => !string.IsNullOrWhiteSpace(prop)))
                //{
                //    TempData["error-message-1"] = "Please provide all required fields.";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if ((signUpData.First_name == null) || (signUpData.First_name == " "))
                //{
                //    TempData["error-message-2"] = "Please Enter First Name";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if ((signUpData.Last_name == null) || (signUpData.Last_name == " "))
                //{
                //    TempData["error-message-3"] = "Please Enter Last Name";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if (!Regex.IsMatch(signUpData.First_name.Trim(), @"^[a-zA-Z]+$"))
                //{
                //    TempData["error-message-4"] = "Use letters only please";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if (!Regex.IsMatch(signUpData.Last_name.Trim(), @"^[a-zA-Z]+$"))
                //{
                //    TempData["error-message-5"] = "Use letters only please";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if ((signUpData.EmailID == null) || (signUpData.EmailID == " "))
                //{
                //    TempData["error-message-6"] = "Enter Valid EmailID";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if ((!Regex.IsMatch(signUpData.EmailID.Trim(),@"^[a-zA-Z0-9._%+-]+@gmail\.com$|^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))||( signUpData.EmailID == null))
                //{
                //    TempData["error-message-7"] = "Enter Valid EmailID";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if ((signUpData.Password == null) || (signUpData.Password == " "))
                //{
                //    TempData["error-message-8"] = "Please Enter Password";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if ((signUpData.role == null) || (signUpData.role == " "))
                //{
                //    TempData["error-message-9"] = "Role is Required";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if (signUpData.Password.Trim().Length!=8)
                //{
                //    TempData["error-message-10"] = "Password must be 8 characters long";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if (!Regex.IsMatch(signUpData.Password.Trim(), @"^\S*$"))
                //{
                //    TempData["error-message-100"] = "Please Enter Right Password";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                //else if (signUpData.Password.Trim() != signUpData.Confirm_Password.Trim())
                //{
                //    TempData["error-message-11"] = "Password and Confirm Password doesn't not match";
                //    return RedirectToAction("SignUp", "Signup");
                //}
                if (result=="\"The same combination of email address and role already exist\"")
                {
                    TempData["error-message-12"] = "The same combination of email address and role already exists";
                    return RedirectToAction("SignUp", "Signup");
                }


                TempData["error-message-13"] = "Somthing Went Wrong ,Try Again";
                return RedirectToAction("SignUp", "Signup");
            }
            else
            {
                TempData["error-message-14"] = "Error registering. Please try again.";
               
            }
            return View(signUpData);
        }

        // -------------------------------------------LOG-IN---------------------------------------------------------------

        //error message -15
        public IActionResult login()
        {
            var loginData = new CommonProperties();

            var firstnlast = new SignUp();
            HttpContext.Session.SetString("mode", "login"); 
            if (!ModelState.IsValid)
            {
                TempData["error-message-15"] = "Enter Valid EmailAdress and Password";
            }
            
            return View(loginData);
        }

        //Success-Message---3
        //error-message----16

        [HttpPost, ActionName("login")]
        public IActionResult Login(CommonProperties loginData)
        {
            var response = _apiservice.Login(loginData);
            //HttpContext.Session.SetString("mode", "login");

            if (response == null)
            {
                TempData["error-message-16"] = "All The Field is Required.";
                return RedirectToAction("login", "Signup");
            }

            if (!response.IsSuccessStatusCode)
            {
                TempData["error-message-17"] = "Enter Valid EmailAdress ,Password and Select Correct Role";
                return RedirectToAction("login", "Signup");
            }

          

            //var role = response.Content;


            

            if (loginData.role == "Employee")
            {
                //if(loginData.role == "Admin")
                //{

                //    TempData["Admin"] = true;

                //}

                
                HttpContext.Session.SetString("Role", "Employee");
                // TempData["Employee"] = true;
                TempData["Success-Message-3"] ="WelCome..!"+ "  "+loginData.EmailID + "  "+"You Entered as" + loginData.role;

                return RedirectToAction("Index", "Employee_");
            }
            else if (loginData.role == "Customer")
            {
                //if (loginData.role == "Admin")
                //{
                //    TempData["Admin"] = true;

                //}
                //var Role = loginData.role;
                HttpContext.Session.SetString("Role", "Customer");

                TempData["Success-Message-4"] = "WelCome..!" + "  " + loginData.EmailID + "  " + "You Entered as" + loginData.role;
                return RedirectToAction("Index", "Customer");
            }
            else if (loginData.role == "Admin")
            {
                //TempData["Admin"] = true;
                HttpContext.Session.SetString("Role", "Admin");

                TempData["Success-Message-5"] = "WelCome..!" + "  " + loginData.EmailID + "  " + "You Entered as" + loginData.role;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["error-message-18"] = "Enter Valid emailAdress and Password";
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
        public IActionResult Signout()
        {
            HttpContext.Session.SetString("mode", "Signout");
            return RedirectToAction("login", "Signup");
        }
    }
}

