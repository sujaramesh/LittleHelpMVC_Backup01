using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittleHelpMVC.Data;
using LittleHelpMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LittleHelpMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LittleHelpMVC.Controllers
{
    public class AdminController : Controller
    {
        private LittleHelpMVCDbContext context;

        public AdminController(LittleHelpMVCDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<LittleHelp> helpers = context.Helpers.Include(c => c.Category).ToList();
            ViewBag.Title = "Little Help";
            return View(helpers);
        }

        //public IActionResult Help()
        //{
        //    List<LittleHelp> helpers = context.Helpers.ToList();
        //    ViewBag.Title = "Little Help";
        //    return View(helpers);
        //}
         
        //public IActionResult Category(int id)
        //{
        //    if (id == 0)
        //    {
        //        return Redirect("/Category");
        //    }

        //    HelpCategory theCategory = context.Categories.Include(c => c.Helpers).Single(c => c.ID == id);
        //    ViewBag.Title = "Service Provider " + theCategory.Name;
        //    return View("Index", theCategory.Helpers);
        //}


        public IActionResult Remove()
        {
            ViewBag.helpers = context.Helpers.Include(c => c.Category).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] helpIds)
        {
            foreach (int helpId in helpIds)
            {
                LittleHelp theHelper = context.Helpers.Single(c => c.ID == helpId);

                context.Helpers.Remove(theHelper);
            }
            context.SaveChanges();
            return RedirectToAction("Index","Admin");
        }

        public IActionResult Edit(int helpId)
        {
            AddEditHelpViewModel addEditHelpViewModel = new AddEditHelpViewModel();

            LittleHelp helpData = context.Helpers.Single(c => c.ID == helpId);
            addEditHelpViewModel.Name = helpData.Name;
            addEditHelpViewModel.Contact = helpData.Contact;
            //    addEditHelpViewModel.HelpId = helpData.HelpId;
            addEditHelpViewModel.Description = helpData.Description;
            ViewBag.Title = "Edit Entry";
            return View(addEditHelpViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditHelpViewModel addEditHelpViewModel)
        {

            LittleHelp helpData = context.Helpers.Single(c => c.ID == addEditHelpViewModel.HelpId);
            helpData.Name = addEditHelpViewModel.Name;
            helpData.Contact = addEditHelpViewModel.Contact;
            helpData.Description = addEditHelpViewModel.Description;

            context.SaveChanges();
            //   return Redirect("/"); 
         //   ViewBag.Title = "Your details has been updated!!!";
            return RedirectToAction("Info", "LittleHelp", new { name = addEditHelpViewModel.Name }); 
            //   return View(addEditHelpViewModel);
            //   return View("Welcome", ViewBag.name = addEditHelpViewModel.Name);
        }

        //public IActionResult RemoveService()
        //{
        //    ViewBag.categories = context.Categories.ToList();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult RemoveService(int[] catIds)
        //{
        //    foreach (int catId in catIds)
        //    {
        //        HelpCategory theCategory = context.Categories.Single(c => c.ID == catId);

        //        context.Categories.Remove(theCategory);
        //    }
        //    context.SaveChanges();
        //    return Redirect("/");
        //}

    }
}
