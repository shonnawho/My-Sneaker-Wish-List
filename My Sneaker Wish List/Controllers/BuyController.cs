﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MySneakerWishList.Controllers
{
    public class BuyController : Microsoft.AspNetCore.Mvc.Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}