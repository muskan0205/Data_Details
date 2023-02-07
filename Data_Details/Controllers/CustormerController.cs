using Dapper;
using Data_Details.Models;
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
    public class CustormerController : Controller
    {
        public readonly IConfiguration _configuration;
        public CustormerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<customerDataModel>>> GetAll_Result()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            IEnumerable<customerDataModel> result = await Select_Result(connection);

            return Ok(result);
        }
        [HttpGet("{customerid}")]
        public async Task<ActionResult<List<customerDataModel>>> GetResultByrank(int customerid)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var Book = await connection.QueryFirstAsync<customerDataModel>("Select * from custormer_data where id = @id",
                new { id = customerid });
            return Ok(Book);

        }
        [HttpPost]
        public async Task<ActionResult<List<EmployeeDataModel>>> CreateResult(customerDataModel customer)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("SET IDENTITY_INSERT employee_data ON");
            await connection.ExecuteAsync("insert into custormer_data( [First_name],[Last_name],[gender],[Product_name].[Price])values(@First_name,@Last_name ,@gender,@Product_name,@Price)", customer);
            // await connection.ExecuteAsync("SET IDENTITY_INSERT employee_data OFF");
            return Ok(await Select_Result(connection));
        }

        [HttpPut]
        public async Task<ActionResult<List<customerDataModel>>> UpdateResult(customerDataModel customer)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update custormer_data set id=@id ,First_name=@First_name,Last_name=@Last_name ,gender=@gender,@Product_name=Product_name,@Price=Price where id = @id", customer);
            return Ok(await Select_Result(connection));
        }

        [HttpDelete("{customerid}")]
        public async Task<ActionResult<List<customerDataModel>>> DeleteResultByID(int customerid)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var Book = await connection.QueryFirstAsync<customerDataModel>("Delete from custormer_data where id = @id",
                new { id = customerid });
            return Ok(await Select_Result(connection));

        }
        static async Task<IEnumerable<customerDataModel>> Select_Result(SqlConnection connection)
        {
            return await connection.QueryAsync<customerDataModel>("Select * from custormer_data");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
    //public IActionResult Index()
    //    {
    //        return View();
    //    }
    }
