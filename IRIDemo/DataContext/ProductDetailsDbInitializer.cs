using CsvHelper;
using IRIDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataContext
{
    class ProductDetailsDbInitializer : DropCreateDatabaseIfModelChanges<ProductDetailsContext>
    {
        protected override void Seed(ProductDetailsContext context)
        {
           
        }
    }
}
