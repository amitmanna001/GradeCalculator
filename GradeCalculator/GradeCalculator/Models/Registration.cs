using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RegistrationLoginDemo.Models
{
    public class Registration
    {
        
            [Key]
            public int UserId { get; set; }

            [Required(ErrorMessage = "Please Enter Username..")]
         
            public string? Username { get; set; }

            [Required(ErrorMessage = "Please Enter Password...")]
          
            public string? Password { get; set; }

            [Required(ErrorMessage = "Please Enter the Confirm Password...")]

             [Compare("Password", ErrorMessage = " Password do not match")]
             public string? ConfirmPassword { get; set; }

              [Required(ErrorMessage = "Please Enter Email...")]

        //[RegularExpression("^[A-Za-z0-9]+@([a-zA-Z]+\\.)+[a-zA-Z]{2,6}]&", ErrorMessage = "Invalid Email id")]
        public string? Email { get; set; }

        
        }
    }

