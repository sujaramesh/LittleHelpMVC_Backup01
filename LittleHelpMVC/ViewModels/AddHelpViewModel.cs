using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LittleHelpMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LittleHelpMVC.ViewModels
{
    public class AddHelpViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddHelpViewModel()
        {
            Categories = new List<SelectListItem>();
        }

        public AddHelpViewModel(List<HelpCategory> categories) : this()
        {
            foreach (HelpCategory category in categories)
            {
                // <option value="ID">Name</option>
                Categories.Add(new SelectListItem()
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }
        }
    }
}
