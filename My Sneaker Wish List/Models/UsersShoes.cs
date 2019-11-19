using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySneakerWishList.Models
{
	public class UsersShoes
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ShoeId { get; set; }

		//public UsersShoes(DbContextOptions<UsersShoes> options) :base()
		//{ }

		//public DbSet<UsersShoes> UserssShoes { get; set; }
	}
}
