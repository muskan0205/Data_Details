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

        public RestResponse GetEmployee(int employeeid);
        // Task<HttpResponseMessage> GetEmployee(int id);
        Task<HttpResponseMessage> UpdateEmployee(int id, EmployeeDataModel model);
       // public RestResponse UpdateEmployee(EmployeeDataModel employee);
        public RestResponse DeleteEmployee(int id);
        // Task<HttpResponseMessage> DeleteEmployee(EmployeeDataModel model);
        //Task<HttpResponseMessage> DeleteEmployee(int employeeid);
        // Task UpdateEmployee(int id, StringContent content);
        //Task UpdateEmployee(int id, StringContent content);


        public RestResponse GetECustormer(int Custormerid);

        Task<HttpResponseMessage> CreateCustormer(customerDataModel model);
        Task<HttpResponseMessage> UpdateCustormer(int id, customerDataModel model);

        public RestResponse DeleteCustormer(int id);
    }
}
