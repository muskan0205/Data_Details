using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Details.Models
{
    public class CommonProperties
    {
        [Required(ErrorMessage ="Email Adress is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        //[]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [StringLength(8,ErrorMessage ="enter 8 digit Password")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Please Enter Coreect Password")]

        //[Compare("Confirm_Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Selcect Your Role")]
        public string role { get; set; }
    }
}
