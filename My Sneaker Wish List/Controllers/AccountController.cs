using MySneakerWishList.ViewModels;
using MySneakerWishList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
//using MySneakerWishList.Data;
using MySneakerWishList.Models.User;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using MySqlX.XDevAPI;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using MySneakerWishList.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;

namespace MySneakerWishList.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        public ShoeDbContext context;

		public object EmailSession { get; private set; }

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
                return Redirect("/Shoe/Add");
            }
        }

        [HttpGet]
		
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            {
                return View();
            }
        }

		//[Route("login")]
		[HttpPost]

		public IActionResult Login(LoginViewModel model)
		{
			using (ShoeDbContext db = new ShoeDbContext())
			{
				//check for password
				User usr = context.Users.FirstOrDefault(s => s.Email == model.Email && s.Password == model.Password);

				if (usr != null)
				{
					HttpContext.Session.SetString("EmailSession", model.Email);
					HttpContext.Session.SetString("PasswordSession", model.Password);

					return Redirect("/Shoe/Add");
				}
				else
				{
					ViewData["Message"] = "Your email or password is wrong";
					return View();
				}
			}
		}


		/*public IActionResult Login(string username, string password)
		{
			if (username != null && password != null && username.Equals("acc1") && password.Equals("123"))
			{
				HttpContext.Session.SetString("username", username);
				return View("Success");
			}

			else
			{
				ViewBag.error = "Invalid Account";
				return View("Index");
			}
		}*/

		[Route("logout")]
		[HttpGet]
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("username");
			return RedirectToAction("Index");

		}

		
	}
}

