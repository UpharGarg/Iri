using IRIDemo.DataProcessing.Interfaces;
using IRIDemo.Domain.Entities;
using IRIDemo.Domain.Interface;
using IRIDemo.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIDemo.DataProcessing.Implementation
{
    public class ShowResults : IShowResult
    {
        private readonly List<IProcessData> _processData;
        public ShowResults()
        {
            _processData = new List<IProcessData> { new ProcessSqlData() }; ;
        }
        public string GetResults(IEnumerable<Product> productData, IEnumerable<ProductSales> productSalesData, string path)
        {
            string route = @path;
            FileStream fs = new FileStream(route, FileMode.Create, FileAccess.ReadWrite);
            using (var sw = new StreamWriter(fs))
            {
                foreach (ResultType r in _processData.Find(x => x.InstanceName("sql")).GetResults(productData, productSalesData))
                {
                    sw.WriteLine($"Prodcut Id : {r.ProductId}  Product Name : {r.ProductName}   CodeType : {r.CodeType}  Code : {r.Code} ");
                }

                
            }
            return route;
        }

         
    }
}
