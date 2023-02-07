using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Models
{
    public class Employee
    {
        
        public List<EmployeeData> EmployeeDataModel { get; set; }
    }
    
    public class EmployeeDataModel
    {
        public int id{ get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string gender { get; set; }
        public int Salary { get; set; }
    }
}
