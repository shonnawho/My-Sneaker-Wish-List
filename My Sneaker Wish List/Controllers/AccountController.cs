using MySneakerWishList.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MySneakerWishList.Data;
using MySneakerWishList.Models.User;

namespace MySneakerWishList.Controllers
{
    public class AccountController : Controller
    {
        public ShoeDbContext context;

        public AccountController(ShoeDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]

        public IActionResult RegisterUser(AccountRegistrationViewModel model)
        {

            User u = new User
            {
                Password = model.Password,
                Email = model.Email,
                Username = model.UserName
            };

            context.Users.Add(u);
            context.SaveChanges();

            return Redirect("/"); 
        }  

        public IActionResult Login()
        {
            return View();
        }


    }
}