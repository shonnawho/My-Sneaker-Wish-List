using MySneakerWishList.Models;
using Microsoft.EntityFrameworkCore;

namespace MySneakerWishList.Data
{
    public class ShoeDbContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeCategory>Categories { get; set; }

    }
}
