using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebUI.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        public string Password
        {
            get;
            set;
        }

        [Display(Name = "UserName")]
        [Required]
        public string UserName
        {
            get;
            set;
        }

        public LoginViewModel()
        {
        }
    }
}