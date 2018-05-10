using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittleHelpMVC.Data;
using LittleHelpMVC.Models;
using LittleHelpMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LittleHelpMVC.Controllers
{
    public class LittleHelpController : Controller
    {
        private LittleHelpMVCDbContext context;

        public LittleHelpController(LittleHelpMVCDbContext dbContext)
        {
            context = dbContext;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
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
        public IActionResult Add(string name, string scrname)
        {
            AddHelpViewModel addHelpViewModel = new AddHelpViewModel(context.Categories.ToList());
            ViewBag.Title = name;
            return View(addHelpViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddHelpViewModel addHelpViewModel, string usrname)
        {
            if (ModelState.IsValid)
            {
                HelpCategory newCheeseCategory =
                   context.Categories.Single(c => c.ID == addHelpViewModel.CategoryID);

                LittleHelp helper = new LittleHelp
                {
                    Name = addHelpViewModel.Name,
                    Contact = addHelpViewModel.Contact,
                    Description = addHelpViewModel.Description,
                    CategoryID = addHelpViewModel.CategoryID
                };

                context.Helpers.Add(helper);
                context.SaveChanges();
                ViewBag.name = addHelpViewModel.Name;
                return RedirectToAction("Info", "LittleHelp", new { name = addHelpViewModel.Name });
            }

            return View(addHelpViewModel);
        }

        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            HelpCategory theCategory = context.Categories.Include(cat => cat.Helpers).Single(cat => cat.ID == id);
            ViewBag.Title = theCategory.Name;

            return View(theCategory.Helpers);
        }

        public IActionResult Info(string name)
        {
            List<LittleHelp> helpers = context.Helpers.Where(c => c.Name == name)
                               .Include(c => c.Category).ToList();
            ViewBag.Name = name;
            ViewBag.Title = name + " entries";

            return View(helpers);
        }

        public IActionResult Edit(int id)
        {
            AddEditHelpViewModel addEditHelpViewModel = new AddEditHelpViewModel();

            LittleHelp helper = context.Helpers.SingleOrDefault(c => c.ID == id);

            addEditHelpViewModel.Name = helper.Name;
            addEditHelpViewModel.Contact = helper.Contact;
            addEditHelpViewModel.Description = helper.Description;
            ViewBag.helpId = id;
            return View(addEditHelpViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditHelpViewModel addEditHelpViewModel)
        {

            LittleHelp helpData = context.Helpers.FirstOrDefault(c => c.ID == addEditHelpViewModel.HelpId);
            helpData.Contact = addEditHelpViewModel.Contact;
            helpData.Description = addEditHelpViewModel.Description;

            context.SaveChanges();
            return RedirectToAction("Info", "LittleHelp", new { name = addEditHelpViewModel.Name });

        }
    }
}
