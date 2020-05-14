using IRIDemo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataProcessing.Interfaces
{
   public interface IShowResult
    {
        string GetResults(IEnumerable<Product> productData, IEnumerable<ProductSales> productSalesData, string path);
    }
}
