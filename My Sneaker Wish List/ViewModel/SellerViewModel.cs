using MySneakerWishList.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace MySneakerWishList.ViewModel
{
	public class SellerViewModel
	{
		[Display(Name = "User Name")]
		[Required]
		[Range(6, 25)]
		public string UserName { get; set; }

		[Required]
		[Display(Name = "Password")]
		[MaxLength(25)]
		[MinLength(6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Confirm Password")]
		[MaxLength(25)]
		[MinLength(6)]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords do not match")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Email Address")]
		[Required]
		[EmailAddress]
		[MaxLength(256)]
		public string Email { get; set; }

	}
}
