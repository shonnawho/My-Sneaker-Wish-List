using Microsoft.EntityFrameworkCore;
using MySneakerWishList.Models;
using MySneakerWishList.Models.User;

namespace MySneakerWishList.Data
{
    public class ShoeDbContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<ShoeCategory> Categories { get; set; }

        //public DbSet<Menu> Menus { get; set; }

       // public DbSet<ShoeMenu> ShoeMenus { get; set; }

        public DbSet<User> Users { get; set; }

		public DbSet<UsersShoes> UsersShoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//modelBuilder.Entity<Menu>()
			//    .HasKey(c => new { c.ShoeID, c.MenuID});

			base.OnModelCreating(modelBuilder);
		}

        public ShoeDbContext(DbContextOptions<ShoeDbContext> options)
            : base(options)
        { }

		public ShoeDbContext()
		{
		}


		//public ShoeDbContext()
		//{
		//}
	}
}