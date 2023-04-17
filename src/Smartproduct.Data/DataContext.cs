using Microsoft.EntityFrameworkCore;
namespace Smartproduct.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Smartproduct.Model.User.ExternalUser> ApplicationUsers { get; set; }
        public DbSet<Smartproduct.Model.Category.Category> Categories { get; set; }
        public DbSet<Smartproduct.Model.Product.Product> Products { get; set; }
        public DbSet<Smartproduct.Model.File.File> Files { get; set; }
    }
}