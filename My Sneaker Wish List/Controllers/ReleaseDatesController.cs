using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySneakerWishList.Controllers
{
    public class ReleaseDatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}