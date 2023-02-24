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
        [Required(ErrorMessage = "Please enter First name.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        // [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string First_name { get; set; }

        [Required(ErrorMessage = "Please enter Last name.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        // [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "Please enter Email ID.")]
        [EmailAddress]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [StringLength(8, ErrorMessage = "Password must be at least 8 characters long", MinimumLength = 8)]
        [RegularExpression(@"^\S*$", ErrorMessage = "Please Enter Coreect Password")]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression(@"^\S*$", ErrorMessage = "Spaces are not allowed.")]
        [Required(ErrorMessage ="Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]

        [NotMapped]
        
        public string Confirm_Password { get; set; }

        [Required(ErrorMessage ="Selcect Your Role")]
        public string role { get; set; }

        //[Key]
        //public int id { get; set; }
    }
}
