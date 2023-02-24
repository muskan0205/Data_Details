using Dapper;
using Data_Details.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Web_Project.Interface;
using Web_Project.Models;


namespace Web_Project.Controllers
{

    public class Employee_Controller : Controller
    {
        private IMyProjectService _apiservice;
        private IConfiguration _configuration;
        public Employee_Controller(IMyProjectService apiservice, IConfiguration configuration)
        {
            _apiservice = apiservice;
            _configuration = configuration;
        }

        //only authenticate employee --user allow to acess the methods.
        public IActionResult Index()
        {
            
            var response = _apiservice.EmployeeList();
            var data = JsonConvert.DeserializeObject<List<EmployeeDataModel>>(response.Content);

            //if (data.Count > 0)
            //{
            //    return View(data[0]);
            //}
            
            return View(data);


        }
        public IActionResult Create()
        {
            return View();
        }

        //Success-Message-11

        //error-message -20

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDataModel model)
        {
            var response = await _apiservice.CreateEmployee(model);
            var result = response.Content;
            if (!response.IsSuccessStatusCode) {
                if (model == null)
                {
                    TempData["error-message-20"] = "All The Fields is required";

                }
                else if (!Regex.IsMatch(model.First_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-21"] = "Use letters Only Please";
                    return RedirectToAction("Create", "Employee_");
                }
                else if (!Regex.IsMatch(model.Last_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-22"] = "Use letters Only Please";
                    return RedirectToAction("Create", "Employee_");
                }
                if (model.Salary < 1000 || model.Salary > 10000000)
                {
                    TempData["error-message-24"] = "Salary must be between 1000 and 10000000";
                    return RedirectToAction("Create", "Employee_");
                }
                else
                {
                    TempData["error-message-23"] = "Something Went wrong,Try Again";
                }
               
            }
            else if (response.IsSuccessStatusCode)
            {
                TempData["Success-Message-11"] = "Data Saved Successfully";
                return RedirectToAction("Index");
            }
            else
            {

            }
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var response = _apiservice.EmployeeList();
            var employeeList = JsonConvert.DeserializeObject<List<EmployeeDataModel>>(response.Content);
            var data = employeeList.FirstOrDefault(model => model.id == id);

            if (data != null)
            {
                return View(data);
            }

            return View();



            //    EmployeeDataModel model = new EmployeeDataModel();
            //    //var response = _apiservice.GetEmployee(id);
            //    //var content = response.Content.ReadAsStringAsync().Result;
            //    //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(content);
            //    // var response = _apiservice.GetEmployee(id);
            //    var response = _apiservice.EmployeeList();
            //    var data = JsonConvert.DeserializeObject<List<EmployeeDataModel>>(response.Content).FirstOrDefault();
            //    if(data.id == id)
            //    {
            //        return View(data);
            //    }
            //    //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(response.Content);
            //    return View();

        }

        //sucessmessage -----21   ...........error-message-31

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeDataModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _apiservice.UpdateEmployee(id, model);
            if (!response.IsSuccessStatusCode)
            {
                 if (!Regex.IsMatch(model.First_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-31"] = "Use letters Only Please";
                    return RedirectToAction("Edit", "Employee_");
                }
                else if (!Regex.IsMatch(model.Last_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-32"] = "Use letters Only Please";
                    return RedirectToAction("Edit", "Employee_");
                }
                else if (model.Salary < 1000 || model.Salary > 10000000)
                {
                    TempData["error-message-34"] = "Salary must be between 1000 and 10000000";
                    return RedirectToAction("Edit", "Employee_");
                }
                else
                {
                    
                    TempData["error-message-33"] = "Something Went wrong,Try Again";
                    
                }
            }

            if (!Regex.IsMatch(model.First_name.Trim(), @"^[a-zA-Z]+$"))
            {
                TempData["error-message-31"] = "Use letters Only Please";
                return RedirectToAction("Edit", "Employee_");
            }
            else if (!Regex.IsMatch(model.Last_name.Trim(), @"^[a-zA-Z]+$"))
            {
                TempData["error-message-32"] = "Use letters Only Please";
                return RedirectToAction("Edit", "Employee_");
            }
            else  if (response.IsSuccessStatusCode)
            {
                TempData["Success-Message-21"] = "Data Edited Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {

                TempData["error-message-33"] = "Something Went wrong,Try Again";

            }

            //if (response.IsSuccessStatusCode)
            //{
            //    TempData["Success-Message-21"] = "Data Edited Successfully";
            //    return RedirectToAction(nameof(Index));
            //}
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            EmployeeDataModel model = new EmployeeDataModel();
            //var response = _apiservice.GetEmployee(id);
            //var content = response.Content.ReadAsStringAsync().Result;
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(content);
            // var response = _apiservice.GetEmployee(id);
            var response = _apiservice.EmployeeList();
            var employeeList = JsonConvert.DeserializeObject<List<EmployeeDataModel>>(response.Content);
            var data = employeeList.FirstOrDefault(model => model.id == id);
            if (data != null)
            {
                return View(data);
            }
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(response.Content);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int ? id)
        {
            EmployeeDataModel model = new EmployeeDataModel();
            //var response = _apiservice.GetEmployee(id);
            //var content = response.Content.ReadAsStringAsync().Result;
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(content);
            // var response = _apiservice.GetEmployee(id);
            var response = _apiservice.EmployeeList();
            var employeeList = JsonConvert.DeserializeObject<List<EmployeeDataModel>>(response.Content);
            var data = employeeList.FirstOrDefault(model => model.id == id);
            if (data  != null)
            {
                return View(data);
            }
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(response.Content);
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id, EmployeeDataModel model)
        //{
        //    var response = _apiservice.DeleteEmployee(id);

        //    if (model.id)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //Sucess-message-41 ---- error-message-51

        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                TempData["Sucess-message-41"] = "Data Deleted Sucessfully";
                _apiservice.DeleteEmployee(id);
              
                return RedirectToAction("Index", "Employee_");

            }
              else
            {
                TempData["error-message-51"] = "Somthing Went Wrong ,Try Again";
                return RedirectToAction("Delete", "Employee_");
            }
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public  IActionResult Delete(EmployeeDataModel model)
        //{
        //    var response = _apiservice.DeleteEmployee( model);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

    }
}
