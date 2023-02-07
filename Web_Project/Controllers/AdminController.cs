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
   
    public class AdminController : Controller
    {
        private IMyProjectService _apiservice;
        private IConfiguration _configuration;
        public AdminController(IMyProjectService apiservice, IConfiguration configuration)
        {
            _apiservice = apiservice;
            _configuration = configuration;
        }
        public ActionResult Index()
        {
            var employeeResponse = _apiservice.EmployeeList();
            var employeeData = JsonConvert.DeserializeObject<List<EmployeeDataModel>>(employeeResponse.Content);
            var customerResponse = _apiservice.CustormerList();
            var customerData = JsonConvert.DeserializeObject<List<customerDataModel>>(customerResponse.Content);

            var combinedData = new Admin
            {
                EmployeeData = employeeData,
                CustomerData = customerData
            };
           
            return View(combinedData);
        }
    }
}
