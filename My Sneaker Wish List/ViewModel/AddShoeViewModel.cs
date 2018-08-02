﻿using MySneakerWishList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySneakerWishList.ViewModels
{
    public class AddShoeViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem>Categories { get; set; }

        public AddShoeViewModel(IEnumerable<ShoeCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name

                });

            }

        }

        
    }
}


