using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Please enter First name.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        public string First_name { get; set; }

        [Required(ErrorMessage = "Please enter Last name.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "Selcect Your Gender.")]
        public string gender { get; set; }

        [Range(1000,100000)]
        public int Salary { get; set; }
    }
}
