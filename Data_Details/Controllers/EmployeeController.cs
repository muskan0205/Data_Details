using Dapper;
using Data_Details.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]  //authenticated employyee can see the data
    public class EmployeeController : Controller
    {
        public readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        { 
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDataModel>>> GetAllResult()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            IEnumerable<EmployeeDataModel> result = await SelectResult(connection);

            return Ok(result);
        }
        [HttpGet("{employeeid}")]
        public async Task<ActionResult<List<EmployeeDataModel>>> GetResultByrank(int employeeid)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var Book = await connection.QueryFirstAsync<EmployeeDataModel>("Select * from employee_data where id = @id",
                new { id = employeeid });
            return Ok(Book);

        }
        [HttpPost]
        public async Task<ActionResult<List<EmployeeDataModel>>> CreateResult(EmployeeDataModel employee)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("SET IDENTITY_INSERT employee_data ON");
            await connection.ExecuteAsync("insert into employee_data( [First_name],[Last_name],[gender],[Salary])values(@First_name,@Last_name ,@gender,@Salary)", employee);
           // await connection.ExecuteAsync("SET IDENTITY_INSERT employee_data OFF");
            return Ok(await SelectResult(connection));
        }

        [HttpPut]
        public async Task<ActionResult<List<EmployeeDataModel>>> UpdateResult(EmployeeDataModel employee)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update employee_data set id=@id ,First_name=@First_name,Last_name=@Last_name ,gender=@gender,Salary=@Salary where id = @id", employee);
            return Ok(await SelectResult(connection));
        }

        [HttpDelete("{employeeid}")]
        public async Task<ActionResult<List<EmployeeDataModel>>> DeleteResultByID(int employeeid)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var Book = await connection.QueryFirstAsync<EmployeeDataModel>("Delete from employee_data where id = @id",
                new { id = employeeid });
            return Ok(await SelectResult(connection));

        }
        static async Task<IEnumerable<EmployeeDataModel>> SelectResult(SqlConnection connection)
        {
            return await connection.QueryAsync<EmployeeDataModel>("Select * from employee_data");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
