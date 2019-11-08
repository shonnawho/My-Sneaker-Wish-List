using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MySneakerWishList.Controllers
{
    public class MenuController : Controller

    {
        private readonly CheeseDbContext context;

        //private ShoeDbContext context;

        public MenuController(ShoeDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();

            return View(menus);
        }

        public IActionResult Add()
        {

            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);

        }
        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                };

                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu/ViewMenu/" + newMenu.ID);
            }

            return View(addMenuViewModel);
        }
        public IActionResult ViewMenu(int id)
        {

         List<ShoeMenu> items = context
            .ShoeMenus
            .Include(item => item.Shoe)
            .Where(cm => cm.MenuID == id)
            .ToList();

         Menu menu = context.Menus.Single(m => m.ID == id);

            ViewMenuViewModel viewModel = new ViewMenuViewModel
            {
                Menu = menu,
                Items = items
            };

            return View(viewModel);
        }

        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
            List<Shoe> cheeses = context.Shoes.ToList();
            return View(new AddMenuItemViewModel(menu, shoes));
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var shoeID = addMenuItemViewModel.ShoeID;
                var menuID = addMenuItemViewModel.MenuID;

                List<ShoeMenu> existingItems = context.ShoeMenus
                    .Where(cm => cm.ShoeID == ShoeID)
                    .Where(cm => cm.MenuID == menuID).ToList();
                if (existingItems.Count == 0)
                {

                    ShoeMenu shoeItem = new ShoeMenu
                    {
                        Shoe = context.Shoes.Single(c => c.ID == shoeID),
                        Menu = context.Menus.Single(m => m.ID == menuID)
                    };

                    context.ShoeMenus.Add(menuItem);
                    context.SaveChanges();

                }

                return Redirect(string.Format("/Menu/ViewMenu/{0}", addMenuItemViewModel.MenuID));

            }

            return View(addMenuItemViewModel);
                
        } 

    }

}
﻿
