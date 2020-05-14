using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataProcessing.Interfaces
{
    public interface IClearDataFromTable
    {
        void ClearDataFromTables(IGenericRepository<Product> _productRepo, IGenericRepository<ProductSales> _productSalesRepo);

    }
}
