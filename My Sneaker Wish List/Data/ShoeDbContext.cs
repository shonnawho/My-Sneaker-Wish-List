using Microsoft.EntityFrameworkCore;
using MySneakerWishList.Models;

namespace MySneakerWishList.Data
{
    public class ShoeDbContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeCategory> Categories { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<ShoeMenu> ShoeMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoeMenu>()
                .HasKey(c => new { c.ShoeID, c.MenuID });
        }



        public ShoeDbContext(DbContextOptions<ShoeDbContext> options)
            : base(options)
        { }

    }
}