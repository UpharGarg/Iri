
using IRIDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataContext
{
    public class ProductDetailsContext : DbContext
    {
        public ProductDetailsContext() : base ("ProductDetailsContext")
        {
            //Database.SetInitializer(new ProductDetailsDbInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSales> ProductSales { get; set; }

        
    }
}
