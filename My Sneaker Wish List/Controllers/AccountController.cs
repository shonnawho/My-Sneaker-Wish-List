using MySneakerWishList.ViewModels;
using MySneakerWishList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MySneakerWishList.Data;
using MySneakerWishList.Models.User;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MySqlX.XDevAPI;

namespace MySneakerWishList.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        public ShoeDbContext context;
        /* private readonly UserManager<IdentityUser> _userManager;
         private readonly object _signInManager; 
         public object _signIManager { get; }*/


        public AccountController(ShoeDbContext dbContext)
        {
            context = dbContext;
        }

        /* public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
         {
             _userManager = userManager;
             _signInManager = signInManager;
         }*/

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

            //Adds users to database
            User u = new User
            {
                Password = model.Password,
                Email = model.Email,
                Username = model.UserName
            };

            context.Users.Add(u);
            context.SaveChanges();
        


            {
                return Redirect("/Account/UserPage");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            {
                return View(loginViewModel);
            }
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewmodel)
        {

            if (ModelState.IsValid)
            {
                return Redirect("/Account/UserPage");
            }
            return View();
        }

    }
}
 