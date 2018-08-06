using MySneakerWishList.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySneakerWishList.ViewModels
{
    public class AccountRegistrationViewModel
    {
        [Display(Name = "Email Address")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "User Name")]
        [Required]
        [Range(6, 25)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(6)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

       
    }
}