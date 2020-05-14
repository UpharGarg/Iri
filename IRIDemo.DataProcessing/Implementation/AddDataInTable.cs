using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.DataProcessing.Interfaces;
using IRIDemo.Domain.Entities;
using IRIDemo.Domain.Interface;
using IRIDemo.Models.Model;
using System.Collections.Generic;

namespace IRIDemo.DataProcessing.Implementation
{
    class AddDataInTable : IAddDataInTable
    {
        private readonly List<IAddData> _addData;
        private readonly ILoadDataFromSource _loadDataFromSource;
        public AddDataInTable(ILoadDataFromSource loadDataFromSource)
        {
            _loadDataFromSource = loadDataFromSource;
            _addData = new List<IAddData> { new AddDataToSqlTables() };
        }
        public void AddDataToTables(IGenericRepository<Product> _productRepo , IGenericRepository<ProductSales> _productSalesRepo)
        {
            _addData.Find(x => x.InstanceName("sql")).AddDataToTable(_productRepo, _loadDataFromSource.LoadProductRelatedDataFromCsv<Product>());

            _addData.Find(x => x.InstanceName("sql")).AddDataToTable(_productSalesRepo, _loadDataFromSource.LoadProductRelatedDataFromCsv<ProductSales>());
        }
    }
}
