using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySneakerWishList.ViewModels
{
    public class LoginViewModel
    {
		public static bool UserName { get; internal set; }
		[Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

    }
}
