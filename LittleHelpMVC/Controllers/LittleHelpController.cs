 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittleHelpMVC.Models;
using LittleHelpMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LittleHelpMVC.Controllers
{
    public class LittleHelpController : Controller
    {
       
        // GET: /<controller>/
        public IActionResult Index()
        {
         //   ViewBag.helpers = LittleHelpData.GetAll();
         //   ViewBag.Title = "Little Help";
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            AddHelpViewModel addHelpViewModel = new AddHelpViewModel(); 
            return View(addHelpViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddHelpViewModel addHelpViewModel)
        {
            LittleHelp helper = new LittleHelp
            {
                Name = addHelpViewModel.Name,
                Contact = addHelpViewModel.Contact,
                Comment = addHelpViewModel.Comment
            };

            LittleHelpData.Add(helper);
            return Redirect("/LittleHelp");
        }

        public IActionResult Remove()
        {
            ViewBag.helpers = LittleHelpData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] helpIds)
        {
            foreach (int helpId in helpIds)
            {
                LittleHelpData.Remove(helpId);
            }
            return Redirect("/");
        }

        public IActionResult Edit(int helpId)
        {
            AddEditHelpViewModel addEditHelpViewModel = new AddEditHelpViewModel();

            LittleHelp helpData  = LittleHelpData.GetById(helpId);
            addEditHelpViewModel.Name = helpData.Name;
            addEditHelpViewModel.Contact = helpData.Contact;
            addEditHelpViewModel.HelpId = helpData.HelpId;
            addEditHelpViewModel.Comment = helpData.Comment;
            return View(addEditHelpViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditHelpViewModel addEditHelpViewModel)
        {
            
            LittleHelp helpData = LittleHelpData.GetById(addEditHelpViewModel.HelpId);
            helpData.Name = addEditHelpViewModel.Name;
            helpData.Contact = addEditHelpViewModel.Contact;
            helpData.Comment = addEditHelpViewModel.Comment;
                
            return Redirect("/");
        }
    }
}
