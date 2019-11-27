using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySneakerWishList.Models
{
	public class Seller
	{
		public int SellerId{ get; set;}
		public string SellerName { get; set; }
		public string SellerEmail { get; set; }
	
	}
}
