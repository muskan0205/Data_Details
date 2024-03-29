﻿using Data_Details.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_Project.Interface;
using Web_Project.Models;

namespace Web_Project.Service
{
    public class MyProjectService : IMyProjectService
    {
        private RestClient _client;
        public MyProjectService(RestClient client)
        {
            _client = client;
        }

        // SIGN_Up--------------
        //public RestResponse Signup()
        //{
        //    RestRequest request = new RestRequest("https://localhost:44387/api/Sign/Signup");
        //    RestResponse response = _client.Execute(request);
        //    return response;
        //}
        //-------------------------------------------Sign-up-------------------------------------------------------
        public RestResponse SignUp(SignUp signUpData)
        {
            var request = new RestRequest("https://localhost:44387/api/Sign/Signup", Method.Post);
            request.AddJsonBody(signUpData);

            

            return _client.Execute(request);

        }
        //-------------------------------------------LOg-in-------------------------------------------------------
        public RestResponse Login(CommonProperties LoginData)
        {
            var request = new RestRequest("https://localhost:44387/api/Sign/login", Method.Post);
            request.AddJsonBody(LoginData);


            return _client.Execute(request);
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    // Deserialize the response content into an object
            //    SignUp Result = JsonConvert.DeserializeObject<SignUp>(response.Content);

            //    // Access the "Role" property
            //    var role = Result.role;
            //}

            //return response;
        }
        // Employee----------
        public RestResponse EmployeeList()
        {
            RestRequest request = new RestRequest("https://localhost:44387/api/Employee");
            RestResponse response = _client.Execute(request);
            return response;
        }
        public  RestResponse GetEmployee(int employeeid)
        {
            RestRequest request = new RestRequest("https://localhost:44387/api/Employee/{employeeid}");
            RestResponse response = _client.Execute(request);
            return response;
        }
        //public async Task<HttpResponseMessage> GetEmployee(int employeeid)
        //{
        //    using var client = new HttpClient();
        //    var response = await client.GetAsync($"https://localhost:44387/api/Employee/{employeeid}");

        //    return response;
        //}
        public async Task<HttpResponseMessage> CreateEmployee(Data_Details.Models.EmployeeDataModel model)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44387/api/Employee", content);

            return response;
        }


        public async Task<HttpResponseMessage> UpdateEmployee(int id, EmployeeDataModel model)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:44387/api/Employee", content);

            return response;
        }

        //public RestResponse UpdateEmployee( EmployeeDataModel employee)
        //{
        //    RestRequest request = new RestRequest("https://localhost:44387/api/Employee");
        //    var json = JsonConvert.SerializeObject(employee);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    RestResponse response = _client.Execute(request);
        //    return response;


        //}
        //public async Task<HttpResponseMessage> DeleteEmployee(EmployeeDataModel model)
        //{
        //    using var client = new HttpClient();
        //    var response = await client.DeleteAsync($"https://localhost:44387/api/Employee");

        //    return response;
        //}

        public RestResponse DeleteEmployee(int id)
        {
            RestRequest request = new RestRequest($"https://localhost:44387/api/Employee/{id}", Method.Delete);
            RestResponse response = _client.Execute(request);
            return response;
        }



        // Custormer--------------------------------------------------------------
        public RestResponse CustormerList()
        {
            RestRequest request = new RestRequest("https://localhost:44387/api/Custormer");
            RestResponse response = _client.Execute(request);
            return response;
        }

        public RestResponse GetECustormer(int Custormerid)
        {
            RestRequest request = new RestRequest("https://localhost:44387/api/Custormer/{ustormerid}");
            RestResponse response = _client.Execute(request);
            return response;
        }
        //public async Task<HttpResponseMessage> GetEmployee(int employeeid)
        //{
        //    using var client = new HttpClient();
        //    var response = await client.GetAsync($"https://localhost:44387/api/Custormer/{custormerid}");

        //    return response;
        //}
        public async Task<HttpResponseMessage> CreateCustormer(customerDataModel model)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44387/api/Custormer", content);

            return response;
        }


        public async Task<HttpResponseMessage> UpdateCustormer(int id, customerDataModel model)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:44387/api/Custormer", content);

            return response;
        }

        public RestResponse DeleteCustormer(int id)
        {
            RestRequest request = new RestRequest($"https://localhost:44387/api/Custormer/{id}", Method.Delete);
            RestResponse response = _client.Execute(request);
            return response;
        }
    }
}
