using Microsoft.AspNetCore.Mvc;
using MySneakerWishList.Models;
using System.Collections.Generic;
using MySneakerWishList.ViewModels;
using MySneakerWishList.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace MySneakerWishList.Controllers
{
    public class ShoeController : Controller
    
    {   
       
        private ShoeDbContext context;

        public ShoeController(ShoeDbContext dbContext)
        {
            context = dbContext;
        }

        //[Authorize]
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


                // Add the new shoe to my existing shoes
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

        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            ShoeCategory theCategory = context.Categories
                .Include(cat => cat.Shoes)
                .Single(cat => cat.ID == id);

            ViewBag.title = "Shoess in category: " + theCategory.Name;

            return View("Index", theCategory.Shoes);
        }


        [HttpPost]
        public IActionResult Remove(int[] shoeIDs)
        {
            foreach (int shoeId in shoeIDs)
            {
                Shoe theShoe = context.Shoes.Single(c => c.ID == shoeId);
                context.Shoes.Remove(theShoe);
            
            }

            context.SaveChanges();

            return Redirect("/");
        }


    }
}