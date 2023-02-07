using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Models
{
    public class Admin
    {
        public List<EmployeeDataModel> EmployeeData { get; set; }
        public List<customerDataModel> CustomerData { get; set; }
    }
}
