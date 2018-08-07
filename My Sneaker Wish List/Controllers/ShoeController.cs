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
        public ShoeDbContext context;

        public ShoeController(ShoeDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Shoe> shoes = context.Shoes.Include(c => c.Category).ToList();

            return View(shoes);
        }

        public IActionResult Add()
        {
            AddShoeViewModel addShoeViewModel = new AddShoeViewModel(context.Categories.ToList());

            return View(addShoeViewModel);
        }


        [HttpPost]
        public IActionResult Add(AddShoeViewModel addShoeViewModel)
        {
            if (ModelState.IsValid)
            {
                ShoeCategory newShoeCategory =
                    context.Categories.Single(c => c.ID == addShoeViewModel.CategoryID);
                // Add the new cheese to my existing cheeses
                Shoe newShoe = new Shoe
                {
                    Name = addShoeViewModel.Name,
                    Description = addShoeViewModel.Description,
                    Category = newShoeCategory

                };

                context.Shoes.Add(newShoe);
                context.SaveChanges();

                return Redirect("/Shoe");
            }

            return View(addShoeViewModel);

        }

    }
}