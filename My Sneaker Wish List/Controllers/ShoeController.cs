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

        // GET: /<controller>/
        public IActionResult Index()
        {
             IList<Shoe> shoes = context.Shoes.Include(c => c.Category).ToList();
            
            return View(shoes);
        }

        public IActionResult Add()
        {
            var listOfCategories = context.Categories.ToList();
            AddShoeViewModel addShoeViewModel = new AddShoeViewModel(listOfCategories);
            return View(addShoeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddShoeViewModel addShoeViewModel)
        {
            if (ModelState.IsValid)
            {
                ShoeCategory catg = context.Categories.Single(s => s.ID == addShoeViewModel.CategoryID);
                // Add the new cheese to my existing cheeses
                Shoe Shoe = new Shoe
                {
                    Name = addShoeViewModel.Name,
                    Description = addShoeViewModel.Description,
                    Category = catg
                };

                context.Shoes.Add(Shoe);
                context.SaveChanges();

                return Redirect("/Shoe");
            }

            return View(addShoeViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Shoes";
            ViewBag.shoes = context.Shoes.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] shoeIds)
        {
            foreach (int shoeId in shoeIds)
            {
                Shoe theShoe = context.Shoes.Single(c => c.ID == shoeId);
                context.Shoes.Remove(theShoe);
            }

            context.SaveChanges();

            return Redirect("/Shoe");
        }
    }
}