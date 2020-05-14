using IRIDemo.Models.Model;
using System.Data.Entity;

namespace IRIDemo.DataContext
{
    public class ProductDetailsContext : DbContext
    {
        public ProductDetailsContext() : base ("ProductDetailsContext")
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSales> ProductSales { get; set; }

        
    }
}
