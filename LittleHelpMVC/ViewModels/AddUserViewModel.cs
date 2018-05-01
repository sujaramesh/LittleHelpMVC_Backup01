using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LittleHelpMVC.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Minimum 3 characters required")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(dataType: DataType.Password)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Verify Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Verify { get; set; }

        public int UserId { get; set; }

        public AddUserViewModel()
        {

        }
    }
}
