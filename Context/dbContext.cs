using Microsoft.EntityFrameworkCore;
using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Context
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }

        public DbSet<Register> registers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<UserLoginInfo> userLoginInfos { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Cart> carts { get; set; }
    }

    
}
