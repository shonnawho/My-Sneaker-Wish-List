using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySneakerWishList.Data;
using MySneakerWishList.Models;
using MySneakerWishList.ViewModels;

namespace MySneakerWishList.Controllers
{
    public class CategoryController : Controller
    {

        public IActionResult Index()
        {
            List<ShoeCategory> categories = context.Categories.ToList();
            return View(categories);

        }

        private readonly ShoeDbContext context;

        public CategoryController(ShoeDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {

                ShoeCategory newCategory = new ShoeCategory
                {
                    Name = addCategoryViewModel.Name

                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }

    }
}
   