using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LittleHelpMVC.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Minimum 3 characters required")]
        public string Username { get; set; }

        [Required]
        [DataType(dataType: DataType.Password)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        public int UserId { get; set; }
        public string ReturnUrl { get; internal set; }

        public SignInViewModel()
        {

        }

    }
}
