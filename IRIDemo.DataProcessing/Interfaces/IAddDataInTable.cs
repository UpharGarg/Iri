using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.Models.Model;

namespace IRIDemo.DataProcessing.Interfaces
{
    public interface IAddDataInTable
    {
        void AddDataToTables(IGenericRepository<Product> _productRepo, IGenericRepository<ProductSales> _productSalesRepo);
    }
}
