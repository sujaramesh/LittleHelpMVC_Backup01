using System;
using System.Collections.Generic;
using System.Linq;
using LittleHelpMVC.Data;
using LittleHelpMVC.Models;
using LittleHelpMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LittleHelpMVC.Controllers
{
    public class UserController : Controller
    {
        private LittleHelpMVCDbContext context;

        public UserController(LittleHelpMVCDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            //   List<User> users = context.Users.ToList();
            //   return View(users);
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };
                context.Users.Add(newUser);
                context.SaveChanges();

                return RedirectToAction("Add", "LittleHelp",new { name=newUser.Username});
            }

            return View(addUserViewModel);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            SignInViewModel signInViewModel = new SignInViewModel();
            ViewBag.Title = "Existing Helpers, Sign In here";
            return View(signInViewModel);

        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel signInViewModel)
        {
            List<User> users = context.Users
                .Where(c => (c.Username == signInViewModel.Username) && (c.ID == signInViewModel.UserId)).ToList();
            if (users.Count == 0)
            {
                ViewBag.Title = "Check the name you entered";
                return View(signInViewModel);
            }
            else
            {
                foreach (var user in users)
                {
                    if (signInViewModel.Password != user.Username)
                    {
                        ViewBag.Title = "Wrong Password";
                        return View(signInViewModel);
                    }

                    if (signInViewModel.Username != user.Username)
                    {
                        ViewBag.Title = "Check the name you entered";
                        return View(signInViewModel);
                    }
                }
            }
            if (ModelState.IsValid)
            {
                List<LittleHelp> helpers = context.Helpers
                         .Where(c => (c.Name == signInViewModel.Username) && (c.ID == signInViewModel.UserId))
                          .Include(c => c.Category).ToList();

                return RedirectToAction("Info", "LittleHelp", new { name = signInViewModel.Username });
                //return RedirectToAction("Info", "LittleHelp", new { name = signInViewModel.Username, id = signInViewModel.UserId });
                //return View(helpers);
            }
            return View(signInViewModel);
        }

        [HttpGet]
        public IActionResult Admin()
        {
            SignInViewModel signInViewModel = new SignInViewModel();
            ViewBag.Title = "Admin, Sign In here";
            return View(signInViewModel);
        }

        [HttpPost]
        public IActionResult Admin(SignInViewModel signInViewModel)
        {
            List<User> users = context.Users.Where(c => c.Username == "Admin").ToList();
            foreach (var user in users)
            {
                if (signInViewModel.Username != "Admin")
                {
                    ViewBag.Title = "Check the name you entered";
                    return View(signInViewModel);
                }

                if (signInViewModel.Password != user.Password) 
                {
                    ViewBag.Title = "Wrong Password";
                    return View(signInViewModel);
                }

                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
