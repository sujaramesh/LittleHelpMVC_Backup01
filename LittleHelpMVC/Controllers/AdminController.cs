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
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Edit(int Id)
        {
            ResetViewModel resetViewModel = new ResetViewModel();

            User userData = context.Users.FirstOrDefault(c => c.ID == Id);
            //           resetViewModel.Password = userData.Password;
            ViewBag.Title = "Reset Password" + Id;
            ViewBag.LoginId = Id;
            return View(resetViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ResetViewModel resetViewModel)
        {
            User user = context.Users.FirstOrDefault(c => c.ID == resetViewModel.UserId);

            if (ModelState.IsValid)
            {
                user.Password = resetViewModel.Password;
                context.SaveChanges();
                ViewBag.Title = "Password changed";
                return View("Welcome");
            }
            ViewBag.Title = "Reset Password failed";
            return View(resetViewModel);
        }
    }
}
