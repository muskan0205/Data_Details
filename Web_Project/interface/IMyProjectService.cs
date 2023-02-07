using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Data_Details.Models;

namespace Web_Project.Interface
{
    public interface IMyProjectService
    {
        public RestResponse SignUp(SignUp signUpData);
        public RestResponse Login(CommonProperties LoginData);
        public RestResponse EmployeeList();
        public RestResponse CustormerList();

        Task<HttpResponseMessage> CreateEmployee(EmployeeDataModel model);
        
        // Task<HttpResponseMessage> GetEmployee(int id);
        // Task<HttpResponseMessage> UpdateEmployee(int id, EmployeeDataModel model);
        // Task<HttpResponseMessage> DeleteEmployee(int id);
        //Task UpdateEmployee(int id, StringContent content);
    }
}
