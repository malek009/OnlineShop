using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Providers.Sql.Models;

namespace OnlineShop.Data.Providers.Sql
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions options) :
            base(options)
        {

        }
        public DbSet<User> Users{get;set; }
        public DbSet<Article> Articles{ get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartArticles> CartsArticles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
