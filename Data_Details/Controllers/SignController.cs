using Dapper;

using Data_Details.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : Controller
    {
        public readonly IConfiguration _configuration;
        public SignController(IConfiguration configuration)
        {
            _configuration = configuration; ;
        }

        //public EmployeeController(IConfiguration _configuration)
        //{
        //    _configuration = configuration;
        //}
        [HttpPost]
        [Route("Signup")]
        public IActionResult Sign_up([FromBody] SignUp signinfo)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            {
                // Check if the email address already exists in the database
                var existingEmail = connection.Query<SignUp>("SELECT EmailID FROM dbo.sign_up WHERE EmailID = @EmailID",
                    new { EmailID = signinfo.EmailID }).FirstOrDefault();
                if (existingEmail != null)
                {
                    return BadRequest("The email address already exists");
                }

                var parameters = new DynamicParameters();
                parameters.Add("@EmailID", signinfo.EmailID, DbType.String);
                parameters.Add("@Confirm_Password", signinfo.Confirm_Password, DbType.String);
                parameters.Add("@Password", signinfo.Password, DbType.String);
                parameters.Add("@Role", signinfo.role, DbType.String);
                parameters.Add("@First_name", signinfo.First_name, DbType.String);
                parameters.Add("@Last_name", signinfo.Last_name, DbType.String);

                connection.Open();
                
                int result = connection.Execute("insert_Data", parameters, commandType: CommandType.StoredProcedure);

                connection.Close();
                // Check if the stored procedure was successful
                if (result > 0)
                {
                    // The stored procedure was successful
                }
                else
                {
                    // The stored procedure failed
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] CommonProperties loginModel)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            {
                var SignUp = new SignUp();

                var parameters = new DynamicParameters();
                parameters.Add("@EmailId", loginModel.EmailID, DbType.String);
                parameters.Add("@Password", loginModel.Password, DbType.String);
                

                connection.Open();

                var LoginResult = connection.ExecuteScalar("sp_Login", parameters, commandType: CommandType.StoredProcedure).ToString();
                
                connection.Close();
                // Check if the stored procedure was successful
                if (LoginResult == "Successful Login")
                {
                    var role = connection.ExecuteScalar("SELECT role FROM dbo.sign_up WHERE EmailID = @EmailID", new { EmailID = loginModel.EmailID }).ToString();
                    if (role == "Employee")
                    {
                        connection.Close();
                        return Ok("Employee");
                    }
                    else if (role == "Custormer")
                    {
                        connection.Close();
                        return Ok("Custormer");
                    }
                    else if (role == "Admin")
                    {
                        connection.Close();
                        return Ok("Admin");
                    }
                    else
                    {
                        return Ok("Error");
                    }
                    // Call sp_GetRole to get the user's role
                    // var role = connection.ExecuteScalar("sp_GetRole", parameters, commandType: CommandType.StoredProcedure);

                    connection.Close();
                    // Return the role as part of the response
                    return Ok();
                }
                else
                {
                    connection.Close();
                    return BadRequest("Login failed");
                }
            }
        }


        //[HttpPost]
        //public IActionResult Login([FromBody] string emailId, [FromBody] string password)
        //{
        //    using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmailID", emailId, DbType.String);
        //        parameters.Add("@Password", password, DbType.String);

        //        connection.Open();

        //        var result = connection.QuerySingleOrDefault<SignUp>("sp_Login", parameters, commandType: CommandType.StoredProcedure);

        //        connection.Close();
        //        // Check if the result is not null
        //        if (result != null)
        //        {
        //            // User was found in the database
        //            return Ok("Success");
        //        }
        //        else
        //        {
        //            // User was not found in the database
        //            return Ok("Incorrect email or password");
        //        }
        //    }
        //}


        //[HttpPost]
        //[Route("login")]
        //public IActionResult login(CommonProperties login)
        //{
        //    using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@UserName", login.EmailID);
        //        parameters.Add("@Password", login.Password);

        //        var result = connection.Execute("sp_Login", parameters, commandType: CommandType.StoredProcedure);
        //      //  var loggedInUser = result.FirstOrDefault();

        //       // if (loggedInUser == null)
        //        {
        //            return BadRequest("Invalid username or password");
        //        }

        //        // return a token or set a cookie ...
        //       // return Ok(loggedInUser);
        //    }
        //   //eturn View();
        //}
    }
}
