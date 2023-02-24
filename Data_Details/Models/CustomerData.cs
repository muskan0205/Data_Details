using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Models
{
    public class CustomerData
    {
        public List<CustomerData> customerDataModel { get; set; }
    }
    public class customerDataModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter First name.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        public string First_name { get; set; }

        [Required(ErrorMessage = "Please enter First name.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "Selcect Your Gender.")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Enter Your ProductName.")]
        public string Product_name { get; set; }

        [MinLength(1, ErrorMessage = "Please Enter Number equal or Greater than 1.")]
        public int Price { get; set; }

    }
}
