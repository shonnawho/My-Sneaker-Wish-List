using Microsoft.AspNetCore.Mvc;
using MySneakerWishList.Models;
using System.Collections.Generic;
using MySneakerWishList.ViewModels;
using MySneakerWishList.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MySneakerWishList.Controllers
{
    public class ShoeController : Controller
    {
        private ShoeDbContext context;

        public ShoeController(ShoeDbContext dbContext)
        {
            context = dbContext;
        }
        
    }
}