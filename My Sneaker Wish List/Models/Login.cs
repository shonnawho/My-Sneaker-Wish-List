using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MySneakerWishList.Models
{
	public class Login
	{
		[Required(ErrorMessage = "Please Enter Username!")]
		[Display(Name ="Enter Email:")]
		public string UserName { get; set; }


		[Required(ErrorMessage ="Please Enter Password")]
		[Display(Name ="Enter Password:")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}

}
