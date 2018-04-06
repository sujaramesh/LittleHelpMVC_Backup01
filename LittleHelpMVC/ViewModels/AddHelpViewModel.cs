using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LittleHelpMVC.Models;

namespace LittleHelpMVC.ViewModels
{
    public class AddHelpViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }

    }
}
