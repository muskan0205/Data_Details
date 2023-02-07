using Data_Details.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //[HttpPost]
        //public async Task<IActionResult> Create(customerDataModel model)
        //{
        //    var response = await _apiservice.CreateEmployee(model);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        //    public IActionResult Edit(int id)
        //    {
        //        var response = _apiservice.GetEmployee(id);
        //        var data = JsonConvert.DeserializeObject<EmployeeDataModel>(response.Content);

        //        return View(data);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, EmployeeDataModel model)
        //    {
        //        var json = JsonConvert.SerializeObject(model);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = await _apiservice.UpdateEmployee(id, content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(model);
        //    }
        //    public IActionResult Delete(int id)
        //    {
        //        var response = _apiservice.GetEmployee(id);
        //        var data = JsonConvert.DeserializeObject<EmployeeDataModel>(response.Content);

        //        return View(data);
        //    }

        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var response = await _apiservice.DeleteEmployee(id);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View();
        //    }

    }
}
    //public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

