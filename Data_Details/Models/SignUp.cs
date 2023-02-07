using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Models
{
    public class SignUp
    {
        [Required]
        public string First_name { get; set; }

        [Required]
        public string Last_name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
       
        [Required]
        [Compare("Confirm_Password")]
        [StringLength(8, ErrorMessage = "enter 8 digit Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string Confirm_Password { get; set; }

        [Required]
        public string role { get; set; }

        //[Key]
        //public int id { get; set; }
    }
}
