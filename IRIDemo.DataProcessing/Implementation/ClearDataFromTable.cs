using IRIDemo.DataContext.Repository.Interface;
using IRIDemo.DataProcessing.Interfaces;
using IRIDemo.Domain.Entities;
using IRIDemo.Domain.Interface;
using IRIDemo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataProcessing.Implementation
{
    public class ClearDataFromTable : IClearDataFromTable
    {
        private readonly List<IClearData> _clearData;
        public ClearDataFromTable()
        {
            _clearData = new List<IClearData> { new ClearDataFromSqlTables() };
        }
        public void ClearDataFromTables(IGenericRepository<Product> _productRepo, IGenericRepository<ProductSales> _productSalesRepo)
        {
            _clearData.Find(x => x.InstanceName("sql")).ClearDataFromTable(_productSalesRepo);
            _clearData.Find(x => x.InstanceName("sql")).ClearDataFromTable(_productRepo);
        }
    }
}
