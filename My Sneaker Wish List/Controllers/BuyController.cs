﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySneakerWishList.Controllers
{
    public class BuyController : Controller
    {
        public IActionResult Buy()
        {
            return View();
        }
    }
}