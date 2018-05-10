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
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            ViewBag.Title = "New Helpers, Register here";
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            //List<User> users = context.Users
            //    .Where(c => (c.Username == addUserViewModel.Username)).ToList();

            User user = context.Users.FirstOrDefault(c => (c.Username == addUserViewModel.Username));

            if (user != null)
            {
                ViewBag.Title = "A Serice Provider already exits with this name !!!";
                return View(addUserViewModel);
            }

            User userEmail = context.Users.FirstOrDefault(c => (c.Email == addUserViewModel.Email));

            if (userEmail != null)
            {
                ViewBag.Title = "A Serice Provider already exists with this email address !!!";
                return View(addUserViewModel);
            }
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = addUserViewModel.Username,
                    Screenname = addUserViewModel.Screenname,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };
                context.Users.Add(newUser);
                context.SaveChanges();

                return RedirectToAction("Add", "LittleHelp",new { name=newUser.Username,scrname=newUser.Screenname});
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
            List<User> users = context.Users.Where(c => (c.Username == signInViewModel.Username)).ToList();

            if (users.Count == 0)
            {
                ViewBag.Title = "No Service Provider, Check the name you entered";
                return View(signInViewModel);
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.Password != signInViewModel.Password)
                    {
                        ViewBag.Title = "Wrong Password";
                        return View(signInViewModel);
                    }

                    if (user.Username != signInViewModel.Username)
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
            User user = context.Users.FirstOrDefault(c => c.Username == "Admin");

            if (signInViewModel.Username != "Admin")
            {
                ViewBag.Title = "Check the name you entered";
                return View(signInViewModel);
            }

            if (signInViewModel.Password != "littlehelp")
            {
                ViewBag.Title = "Wrong Password";
                return View(signInViewModel);
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
