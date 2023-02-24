using Data_Details.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web_Project.Interface;

namespace Web_Project.Controllers
{
   
    public class CustomerController : Controller
    {
        private IMyProjectService _apiservice;
        private IConfiguration _configuration;
        public CustomerController(IMyProjectService apiservice, IConfiguration configuration)
        {
            _apiservice = apiservice;
            _configuration = configuration;
        }

        //only authenticate employee --user allow to acess the methods.
        public IActionResult Index()
        {
            var response = _apiservice.CustormerList();
            var data = JsonConvert.DeserializeObject<List<customerDataModel>>(response.Content);

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

        //error-message ----71 sucess-message -71

        [HttpPost]
        public async Task<IActionResult> Create(customerDataModel model)
        {
            var response = await _apiservice.CreateCustormer(model);
            if (!response.IsSuccessStatusCode)
            {
                if (model == null)
                {
                    TempData["error-message-71"] = "All The Fields is required";

                }
                else if (!Regex.IsMatch(model.First_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-72"] = "Use letters Only Please";
                    return RedirectToAction("Create", "Customer");
                }
                else if (!Regex.IsMatch(model.Last_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-73"] = "Use letters Only Please";
                    return RedirectToAction("Create", "Customer");
                }
                else if (!Regex.IsMatch(model.Product_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-74"] = "Use letters Only Please";
                    return RedirectToAction("Create", "Customer");
                }
                else
                {
                    TempData["error-message-75"] = "Something Went wrong,Try Again";
                    return RedirectToAction("Create", "Customer");
                }

            }

            //if (model == null)
            //{
            //    TempData["error-message-71"] = "All The Fields is required";

            //}
            //else if (!Regex.IsMatch(model.First_name.Trim(), @"^[a-zA-Z]+$"))
            //{
            //    TempData["error-message-72"] = "Use letters Only Please";
            //    return RedirectToAction("Create", "Customer");
            //}
            //else if (!Regex.IsMatch(model.Last_name.Trim(), @"^[a-zA-Z]+$"))
            //{
            //    TempData["error-message-73"] = "Use letters Only Please";
            //    return RedirectToAction("Create", "Customer");
            //}
            //else if (!Regex.IsMatch(model.Product_name.Trim(), @"^[a-zA-Z]+$"))
            //{
            //    TempData["error-message-74"] = "Use letters Only Please";
            //    return RedirectToAction("Create", "Customer");
            //}
            //else if (response.IsSuccessStatusCode)
            //{
            //    TempData["Success-Message-71"] = "Data Saved Successfully";
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    TempData["error-message-75"] = "Something Went wrong,Try Again";
            //    return RedirectToAction("Create", "Customer");
            //}



          

            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var response = _apiservice.CustormerList();
            var custormerList = JsonConvert.DeserializeObject<List<customerDataModel>>(response.Content);
            var data = custormerList.FirstOrDefault(model => model.id == id);

            if (data != null)
            {
                return View(data);
            }

            return View();


        }

        //error-message ----81 sucess-message -81

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, customerDataModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _apiservice.UpdateCustormer(id, model);
            if (!response.IsSuccessStatusCode)
            {
                if (!Regex.IsMatch(model.First_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-81"] = "Use letters Only Please";
                    return RedirectToAction("Edit", "Customer");
                }
                else if (!Regex.IsMatch(model.Last_name.Trim(), @"^[a-zA-Z]+$"))
                {
                    TempData["error-message-82"] = "Use letters Only Please";
                    return RedirectToAction("Edit", "Customer");
                }
                else
                {

                    TempData["error-message-84"] = "Something Went wrong,Try Again";
                    return RedirectToAction("Edit", "Customer");
                }
            }
            if (response.IsSuccessStatusCode)

            {
                TempData["Success-Message-81"] = "Data Edited Successfully";
                return RedirectToAction(nameof(Index));
            }

            //if (!Regex.IsMatch(model.First_name.Trim(), @"^[a-zA-Z]+$"))
            //{
            //    TempData["error-message-81"] = "Use letters Only Please";
            //    return RedirectToAction("Edit", "Customer");
            //}
            //else if (!Regex.IsMatch(model.Last_name.Trim(), @"^[a-zA-Z]+$"))
            //{
            //    TempData["error-message-82"] = "Use letters Only Please";
            //    return RedirectToAction("Edit", "Customer");
            //}
            //else if (!Regex.IsMatch(model.Product_name.Trim(), @"^[a-zA-Z]+$"))
            //{
            //    TempData["error-message-83"] = "Use letters Only Please";
            //    return RedirectToAction("Edit", "Customer");
            //}
            //else if (response.IsSuccessStatusCode)

            //{
            //    TempData["Success-Message-81"] = "Data Edited Successfully";
            //    return RedirectToAction(nameof(Index));
            //}
            //else
            //{

            //    TempData["error-message-84"] = "Something Went wrong,Try Again";
            //    return RedirectToAction("Edit", "Customer");
            //}


            return View(model);
        }
        public IActionResult Details(int? id)
        {
            customerDataModel model = new customerDataModel();
            //var response = _apiservice.GetEmployee(id);
            //var content = response.Content.ReadAsStringAsync().Result;
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(content);
            // var response = _apiservice.GetEmployee(id);
            var response = _apiservice.CustormerList();
            var customerList = JsonConvert.DeserializeObject<List<customerDataModel>>(response.Content);
            var data = customerList.FirstOrDefault(model => model.id == id);
            if (data != null)
            {
                return View(data);
            }
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(response.Content);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int? id)
        {
            customerDataModel model = new customerDataModel();
            //var response = _apiservice.GetEmployee(id);
            //var content = response.Content.ReadAsStringAsync().Result;
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(content);
            // var response = _apiservice.GetEmployee(id);
            var response = _apiservice.CustormerList();
            var customerList = JsonConvert.DeserializeObject<List<customerDataModel>>(response.Content);
            var data = customerList.FirstOrDefault(model => model.id == id);
            if (data != null)
            {
                return View(data);
            }
            //var data = JsonConvert.DeserializeObject<EmployeeDataModel>(response.Content);
            return RedirectToAction(nameof(Index));

        }

        //error-message ----91 sucess-message -92

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)

            {
                TempData["Sucess-message-91"] = "Data Deleted Sucessfully";
                _apiservice.DeleteCustormer(id);
               
                return RedirectToAction("Index", "Customer");

            }
            else
            {
                TempData["error-message-91"] = "Somthing Went Wrong ,Try Again";
                return RedirectToAction("Delete", "Customer");
            }

        }

        //public IActionResult Delete(int id)
        //{
        //    var response = _apiservice.GetECustormer(id);
        //    var data = JsonConvert.DeserializeObject<customerDataModel>(response.Content);

        //    return View(data);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var response = await _apiservice.DeleteEmployee(id);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

    }
}
    //public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

