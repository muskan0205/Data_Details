using Data_Details.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web_Project.Interface;

namespace Web_Project.Controllers
{

    public class AdminController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

    }
}

